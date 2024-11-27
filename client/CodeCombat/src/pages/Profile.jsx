import Container from "react-bootstrap/esm/Container";
import ProfileHead from "../modules/account/ProfileHead";
import ProfileInfo from "../modules/account/ProfileInfo";
import MyCalendar from "../modules/account/MyCalendar";
import MyCourses from "../modules/account/MyCourses";
import MyAchievements from "../modules/account/MyAchievements";

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
