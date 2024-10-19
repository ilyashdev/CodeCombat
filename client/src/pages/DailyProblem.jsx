import { useState } from "react";
import { Container } from "react-bootstrap";
import ProblemTabs from "../modules/ProblemTabs";
import { useLaunchParams } from "@telegram-apps/sdk-react";

function DailyProblem() {
  const lp = useLaunchParams();
  lp.initData.hash
  
  return (
    <Container className="py-3">
      <ProblemTabs></ProblemTabs>
    </Container>
  );
}

export default DailyProblem;
