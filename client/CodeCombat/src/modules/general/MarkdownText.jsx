import ReactMarkdown from "react-markdown";
import { Prism as SyntaxHighlighter } from "react-syntax-highlighter";
import remarkGfm from "remark-gfm";
import rehypeRaw from "rehype-raw";
import rehypeKatex from "rehype-katex";
import remarkMath from "remark-math";
import remarkRehype from "remark-rehype";
import rehypeCallouts from "rehype-callouts";
import rehypeFigure  from "rehype-figure"
import { nord } from "react-syntax-highlighter/dist/esm/styles/prism";
import "katex/dist/katex.min.css";
import "rehype-callouts/theme/vitepress";

const MarkdownText = ({ children }) => {
  return (
    <ReactMarkdown
      className="m-2"
      remarkPlugins={[remarkRehype, remarkGfm, remarkMath]}
      rehypePlugins={[rehypeRaw, rehypeKatex, rehypeCallouts, rehypeFigure]}
      components={{
        code({ className, children, ...rest }) {
          const match = /language-(\w+)/.exec(className || "");
          return match ? (
            <SyntaxHighlighter
              PreTag="div"
              language={match[1]}
              style={nord}
              {...rest}
            >
              {children}
            </SyntaxHighlighter>
          ) : (
            <code {...rest} className={className}>
              {children}
            </code>
          );
        },
      }}
    >
      {children}
    </ReactMarkdown>
  );
};

export default MarkdownText;
