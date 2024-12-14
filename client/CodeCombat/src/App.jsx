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
import { init, backButton, viewport, initData } from "@telegram-apps/sdk";
import { writeAccount } from "./shared/redux/store";

function App() {
  const dispatch = useDispatch();
  try {
    init();
  } catch {}
  useEffect(() => {
    try {
      initData.restore();
      dispatch(writeAccount({ AccountData: initData.user() }));
    } catch {}
    if (backButton.show.isAvailable()) {
      backButton.show();
    }

    if (viewport.mount.isAvailable()) {
      viewport.mount();
      if (viewport.requestFullscreen.isAvailable()) {
        viewport.requestFullscreen();
      }
    }
  }, []);

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
          <Route
            path="/course/:courseInfo/:moduleInfo"
            element={<MainLayout />}
          >
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
