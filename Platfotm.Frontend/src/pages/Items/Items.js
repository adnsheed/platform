import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getItems, reset } from "../../features/items/itemsSlice";
import { useNavigate } from "react-router-dom";

import "../../assets/styles/table.css";
import "../../pages/Students/styles/students.css";

import { Button } from "react-bootstrap";
import Select from "react-select";

import Pagination from "react-bootstrap/Pagination";

const Items = () => {
  const [filter, setFilter] = useState("");
  const [value, setValue] = useState("");
  const [sort, setSort] = useState("");
  const [page, setPage] = useState(1);
  // eslint-disable-next-line
  const [pageSize, setPageSize] = useState(3);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { user } = useSelector((state) => state.reducer.auth);
  const { items } = useSelector((state) => state.items);

  useEffect(() => {
    const data = {
      api: `/api/items?filter=${filter}&value=${value}&sort=${sort}&page=${page}&pageSize=${pageSize}`,
      token: user?.data?.token,
    };
    dispatch(getItems(data));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token, sort, value, page]);

  const itemType = {
    0: "Lecture",
    1: "Event",
  };

  const options = [
    { value: "name", label: "Name" },
    { value: "workHours", label: "Work Hours" },
  ];

  let pagItems = [];
  for (let number = 1; number <= items?.pages; number++) {
    pagItems.push(
      <Pagination.Item
        key={number}
        onClick={() => setPage(number)}
        active={number === page}
      >
        {number}
      </Pagination.Item>
    );
  }

  return (
    <div>
      <h1>items</h1>
      <div className="items-form">
        <div className="filter-form">
          <div className="filter-field">
            <label>Filter by:</label>
            <Select
              options={options}
              onChange={(choice) => setFilter(choice.value)}
            />
          </div>
          <input
            type="text"
            value={value}
            onChange={(e) => setValue(e.target.value)}
          />
        </div>
        <Button onClick={() => navigate("/additem")}>Add Item</Button>
      </div>
      <table>
        <thead>
          <tr>
            <th
              onClick={() => {
                setSort("name");
              }}
            >
              Name
            </th>
            <th
              onClick={() => {
                setSort("type");
              }}
            >
              Type
            </th>
            <th
              onClick={() => {
                setSort("description");
              }}
            >
              Description
            </th>
            <th
              onClick={() => {
                setSort("workHours");
              }}
            >
              Work Hours
            </th>
            <th>URL</th>
          </tr>
        </thead>
        <tbody>
          {items?.data?.map((item) => {
            return (
              <tr key={item.id}>
                <td data-label="Name" style={{ textAlign: "start" }}>
                  {item.name}
                </td>
                <td data-label="Type">{itemType[item.type]}</td>
                <td data-label="Description" style={{ textAlign: "start" }}>
                  {item.description}
                </td>
                <td data-label="Work Hours">{item.workHours}</td>
                <td data-label="URL">
                  <a href={item.urls} target="_blank" rel="noreferrer">
                    LINK
                  </a>
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
      <div className="pagination">
        <Pagination>{pagItems}</Pagination>
      </div>
    </div>
  );
};

export default Items;
