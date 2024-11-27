import { Container } from "react-bootstrap";
import MainNav from "../modules/general/MainNav";
import Footer from "../modules/general/Footer";

const ErrorPage = () => {
  return (
    <>
      <MainNav />
      <Container style={{ height: "70vh" }}>
        <h1>Что-то пошло не так...</h1>
      </Container>
      <Footer />
    </>
  );
};

export default ErrorPage;
