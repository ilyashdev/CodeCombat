import { Outlet } from "react-router-dom";
import Footer from "../modules/general/Footer";

const FooterLayout = () => {
  return (
    <>
      <Outlet />
      <Footer />
    </>
  );
};

export default FooterLayout;
