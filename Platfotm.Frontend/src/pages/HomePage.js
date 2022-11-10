import { Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import platform from "../assets/images/platform.png";

import "../assets/styles/forms.css";
import "../assets/styles/homepage.css";

const HomePage = () => {
  const navigate = useNavigate();
  return (
    <div className="homepage">
      <h1 className="main-title">Welcome to the Platform!</h1>
      <img src={platform} alt="platform" className="home-img" />
      <div className="form-buttons">
        <Button
          variant="outline-primary"
          type="buttton"
          onClick={() => {
            navigate("/login");
          }}
        >
          Let's begin
        </Button>
        {/* <Button variant="outline-primary" type="buttton">
          Dashboard
        </Button> */}
      </div>
    </div>
  );
};

export default HomePage;
