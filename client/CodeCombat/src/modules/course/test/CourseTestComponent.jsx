import { useQuery } from "@tanstack/react-query";
import {
  Button,
  Card,
  Container,
  Spinner,
  ToggleButton,
  ToggleButtonGroup,
} from "react-bootstrap";
import { useSelector } from "react-redux";
import { CourseAPI } from "../../../http/CourseAPI";
import MarkdownText from "../../general/MarkdownText";
import { useState } from "react";

const CourseTestComponent = () => {
  const ModuleID = useSelector((state) => {
    return state.activeModule.id;
  });

  const { data, isPending, error } = useQuery({
    queryKey: ["course", "moduleInfo", ModuleID],
    queryFn: () => CourseAPI.getModule(1, ModuleID),
  });

  const [quetion, setQuetion] = useState(0);

  if (isPending) return <Spinner />;
  return (
    <Container>
      <h2 className="mt-3">{data.nameModle}</h2>
      <Card
        data-bs-theme="dark"
        className="p-3 m-2 mb-4 d-flex"
        style={{ minHeight: "60vh" }}
      >
        <MarkdownText>{data.data[quetion].question}</MarkdownText>
        <h2>Варианты ответа:</h2>
        <ToggleButtonGroup
          type={data.data[quetion].mode == "oneAns" ? "radio" : "checkbox"}
          name="answer"
          className="d-flex flex-wrap justify-content-center"
        >
          {data.data[quetion].variants.map((variant) => (
            <ToggleButton
              key={variant}
              id={data.data[quetion].mode + variant}
              value={variant}
              variant="outline-light"
              className="m-2 rounded-3 d-flex justify-content-center"
              style={{
                height: "50px",
                width: "80vw",
                maxWidth: "500px",
                fontSize: "calc(14px + 6 * (100vw - 320px) / 880)",
              }}
            >
              <p className="m-0 p-0 align-self-center">{variant}</p>
            </ToggleButton>
          ))}
        </ToggleButtonGroup>
        <Container className="my-3 d-flex justify-content-between algin-self-end algin-items-end">
          {quetion > 1 ? (
            <Button onClick={() => setQuetion(quetion - 1)}>Предыдущий</Button>
          ) : (
            <p></p>
          )}
          {quetion < data.data.length ? (
            <Button onClick={() => setQuetion(quetion + 1)}>Следующий</Button>
          ) : (
            <p></p>
          )}
        </Container>
      </Card>
    </Container>
  );
};

export default CourseTestComponent;
