import axios from "axios";
import { REACT_APP_API_URL } from "../consts/consts";
import { useLaunchParams } from "@telegram-apps/sdk-react";

const $host = axios.create({
  baseURL: REACT_APP_API_URL,
});

export { $host };
