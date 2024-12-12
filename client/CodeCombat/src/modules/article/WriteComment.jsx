import { useRef } from "react";
import { Button, Card, Container, Form } from "react-bootstrap";

const WriteComment = () => {
  const textareaRef = useRef(null);

  const handleTextareaChange = (event) => {
    const textarea = textareaRef.current;
    textarea.style.height = "auto";
    textarea.style.height = `${textarea.scrollHeight}px`;
  };

  return (
    <Card data-bs-theme="dark" className="mx-2 mb-4 p-3 rounded-4">
      <Form.Group className="mb-3" controlId="exampleForm.ControlTextarea1">
        <Form.Label>Ваш Комментарий</Form.Label>
        <Form.Control
          as="textarea"
          rows={3}
          ref={textareaRef}
          onChange={handleTextareaChange}
          style={{ resize: "none", overflow: "hidden" }}
        />
        <Button className="mt-3" variant="outline-success">
          Отправить
        </Button>
      </Form.Group>
    </Card>
  );
};

export default WriteComment;
