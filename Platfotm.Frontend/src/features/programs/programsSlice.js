import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
  programs: null,
  programById: null,
  isError: false,
  isSuccess: false,
  isCreated: false,
  message: "",
};

export const getPrograms = createAsyncThunk(
  "programs/get",
  async (token, thunkAPI) => {
    try {
      const response = await axios.get("/api/programs", {
        headers: {
          Authorization: `bearer ${token}`,
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

export const getProgramById = createAsyncThunk(
  "programs/id",
  async (program, thunkAPI) => {
    try {
      const response = await axios.get(`/api/programs/${program.id}`, {
        headers: {
          Authorization: `bearer ${program.token}`,
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

export const addItemToProgram = createAsyncThunk(
  "programs/additem",
  async (program, thunkAPI) => {
    try {
      const response = await axios.post(`/api/programs/additem`, program.data, {
        headers: {
          Authorization: `bearer ${program.token}`,
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

export const programsSlice = createSlice({
  name: "programs",
  initialState,
  reducers: {
    reset: (state) => {
      state.isError = false;
      state.isSuccess = false;
      state.isCreated = false;
      state.message = "";
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getPrograms.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(getPrograms.fulfilled, (state, action) => {
        state.programs = action.payload;
      })
      .addCase(getProgramById.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(getProgramById.fulfilled, (state, action) => {
        state.programById = action.payload;
      })
      .addCase(addItemToProgram.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(addItemToProgram.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(addItemToProgram.fulfilled, (state) => {
        state.isCreated = true;
      });
  },
});

export const { reset } = programsSlice.actions;
export default programsSlice.reducer;
