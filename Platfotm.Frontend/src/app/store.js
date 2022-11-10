import { configureStore, combineReducers } from "@reduxjs/toolkit";
import storage from "redux-persist/lib/storage";
import { persistReducer } from "redux-persist";

import authReducer from "../features/auth/authSlice";
import studentsReducer from "../features/students/studentsSlice";
import programsReducer from "../features/programs/programsSlice";
import selectionsReducer from "../features/selections/selectionsSlice";
import itemsReducer from "../features/items/itemsSlice";

const persistConfig = {
  key: "root",
  version: 1,
  storage,
};

const reducer = combineReducers({
  auth: authReducer,
});

const persistedReducer = persistReducer(persistConfig, reducer);

export const store = configureStore({
  reducer: {
    reducer: persistedReducer,
    students: studentsReducer,
    programs: programsReducer,
    selections: selectionsReducer,
    items: itemsReducer,
  },
});
