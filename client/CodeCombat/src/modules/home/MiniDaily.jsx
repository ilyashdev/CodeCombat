import Container from "react-bootstrap/esm/Container";
import Card from "react-bootstrap/Card";
import { NavLink } from "react-router-dom";

const MiniDaily = () => {
  return (
    <Container className="mt-3">
      <NavLink
        style={{ textDecoration: "none", color: "#eee" }}
        to="/problems/1"
      >
        <h2 style={{ fontWeight: "bold" }}>Популярные задачи</h2>
      </NavLink>
      {[1, 2].map((index) => (
        <NavLink
          style={{ textDecoration: "none", color: "#eee" }}
          to={"/problem/" + index}
          key={index}
        >
          <Card key={index} className="rounded-5 p-3 my-2 bg-dark text-light">
            <Card.Title className="">Название задачи</Card.Title>
            <Card.Text>
              Краткое описание задачи Lorem ipsum dolor sit amet consectetur
              adipisicing elit. Unde expedita in, perspiciatis, autem soluta
              dignissimos voluptate labore, laboriosam molestias accusantium
              doloremque rerum esse facere quos inventore? Magnam molestias a
              nihil!
            </Card.Text>
          </Card>
        </NavLink>
      ))}
    </Container>
  );
};

export default MiniDaily;
