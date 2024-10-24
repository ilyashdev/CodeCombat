import Navbar from "react-bootstrap/Navbar";
import Container from "react-bootstrap/Container";
import logo from "../assets/mobile-logo.png";
import Image from "react-bootstrap/esm/Image";

const MainNav = () => {
  return (
    <Navbar className="bg-dark text-light">
      <Container className="d-flex ">
        <Navbar.Brand className="text-light">
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
          <Image
            width="40"
            src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRaOQkNni05Nb3SqMBDsQ40HrAplq15_NMGIA&s"
            roundedCircle
          />
        </Navbar.Brand>
      </Container>
    </Navbar>
  );
};

export default MainNav;
