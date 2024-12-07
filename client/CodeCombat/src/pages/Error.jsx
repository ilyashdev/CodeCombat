import { Container, NavLink } from "react-bootstrap";
import MainNav from "../modules/general/MainNav";
import Footer from "../modules/general/Footer";

const ErrorPage = () => {
  return (
    <>
      <MainNav />
      <Container
        //className="d-flex justify-content-start"
        style={{ height: "70vh" }}
      >
        <h1>
          Что-то пошло не так... <a className="text-decoration-none" href="/">На главную</a>
        </h1>
      </Container>
      <Footer />
    </>
  );
};

export default ErrorPage;
