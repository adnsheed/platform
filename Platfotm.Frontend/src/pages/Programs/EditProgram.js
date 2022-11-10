import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { reset, addItemToProgram } from "../../features/programs/programsSlice";
import { getItems, reset as resetItems } from "../../features/items/itemsSlice";

import { Button } from "react-bootstrap";
import "../Programs/styles/program.css";

import Select from "react-select";
import { useState } from "react";
import { toast } from "react-toastify";

const EditProgram = () => {
  // eslint-disable-next-line
  const [itemId, setItemId] = useState(1);
  const [orderNumber, setOrderNumber] = useState(1);
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const params = useParams();

  const { user } = useSelector((state) => state.reducer.auth);
  const { isError, isCreated, message } = useSelector(
    (state) => state.programs
  );
  const { items } = useSelector((state) => state.items);

  //   useEffect(() => {
  //     const program = {
  //       id: params.id,
  //       token: user?.data?.token,
  //     };
  //     dispatch(getProgramById(program));
  //     dispatch(resetItem());
  //     // eslint-disable-next-line react-hooks/exhaustive-deps
  //   }, [dispatch, user?.data?.token]);

  useEffect(() => {
    const data = {
      api: `/api/items`,
      token: user?.data?.token,
    };
    dispatch(getItems(data));
    dispatch(resetItems());
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [dispatch, user?.data?.token]);

  const options = items?.data?.map((item) => ({
    value: item.id,
    label: item.name,
  }));

  useEffect(() => {
    if (isError) {
      toast.error(message);
      dispatch(reset());
    }
    if (isCreated) {
      toast.success("You've successfully added new item to program.");
      dispatch(reset());
      navigate(-1);
    }
    // eslint-disable-next-line
  }, [isError, isCreated, message]);

  const handleAddItem = (e) => {
    e.preventDefault();
    const program = {
      token: user?.data?.token,
      data: {
        itemId,
        programId: params.id,
        orderNumber: parseInt(orderNumber),
      },
    };
    dispatch(addItemToProgram(program));
  };

  return (
    <div>
      <h1>edit program</h1>
      <form className="add-item" onSubmit={handleAddItem}>
        <h3>Add Item to program</h3>
        <Select
          options={options}
          onChange={(choice) => setItemId(choice.value)}
        />
        <div className="order-num">
          <label>Order Number</label>
          <input
            type="number"
            onChange={(e) => setOrderNumber(e.target.value)}
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
    </div>
  );
};

export default EditProgram;
