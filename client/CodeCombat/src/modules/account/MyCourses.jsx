import Container from "react-bootstrap/esm/Container";
import Card from "react-bootstrap/Card";
import Image from "react-bootstrap/Image";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { NavLink } from "react-router-dom";
import "../css/CutImg.css";
import MiniCourse from "../home/MiniCard";

const MyCourses = () => {
  return (
    <Container className="my-4">
      <NavLink style={{ textDecoration: "none", color: "#eee" }} to="courses">
        <h2 style={{ fontWeight: "bold" }}>Мои курсы &gt;</h2>
      </NavLink>
      <MiniCourse imgWidth="75" />
      <MiniCourse imgWidth="75" />
    </Container>
  );
};

export default MyCourses;
