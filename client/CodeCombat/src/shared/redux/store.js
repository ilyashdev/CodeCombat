import { configureStore, createSlice } from "@reduxjs/toolkit";

const activeModule = createSlice({
  name: "activeModule",
  initialState: {
    activeModule: { id: 0, type: "", name: "" },
    activeCouse: {
      id: 0,
      name: 0,
    },
    AccountData: {
      addedToAttachmentMenu: false,
      allowsWriteToPm: false,
      isPremium: false,
      firstName: "Unauthorize",
      id: 0,
      isBot: false,
      lastName: "",
      languageCode: "ru",
      photoUrl:
        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRaOQkNni05Nb3SqMBDsQ40HrAplq15_NMGIA&s",
      username: "",
    },
    source: "none",
  },
  reducers: {
    writeModule: (state, action) => {
      return { ...state, activeModule: action.payload.activeModule };
    },
    writeCourse: (state, action) => {
      return { ...state, activeCouse: action.payload.activeCouse };
    },
    writeAccount: (state, action) => {
      return { ...state, AccountData: action.payload.AccountData };
    },
    setSource: (state, action) => {
      return { ...state, source: action.payload.source };
    },
  },
});
export const store = configureStore({
  reducer: activeModule.reducer,
});

export const { writeModule, writeCourse, writeAccount, setSource} = activeModule.actions;
