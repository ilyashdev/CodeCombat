import * as Icon from "react-bootstrap-icons";
import defaultImage from "../assets/undefine.png";
import { useContext, useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { Container, Navbar } from "react-bootstrap";
import { Context } from "../main";

function NavProfile() {
  const { user } = useContext(Context);

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
        <h3 className="m-0 px-3">{user.user.name}</h3>
      </Container>
    </Navbar>
  );
}

export default NavProfile;
