import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate } from "react-router-dom";

import {
  getSelections,
  reset,
  addStudent,
} from "../../features/selections/selectionsSlice";

import Select from "react-select";
import "../Programs/styles/program.css";
import { Button } from "react-bootstrap";
import { toast } from "react-toastify";

const AddStudentToSelection = () => {
  const [selectionId, setSelectionId] = useState();
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { user } = useSelector((state) => state.reducer.auth);
  const { selections, isError, isCreated, message } = useSelector(
    (state) => state.selections
  );
  const { currentStudent } = useSelector((state) => state.students);

  useEffect(() => {
    const data = {
      api: `/api/selections`,
      token: user?.data?.token,
    };
    dispatch(getSelections(data));
    dispatch(reset());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token]);

  const options = selections?.data?.map((selection) => ({
    value: selection.id,
    label: selection.title,
  }));

  useEffect(() => {
    if (isError) {
      toast.error(message);
      dispatch(reset());
    }
    if (isCreated) {
      toast.success("You've successfully added student to selection.");
      dispatch(reset());
      navigate(-1);
    }
    // eslint-disable-next-line
  }, [isError, isCreated, message]);

  const getProgramId = () => {
    let currSel = selections?.data?.filter(
      (selection) => selection.id === selectionId
    );
    return currSel[0].program.id;
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const selection = {
      token: user?.data?.token,
      selectionId,
      studentId: parseInt(currentStudent),
      programId: getProgramId(),
    };
    dispatch(addStudent(selection));
    console.log(selection);
  };

  return (
    <div>
      <h1>Add student to selection</h1>
      <form className="add-item" onSubmit={handleSubmit}>
        <h3>Choose Selection</h3>
        <Select
          options={options}
          onChange={(choice) => setSelectionId(choice.value)}
        />
        <div className="form-buttons">
          <Button variant="dark" type="submit">
            Submit
          </Button>
          <Button variant="dark" type="button" onClick={() => navigate(-1)}>
            cancel
          </Button>
        </div>
      </form>
    </div>
  );
};

export default AddStudentToSelection;
