import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

const initialState = {
  user: null,
  isError: false,
  isSuccess: false,
  message: "",
};

export const loginUser = createAsyncThunk(
  "auth/login",
  async (userData, thunkAPI) => {
    try {
      const response = await axios.post("/api/auth/login", userData);
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

export const logoutUser = createAsyncThunk("auth/logout", () => {
  localStorage.removeItem("persist:root");
});

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    reset: (state) => {
      state.isError = false;
      state.isSuccess = false;
      state.message = "";
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(loginUser.rejected, (state, action) => {
        state.isError = true;
        state.message = action.payload;
      })
      .addCase(loginUser.fulfilled, (state, action) => {
        state.isSuccess = true;
        state.user = action.payload;
      })
      .addCase(logoutUser.fulfilled, (state) => {
        state.user = null;
        state.isError = false;
        state.isSuccess = false;
        state.message = "";
      });
  },
});

export const { reset } = authSlice.actions;
export default authSlice.reducer;
