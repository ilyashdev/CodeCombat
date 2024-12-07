import Container from "react-bootstrap/esm/Container";
import { Button, Navbar, Offcanvas, Spinner } from "react-bootstrap";


const ArticleNav = ({Name}) => {
  
  return (
    <Navbar className="bg-light bg-opacity-10 position-sticky">
      <Container className="d-flex justify-content-start">
        <h3 className="m-0 mx-3">{Name}</h3>
      </Container>
    </Navbar>
  );
};

export default ArticleNav;
