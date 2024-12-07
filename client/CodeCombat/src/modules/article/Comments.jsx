import { Card, Container } from "react-bootstrap";
import Comment from "../general/Comment";

const Comments = () => {
  return (
    <Container className="px-2">
      <h3>Комментарии:</h3>
      <Container >
        <Comment>
          <Comment>
            <Comment />
          </Comment>
          <Comment />
        </Comment>
        <Comment />
      </Container>
    </Container>
  );
};

export default Comments;
