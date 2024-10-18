import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import logo from "../assets/mobile-logo.png";
import defaultImage from "../assets/undefine.png";
import { useState } from "react";

function MainBar() {
  return (
    <Navbar className="bg-body-tertiary bg-opacity-10 p-1">
      <Container>
        <Navbar.Brand className="text-light">
          <img
            alt=""
            src={logo}
            width="30"
            height="30"
            className="d-inline-block align-top"
          />{" "}
          CodeCombat
        </Navbar.Brand>
        <Navbar.Brand href="/profile" className="justify-content-end">
          <img
            alt=""
            src={defaultImage}
            width="35"
            height="35"
            className="d-inline-block align-top rounded-circle"
          />
        </Navbar.Brand>
      </Container>
    </Navbar>
  );
}

export default MainBar;
