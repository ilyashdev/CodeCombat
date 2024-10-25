import { useState } from "react";
import { Route, Routes } from "react-router-dom";
import "./App.css";
import Home from "./pages/home";
import MainLayout from "./components/MainLayout";
import Profile from "./pages/Profile";
import FooterLayout from "./components/FooterLayout";

function App() {
  return (
    <Routes>
      <Route path="/" element={<MainLayout />}>
        <Route index element={<Home />} />
      </Route>
      <Route path="/profile" element={<Profile />} />
    </Routes>
  );
}

export default App;
