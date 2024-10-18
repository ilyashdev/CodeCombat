import axios from "axios";
import { REACT_APP_API_URL } from "../consts/consts";

const $host = axios.create({
  baseURL: REACT_APP_API_URL,
  params: {
    id: "1002993",
    username: "@k0lan4ik",
    ttoken: "sometgtoken",
    name: "Undefine",
  },
});

export { $host };
