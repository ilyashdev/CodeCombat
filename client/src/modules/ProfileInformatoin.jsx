import React, { useState, useCallback } from "react";
import { Calendar } from "@natscale/react-calendar";
import { Card, Container, Image, Navbar, Stack, Table } from "react-bootstrap";
import coinImage from "../assets/coin-logo.png";
import "@natscale/react-calendar/dist/main.css";

function ProfileInformation() {
  const [value, setValue] = useState([
    new Date("2024-10-10"),
    new Date("2024-10-11"),
    new Date("2024-10-12"),
    new Date("2024-10-13"),
  ]);

  return (
    <Container className="py-3">
      <Stack>
        <Card
          className="bg-dark p-2 mb-2 text-white"
          style={{ borderRadius: "20px" }}
        >
          <Card.Text className="d-flex justify-content-start align-items-center">
            <Image src={coinImage} className="me-2" height={30}></Image>
            <p className="m-0">12220000</p>
            <p className="text-success mb-2">(+100)</p>
          </Card.Text>
        </Card>
        <Card
          className="bg-dark p-2 mb-2 text-white"
          style={{ borderRadius: "20px" }}
        >
          <Card.Title>Календарь заданий</Card.Title>
          <Card.Text className="d-flex justify-content-center align-items-center">
            <Calendar
              useDarkMode
              lockView
              isMultiSelector
              className="w-90"
              value={value}
            ></Calendar>
          </Card.Text>
        </Card>
      </Stack>
    </Container>
  );
}

export default ProfileInformation;
