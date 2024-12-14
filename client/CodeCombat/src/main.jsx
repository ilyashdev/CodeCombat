import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App.jsx";
import { BrowserRouter } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import "./index.css";
import { Provider } from "react-redux";
import { store } from "./shared/redux/store";
import { backButton, init, viewport } from "@telegram-apps/sdk";

try {
  init();
} catch {}

if (backButton.show.isAvailable()) {
  backButton.show();
}

if (viewport.mount.isAvailable()) {
  viewport.mount();
}

ReactDOM.createRoot(document.getElementById("root")).render(
  <BrowserRouter>
    <Provider store={store}>
      <App />
    </Provider>
  </BrowserRouter>
);
