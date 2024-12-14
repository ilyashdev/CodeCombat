import Navbar from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";
import logo from "../../assets/mobile-logo.png";
import Image from "react-bootstrap/esm/Image";
import { useSelector } from "react-redux";

const MainNav = () => {
  const photoUserURL = useSelector((state) => state.AccountData.photoUrl);

  return (
    <Navbar className="bg-dark text-light">
      <Container className="d-flex ">
        <Navbar.Brand className="text-light" href="/">
          <img
            alt=""
            src={logo}
            width="30"
            height="30"
            className="d-inline-block align-top"
          />{" "}
          CodeCombat
        </Navbar.Brand>
        <Navbar.Toggle />
        <Navbar.Brand href="/profile" className="p-1 justify-content-end">
          <Image width="40" src={photoUserURL} roundedCircle />
        </Navbar.Brand>
      </Container>
    </Navbar>
  );
};

export default MainNav;
