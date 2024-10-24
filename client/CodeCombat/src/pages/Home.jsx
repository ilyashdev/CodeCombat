import Container from "react-bootstrap/esm/Container";
import MiniDaily from "../modules/MiniDaily";
import MiniCourses from "../modules/MiniCourses";
import PopularCourses from "../modules/PopularCourse";

const Home = () => {
  return (
    <Container>
      <MiniDaily />
      <MiniCourses />
      <PopularCourses />
    </Container>
  );
};

export default Home;
