const BASE_URL = "http://localhost:3000/";
import axios from "axios";

export const $host = axios.create({
  baseURL: BASE_URL,
});
