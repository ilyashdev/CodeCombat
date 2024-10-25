import { Calendar } from "@natscale/react-calendar";
import Card from "react-bootstrap/Card";
import "@natscale/react-calendar/dist/main.css";
import Container from "react-bootstrap/esm/Container";

const MyCalendar = () => {
  return (
    <Container className="my-4">
      <h2 style={{ fontWeight: "bold" }}>Календарь заданий</h2>
      <Container className="d-flex justify-content-center align-items-center">
        <Calendar
          useDarkMode
          //lockView
          isMultiSelector
          className="w-90"
          value={[
            new Date("10.10.2024"),
            new Date("10.09.2024"),
            new Date("09.09.2024"),
          ]}
        ></Calendar>
      </Container>
    </Container>
  );
};

export default MyCalendar;
