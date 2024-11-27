import Card from "react-bootstrap/esm/Card";
import Col from "react-bootstrap/esm/Col";
import Row from "react-bootstrap/esm/Row";
import { NavLink } from "react-router-dom";

const MiniCourse = ({
  imgSourse = "https://blog.coursify.me/wp-content/uploads/2018/08/plan-your-online-course.jpg",
  imgWidth = "100",
  courseName = "Undefi course",
  courseDiscription = "Undefi description",
  courseModuleName = "First",
  courseModuleId = 1,
  courseId = 0,
  courseURL = courseName +
    "&" +
    courseId +
    "/" +
    courseModuleName +
    "&" +
    courseModuleId,
  my = "2",
}) => {
  return (
    <NavLink
      style={{ textDecoration: "none", color: "#eee" }}
      to={"/course/" + courseURL}
    >
      <Card className={"rounded-5 p-3 bg-dark text-light my-" + my}>
        <Row>
          <Col xs="auto">
            <div
              data-width={imgWidth}
              style={{
                backgroundImage: `url(${imgSourse})`,
              }}
              className="rounded-4 CutImg"
            />
          </Col>
          <Col>
            <Card.Title className="">{courseName}</Card.Title>
            <Card.Text>{courseDiscription}</Card.Text>
          </Col>
        </Row>
      </Card>
    </NavLink>
  );
};

export default MiniCourse;
