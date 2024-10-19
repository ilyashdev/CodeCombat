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
  const user = useLaunchParams().initData;

  useEffect(() => {
    try {
      //console.log(TelegramWebApp)id username ttoken name;
      authAPI(user)
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
    <Routes>
      <Route path="/" element={<Layout />}>
        <Route index element={<DailyProblem />} />
      </Route>
      <Route path="/profile" element={<Profile />}>
        <Route index element={<ProfileInformation />} />
      </Route>
    </Routes>
  );
}

export default App;
