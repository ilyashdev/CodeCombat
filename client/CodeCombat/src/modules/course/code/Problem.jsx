import { Container } from "react-bootstrap";
import MarkdownText from "../../general/MarkdownText";

const Problem = ({ children }) => {
  return (
    <Container>
      <MarkdownText>{children}</MarkdownText>
    </Container>
  );
};

export default Problem;
