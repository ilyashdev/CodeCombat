import Container from "react-bootstrap/esm/Container";
import ProfileHead from "../modules/ProfileHead";
import ProfileInfo from "../modules/ProfileInfo";
import MyCalendar from "../modules/MyCalendar";
import MyCourses from "../modules/MyCourses";
import MyAchievements from "../modules/MyAchievements";
import Footer from "../modules/Footer";

const Profile = () => {
  return (
    <Container>
      <ProfileHead />
      <ProfileInfo />
      <MyCalendar />
      <MyCourses />
      <MyAchievements />
    </Container>
  );
};

export default Profile;
