import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { getProgramById, reset } from "../../features/programs/programsSlice";

import { Button } from "react-bootstrap";

import "../../assets/styles/table.css";

const ProgramDetails = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const params = useParams();

  const { user } = useSelector((state) => state.reducer.auth);
  const { programById } = useSelector((state) => state.programs);

  useEffect(() => {
    const program = {
      id: params.id,
      token: user?.data?.token,
    };
    dispatch(getProgramById(program));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token]);

  const itemType = {
    0: "Lecture",
    1: "Event",
  };

  return (
    <div>
      <h1>{programById?.data?.title} details</h1>
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Type</th>
            <th>Description</th>
            <th>Work Hours</th>
            <th>URL</th>
          </tr>
        </thead>
        <tbody>
          {programById?.data?.items.map((item) => {
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
      <Button onClick={() => navigate(-1)}>Go Back</Button>
    </div>
  );
};

export default ProgramDetails;
