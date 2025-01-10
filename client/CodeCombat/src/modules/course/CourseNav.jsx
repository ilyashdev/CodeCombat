import Container from "react-bootstrap/esm/Container";
import SearchBar from "../search/SearchBar";
import ViewCourses from "../search/ViewCourses";
import Pagintion from "../search/Pagintion";
import { useQuery } from "@tanstack/react-query";
import {
  Button,
  CardSubtitle,
  Navbar,
  Offcanvas,
  Spinner,
} from "react-bootstrap";
import {
  Book,
  CardImage,
  CardText,
  CarFront,
  Check2All,
  CodeSlash,
  MenuApp,
  MenuButton,
  PencilSquare,
} from "react-bootstrap-icons";
import { useContext, useState } from "react";
import { CourseAPI } from "../../http/CourseAPI";
import { useDispatch, useSelector } from "react-redux";
import { setEditCourse, writeModule } from "../../shared/redux/store";
import { redirect, useNavigate } from "react-router-dom";

const CourseNav = () => {
  const [offcanvas, SetOffcanvas] = useState(false);
  const navigate = useNavigate();

  const dispath = useDispatch();
  const activeModuleId = useSelector((state) => state.activeModule.id);
  const activeCourse = useSelector((state) => state.activeCouse);

  const { data, isPending, error } = useQuery({
    queryKey: ["course", activeCourse.id, "modules"],
    queryFn: () =>
      CourseAPI.getStructCourse(activeCourse.id, activeCourse.name),
  });

  const OnChoseModule = (module) => {
    dispath(writeModule({ activeModule: module }));
    navigate(
      "/course/" +
        activeCourse.name +
        "&" +
        activeCourse.id +
        "/" +
        module.name +
        "&" +
        module.id
    );
    SetOffcanvas(false);
  };

  const OnEdit = () => {
    dispath(setEditCourse());
  };

  if (isPending) {
    //return <Spinner />;
  }

  return (
    <Navbar
      className="sticky-top"
      style={{ backgroundColor: "rgba(46, 41, 58, 0.9)" }}
    >
      <Container className="d-flex justify-content-between">
        <div className="d-flex justify-content-start">
          {" "}
          <Button
            variant="link"
            className=""
            style={{
              textDecoration: "none",
              color: "#eee",
            }}
            onClick={() => {
              SetOffcanvas(true);
            }}
          >
            <MenuApp height={25} width={25} />
          </Button>
          <h3 className="m-0 mx-3 align-self-center">{data.Name}</h3>
        </div>

        <Button
          variant="outline-light"
          className=" d-flex justify-content-start align-item-center"
          onClick={() => {
            OnEdit();
          }}
        >
          <p className="m-0 me-1 align-self-center">Редактировать</p>
          <PencilSquare className=" align-self-center" height={20} width={20} />
        </Button>
      </Container>
      <Offcanvas
        data-bs-theme="dark"
        show={offcanvas}
        onHide={() => {
          SetOffcanvas(false);
        }}
      >
        <Offcanvas.Header closeButton>
          <h2>{data.Name}</h2>
        </Offcanvas.Header>
        <Offcanvas.Body>
          {data.data.map((module) =>
            module.type == "text" ? (
              <Button
                key={module.id}
                variant="outline-secondary"
                style={{ textDecoration: "none", color: "#eee" }}
                disabled={module.id == activeModuleId}
                className={"d-flex p-2 my-2 container"}
                onClick={() => OnChoseModule(module)}
              >
                <Book key={module.id} width={20} height={20} />
                <h5 className="m-0 mx-2">{module.name}</h5>
              </Button>
            ) : module.type == "code" ? (
              <Button
                key={module.id}
                variant="outline-secondary"
                style={{ textDecoration: "none", color: "#eee" }}
                disabled={module.id == activeModuleId}
                className={"d-flex p-2 my-2 container"}
                onClick={() => OnChoseModule(module)}
              >
                <CodeSlash key={module.id} width={20} height={20} />

                <h5 className="m-0 mx-2">{module.name}</h5>
              </Button>
            ) : module.type == "flashcard" ? (
              <Button
                key={module.id}
                variant="outline-secondary"
                style={{ textDecoration: "none", color: "#eee" }}
                disabled={module.id == activeModuleId}
                className={"d-flex p-2 my-2 container"}
                onClick={() => OnChoseModule(module)}
              >
                <CardText key={module.id} width={20} height={20} />
                <h5 className="m-0 mx-2">{module.name}</h5>
              </Button>
            ) : module.type == "code" ? (
              <Button
                key={module.id}
                variant="outline-secondary"
                style={{ textDecoration: "none", color: "#eee" }}
                disabled={module.id == activeModuleId}
                className={"d-flex p-2 my-2 container"}
                onClick={() => OnChoseModule(module)}
              >
                <CardSubtitle key={module.id} width={20} height={20} />
                <h5 className="m-0 mx-2">{module.name}</h5>
              </Button>
            ) : (
              <Button
                key={module.id}
                variant="outline-secondary"
                style={{ textDecoration: "none", color: "#eee" }}
                disabled={module.id == activeModuleId}
                className={"d-flex p-2 my-2 container"}
                onClick={() => OnChoseModule(module)}
              >
                <Check2All key={module.id} width={20} height={20} />
                <h5 className="m-0 mx-2">{module.name}</h5>
              </Button>
            )
          )}
        </Offcanvas.Body>
      </Offcanvas>
    </Navbar>
  );
};

export default CourseNav;
