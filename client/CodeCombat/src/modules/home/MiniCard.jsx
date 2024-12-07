import Card from "react-bootstrap/esm/Card";
import Col from "react-bootstrap/esm/Col";
import Row from "react-bootstrap/esm/Row";
import { NavLink } from "react-router-dom";
import "../css/CutImg.css";

const MiniCard = ({
  imgSourse = "https://blog.coursify.me/wp-content/uploads/2018/08/plan-your-online-course.jpg",
  imgWidth = "100",
  rounded = "5",
  courseName = "Undefi course",
  courseDiscription = "Undefi description",
  courseModuleName = "First",
  courseModuleId = 1,
  courseId = 0,
  courseURL = "/course/" +
    courseName +
    "&" +
    courseId +
    "/" +
    courseModuleName +
    "&" +
    courseModuleId,
  my = "2",
  mx = "0",
}) => {
  return (
    <NavLink style={{ textDecoration: "none", color: "#eee" }} to={courseURL}>
      <Card
        data-bs-theme="dark"
        className={
          "rounded-" +
          rounded +
          " p-3 bg-dark text-light my-" +
          my +
          " mx-" +
          mx
        }
      >
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

export default MiniCard;
