import { useEffect, useState } from "react";
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
  Spinner,
} from "react-bootstrap";
import Tab from "react-bootstrap/Tab";
import Tabs from "react-bootstrap/Tabs";
import CodeMirror from "@uiw/react-codemirror";
import { nord, nordInit } from "@uiw/codemirror-theme-nord";
import { javascript } from "@codemirror/lang-javascript";
import { cpp } from "@codemirror/lang-cpp";
import { csharp } from "@replit/codemirror-lang-csharp";
import { python } from "@codemirror/lang-python";
import {
  GetRanking,
  GetSolutions,
  PostSolve,
  TakeDaily,
} from "../http/dailyAPI";

function ProblemTabs() {
  const [daily, setDaily] = useState();
  const [solutions, setSolutions] = useState();
  const [ranked, setRanked] = useState();
  const [loading, setLoading] = useState(true);
  const [code, setCode] = useState("");
  const [language, setLanguage] = useState("javascript");
  const [style, setStyle] = useState(javascript("jsx"));

  const lanstyle = {
    javascript: javascript("jsx"),
    "c++": cpp(),
    "c#": csharp(),
    python: python(),
  };

  useEffect(() => {
    if (loading) {
      TakeDaily()
        .then((data) => {
          setDaily(data);
          console.log(data);
        })
        .catch(() => {
          if (loading)
            setDaily({
              title: "Default Problem",
              description:
                "Default description Lorem ipsum dolor sit amet consectetur adipisicingelit. Consequatur accusantium porro tenetur ad tempore hicobcaecati accusamus dolorem impedit, iusto repellendus suscipit,voluptate nihil dicta sapiente perferendis ipsa incidunt nesciunt.",
              input: "Default Input i = 100 z = N",
              output: "Defaut Output i + z",
              exemples: [
                {
                  input: "100 4",
                  output: "104",
                },
                {
                  input: "100 304",
                  output: "404",
                },
              ],
            });
        })
        .finally(() => {
          GetSolutions()
            .then((data) => {
              setSolutions(data);
            })
            .catch(() => {
              setSolutions({
                solutions: [
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
                ],
              });
            })
            .finally(() => {
              GetRanking()
                .then((data) => {
                  setRanked(data);
                })
                .catch(() => {
                  setRanked({
                    ranked: [
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
                      {
                        lang: "Python",
                        time: "0.78s",
                        memory: "30mb",
                      },
                    ],
                  });
                })
                .finally(() => {
                  setLoading(false);
                });
            });
        });
      GetRanking()
        .then((data) => {
          setRanked(data);
        })
        .catch(() => {
          setRanked({
            ranked: [
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
              {
                lang: "Python",
                time: "0.78s",
                memory: "30mb",
              },
            ],
          });
        });
      //setLoading(false);
    }
  });

  const onPostCode = () => {
    PostSolve({ code, language });
  };

  if (loading) {
    return <Spinner animation={"grow"} />;
  }
  return (
    <Card className="pb-3 bg-dark text-white">
      <Tabs defaultActiveKey="problem" id="problems-tab" className="mb-3" fill>
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
        <Tab eventKey="solve" title="Solve">
          <Container>
            <CodeMirror
              className="mb-3"
              value=""
              height="60vh"
              basicSetup={{
                foldGutter: false,
                dropCursor: false,
                allowMultipleSelections: false,
                indentOnInput: false,
              }}
              theme={nord}
              extensions={[style]}
              onChange={(value, viewUpdate) => {
                setCode(value);
              }}
            />
            <Nav>
              <Nav.Item className="w-100 d-flex justify-content-end">
                <ButtonGroup>
                  <DropdownButton
                    as={ButtonGroup}
                    id="dropdown"
                    title={language}
                    drop={"up"}
                    variant="light"
                  >
                    {["javascript", "c#", "c++", "python"].map((language) => (
                      <Dropdown.Item
                        eventKey={language}
                        onClick={() => {
                          setLanguage(language);
                          setStyle(lanstyle[language]);
                        }}
                        className="flex-fill"
                      >
                        {language}
                      </Dropdown.Item>
                    ))}
                  </DropdownButton>
                  <Button variant="success" className="" onClick={onPostCode}>
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
            solutions.solutions.map((ctn) => (
              <Alert className="mx-2" key={ctn.data.date} variant={ctn.type}>
                {Object.values(ctn.data).map((value, index) => (
                  <p key={index}>{value}</p>
                ))}
              </Alert>
            ))
          )}
        </Tab>
        <Tab eventKey="ranking" title="Ranking">
          {ranked.ranked.map((ctn, index) => (
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
