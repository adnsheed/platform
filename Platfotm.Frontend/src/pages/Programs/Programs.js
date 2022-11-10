import { useEffect } from "react";
import { Button } from "react-bootstrap";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { getPrograms, reset } from "../../features/programs/programsSlice";

const Programs = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { user } = useSelector((state) => state.reducer.auth);
  const { programs } = useSelector((state) => state.programs);

  useEffect(() => {
    dispatch(getPrograms(user?.data?.token));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token]);

  return (
    <div>
      <h1>Programs</h1>
      <table>
        <thead>
          <tr>
            <th>Title</th>
            <th>Description</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {programs?.data?.map((prg) => {
            return (
              <tr key={prg.id}>
                <td>{prg.title}</td>
                <td style={{ textAlign: "start" }}>{prg.description}</td>
                <td>
                  <Button
                    variant="outline-success"
                    size="sm"
                    className="table-btn"
                    onClick={() => navigate(`/programs/edit/${prg.id}`)}
                  >
                    Edit
                  </Button>
                  <Button
                    variant="outline-danger"
                    size="sm"
                    className="table-btn"
                  >
                    Delete
                  </Button>
                  <Button
                    variant="outline-info"
                    size="sm"
                    className="table-btn"
                    onClick={() => navigate(`/programs/${prg.id}`)}
                  >
                    Details
                  </Button>
                </td>
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};

export default Programs;
