import Col from "react-bootstrap/esm/Col";
import Row from "react-bootstrap/esm/Row";
import Card from "react-bootstrap/Card";
import Container from "react-bootstrap/esm/Container";

const ProfileInfo = () => {
  return (
    <Container>
      <Row className="my-3 d-flex justify-content-around flex-wrap">
        <Col xs="auto" md={3} className="p-0">
          <Card className="p-3 bg-dark text-light rounded-4">
            <h3>Коины</h3>
            <p className="m-0">1488</p>
          </Card>
        </Col>
        <Col xs="auto" md={3} className="p-0">
          <Card className="p-3 bg-dark text-light rounded-4">
            <h3>Серия</h3>
            <p className="m-0">10 дней</p>
          </Card>
        </Col>
        <Col xs="auto" md={3} className="p-0">
          <Card className="p-3 bg-dark text-light rounded-4">
            <h3>Курсы</h3>
            <p className="m-0">12</p>
          </Card>
        </Col>
      </Row>
    </Container>
  );
};

export default ProfileInfo;
