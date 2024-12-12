import { useQuery } from "@tanstack/react-query";
import { Button, Card, Container, Form, Spinner } from "react-bootstrap";
import { useSelector } from "react-redux";
import { CourseAPI } from "../../../http/CourseAPI";
import MarkdownText from "../../general/MarkdownText";

const CourseTestComponent = () => {
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
        className="p-3 m-2 mb-4 d-flex"
        style={{ minHeight: "60vh" }}
      >
        <MarkdownText>{data.data[0].question}</MarkdownText>
        <h2>Варианты ответа:</h2>
        {data.data[0].variants.map((variant) => (
          <Form.Check
            style={{ fontSize: " calc(16px + 4 * (100vw - 320px) / 880)" }}
            type={data.data[0].mode == "oneAns" ? "radio" : "checkbox"}
            label={variant}
            key={variant}
            name={data.data[0].question}
            id={variant}
          />
        ))}
        <Container className="my-3 d-flex justify-content-between algin-self-end algin-items-end">
          <Button>1</Button>
          <Button>3</Button>
        </Container>
      </Card>
    </Container>
  );
};

export default CourseTestComponent;
