import { useEffect, useState } from "react";
import { Route, Routes } from "react-router-dom";
import "./App.css";
import MainLayout from "./components/MainLayout";
import Profile from "./pages/Profile";
import FooterLayout from "./components/FooterLayout";
import Courses from "./pages/Courses";
import Course from "./pages/Course";
import { QueryClientProvider } from "@tanstack/react-query";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import { queryClient } from "./shared/query-client";
import { Provider, useDispatch } from "react-redux";
import Home from "./pages/Home";
import ErrorPage from "./pages/Error";
import Article from "./pages/Article";
import {
  init,
  backButton,
  viewport,
  initData,
  requestFullscreen,
  initDataRaw,
} from "@telegram-apps/sdk";
import { writeAccount } from "./shared/redux/store";

function App() {
  const dispatch = useDispatch();
  const [devise, setDevise] = useState("None");

  useEffect(() => {
    try {
      initData.restore();
      dispatch(writeAccount({ AccountData: initData.user() }));
      console.log(initData.raw());
      console.log(initData.startParam());
      console.log(initData.hash());
    } catch {}
    const userAgent = navigator.userAgent;
    if (/Windows|Macintosh/i.test(userAgent)) {
      console.log(userAgent);
      setDevise("Desktop");
    }
  }, []);
  useEffect(() => {
    if (devise == "Desktop") {
      async function fullscreen() {
        if (viewport.requestFullscreen.isAvailable()) {
          await viewport.requestFullscreen();
        } else {
          console.log(viewport.requestFullscreen.isAvailable());
        }
      }
      fullscreen();
    }
  }, [devise, viewport.requestFullscreen.isAvailable()]);

  return (
    <QueryClientProvider client={queryClient}>
      <Routes>
        <Route path="/" element={<MainLayout />}>
          <Route index element={<Home />} />
        </Route>
        <Route path="/profile" element={<Profile />} />
        <Route path="/courses/:page" element={<MainLayout />}>
          <Route index element={<Courses />} />
        </Route>
        <Route path="/course/:courseInfo/:moduleInfo" element={<MainLayout />}>
          <Route index element={<Course />} />
        </Route>
        <Route path="/article/:articleInfo" element={<MainLayout />}>
          <Route index element={<Article />} />
        </Route>
        {/*<Route path="/daily" element={<MainLayout />}>
            <Route index element={<Daily />} />
          </Route>*/}
        <Route path="*" element={<ErrorPage />} />
      </Routes>
      <ReactQueryDevtools initialIsOpen={false} />
    </QueryClientProvider>
  );
}

export default App;
