import { Navigate } from "react-router-dom";
import { useSelector } from "react-redux";

function StudentRoute({ children }) {
  const { user } = useSelector((state) => state.reducer.auth);
  return user?.data?.role === "Student" ? children : <Navigate to="/" />;
}

export default StudentRoute;
