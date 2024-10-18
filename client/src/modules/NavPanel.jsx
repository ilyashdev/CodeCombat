import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import logo from "../assets/mobile-logo.png";
import { useState } from "react";
import { Button } from "react-bootstrap";

function NavPanel() {
  return (
    <Navbar className="bg-body-tertiary fixed-bottom bg-opacity-10">
      <Container>
        <Button variant="outline-light">Light</Button>{" "}
        <Button variant="outline-light">Light</Button>{" "}
        <Button variant="outline-light">Light</Button>{" "}
      </Container>
    </Navbar>
  );
}

export default NavPanel;
