import { Card, Container, Spinner } from "react-bootstrap";
import ReactMarkdown from "react-markdown";
import { useSelector } from "react-redux";
import { CourseAPI } from "../../http/CourseAPI";
import { useQuery } from "@tanstack/react-query";
import remarkGfm from "remark-gfm";
import MarkdownText from "../general/MarkdownText";

const CourseTextComponent = () => {
  const ModuleID = useSelector((state) => {
    return state.activeModule.id;
  });

  const { data, isPending, error } = useQuery({
    queryKey: ["course", "moduleInfo", ModuleID],
    queryFn: () => CourseAPI.getModule(1, ModuleID),
  });

  if (isPending) return <Spinner />;
  return (
    <Container>
      <h2 className="mt-3">{data.nameModle}</h2>
      <Card
        data-bs-theme="dark"
        className="p-3 m-2 "
        style={{ minHeight: "65vh" }}
      >
        {data.data.map((text) => (
          <MarkdownText key={text}>{text.text}</MarkdownText>
        ))}
      </Card>
    </Container>
  );
};

export default CourseTextComponent;
