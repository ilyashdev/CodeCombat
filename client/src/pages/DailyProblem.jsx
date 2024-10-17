import { useState } from "react";
import { Container } from "react-bootstrap";
import ProblemTabs from "../modules/ProblemTabs";

function DailyProblem() {
  return (
    <Container className="py-3">
      <ProblemTabs></ProblemTabs>
    </Container>
  );
}

export default DailyProblem;
