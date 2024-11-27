import { Card, Container, Tab, Tabs } from "react-bootstrap";
import ProblemTab from "./tabs/ProblemTab";
import CodeMirror from "@uiw/react-codemirror";

const DailyTabs = () => {
  return (
    <Card className="pb-3 bg-dark text-white">
      <Tabs
        activeKey={key}
        id="problems-tab"
        onSelect={(k) => setKey(k)}
        className="mb-3"
        fill
      >
        <ProblemTab/>
        <Tab eventKey="solve" title="Solve">
          <Container>
            <CodeMirror
              className="mb-3"
              value={solutions.length != 0 ? solutions.at(-1).code : ""}
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
                  <Button
                    variant="success"
                    className=""
                    onClick={onPostCode}
                    disabled={refresh}
                  >
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
                    <p>
                      {key}: {ctn[key]}
                    </p>
                  ))}
              </Alert>
            ))}
        </Tab>
        <Tab eventKey="ranking" title="Ranking">
          {ranked.map((ctn, index) => (
            <Alert className="mx-2" key={index} variant="light">
              <p className="mx-1">
                {index + 1}. {ctn.username}
              </p>
              <p className="mx-1">language: {ctn.langType}</p>
              <p className="mx-1">runtime: {ctn.runtime}</p>
            </Alert>
          ))}
        </Tab>
      </Tabs>
    </Card>
  );
};

export default DailyTabs;
