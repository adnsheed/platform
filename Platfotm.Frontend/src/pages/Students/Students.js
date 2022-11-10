import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  getStudents,
  reset,
  select,
} from "../../features/students/studentsSlice";
import { useNavigate } from "react-router-dom";
import dayjs from "dayjs";

import "../../assets/styles/table.css";
import "./styles/students.css";
import "react-pagination-bar/dist/index.css";
import { Button, Pagination } from "react-bootstrap";

import Select from "react-select";
import DeleteModal from "../../components/DeleteModalStudent";

const Students = () => {
  const [filter, setFilter] = useState("");
  const [value, setValue] = useState("");
  const [sort, setSort] = useState("");
  const [page, setPage] = useState(1);
  // eslint-disable-next-line
  const [pageSize, setPageSize] = useState(3);
  const [modalShow, setModalShow] = useState(false);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { user } = useSelector((state) => state.reducer.auth);
  const { students } = useSelector((state) => state.students);

  useEffect(() => {
    const data = {
      api: `/api/students?filter=${filter}&value=${value}&sort=${sort}&page=${page}&pageSize=${pageSize}`,
      token: user?.data?.token,
    };
    dispatch(getStudents(data));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token, sort, value, page]);

  const options = [
    { value: "selection", label: "Selection" },
    { value: "program", label: "Program" },
    { value: "", label: "None" },
  ];

  const studentStatus = {
    0: "InProgram",
    1: "Success",
    2: "Failed",
    3: "Extended",
  };

  let pagItems = [];
  for (let number = 1; number <= students?.pages; number++) {
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

  const addStudent = (id) => {
    dispatch(select(id));
    navigate("/selections/addstudent");
  };

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
        <Button onClick={() => navigate("/add")}>Add Student</Button>
      </div>
      <table>
        <thead>
          <tr>
            <th
              onClick={() => {
                setSort("firstName");
              }}
            >
              First Name
            </th>
            <th
              onClick={() => {
                setSort("lastName");
              }}
            >
              Last Name
            </th>
            <th>Birth Date</th>
            <th
              onClick={() => {
                setSort("status");
              }}
            >
              Status
            </th>
            <th
              onClick={() => {
                setSort("selection");
              }}
            >
              Selection
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
          {students?.data?.map((student) => {
            return (
              <tr key={student.id}>
                <td data-label="First Name">{student.firstName}</td>
                <td data-label="Last Name">{student.lastName}</td>
                <td data-label="Birth Date">
                  {dayjs(student.birthDate).format("DD/MM/YYYY")}
                </td>
                <td data-label="Status">{studentStatus[student.status]}</td>
                <td data-label="Selection">{student.selection?.title}</td>
                <td data-label="Program">
                  {student.selection?.program?.title}
                </td>
                <td data-label="Actions">
                  <Button
                    variant="outline-success"
                    size="sm"
                    className="table-btn"
                    onClick={() => navigate("/edit")}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="outline-danger"
                    size="sm"
                    className="table-btn"
                    onClick={() => setModalShow(true)}
                  >
                    Delete
                  </Button>
                  {!student.selection?.title && (
                    <Button
                      variant="outline-info"
                      size="sm"
                      className="table-btn"
                      onClick={() => addStudent(student.id)}
                    >
                      Add
                    </Button>
                  )}
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
      <div className="pagination">
        <Pagination>{pagItems}</Pagination>
      </div>
      <DeleteModal show={modalShow} onHide={() => setModalShow(false)} />
    </div>
  );
};

export default Students;
