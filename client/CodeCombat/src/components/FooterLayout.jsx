import { Outlet } from "react-router-dom";
import Footer from "../modules/Footer";

const FooterLayout = () => {
  return (
    <>
      <Outlet />
      <Footer />
    </>
  );
};

export default FooterLayout;
