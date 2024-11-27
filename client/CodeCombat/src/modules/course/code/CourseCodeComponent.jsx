import { Card, Container, Spinner } from "react-bootstrap";
import Problem from "./Problem";
import CodeHolder from "./CodeHolder";
import { useQuery } from "@tanstack/react-query";
import { useSelector } from "react-redux";
import { CourseAPI } from "../../../http/CourseAPI";

const CourseCode = () => {
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
      <Card data-bs-theme="dark" className="p-2 m-2">
        <Problem>
          {data.data.reduce((acc, data) => acc + data.text + "\n", "")}
        </Problem>
        <CodeHolder />
      </Card>
    </Container>
  );
};

export default CourseCode;
