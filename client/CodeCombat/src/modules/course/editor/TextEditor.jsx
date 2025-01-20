import { useQuery } from "@tanstack/react-query";
import { Card, Container, Spinner } from "react-bootstrap";
import { useSelector } from "react-redux";
import { useEffect, useState } from "react";
import {
  headingsPlugin,
  listsPlugin,
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
  ShowSandpackInfo,
  ChangeCodeMirrorLanguage,
  BoldItalicUnderlineToggles,
  toolbarPlugin,
} from "@mdxeditor/editor";
import "@mdxeditor/editor/style.css";
const TextEditor = () => {
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
      <h2 className="mt-3">{data.nameModle}</h2>
      <Card
        data-bs-theme="dark"
        className="p-3 m-2 "
        style={{ minHeight: "65vh" }}
      >
        <MDXEditor
          markdown={value}
          plugins={[
            headingsPlugin(),
            listsPlugin(),
            quotePlugin(),
            thematicBreakPlugin(),
            markdownShortcutPlugin(),
            codeBlockPlugin({ defaultCodeBlockLanguage: "js" }),
            sandpackPlugin({ sandpackConfig: simpleSandpackConfig }),
            codeMirrorPlugin({
              codeBlockLanguages: { js: "JavaScript", css: "CSS" },
            }),
            toolbarPlugin({
              toolbarContents: () => (
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
                          <InsertSandpack />
                        </>
                      ),
                    },
                  ]}
                />
              ),
            }),
          ]}
        />
      </Card>
    </Container>
  );
};

export default TextEditor;
