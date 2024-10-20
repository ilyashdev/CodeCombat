import { $host } from ".";

export const authAPI = async (user) => {
  const data = await $host.get("user", {
    params: {
      id: user.user.id,
      username: user.user.username,
      ttoken: "1",
    },
  });
  if (data.status == 304) return localStorage.getItem("auth");
  localStorage.setItem("auth", data.data);
  return data.data;
};

export const getCoin = async (user) => {
  const data = await $host.get("data/coin", {
    params: {
      id: user.user.id,
      username: user.user.username,
      ttoken: "1",
    },
  });
  if (data.status == 304) return localStorage.getItem("coin");
  localStorage.setItem("coin", data.data);
  return data.data;
};
