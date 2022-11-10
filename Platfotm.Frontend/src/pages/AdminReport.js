import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { adminReport, reset } from "../features/students/studentsSlice";

import "../assets/styles/table.css";

const AdminReport = () => {
  const dispatch = useDispatch();

  const { user } = useSelector((state) => state.reducer.auth);
  const { report } = useSelector((state) => state.students);

  useEffect(() => {
    dispatch(adminReport(user?.data?.token));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <div>
      <h1>Admin Report</h1>
      <div style={{ margin: "30px 0 30px 0" }}>
        <h2>Overall Success Rate: {report?.data?.overallSuccessRate} %</h2>
      </div>
      <div>
        <h2>Selections Success Rate</h2>
        <table>
          <thead>
            <tr>
              <th>Selection</th>
              <th>Success Rate</th>
            </tr>
          </thead>
          <tbody>
            {report?.data?.selectionSuccessesRate.map((sel) => {
              return (
                <tr key={sel.id}>
                  <td>{sel.selectionTitle}</td>
                  <td>{sel.successRate} %</td>
                </tr>
              );
            })}
          </tbody>
        </table>
        <div></div>
      </div>
    </div>
  );
};

export default AdminReport;
