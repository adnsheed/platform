import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
  selections: null,
  isError: false,
  isLoading: false,
  isSuccess: false,
  isCreated: false,
  message: "",
};

export const getSelections = createAsyncThunk(
  "selections/get",
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

export const addStudent = createAsyncThunk(
  "selections/addstudent",
  async (selection, thunkAPI) => {
    try {
      const headers = {
        Authorization: `bearer ${selection.token}`,
      };
      const response = await axios.put(
        `/api/selections/addstudent?selectionId=${selection.selectionId}&studentId=${selection.studentId}&programId=${selection.programId}`,
        selection,
        { headers }
      );
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

export const selectionsSlice = createSlice({
  name: "selections",
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
      .addCase(getSelections.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(getSelections.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(getSelections.fulfilled, (state, action) => {
        state.isSuccess = true;
        state.selections = action.payload;
      })
      .addCase(addStudent.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(addStudent.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(addStudent.fulfilled, (state) => {
        state.isCreated = true;
      });
  },
});

export const { reset } = selectionsSlice.actions;
export default selectionsSlice.reducer;
