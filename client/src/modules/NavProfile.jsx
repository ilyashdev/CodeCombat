import * as Icon from "react-bootstrap-icons";
import defaultImage from "../assets/undefine.png";
import { useState } from "react";
import { Button } from "react-bootstrap";
import { Container, Navbar } from "react-bootstrap";

function NavProfile() {
  return (
    <Navbar className="bg-body-tertiary bg-opacity-10 text-white">
      <Container className="d-flex justify-content-start align-items-center">
        <Navbar.Brand href="/" className="text-light">
          <Icon.ChevronLeft size={25} />
        </Navbar.Brand>
        <img
          alt=""
          src={defaultImage}
          width="35"
          height="35"
          className="d-inline-block align-top rounded-circle"
        />
        <h3 className="m-0 px-3">Имя Профиля</h3>
      </Container>
    </Navbar>
  );
}

export default NavProfile;
