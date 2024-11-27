import { $host } from ".";

export const CourseAPI = {
  getStructCourse: async (CourseId, nameId) => {
    const data = await (await $host.get("CourseStruct")).data[--CourseId];
    if (nameId == data.Name) return data;
    return window.location.replace("/NotFound");
  },
  getModule: async (CourseId, ModuleId) => {
    return await (
      await $host.get("CourseModule")
    ).data[--ModuleId];
  },
  getTopCourse: async () => {
    return await (await $host.get("TopCourses")).data.slice(0, 2);
  },
  getCurrentCountCourse: async (page, count) => {
    console.log(page);
    return await (
      await $host.get("TopCourses")
    ).data.slice((page - 1) * count, count * page);
  },
};
