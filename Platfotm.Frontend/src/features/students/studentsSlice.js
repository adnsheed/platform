import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
  students: null,
  studentById: null,
  currentStudent: null,
  report: null,
  isError: false,
  isLoading: false,
  isSuccess: false,
  isCreated: false,
  message: "",
};

export const getStudents = createAsyncThunk(
  "students/get",
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

export const addStudents = createAsyncThunk(
  "students/add",
  async (data, thunkAPI) => {
    try {
      const response = await axios.post("/api/students", data.student, {
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

export const getStudentById = createAsyncThunk(
  "students/getById",
  async (data, thunkAPI) => {
    try {
      const response = await axios.get(`/api/students/${data.id}`, {
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

export const adminReport = createAsyncThunk(
  "students/report",
  async (token, thunkAPI) => {
    try {
      const response = await axios.get(`/api/admins/report`, {
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

export const studensSlice = createSlice({
  name: "students",
  initialState,
  reducers: {
    reset: (state) => {
      state.isError = false;
      state.isSuccess = false;
      state.isLoading = false;
      state.message = "";
    },
    select: (state, action) => {
      state.currentStudent = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getStudents.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(getStudents.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(getStudents.fulfilled, (state, action) => {
        state.isSuccess = true;
        state.students = action.payload;
      })
      .addCase(addStudents.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(addStudents.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(addStudents.fulfilled, (state) => {
        state.isCreated = true;
      })
      .addCase(getStudentById.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(getStudentById.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(getStudentById.fulfilled, (state, action) => {
        state.studentById = action.payload;
      })
      .addCase(adminReport.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(adminReport.fulfilled, (state, action) => {
        state.report = action.payload;
      });
  },
});

export const { reset, select } = studensSlice.actions;
export default studensSlice.reducer;
