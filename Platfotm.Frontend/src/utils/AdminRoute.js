import { Navigate } from "react-router-dom";
import { useSelector } from "react-redux";

function AdminRoute({ children }) {
  const { user } = useSelector((state) => state.reducer.auth);
  return user?.data?.role === "Admin" ? children : <Navigate to="/" />;
}

export default AdminRoute;
