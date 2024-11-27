import Container from "react-bootstrap/esm/Container";
import SearchBar from "../modules/search/SearchBar";
import ViewCourses from "../modules/search/ViewCourses";
import Pagintion from "../modules/search/Pagintion";

const Courses = () => {
  return (
    <Container className="p-2">
      <h1 style={{ fontWeight: "bold" }}>Курсы</h1>
      <SearchBar />
      <ViewCourses className="mt-4" />
      <Pagintion />
    </Container>
  );
};

export default Courses;

