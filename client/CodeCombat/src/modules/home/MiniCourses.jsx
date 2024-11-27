import Container from "react-bootstrap/esm/Container";
import Card from "react-bootstrap/Card";
import Image from "react-bootstrap/Image";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { NavLink } from "react-router-dom";
import "../css/CutImg.css";
import MiniCourse from "./MiniCourse";
import { useQuery } from "@tanstack/react-query";
import { CourseAPI } from "../../http/CourseAPI";
import { Spinner } from "react-bootstrap";

const MiniCourses = () => {
  const { data, isPending } = useQuery({
    queryKey: ["course", "top"],
    queryFn: () => CourseAPI.getTopCourse(),
  });

  if (isPending) return <Spinner />;

  return (
    <Container className="mt-4 mb-3">
      <NavLink
        style={{ textDecoration: "none", color: "#eee" }}
        to="/courses/1"
      >
        <h2 style={{ fontWeight: "bold" }}>Наши курсы</h2>
      </NavLink>
      {data.map((course) => (
        <MiniCourse
          key={course.id}
          courseName={course.name}
          courseDiscription={course.description}
          courseModuleName={course.firstModule.name}
          courseModuleId={course.firstModule.id}
          courseId={course.id}
        />
      ))}
    </Container>
  );
};

export default MiniCourses;
