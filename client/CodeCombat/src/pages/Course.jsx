import { createContext, useEffect, useState } from "react";
import CourseNav from "../modules/course/CourseNav";
import CourseTextComponent from "../modules/course/CourseTextComponent";
import CourseTextCard from "../modules/course/card/CourseTextCard";
import CourseCode from "../modules/course/code/CourseCodeComponent";
import { moudleType } from "../shared/consts/consts";
import { useDispatch, useSelector } from "react-redux";
import { Spinner } from "react-bootstrap";
import { useQuery } from "@tanstack/react-query";
import { CourseAPI } from "../http/CourseAPI";
import { writeCourse, writeModule } from "../shared/redux/store";
import { useParams } from "react-router-dom";
import CourseTestComponent from "../modules/course/test/CourseTestComponent";
import TextEditor from "../modules/course/editor/TextEditor";
import CodeEditor from "../modules/course/code/CodeEditor";

const Course = () => {
  const dispath = useDispatch();
  const actionModule = useSelector((state) => {
    return state.activeModule;
  });
  const actionCourse = useSelector((state) => {
    return state.activeCouse;
  });

  const { courseInfo, moduleInfo } = useParams();

  useEffect(() => {
    const course = courseInfo.split("&");
    const module = moduleInfo.split("&");
    dispath(writeCourse({ activeCouse: { id: course[1], name: course[0] } }));
    dispath(writeModule({ activeModule: { id: module[1], name: module[0] } }));
  }, [courseInfo]);

  const { data, isPending, isSuccess, error } = useQuery({
    queryKey: ["course", actionCourse.id, "modules"],
    queryFn: () =>
      CourseAPI.getStructCourse(actionCourse.id, actionCourse.name),
  });

  useEffect(() => {
    if (isSuccess) {
      const module = moduleInfo.split("&");
      dispath(
        writeModule({
          activeModule:
            data.data.find((item) => item.id == module[1]) ?? data.data[0],
        })
      );
    }
  }, [moduleInfo]);

  useEffect(() => {
    if (isSuccess)
      dispath(
        writeModule({
          activeModule: data.data.find(
            (item) => item.id == actionModule.id ?? data.data[0]
          ),
        })
      );
  }, [isSuccess]);

  if (error) console.log(error);

  if (isPending) {
    return <Spinner />;
  }

  return (
    <div>
      <CourseNav />
      {actionModule.type == "text" ? (
        actionCourse.isEdit ? (
          <TextEditor />
        ) : (
          <CourseTextComponent />
        )
      ) : actionModule.type == "code" ? (
        actionCourse.isEdit ? (
          <CodeEditor />
        ) : (
          <CourseCode />
        )
      ) : actionModule.type == "flashcard" ? (
        <CourseTextCard />
      ) : actionModule.type == "test" ? (
        <CourseTestComponent />
      ) : (
        <Spinner />
      )}
    </div>
  );
};

export default Course;
