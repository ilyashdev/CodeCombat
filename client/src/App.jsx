import { useContext, useEffect, useState } from "react";
//import "./App.css";
import MainBar from "./modules/NavBar";
import DailyProblem from "./pages/DailyProblem";
import { Route, Router, Routes } from "react-router-dom";
import Layout from "./modules/Layout";
import Profile from "./pages/Profile";
import ProfileInformation from "./modules/ProfileInformatoin";
import { Context } from "./main";
import { Spinner } from "react-bootstrap";
import { authAPI } from "./http/userAPI";
import TelegramWebAppData from "./utils/TelegramWedAppData";
import { useLaunchParams } from "@telegram-apps/sdk-react";

function App() {
  const [loading, setLoading] = useState(true);
  const [show, setShow] = useState(false);
  const user = useLaunchParams().initData;

  useEffect(() => {
    try {
      if (loading)
        //console.log(TelegramWebApp)id username ttoken name;
        authAPI(user)
          .then((data) => {
            setShow(data);
          })
          .catch((error) => {
            console.error(error);
          })
          .finally(() => setLoading(false));
    } catch {}
  }, []);

  if (loading) {
    return <Spinner animation={"grow"} />;
  }

  return (
    <>
      <Modal show={show}>
        <Modal.Header closeButton>
          <Modal.Title>О приложении</Modal.Title>
        </Modal.Header>

        <Modal.Body>
          <p>
            CodeCombat - это платформа, где каждый день публикуются новые задачи
            по программированию, аналогичные тем, что можно встретить на
            LeetCode. Чем лучше у тебя решение исходя из оптимальности кода и
            его эффективности тем больше токенов ты получишь
          </p>
        </Modal.Body>

        <Modal.Footer>
          <Button variant="primary" onClick={setShow(false)}>
            Понятно
          </Button>
        </Modal.Footer>
      </Modal>
      <Routes>
        <Route path="/" element={<Layout />}>
          <Route index element={<DailyProblem />} />
        </Route>
        <Route path="/profile" element={<Profile />}>
          <Route index element={<ProfileInformation />} />
        </Route>
      </Routes>
    </>
  );
}

export default App;
