import { Outlet } from "react-router-dom";
import MainBar from "./NavBar";
import NavPanel from "./NavPanel";

const Layout = () => {
  return (
    <>
      <MainBar />
      <Outlet />
    </>
  );
};

export default Layout;
