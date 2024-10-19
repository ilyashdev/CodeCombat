import { $host } from ".";

export const TakeDaily = async (user) => {
  const { data } = await $host.get("daily", {
    params: {
      id: user.user.id,
      username: user.user.username,
      ttoken: user.hash,
    },
  });
  return data;
};

export const PostSolve = async (solution, user) => {
  const { data } = await $host.post("data/solutions", solution, {
    params: {
      id: user.user.id,
      username: user.user.username,
      ttoken: "1",
    },
  });
  return data;
};

export const GetSolutions = async (user) => {
  const data = await $host.get("data/solutions", {
    params: {
      id: user.user.id,
      username: user.user.username,
      ttoken: "1",
    },
  });
  if (data.status == 204) return [{}];
  return data.data;
};

export const GetRanking = async (user) => {
  const data = await $host.get("data/top", {
    params: {
      id: user.user.id,
      username: user.user.username,
      ttoken: "1",
    },
  });
  if (data.status == 204) return [{}];
  return data.data;
};
