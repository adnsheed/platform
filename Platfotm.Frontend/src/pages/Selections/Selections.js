import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  getSelections,
  reset,
} from "../../features/selections/selectionsSlice";
import { useNavigate } from "react-router-dom";
import dayjs from "dayjs";

import "../../assets/styles/table.css";
import "../../pages/Students/styles/students.css";

import { Button, Pagination } from "react-bootstrap";

import Select from "react-select";

const Selections = () => {
  const [filter, setFilter] = useState("");
  const [value, setValue] = useState("");
  const [sort, setSort] = useState("");
  const [page, setPage] = useState(1);
  // eslint-disable-next-line
  const [pageSize, setPageSize] = useState(5);
  //const [modalShow, setModalShow] = useState(false);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { user } = useSelector((state) => state.reducer.auth);
  const { selections } = useSelector((state) => state.selections);

  useEffect(() => {
    const data = {
      api: `/api/selections?filter=${filter}&value=${value}&sort=${sort}&page=${page}&pageSize=${pageSize}`,
      token: user?.data?.token,
    };
    dispatch(getSelections(data));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token, sort, value, page]);

  const options = [
    { value: "program", label: "Program" },
    { value: "", label: "None" },
  ];

  const selectionStatus = {
    0: "Active",
    1: "Complete",
  };

  let pagItems = [];
  for (let number = 1; number <= selections?.pages; number++) {
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
      <h1>Students</h1>
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
        {/* <Button onClick={() => navigate("/selections/addstudent")}>
          Add Student to selection
        </Button>
        <Button onClick={() => navigate("/add")}>
          Remove Student from selection
        </Button> */}
        <Button onClick={() => navigate("/add")}>Add Selection</Button>
      </div>
      <table>
        <thead>
          <tr>
            <th
              onClick={() => {
                setSort("title");
              }}
            >
              Title
            </th>
            <th
              onClick={() => {
                setSort("startDate");
              }}
            >
              Start Date
            </th>
            <th
              onClick={() => {
                setSort("endDate");
              }}
            >
              End Date
            </th>
            <th
              onClick={() => {
                setSort("status");
              }}
            >
              Status
            </th>
            <th
              onClick={() => {
                setSort("program");
              }}
            >
              Program
            </th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {selections?.data?.map((sel) => {
            return (
              <tr key={sel.id}>
                <td data-label="Title">{sel.title}</td>
                <td data-label="Start Date">
                  {dayjs(sel.startDate).format("DD/MM/YYYY")}
                </td>
                <td data-label="End Date">
                  {dayjs(sel.endDate).format("DD/MM/YYYY")}
                </td>
                <td data-label="Status">{selectionStatus[sel.status]}</td>
                <td data-label="Program">{sel.program?.title}</td>
                <td data-label="Actions">
                  <Button
                    variant="outline-success"
                    size="sm"
                    className="table-btn"
                    //onClick={() => navigate("/edit")}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="outline-danger"
                    size="sm"
                    className="table-btn"
                    //onClick={() => setModalShow(true)}
                  >
                    Delete
                  </Button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
      <div className="pagination">
        <Pagination>{pagItems}</Pagination>
      </div>
      {/* <DeleteModal show={modalShow} onHide={() => setModalShow(false)} /> */}
    </div>
  );
};

export default Selections;
