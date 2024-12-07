import { useEffect, useState } from "react";
import { Card, Spinner } from "react-bootstrap";
import ReactMarkdown from "react-markdown";
import "../../css/Flashcard.css";
import remarkGfm from "remark-gfm";
import { useSelector } from "react-redux";
import { useQuery } from "@tanstack/react-query";
import { CourseAPI } from "../../../http/CourseAPI";
import MarkdownText from "../../general/MarkdownText";

const Flashcard = ({ flashcard, isVisible }) => {
  const [flip, setFlip] = useState(false);
  useEffect(() => {
    if (!isVisible.isActive) {
      setFlip(false);
    }
  }, [isVisible]);

  return (
    <button
      onClick={() => {
        setFlip(!flip);
      }}
      data-bs-theme="dark"
      className={`mx-2 my-4 h-75 card
     flashcard ${flip ? "flip" : ""}`}
    >
      <Card.Body className="p-1 front">
        <MarkdownText>{flashcard.quetion}</MarkdownText>
      </Card.Body>
      <Card.Body className="p-1 back">
        <ReactMarkdown>{flashcard.answer}</ReactMarkdown>
      </Card.Body>
    </button>
  );
};

export default Flashcard;
