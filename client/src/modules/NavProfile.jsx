import * as Icon from "react-bootstrap-icons";
import defaultImage from "../assets/undefine.png";
import { useContext, useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { Container, Navbar } from "react-bootstrap";
import { initData } from "@telegram-apps/sdk";
import { useLaunchParams } from "@telegram-apps/sdk-react";

function NavProfile() {
  let user;
  try {
    user = useLaunchParams().initData.user;
  } catch {
    user = {
      user: { id: 1, username: "1", firstName: "undefi", lastName: "user" },
      hash: "1",
    }.user;
  }

  return (
    <Navbar className="bg-body-tertiary bg-opacity-10 text-white">
      <Container className="d-flex justify-content-start align-items-center">
        <Navbar.Brand href="/" className="text-light">
          <Icon.ChevronLeft size={25} />
        </Navbar.Brand>
        <img
          alt=""
          src={user.photoUrl ? user.photoUrl : defaultImage}
          width="35"
          height="35"
          className="d-inline-block align-top rounded-circle"
        />
        <h3 className="m-0 px-3">{user.firstName + " " + user.lastName}</h3>
      </Container>
    </Navbar>
  );
}

export default NavProfile;
