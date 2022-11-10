import { useState } from "react";
import { NavLink } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";

import { logoutUser } from "../features/auth/authSlice";

import "../assets/styles/sidebar.css";
import student from "../assets/images/student.png";

import { Button } from "react-bootstrap";
import {
  FaBars,
  FaUserAlt,
  FaRegChartBar,
  FaThList,
  FaSignOutAlt,
  FaTable,
  FaAlignJustify,
} from "react-icons/fa";

const Sidebar = ({ children }) => {
  const dispatch = useDispatch();
  //const navigate = useNavigate();
  const { user } = useSelector((state) => state.reducer.auth);
  const [isOpen, setIsOpen] = useState(true);
  const toggle = () => setIsOpen(!isOpen);
  const menuItem = [
    {
      path: "/students",
      name: "Students",
      icon: <FaUserAlt />,
    },
    {
      path: "/programs",
      name: "Programs",
      icon: <FaRegChartBar />,
    },
    {
      path: "/selections",
      name: "Selections",
      icon: <FaThList />,
    },
    {
      path: "/items",
      name: "Items",
      icon: <FaAlignJustify />,
    },
    {
      path: "/report",
      name: "Admin Report",
      icon: <FaTable />,
    },
  ];

  const handleLogut = () => {
    dispatch(logoutUser());
  };

  return (
    <div className="sidebar-container">
      {user && (
        <div style={{ width: isOpen ? "200px" : "50px" }} className="sidebar">
          <div className="top_section">
            <h1 style={{ display: isOpen ? "block" : "none" }} className="logo">
              <img src={student} alt="student" className="logoPic" />
            </h1>
            <div
              style={{ marginLeft: isOpen ? "50px" : "0px" }}
              className="bars"
            >
              <FaBars onClick={toggle} />
            </div>
          </div>
          {user?.data?.role === "Admin" &&
            menuItem.map((item, index) => (
              <NavLink
                to={item.path}
                key={index}
                className="link"
                activeclassname="active"
              >
                <div className="icon">{item.icon}</div>
                <div
                  style={{ display: isOpen ? "block" : "none" }}
                  className="link_text"
                >
                  {item.name}
                </div>
              </NavLink>
            ))}

          <Button
            variant="danger"
            className="logout-btn"
            onClick={handleLogut}
            size={isOpen ? "" : "sm"}
            //style={{ display: isOpen ? "block" : "none" }}
          >
            {isOpen ? "Logout" : <FaSignOutAlt />}
          </Button>
        </div>
      )}

      <main className="sidebar-main">{children}</main>
    </div>
  );
};

export default Sidebar;
