import { $host } from ".";

export const authAPI = async (user) => {
  const { data } = await $host.get("user", {
    params: {
      id: user.user.id,
      username: user.user.username,
      ttoken: user.hash,
    },
  });
  return data;
};

export const getCoin = async (user) => {
  const { data } = await $host.get("data/coin", {
    params: {
      id: user.user.id,
      username: user.user.username,
      ttoken: user.hash,
    },
  });
  return data;
};
