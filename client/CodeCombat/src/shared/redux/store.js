import { configureStore, createSlice } from "@reduxjs/toolkit";

const activeModule = createSlice({
  name: "activeModule",
  initialState: {
    activeModule: { id: 0, type: "", name: "" },
    activeCouse: {
      id: 0,
      name: 0,
    },
  },
  reducers: {
    writeModule: (state, action) => {
      return { ...state, activeModule: action.payload.activeModule };
    },
    writeCourse: (state, action) => {
      return { ...state, activeCouse: action.payload.activeCouse };
    },
  },
});
export const store = configureStore({
  reducer: activeModule.reducer,
});

export const { writeModule, writeCourse } = activeModule.actions;
