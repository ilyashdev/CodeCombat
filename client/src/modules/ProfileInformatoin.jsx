import React, { useState, useCallback, useEffect, useContext } from "react";
import { Calendar } from "@natscale/react-calendar";
import { Card, Container, Image, Navbar, Stack, Table } from "react-bootstrap";
import coinImage from "../assets/coin-logo.png";
import "@natscale/react-calendar/dist/main.css";
import { getCoin } from "../http/userAPI";
import { GetSolutions } from "../http/dailyAPI";
import { useLaunchParams } from "@telegram-apps/sdk-react";

function ProfileInformation() {
  const [coin, setCoin] = useState();
  const [solutions, setSolutions] = useState();
  const [loading, setLoading] = useState(true);
  let user;
  try {
    user = useLaunchParams().initData;
  } catch {
    user = {
      user: { id: 1, username: "1", firstName: "undefi", lastName: "user" },
      hash: "1",
    };
  }
  useEffect(() => {
    getCoin(user)
      .then((data) => {
        setCoin(data);
      })
      .catch(() => {
        setCoin(1203444);
      })
      .finally(() => {
        GetSolutions(user)
          .then((data) => {
            let acept = [];
            data.map((sol) => {
              if (sol.status == "Accept") acept.push(new Date(sol.daytime));
            });
            setSolutions(acept);
          })
          .catch(() => {
            let acept = [];
            [
              {
                id: 1,
                daytime: "2024-10-18T17:17:41.061693Z",
                code: "print(input())",
                runtime: 0.5857564000000001,
                status: "Accept",
              },
              {
                id: 1,
                daytime: "2024-10-17T17:17:41.061693Z",
                code: "print(input())",
                runtime: 0.5857564000000001,
                status: "Accept",
              },
              {
                id: 1,
                daytime: "2024-10-18T17:17:41.061693Z",
                code: "print(input())",
                runtime: 0.5857564000000001,
                status: "Wrong",
              },
            ].map((sol) => {
              if (sol.status == "Accept") acept.push(new Date(sol.daytime));
            });
            setSolutions(acept);
          })
          .finally(() => {
            setLoading(false);
          });
      });
    console.log("запрос на получение пользовательской информации");
  }, []);

  return (
    <Container className="py-3">
      <Stack>
        <Card
          className="bg-dark p-2 mb-2 text-white"
          style={{ borderRadius: "20px" }}
        >
          <Card.Text className="d-flex justify-content-start align-items-center">
            <Image src={coinImage} className="me-2" height={30}></Image>
            <p className="m-0">{coin}</p>
            <p className="text-success mb-2">(+0)</p>
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
              value={solutions}
            ></Calendar>
          </Card.Text>
        </Card>
      </Stack>
    </Container>
  );
}

export default ProfileInformation;
