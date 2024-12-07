import { Button, Card, Container, Nav } from "react-bootstrap";
import { ArrowDown, ArrowUp, Chat } from "react-bootstrap-icons";

const Comment = ({
  children,
  imgSourse = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRaOQkNni05Nb3SqMBDsQ40HrAplq15_NMGIA&s",
  deepence = 0,
  data: { firstName, lastName, text, time, rating },
}) => {
  const maxDeph = 3;

  return (
    <Container className="p-0">
      <Card data-bs-theme="dark" className="p-3 rounded-5 my-1">
        <Nav className="align-items-center">
          <div
            data-width={30}
            style={{
              backgroundImage: `url(${imgSourse})`,
            }}
            className="rounded-4 CutImg"
          />
          <p className="px-2 m-0">
            {firstName} {lastName}
          </p>
          <p className="m-0 text-secondary"> {time}</p>
        </Nav>
        <p className="my-2">{text}</p>
        <Nav className="align-items-center">
          <Button
            variant="link"
            className="text-light text-decoration-none p-2 py-1"
          >
            <ArrowUp width={20} height={20} />
          </Button>
          <p className="m-0">{rating}</p>
          <Button
            variant="link"
            className="text-light text-decoration-none p-2 py-1"
          >
            <ArrowDown width={20} height={20} />
          </Button>
          <Button
            variant="link"
            className="text-light text-decoration-none p-2 py-1 d-flex"
          >
            <Chat width={20} height={20} />
            <p className="m-0 mx-2">Ответить</p>
          </Button>
        </Nav>
      </Card>
      <Container className="p-0 d-flex">
        <div
          style={{
            marginLeft: "1.5em",
            marginRight: "1em",
            width: "1px",
            backgroundColor: "lightgrey",
          }}
        />{" "}
        {children != undefined ? (
          deepence >= maxDeph ? (
            <Button
              variant="outline-secondary"
              className="text-decoration-none text-light rounded-4 mb-2 "
            >
              Ещё ответы
            </Button>
          ) : (
            <Container className="p-0">{children}</Container>
          )
        ) : (
          <></>
        )}
      </Container>
    </Container>
  );
};

export default Comment;
