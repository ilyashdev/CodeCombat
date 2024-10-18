import { $host } from ".";

export const TakeDaily = async () => {
  const { data } = await $host.get("daily");
  return data;
};

export const PostSolve = async (solution) => {
  const { data } = await $host.post("data/solutions", solution);
  return data;
};

export const GetSolutions = async () => {
  const { data } = await $host.get("data/solutions");
  return data;
};

export const GetRanking = async () => {
  const { data } = await $host.get("data/top");
  return data;
};
