import { Outlet } from "react-router-dom";
import MainNav from "../modules/general/MainNav";
import Footer from "../modules/general/Footer";

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
