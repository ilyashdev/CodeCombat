import { StrictMode, useEffect } from "react";
import ReactDOM from "react-dom/client";
import UserStore from "./store/UserStore";
import App from "./App.jsx";
import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { init, backButton } from "@telegram-apps/sdk-react";
import { BrowserRouter } from "react-router-dom";
import React, { createContext } from "react";

init();

//backButton.mount();

export const Context = createContext(null);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <StrictMode>
    <Context.Provider
      value={{
        user: new UserStore(),
      }}
    >
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Context.Provider>
  </StrictMode>
);
