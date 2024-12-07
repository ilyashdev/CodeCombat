import { Container, Spinner } from "react-bootstrap";
import MiniCard from "../home/MiniCard";
import { useQuery } from "@tanstack/react-query";

const ArticleAuthor = () => {
  const { data, isPending, error } = useQuery({
    queryKey: ["article", "authorInfo", 1],
    queryFn: () =>
      Promise.resolve({
        firstName: "Имя",
        lastName: "фамилия",
        username: "username",
      }),
  });

  if (isPending) return <Spinner />;

  return (
    <Container className="px-3">
      <MiniCard
        courseName={data.firstName + " " + data.lastName}
        courseDiscription={"@" + data.username}
        courseURL={"/profile/" + data.username}
        rounded="2"
        imgWidth="50"
        mx="1"
      />
    </Container>
  );
};

export default ArticleAuthor;
