import { Button, Card, Container, Nav } from "react-bootstrap";
import { ArrowDown, ArrowUp, Chat } from "react-bootstrap-icons";

const Comment = (
  { children },
  {
    imgSourse = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRaOQkNni05Nb3SqMBDsQ40HrAplq15_NMGIA&s",
  }
) => {
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
          <p className="px-2 m-0">Имя Фамилия</p>
          <p className="m-0 text-secondary"> 2ч назад</p>
        </Nav>
        <p className="my-2">
          Lorem, ipsum dolor sit amet consectetur adipisicing elit. Sed
          consectetur neque tempora dignissimos rerum saepe quidem aliquam
          labore facilis ipsam rem tempore, maxime reiciendis asperiores fuga!
          Quam labore culpa perspiciatis.
        </p>
        <Nav className="align-items-center">
          <Button
            variant="link"
            className="text-light text-decoration-none p-2 py-1"
          >
            <ArrowUp width={20} height={20} />
          </Button>
          <p className="m-0">14</p>
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
      <Container className="px-5 pe-0">{children}</Container>
    </Container>
  );
};

export default Comment;
