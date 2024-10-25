import { Outlet } from "react-router-dom";
import MainNav from "../modules/MainNav";
import Footer from "../modules/Footer";

const MainLayout = () => {
  return (
    <>
      <MainNav />
      <Outlet />
      <Footer />
    </>
  );
};

export default MainLayout;
