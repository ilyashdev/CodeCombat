import Container from "react-bootstrap/esm/Container";
import "../css/CutImg.css";
import Col from "react-bootstrap/esm/Col";
import Row from "react-bootstrap/esm/Row";
import { List } from "react-bootstrap-icons";

const ProfileHead = () => {
  return (
    <Container className="p-1 pt-3 d-flex">
      <Col className="d-flex">
        <Row xs="auto">
          <Col>
            <div
              data-width="75"
              style={{
                backgroundImage:
                  'url("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRaOQkNni05Nb3SqMBDsQ40HrAplq15_NMGIA&s")',
              }}
              className="rounded-4 CutImg"
            />
          </Col>
          <Col>
            <Row
              xxl="auto"
              xl="auto"
              md="auto"
              className="d-flex flex-row justify-content-start"
            >
              <h3 className="">{"Firstname"}</h3>
              <h3 className="">{"Lastname"}</h3>
            </Row>
            <Row>
              <p>@username</p>
            </Row>
          </Col>
        </Row>
      </Col>
    </Container>
  );
};

export default ProfileHead;
