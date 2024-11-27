import { Card, Container, Tab } from "react-bootstrap";

const ProblemTab = () => {
  return (
    <Tab eventKey="problem" title="Problem">
      <Container>
        <h3>{daily.title}</h3>
        <p>{daily.description}</p>
        <h3>Input</h3>
        <p>{daily.input}</p>
        <h3>Output</h3>
        <p>{daily.output}</p>
        <h3>Exemple</h3>
        {daily.exemples.map((exemple) => (
          <Card className="p-1 my-2 bg-dark border-secondary text-white">
            <p>Input:</p>
            <Card
              border="light"
              className=" mb-3 p-1"
              style={{ width: "18rem" }}
            >
              <code>{exemple.input}</code>
            </Card>
            <p>Output:</p>
            <Card
              border="light"
              className="mb-3 p-1"
              style={{ width: "18rem" }}
            >
              <code>{exemple.output}</code>
            </Card>
          </Card>
        ))}
      </Container>
    </Tab>
  );
};

export default ProblemTab;
