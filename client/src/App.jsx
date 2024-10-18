import { useState } from "react";
//import "./App.css";
import MainBar from "./modules/NavBar";
import DailyProblem from "./pages/DailyProblem";
import { Route, Router, Routes } from "react-router-dom";
import Layout from "./modules/Layout";

function App() {
  const [count, setCount] = useState(0);

  return (
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<DailyProblem />} />
      </Route>
    </Routes>
  );
}

export default App;
