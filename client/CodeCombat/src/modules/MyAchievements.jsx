import Container from "react-bootstrap/esm/Container";
import Card from "react-bootstrap/Card";
import Image from "react-bootstrap/Image";
import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import { NavLink } from "react-router-dom";
import "./css/CutImg.css";
import { Award } from "react-bootstrap-icons";

const MyAchievements = () => {
  return (
    <Container className="my-4">
      <NavLink
        style={{ textDecoration: "none", color: "#eee" }}
        to="achievements"
      >
        <h2 style={{ fontWeight: "bold" }}>Мои достижения &gt;</h2>
      </NavLink>
      <Container className="p-0">
        <Card className="rounded-5 p-3 my-2 bg-dark text-light">
          <Row>
            <Col xs="auto" className="pe-1 align-self-center">
              <Award size={35} />
            </Col>
            <Col>
              <Card.Title className="">Название достижения</Card.Title>
              <Card.Text className="mt-1">
                Краткое описание за что достижение
              </Card.Text>
            </Col>
          </Row>
        </Card>
      </Container>
      <Container className="p-0">
        <Card className="rounded-5 p-3 my-2 bg-dark text-light">
          <Row>
            <Col xs="auto" className="pe-1 align-self-center">
              <Award size={35} />
            </Col>
            <Col>
              <Card.Title className="">Название достижения</Card.Title>
              <Card.Text className="mt-1">
                Краткое описание за что достижение
              </Card.Text>
            </Col>
          </Row>
        </Card>
      </Container>
    </Container>
  );
};

export default MyAchievements;
