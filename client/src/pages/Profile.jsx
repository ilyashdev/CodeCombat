import { useState } from "react";
import { Container } from "react-bootstrap";
import ProblemTabs from "../modules/ProblemTabs";
import ProfileInformation from "../modules/ProfileInformatoin";
import { Outlet } from "react-router-dom";
import NavProfile from "../modules/NavProfile";

function Profile() {
  return (
    <>
      <NavProfile />
      <Outlet />
    </>
  );
}

export default Profile;
