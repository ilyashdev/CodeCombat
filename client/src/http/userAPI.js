import { $host } from ".";

export const authAPI = async () => {
    const { data } = await $host.get("user");
    return data; 
}

export const getCoin = async () => {
    const { data } = await $host.get("data/coin");
    return data;
}