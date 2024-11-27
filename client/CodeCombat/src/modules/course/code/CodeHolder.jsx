import { Alert, Button, Container } from "react-bootstrap";
import CodeMirror from "@uiw/react-codemirror";
import { nord, nordInit } from "@uiw/codemirror-theme-nord";
import { javascript } from "@codemirror/lang-javascript";
import { cpp } from "@codemirror/lang-cpp";
import { csharp } from "@replit/codemirror-lang-csharp";
import { python } from "@codemirror/lang-python";

const CodeHolder = () => {
  return (
    <Container className="mb-3">
      <h4 className="m-1">Ваш код:</h4>
      <CodeMirror
        className="mb-3"
        value={"int main(){\n}"}
        height="60vh"
        basicSetup={{
          foldGutter: false,
          dropCursor: false,
          allowMultipleSelections: false,
          indentOnInput: false,
        }}
        theme={nord}
        extensions={[cpp()]}
      ></CodeMirror>
      <Button>{"Проверить"}</Button>
      <Alert variant="danger" className="mx-2 my-4">{"Ошибка компиляции"}</Alert>
    </Container>
  );
};

export default CodeHolder;
