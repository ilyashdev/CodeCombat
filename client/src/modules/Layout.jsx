import { Outlet } from "react-router-dom";
import MainBar from "./NavBar";
import NavPanel from "./NavPanel";
import CheckUser from "./CheckUser";

const Layout = () => {
  return (
    <>
      <CheckUser/>
      <MainBar />
      <Outlet />
    </>
  );
};

export default Layout;
