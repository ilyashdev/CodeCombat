import { Container } from "react-bootstrap";
import ArticleNav from "../modules/article/ArticleNav";
import ArticleTextComponent from "../modules/article/ArticleTextComponent";
import ArticleAuthor from "../modules/article/ArticleAuthor";
import Comments from "../modules/article/Comments";

const Article = () => {
  return (
    <Container>
      <ArticleTextComponent />
      <ArticleAuthor />
      <Comments />
    </Container>
  );
};

export default Article;
