import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { reset, loginUser } from "../features/auth/authSlice";

import "../assets/styles/forms.css";
import "../assets/styles/login.css";

import { Button } from "react-bootstrap";
import { toast } from "react-toastify";

const Login = () => {
  const [formData, setFormData] = useState({
    username: "",
    password: "",
  });

  const { username, password } = formData;

  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { user, isError, isSuccess, message } = useSelector(
    (state) => state.reducer.auth
  );

  useEffect(() => {
    if (user) {
      navigate("/");
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  useEffect(() => {
    if (isError) {
      toast.error(message);
      dispatch(reset());
    }
    if (isSuccess) {
      toast.success("You've successfully logged in.");
      dispatch(reset());
      if (user?.data?.role === "Admin") {
        navigate("/students");
      } else {
        navigate("/profile");
      }
    }
  }, [isError, isSuccess, message, dispatch, navigate, user?.data?.role]);

  const onChange = (e) => {
    setFormData((prevState) => ({
      ...prevState,
      [e.target.name]: e.target.value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const userData = { username, password };
    dispatch(loginUser(userData));
  };
  return (
    <>
      <h1 className="main-title">please Enter your Platform credentials</h1>
      <section className="form">
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Username</label>
            <input
              type="text"
              id="username"
              name="username"
              value={username}
              onChange={onChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Password</label>
            <input
              type="password"
              id="password"
              name="password"
              value={password}
              onChange={onChange}
              required
            />
          </div>
          <div className="form-buttons">
            <Button variant="dark" type="submit">
              Submit
            </Button>
          </div>
        </form>
      </section>
    </>
  );
};

export default Login;
