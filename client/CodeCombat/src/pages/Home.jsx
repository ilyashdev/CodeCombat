import Container from "react-bootstrap/esm/Container";
import MiniDaily from "../modules/home/MiniDaily";
import MiniCourses from "../modules/home/MiniCourses";
import MiniArticles from "../modules/home/MiniArticles/MiniArticles";
import PopularCourses from "../modules/home/PopularCourse";

const Home = () => {
  return (
    <Container>
      <MiniDaily />
      <MiniCourses />
      <MiniArticles />
      {/*<PopularCourses />*/}
    </Container>
  );
};

export default Home;
