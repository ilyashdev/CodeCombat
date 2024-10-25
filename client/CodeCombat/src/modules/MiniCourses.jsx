import Container from "react-bootstrap/esm/Container";
import Card from "react-bootstrap/Card";
import Image from "react-bootstrap/Image";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { NavLink } from "react-router-dom";
import "./css/CutImg.css";

const MiniCourses = () => {
  return (
    <Container className="mt-4">
      <NavLink style={{ textDecoration: "none", color: "#eee" }} to="/courses">
        <h2 style={{ fontWeight: "bold" }}>Наши курсы</h2>
      </NavLink>
      <NavLink
        style={{ textDecoration: "none", color: "#eee" }}
        to={"/courses/" + "название курса"}
      >
        <Card className="rounded-5 p-3 my-2 bg-dark text-light">
          <Row>
            <Col xs="auto">
              <div
                style={{
                  backgroundImage:
                    'url("https://blog.coursify.me/wp-content/uploads/2018/08/plan-your-online-course.jpg")',
                }}
                className="rounded-4 CutImg"
              />
            </Col>
            <Col>
              <Card.Title className="">Название курса</Card.Title>
              <Card.Text>
                Краткое описание задачи Lorem ipsum dolor sit amet consectetur
                adipisicing elit.
              </Card.Text>
            </Col>
          </Row>
        </Card>
      </NavLink>
      <NavLink
        style={{ textDecoration: "none", color: "#eee" }}
        to={"/courses/" + "название курса"}
      >
        <Card className="rounded-5 p-3 my-2 bg-dark text-light">
          <Row>
            <Col xs="auto">
              <div
                style={{
                  backgroundImage:
                    'url("https://blog.coursify.me/wp-content/uploads/2018/08/plan-your-online-course.jpg")',
                }}
                className="rounded-4 CutImg"
              />
            </Col>
            <Col>
              <Card.Title className="">Название курса</Card.Title>
              <Card.Text>
                Краткое описание задачи Lorem ipsum dolor sit amet consectetur
                adipisicing elit.
              </Card.Text>
            </Col>
          </Row>
        </Card>
      </NavLink>
    </Container>
  );
};

export default MiniCourses;
