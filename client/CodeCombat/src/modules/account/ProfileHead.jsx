import Container from "react-bootstrap/esm/Container";
import "../css/CutImg.css";
import Col from "react-bootstrap/esm/Col";
import Row from "react-bootstrap/esm/Row";
import { ArrowLeft, ChevronLeft, List } from "react-bootstrap-icons";
import { useSelector } from "react-redux";
import { Button, Image } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const ProfileHead = () => {
  const UserInfo = useSelector((state) => state.AccountData);
  const navigate = useNavigate();
  return (
    <Container className="p-1 pt-3 d-flex">
      <Col className="d-flex">
        <Row xs="auto">
          <Col className="d-flex">
            <Button
              variant="link"
              className="text-light align-self-center"
              onClick={() => navigate(-1)}
            >
              <ChevronLeft height={50} width={50} />
            </Button>
          </Col>
          <Col>
            <Image height={75} src={UserInfo.photoUrl} className="rounded-4" />
          </Col>
          <Col>
            <Row
              xxl="auto"
              xl="auto"
              md="auto"
              className="d-flex flex-row justify-content-start"
            >
              <h3 className="">{UserInfo.firstName}</h3>
              <h3 className="">{UserInfo.lastName}</h3>
            </Row>
            <Row>
              <p>@{UserInfo.username}</p>
            </Row>
          </Col>
        </Row>
      </Col>
    </Container>
  );
};

export default ProfileHead;
