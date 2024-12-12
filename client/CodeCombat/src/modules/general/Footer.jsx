import Col from "react-bootstrap/esm/Col";
import Container from "react-bootstrap/esm/Container";
import { EnvelopeAtFill, Telegram, TelephoneFill } from "react-bootstrap-icons";
import Row from "react-bootstrap/esm/Row";
import { NavLink } from "react-router-dom";

const Footer = () => {
  return (
    <footer className="bg-dark">
      <Container>
        <Row className="py-3">
          <Col>
            <h5>Ссылки</h5>
            <Row>
              <NavLink className="my-1 text-light" to="/">
                Главная
              </NavLink>
            </Row>
            <Row>
              <NavLink className="my-1 text-light" to="/articles/1">
                Статьи
              </NavLink>
            </Row>
            <Row>
              <NavLink className="my-1 text-light" to="/courses/1">
                Курсы
              </NavLink>
            </Row>
          </Col>
          <Col>
            <h5>Контакты</h5>
            <Row>
              <a
                href="https://t.me/code_combat"
                style={{ textDecoration: "none" }}
                className="my-1 text-light"
              >
                <Telegram className="mx-1" />
                t.me/code_combat
              </a>
            </Row>
            <Row>
              <a style={{ textDecoration: "none" }} className="my-1 text-light">
                <EnvelopeAtFill className="mx-1" />
                codecombat@email.com
              </a>
            </Row>
            <Row>
              <a style={{ textDecoration: "none" }} className="my-1 text-light">
                <TelephoneFill className="mx-1" />
                +375(33)32-20-898
              </a>
            </Row>
          </Col>
        </Row>
        <p className="m-0 p-1 d-flex justify-content-center">
          © 2024 CodeCombat
        </p>
      </Container>
    </footer>
  );
};

export default Footer;
