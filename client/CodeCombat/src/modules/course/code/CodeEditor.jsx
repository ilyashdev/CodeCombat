import { useQuery } from "@tanstack/react-query";
import { Card, Container, Form, Spinner } from "react-bootstrap";
import { useSelector } from "react-redux";
import { useEffect, useState } from "react";
import {
  headingsPlugin,
  listsPlugin,
  linkPlugin,
  tablePlugin,
  InsertTable,
  DiffSourceToggleWrapper,
  imagePlugin,
  directivesPlugin,
  diffSourcePlugin,
  quotePlugin,
  thematicBreakPlugin,
  markdownShortcutPlugin,
  codeBlockPlugin,
  sandpackPlugin,
  MDXEditor,
  InsertCodeBlock,
  codeMirrorPlugin,
  UndoRedo,
  BlockTypeSelect,
  ChangeAdmonitionType,
  ConditionalContents,
  InsertSandpack,
  InsertImage,
  ListsToggle,
  InsertThematicBreak,
  InsertAdmonition,
  ShowSandpackInfo,
  ChangeCodeMirrorLanguage,
  AdmonitionDirectiveDescriptor,
  BoldItalicUnderlineToggles,
  toolbarPlugin,
} from "@mdxeditor/editor";
import "@mdxeditor/editor/style.css";
import "../../css/Editor.css";
import CodeHolder from "./CodeHolder";
const CodeEditor = () => {
  const ModuleID = useSelector((state) => {
    return state.activeModule.id;
  });

  const { data, isPending, error } = useQuery({
    queryKey: ["course", "moduleInfo", ModuleID],
    queryFn: () => CourseAPI.getModule(1, ModuleID),
  });

  const [value, setValue] = useState(data.data[0].text);
  useEffect(() => {
    setValue(data.data[0].text);
  }, [isPending]);

  const defaultSnippetContent = `
export default function App() {
  return (
    <div className="App">
      <h1>Hello CodeSandbox</h1>
      <h2>Start editing to see some magic happen!</h2>
    </div>
  );
}
`.trim();

  const simpleSandpackConfig = {
    defaultPreset: "react",
    presets: [
      {
        label: "React",
        name: "react",
        meta: "live react",
        sandpackTemplate: "react",
        sandpackTheme: "light",
        snippetFileName: "/App.js",
        snippetLanguage: "jsx",
        initialSnippetContent: defaultSnippetContent,
      },
    ],
  };

  if (isPending) return <Spinner />;
  return (
    <Container>
      <Form.Control
        type="text"
        data-bs-theme="dark"
        plaintext
        className="mt-2 p-0 h2"
        placeholder={"Название модуля"}
        defaultValue={data.nameModle}
      />
      <Card
        data-bs-theme="dark"
        className="p-3 m-2 dark-theme dark"
        style={{ minHeight: "65vh" }}
      >
        <MDXEditor
          markdown={value}
          plugins={[
            headingsPlugin(),
            listsPlugin(),
            quotePlugin(),
            markdownShortcutPlugin(),
            directivesPlugin({
              directiveDescriptors: [AdmonitionDirectiveDescriptor],
            }),
            tablePlugin(),
            linkPlugin(),
            imagePlugin({
              imageUploadHandler: () => {
                return Promise.resolve("https://picsum.photos/200/300");
              },
              imageAutocompleteSuggestions: [
                "https://picsum.photos/200/300",
                "https://picsum.photos/200",
              ],
            }),
            thematicBreakPlugin(),
            markdownShortcutPlugin(),
            diffSourcePlugin({
              diffMarkdown: data.data[0].text,
              viewMode: "rich-text",
            }),
            codeBlockPlugin({ defaultCodeBlockLanguage: "js" }),
            sandpackPlugin({ sandpackConfig: simpleSandpackConfig }),
            codeMirrorPlugin({
              codeBlockLanguages: { js: "JavaScript", css: "CSS", cpp: "C++" },
              autoLoadLanguageSupport: true,
            }),
            toolbarPlugin({
              toolbarContents: () => (
                <>
                  {" "}
                  <DiffSourceToggleWrapper>
                    <UndoRedo />
                    <BoldItalicUnderlineToggles />
                    <ListsToggle />
                    <BlockTypeSelect />
                    <InsertImage />
                    <InsertTable />
                    <InsertThematicBreak />
                    <ConditionalContents
                      options={[
                        {
                          when: (editor) => editor?.editorType === "codeblock",
                          contents: () => <ChangeCodeMirrorLanguage />,
                        },
                        {
                          when: (editor) => editor?.editorType === "sandpack",
                          contents: () => <ShowSandpackInfo />,
                        },
                        {
                          fallback: () => (
                            <>
                              <InsertCodeBlock />
                            </>
                          ),
                        },
                      ]}
                    />
                    <InsertAdmonition />
                  </DiffSourceToggleWrapper>
                </>
              ),
            }),
          ]}
        />
        <CodeHolder />
      </Card>
    </Container>
  );
};

export default CodeEditor;
