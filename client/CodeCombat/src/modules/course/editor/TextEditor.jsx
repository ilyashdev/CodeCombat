import { useQuery } from "@tanstack/react-query";
import { Card, Container, Spinner } from "react-bootstrap";
import { useSelector } from "react-redux";
import MDEditor, { getCommands, getExtraCommands } from "@uiw/react-md-editor";
import { useEffect, useState } from "react";

const TextEditor = () => {
  const ModuleID = useSelector((state) => {
    return state.activeModule.id;
  });

  const { data, isPending, error } = useQuery({
    queryKey: ["course", "moduleInfo", ModuleID],
    queryFn: () => CourseAPI.getModule(1, ModuleID),
  });

  const [value, setValue] = useState(data);
  useEffect(() => {
    setValue(data.data[0].text);
  }, [isPending]);

  if (isPending) return <Spinner />;
  return (
    <Container>
      <h2 className="mt-3">{data.nameModle}</h2>
      <Card
        data-bs-theme="dark"
        className="p-3 m-2 "
        style={{ minHeight: "65vh" }}
      >
        <MDEditor
          value={value}
          onChange={(tx) => {
            setValue(tx);
          }}
          height={600}
          className="d-flex"
          preview="edit"
          commands={[...getCommands()]}
          extraCommands={[...getExtraCommands()]}
        />
      </Card>
    </Container>
  );
};

export default TextEditor;
