import Navbar from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";
import logo from "../../assets/mobile-logo.png";
import { useSelector } from "react-redux";
import { useState } from "react";
import { Button, Col, Image, Offcanvas, Row } from "react-bootstrap";
import {
  ChatLeftText,
  Journal,
  Journals,
  List,
  ListOl,
  ListUl,
  Newspaper,
  Terminal,
  Window,
  WindowSidebar,
} from "react-bootstrap-icons";

const MainNav = () => {
  const photoUserURL = useSelector((state) => state.AccountData.photoUrl);
  const [offcanvas, SetOffcanvas] = useState(false);

  return (
    <Navbar className="bg-dark text-light">
      <Container className="d-flex justify-content-start">
        <Navbar.Brand
          onClick={() => SetOffcanvas(true)}
          className="ms-3 p-1 justify-content-end text-light"
        >
          <List className="p-0" height={40} width={40} />
        </Navbar.Brand>
        <Navbar.Brand className="text-light" href="/">
          <img
            alt=""
            src={logo}
            width="30"
            height="30"
            className="d-inline-block align-top"
          />{" "}
          CodeCombat
        </Navbar.Brand>
        <Navbar.Toggle />
      </Container>
      <Offcanvas
        data-bs-theme="dark"
        show={offcanvas}
        onHide={() => {
          SetOffcanvas(false);
        }}
      >
        <Offcanvas.Header closeButton style={{ backgroundColor: "#333" }}>
          <Navbar.Brand
            className="text-light d-flex align-self-center"
            href="/"
          >
            <img
              alt=""
              src={logo}
              width="30"
              height="30"
              className="d-inline-block align-top"
              style={{ fontSize: "20px" }}
            />
            <p className="m-0 ms-2" style={{ fontSize: "20px" }}>
              CodeCombat
            </p>
          </Navbar.Brand>
        </Offcanvas.Header>
        <Offcanvas.Body className="d-flex m-0 p-0">
          <Container className="m-0 p-0">
            <Button
              variant="outline-light"
              className="w-100 py-2 d-flex align-items-center rounded-0 border-0"
              href="/profile"
            >
              <Image width={40} height={40} src={photoUserURL} roundedCircle />
              <p className="p-0 m-0 ms-2" style={{ fontSize: "20px" }}>
                Профиль
              </p>
            </Button>
            <Container className="p-0 m-0 ">
              <div
                className="m-0 p-0"
                style={{ height: "3px", backgroundColor: "#333" }}
              ></div>
            </Container>
            <Button
              variant="outline-light"
              className="w-100 py-2 d-flex align-items-center rounded-0 border-0"
              href="/courses/1"
            >
              <Journals width={40} height={40} />
              <p className="p-0 m-0 ms-2" style={{ fontSize: "20px" }}>
                Курсы
              </p>
            </Button>
            <Button
              variant="outline-light"
              className="w-100 py-2 d-flex align-items-center rounded-0 border-0"
              href="/articles/1"
            >
              <Newspaper width={40} height={40} />
              <p className="p-0 m-0 ms-2" style={{ fontSize: "20px" }}>
                Статьи
              </p>
            </Button>
            <Button
              variant="outline-light"
              className="w-100 py-2 d-flex align-items-center rounded-0 border-0"
              href="/courses/1"
            >
              <Terminal width={40} height={40} />
              <p className="p-0 m-0 ms-2" style={{ fontSize: "20px" }}>
                Задачи
              </p>
            </Button>
            <Button
              variant="outline-light"
              className="w-100 py-2 d-flex align-items-center rounded-0 border-0"
              href="/problems/1"
            >
              <ChatLeftText width={40} height={40} />
              <p className="p-0 m-0 ms-2" style={{ fontSize: "20px" }}>
                Форум
              </p>
            </Button>
          </Container>
        </Offcanvas.Body>
      </Offcanvas>
    </Navbar>
  );
};

export default MainNav;
