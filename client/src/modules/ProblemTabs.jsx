import { useState } from "react";
import {
  Button,
  ButtonGroup,
  Card,
  Container,
  Dropdown,
  DropdownButton,
  Form,
  Nav,
  Navbar,
} from "react-bootstrap";
import Tab from "react-bootstrap/Tab";
import Tabs from "react-bootstrap/Tabs";
import CodeMirror from "@uiw/react-codemirror";
import { nord, nordInit } from "@uiw/codemirror-theme-nord";
import { javascript } from "@codemirror/lang-javascript";

function ProblemTabs() {
  return (
    <Card className="pb-3 bg-dark text-white">
      <Tabs defaultActiveKey="problem" id="problems-tab" className="mb-3" fill>
        <Tab eventKey="problem" title="Problem">
          <Container>
            <h3>Название задачи{}</h3>
            <p>
              Условие задачи Lorem ipsum dolor sit amet consectetur adipisicing
              elit. Consequatur accusantium porro tenetur ad tempore hic
              obcaecati accusamus dolorem impedit, iusto repellendus suscipit,
              voluptate nihil dicta sapiente perferendis ipsa incidunt nesciunt.
            </p>
            <h3>Input</h3>
            <p>Какие-то условия</p>
            <h3>Output</h3>
            <p>коакой-то оутпут</p>
            <h3>Exemple</h3>
            <p>Input:</p>
            <Card
              border="light"
              className=" mb-3 p-1"
              style={{ width: "18rem" }}
            >
              <code>1 какой-то ввод</code>
            </Card>
            <p>Output:</p>
            <Card
              border="light"
              className="mb-3 p-1"
              style={{ width: "18rem" }}
            >
              <code>какой-то вывод</code>
            </Card>
          </Container>
        </Tab>
        <Tab eventKey="solve" title="Solve">
          <Container>
            <CodeMirror
              className="mb-3"
              value="console.log('hello world!');"
              height="60vh"
              basicSetup={{
                foldGutter: false,
                dropCursor: false,
                allowMultipleSelections: false,
                indentOnInput: false,
              }}
              theme={nord}
              extensions={[javascript({ jsx: true })]}
              onChange={(value, viewUpdate) => {
                console.log("value:", value);
              }}
            />
            <Nav>
              <Nav.Item className="w-100 d-flex justify-content-end">
                <ButtonGroup>
                  <DropdownButton
                    as={ButtonGroup}
                    id="bg-nested-dropdown"
                    title="javascript"
                    drop={"up"}
                    variant="light"
                  >
                    {["javascript", "c#", "c++", "python"].map((language) => (
                      <Dropdown.Item eventKey="1" className="flex-fill">
                        {language}
                      </Dropdown.Item>
                    ))}
                  </DropdownButton>
                  <Button variant="success" className="">
                    RUN {">"}
                  </Button>
                </ButtonGroup>
              </Nav.Item>
            </Nav>
          </Container>
        </Tab>
        <Tab eventKey="history" title="History">
          Tab content for Loooonger Tab
        </Tab>
        <Tab eventKey="ranking" title="Ranking">
          Tab content for Loooonger Tab
        </Tab>
      </Tabs>
    </Card>
  );
}

export default ProblemTabs;
