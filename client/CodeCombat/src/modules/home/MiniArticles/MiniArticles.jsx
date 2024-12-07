import Container from "react-bootstrap/esm/Container";
import { NavLink } from "react-router-dom";
import MiniCourse from "../MiniCard";
import { useQuery } from "@tanstack/react-query";
import { CourseAPI } from "../../../http/CourseAPI";
import { Spinner } from "react-bootstrap";
import MiniCard from "../MiniCard";

const ArticleAuthor = () => {
  const { data, isPending } = useQuery({
    queryKey: ["course", "top"],
    queryFn: () => CourseAPI.getTopCourse(),
  });

  if (isPending) return <Spinner />;

  return (
    <Container className="mt-4 mb-3">
      <NavLink
        style={{ textDecoration: "none", color: "#eee" }}
        to="/articles/1"
      >
        <h2 style={{ fontWeight: "bold" }}>Интересные статьи</h2>
      </NavLink>
      {data.map((article) => (
        <MiniCard
          key={article.id}
          courseName={article.name}
          courseDiscription={article.description}
          courseId={article.id}
          courseURL={"article/" + article.name + "&" + article.id}
        />
      ))}
    </Container>
  );
};

export default ArticleAuthor;
