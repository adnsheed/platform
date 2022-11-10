import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getStudentById, reset } from "../features/students/studentsSlice";

import dayjs from "dayjs";

import "../assets/styles/table.css";

const StudentProfile = () => {
  const dispatch = useDispatch();
  const { user } = useSelector((state) => state.reducer.auth);
  const { studentById } = useSelector((state) => state.students);

  useEffect(() => {
    const data = {
      id: user?.data?.id,
      token: user?.data?.token,
    };
    dispatch(getStudentById(data));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  const itemType = {
    0: "Lecture",
    1: "Event",
  };

  const studentStatus = {
    0: "InProgram",
    1: "Success",
    2: "Failed",
    3: "Extended",
  };

  return (
    <div>
      <h1>
        {studentById?.data?.firstName} {studentById?.data?.lastName} Profile
      </h1>
      <div style={{ marginTop: "40px" }}>
        <p>
          Date of Birth:{" "}
          {dayjs(studentById?.data?.birthDate).format("DD/MM/YYYY")}
        </p>
        <p>Selection: {studentById?.data?.selection?.title}</p>
        <p>Status: {studentStatus[studentById?.data?.selection?.status]}</p>
      </div>
      <div style={{ marginTop: "40px" }}>
        <h3>Personalized program</h3>
        <table>
          <thead>
            <tr>
              <th>Order Number</th>
              <th>Name</th>
              <th>Type</th>
              <th>Description</th>
              <th>Work Hours</th>
              <th>Url</th>
              <th>Start Date</th>
              <th>End Date</th>
              <th>Progress</th>
              <th>Progress Status</th>
            </tr>
          </thead>
          <tbody>
            {studentById?.data?.itemStudents.map((item) => {
              return (
                <tr key={item.orderNumber}>
                  <td>{item.orderNumber}</td>
                  <td>{item.name}</td>
                  <td>{itemType[item.type]}</td>
                  <td style={{ textAlign: "start" }}>{item.description}</td>
                  <td>{item.workHours}</td>
                  <td data-label="URL">
                    <a href={item.urls} target="_blank" rel="noreferrer">
                      LINK
                    </a>
                  </td>

                  <td>{dayjs(item.startDate).format("DD/MM/YYYY")}</td>
                  <td>{dayjs(item.endDate).format("DD/MM/YYYY")}</td>
                  <td>{item.progress} %</td>
                  <td>{item.progressStatus}</td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default StudentProfile;
