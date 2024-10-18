import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import logo from "../assets/mobile-logo.png";
import { useState } from "react";

function MainBar() {
  return (
    <Navbar className="bg-body-tertiary bg-opacity-10">
      <Container>
        <Navbar.Brand href="/" className="text-light">
          <img
            alt=""
            src={logo}
            width="30"
            height="30"
            className="d-inline-block align-top"
          />{" "}
          CodeCombat
        </Navbar.Brand>
      </Container>
    </Navbar>
  );
}

export default MainBar;
