import { Outlet } from "react-router-dom";
import MainNav from "../modules/MainNav";
import Footer from "../modules/Footer";

const Layout = () => {
  return (
    <>
      <MainNav />
      <Outlet />
      <Footer />
    </>
  );
};

export default Layout;
