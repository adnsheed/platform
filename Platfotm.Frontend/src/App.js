import { BrowserRouter, Route, Routes } from "react-router-dom";
import Sidebar from "./components/Sidebar";
import Students from "./pages/Students/Students";
import Programs from "./pages/Programs/Programs";
import Selections from "./pages/Selections/Selections";
import AddStudent from "./pages/Students/AddStudent";
import Login from "./pages/Login";
import HomePage from "./pages/HomePage";
import StudentProfile from "./pages/StudentProfile";
import AdminReport from "./pages/AdminReport";
import EditStudent from "./pages/Students/EditStudent";
import Items from "./pages/Items/Items";
import AddItem from "./pages/Items/AddItem";
import ProgramDetails from "./pages/Programs/ProgramDetails";
import EditProgram from "./pages/Programs/EditProgram";
import AddStudentToSelection from "./pages/Selections/AddStudentToSelection";

import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

import AdminRoute from "./utils/AdminRoute";
import StudentRoute from "./utils/StudentRoute";

function App() {
  return (
    <>
      <BrowserRouter>
        <Sidebar>
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/login" element={<Login />} />
            <Route
              path="/students"
              element={
                <AdminRoute>
                  <Students />
                </AdminRoute>
              }
            />
            <Route
              path="/add"
              element={
                <AdminRoute>
                  <AddStudent />
                </AdminRoute>
              }
            />
            <Route
              path="/edit"
              element={
                <AdminRoute>
                  <EditStudent />
                </AdminRoute>
              }
            />
            <Route
              path="/report"
              element={
                <AdminRoute>
                  <AdminReport />
                </AdminRoute>
              }
            />
            <Route
              path="/programs"
              element={
                <AdminRoute>
                  <Programs />
                </AdminRoute>
              }
            />
            <Route
              path="/programs/:id"
              element={
                <AdminRoute>
                  <ProgramDetails />
                </AdminRoute>
              }
            />
            <Route
              path="/programs/edit/:id"
              element={
                <AdminRoute>
                  <EditProgram />
                </AdminRoute>
              }
            />
            <Route
              path="/selections"
              element={
                <AdminRoute>
                  <Selections />
                </AdminRoute>
              }
            />
            <Route
              path="/selections/addstudent"
              element={
                <AdminRoute>
                  <AddStudentToSelection />
                </AdminRoute>
              }
            />
            <Route
              path="/items"
              element={
                <AdminRoute>
                  <Items />
                </AdminRoute>
              }
            />
            <Route
              path="/additem"
              element={
                <AdminRoute>
                  <AddItem />
                </AdminRoute>
              }
            />
            <Route
              path="/profile"
              element={
                <StudentRoute>
                  <StudentProfile />
                </StudentRoute>
              }
            />
          </Routes>
        </Sidebar>
      </BrowserRouter>
      <ToastContainer hideProgressBar={true} />
    </>
  );
}

export default App;
