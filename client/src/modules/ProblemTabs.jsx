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
import { useLaunchParams } from "@telegram-apps/sdk-react";
import { keys } from "mobx";

function ProblemTabs() {
  const [daily, setDaily] = useState();
  const [solutions, setSolutions] = useState();
  const [ranked, setRanked] = useState([]);
  const [loading, setLoading] = useState(true);
  const [code, setCode] = useState("");
  const [language, setLanguage] = useState("javascript");
  const [style, setStyle] = useState(javascript("jsx"));
  const [key, setKey] = useState("problem");
  const [refresh, setRefresh] = useState(false);
  const [run, setRun] = useState(false);
  const user = useLaunchParams().initData;

  const lanstyle = {
    javascript: javascript("jsx"),
    "c++": cpp(),
    "c#": csharp(),
    python: python(),
  };
  const lang = {
    javascript: "js",
    "c++": "cpp",
    "c#": "cs",
    python: "py",
  };

  useEffect(() => {
    if (loading) {
      TakeDaily(user)
        .then((data) => {
          setDaily(data);
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
          GetSolutions(user)
            .then((data) => {
              setSolutions(data);
              setLanguage(
                Object.entries(lang).map((mass) => {
                  if (mass[1] == data.langType) {
                    return mass[0];
                  }
                })
              );
            })
            .catch(() => {
              setSolutions([]);
            })
            .finally(() => {
              GetRanking(user)
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
      //setLoading(false);
    }
    if (refresh) {
      GetSolutions(user)
        .then((data) => {
          setSolutions(data);
          setLanguage(
            Object.entries(lang).map((mass) => {
              if (mass[1] == data.langType) {
                return mass[0];
              }
            })
          );
        })
        .catch(() => {
          setSolutions([
            { id: 1, status: "z" },
            { id: 2, status: "z" },
          ]);
        })
        .finally(() => {
          GetRanking(user)
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
              setRefresh(false);
            });
        });
      //setRefresh(false);
    }
  });

  const onPostCode = () => {
    setRun(true);
    PostSolve({ code, langType: lang[language] }, user)
      .then()
      .catch(() => {})
      .finally(() => {
        setKey("history");
        setRefresh(true);
        setRun(false);
      });
  };

  if (loading) {
    return <Spinner animation={"grow"} />;
  }
  return (
    <Card className="pb-3 bg-dark text-white">
      <Tabs
        activeKey={key}
        id="problems-tab"
        onSelect={(k) => setKey(k)}
        className="mb-3"
        fill
      >
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
              value={solutions.at(-1).code ? solutions.at(-1).code : ""}
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
                    {run ? (
                      <>
                        Run <Spinner size="sm" animation={"grow"} />
                      </>
                    ) : (
                      "Run >"
                    )}
                  </Button>
                </ButtonGroup>
              </Nav.Item>
            </Nav>
          </Container>
        </Tab>
        <Tab eventKey="history" title="History">
          {solutions
            .slice()
            .reverse()
            .map((ctn) => (
              <Alert
                className="mx-2"
                key={ctn.id}
                variant={ctn.status == "Accept" ? "success" : "danger"}
              >
                {Object.keys(ctn)
                  .splice(2, 6)
                  .map((key) => (
                    <p key={ctn.id}>
                      {key}: {ctn[key]}
                    </p>
                  ))}
              </Alert>
            ))}
        </Tab>
        <Tab eventKey="ranking" title="Ranking">
          {ranked
            .reduce((unique, item) => {
              if (!unique.some((obj) => obj.userID == item.userID)) {
                unique.push(item);
              }
              return unique;
            }, [])
            .map((ctn, index) => (
              <Alert className="mx-2" key={index} variant="light">
                <p className="mx-1">
                  {index + 1}. {user.user.firstName + " " + user.user.lastName}
                </p>
                <p className="mx-1">language: {ctn.langType}</p>
                <p className="mx-1">runtime: {ctn.runtime}</p>
              </Alert>
            ))}
        </Tab>
      </Tabs>
    </Card>
  );
}

export default ProblemTabs;
