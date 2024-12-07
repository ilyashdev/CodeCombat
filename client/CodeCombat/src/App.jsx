import { useState } from "react";
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
import Daily from "./pages/Daily";
import { Provider } from "react-redux";
import { store } from "./shared/redux/store";
import Home from "./pages/Home";
import ErrorPage from "./pages/Error";
import Article from "./pages/Article";

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <Provider store={store}>
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
      </Provider>
      <ReactQueryDevtools initialIsOpen={false} />
    </QueryClientProvider>
  );
}

export default App;
