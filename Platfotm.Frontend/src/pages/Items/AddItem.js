import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";
import { addItems, reset } from "../../features/items/itemsSlice";

import { Button } from "react-bootstrap";

import "../../assets/styles/forms.css";

import Select from "react-select";
import { toast } from "react-toastify";

const AddItem = () => {
  const [type, setType] = useState("Lecture");
  const [formData, setFormData] = useState({
    name: "",
    description: "",
    workHours: "",
    urls: "",
  });

  const { name, description, workHours, urls } = formData;

  const dispatch = useDispatch();
  const navigate = useNavigate();
  const { user } = useSelector((state) => state.reducer.auth);
  const { isError, isCreated, message } = useSelector((state) => state.items);

  const options = [
    { value: "Lecture", label: "Lecture" },
    { value: "Event", label: "Event" },
  ];

  useEffect(() => {
    if (isError) {
      toast.error(message);
      dispatch(reset());
    }
    if (isCreated) {
      toast.success("You've successfully created new item.");
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
      item: {
        name,
        type,
        description,
        workHours: parseInt(workHours),
        urls,
      },
      token: user?.data?.token,
    };
    dispatch(addItems(data));
  };

  return (
    <div>
      <h1>Add new item</h1>
      <section className="form">
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Name</label>
            <input
              type="text"
              id="name"
              name="name"
              value={name}
              onChange={onChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Type</label>
            <Select
              options={options}
              onChange={(choice) => setType(choice.value)}
            />
          </div>
          <div className="form-group">
            <label>Description</label>
            <input
              type="text"
              id="description"
              name="description"
              value={description}
              onChange={onChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Work Hours</label>
            <input
              type="text"
              id="workHours"
              name="workHours"
              value={workHours}
              onChange={onChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Urls</label>
            <input
              type="text"
              id="urls"
              name="urls"
              value={urls}
              onChange={onChange}
              required
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

export default AddItem;
