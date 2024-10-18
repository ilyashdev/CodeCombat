import { useState } from "react";
import {
  Alert,
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
                    id="dropdown"
                    title="javascript"
                    drop={"up"}
                    variant="light"
                  >
                    {["javascript", "c#", "c++", "python"].map((language) => (
                      <Dropdown.Item eventKey={language} className="flex-fill">
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
          {false ? (
            <p></p>
          ) : (
            [
              {
                data: {
                  date: "20.10.2024",
                  name: "Название задачи",
                  message: "Сообщение ошибки",
                },
                type: "danger",
              },
              {
                data: {
                  date: "15.10.2024",
                  name: "Название задачи",
                  time: "0.56s",
                  memory: "10mb",
                  coin: "1000cc",
                },
                type: "success",
              },
              {
                data: {
                  date: "14.10.2024",
                  name: "Название задачи",
                  time: "0.56s",
                  memory: "10mb",
                  coin: "1000cc",
                },
                type: "success",
              },
            ].map((ctn) => (
              <Alert className="mx-2" key={ctn.data.date} variant={ctn.type}>
                {Object.values(ctn.data).map((value, index) => (
                  <p key={index}>{value}</p>
                ))}
              </Alert>
            ))
          )}
        </Tab>
        <Tab eventKey="ranking" title="Ranking">
          {[
            {
              lang: "C#",
              time: "0.56s",
              memory: "10mb",
            },
            {
              lang: "C++",
              time: "0.56s",
              memory: "10mb",
            },
          ].map((ctn, index) => (
            <Alert className="mx-2 d-flex" key={index} variant="light">
              <p className="mx-1">{index + 1}.</p>
              <p className="mx-1">{ctn.lang}</p>
              <p className="mx-1">{ctn.memory}</p>
              <p className="mx-1">{ctn.time}</p>
            </Alert>
          ))}
        </Tab>
      </Tabs>
    </Card>
  );
}

export default ProblemTabs;
