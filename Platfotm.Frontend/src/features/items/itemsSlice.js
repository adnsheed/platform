import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
  items: null,
  isError: false,
  isLoading: false,
  isSuccess: false,
  isCreated: false,
  message: "",
};

export const getItems = createAsyncThunk(
  "items/get",
  async (data, thunkAPI) => {
    try {
      const response = await axios.get(data.api, {
        headers: {
          Authorization: `bearer ${data.token}`,
        },
      });
      return response.data;
    } catch (error) {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();
      return thunkAPI.rejectWithValue(message);
    }
  }
);

export const addItems = createAsyncThunk(
  "items/add",
  async (data, thunkAPI) => {
    try {
      const response = await axios.post("/api/items", data.item, {
        headers: {
          Authorization: `bearer ${data.token}`,
        },
      });
      return response.data;
    } catch (error) {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();
      return thunkAPI.rejectWithValue(message);
    }
  }
);

export const itemsSlice = createSlice({
  name: "items",
  initialState,
  reducers: {
    reset: (state) => {
      state.isError = false;
      state.isSuccess = false;
      state.isLoading = false;
      state.isCreated = false;
      state.message = "";
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getItems.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(getItems.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(getItems.fulfilled, (state, action) => {
        state.isSuccess = true;
        state.items = action.payload;
      })
      .addCase(addItems.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(addItems.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(addItems.fulfilled, (state) => {
        state.isCreated = true;
      });
  },
});

export const { reset } = itemsSlice.actions;
export default itemsSlice.reducer;
