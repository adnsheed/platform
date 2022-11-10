import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { addStudents, reset } from "../../features/students/studentsSlice";

import DatePicker from "react-datepicker";
import { Button } from "react-bootstrap";

import "../../assets/styles/forms.css";
import "react-datepicker/dist/react-datepicker.css";

import Select from "react-select";
import dayjs from "dayjs";
import { toast } from "react-toastify";

const AddStudent = () => {
  const [birthDate, setBirthDate] = useState(new Date());
  const [status, setStatus] = useState("InProgram");
  const [formData, setFormData] = useState({
    userName: "",
    password: "",
    firstName: "",
    lastName: "",
    email: "",
  });

  const { userName, password, firstName, lastName, email } = formData;

  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { user } = useSelector((state) => state.reducer.auth);
  const { isError, isCreated, message } = useSelector(
    (state) => state.students
  );

  const options = [
    { value: "InProgram", label: "InProgram" },
    { value: "Success", label: "Success" },
    { value: "Failed", label: "Failed" },
    { value: "Extended", label: "Extended" },
  ];

  useEffect(() => {
    if (isError) {
      toast.error(message);
      dispatch(reset());
    }
    if (isCreated) {
      toast.success("You've successfully created new student.");
      dispatch(reset());
      navigate(-1);
    }
    // eslint-disable-next-line
  }, [isError, isCreated, message]);

  const onChange = (e) => {
    setFormData((prevState) => ({
      ...prevState,
      [e.target.name]: e.target.value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const data = {
      student: {
        userName,
        password,
        firstName,
        lastName,
        email,
        birthDate: dayjs(birthDate).format("YYYY,MM,DD"),
        status,
      },
      token: user?.data?.token,
    };
    dispatch(addStudents(data));
  };

  return (
    <div>
      <h1>Add new student</h1>
      <section className="form">
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Username</label>
            <input
              type="text"
              id="userName"
              name="userName"
              value={userName}
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
          <div className="form-group">
            <label>First Name</label>
            <input
              type="text"
              id="firstName"
              name="firstName"
              value={firstName}
              onChange={onChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Last name</label>
            <input
              type="text"
              id="lastName"
              name="lastName"
              value={lastName}
              onChange={onChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Email</label>
            <input
              type="email"
              id="email"
              name="email"
              value={email}
              onChange={onChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Birth date</label>
            <DatePicker
              selected={birthDate}
              onChange={(date) => setBirthDate(date)}
              showYearDropdown
              yearDropdownItemNumber={15}
              scrollableYearDropdown
            />
          </div>
          <div className="form-group">
            <label>Status</label>
            <Select
              options={options}
              onChange={(choice) => setStatus(choice.value)}
            />
          </div>
          <div className="form-buttons">
            <Button variant="dark" type="submit">
              Submit
            </Button>
            <Button variant="dark" type="button" onClick={() => navigate(-1)}>
              cancel
            </Button>
          </div>
        </form>
      </section>
    </div>
  );
};

export default AddStudent;
