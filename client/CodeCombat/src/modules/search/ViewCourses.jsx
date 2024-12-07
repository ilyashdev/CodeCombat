import { Container, Spinner } from "react-bootstrap";
import MiniCourse from "../home/MiniCard";
import { useParams } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import CourseCode from "../course/code/CourseCodeComponent";
import { CourseAPI } from "../../http/CourseAPI";
import { useEffect } from "react";
import MiniCard from "../home/MiniCard";

const ViewCourses = ({ className }) => {
  const { page } = useParams();

  const { data, isPending } = useQuery({
    queryKey: ["search", "courses"],
    queryFn: () => CourseAPI.getCurrentCountCourse(page, 10),
  });

  if (isPending) return <Spinner />;

  return (
    <Container className={className}>
      {data.map((course) => (
        <MiniCard
          courseId={course.id}
          key={course.id}
          courseName={course.name}
          my="3"
        />
      ))}
    </Container>
  );
};

export default ViewCourses;
