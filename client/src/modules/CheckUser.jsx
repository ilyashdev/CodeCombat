import { Button, Modal, Spinner } from "react-bootstrap";
import { authAPI } from "../http/userAPI";
import { useLaunchParams } from "@telegram-apps/sdk-react";
import { useEffect, useState } from "react";
import { set } from "mobx";

const CheckUser = () => {
  let user;
  try {
    user = useLaunchParams().initData;
  } catch {
    user = {
      user: { id: 1, username: "1", firstName: "undefi", lastName: "user" },
      hash: "1",
    };
  }

  const [show, setShow] = useState(false);
  useEffect(() => {
    console.log("дай пользователя пж");
    authAPI(user).then((data) => {
      console.log(data);
      return setShow(data);
    });
  }, []);

  const handleClose = () => setShow(false);

  return (
    <Modal onHide={handleClose} show={show}>
      <Modal.Header className="bg-dark text-white">
        <Modal.Title className="bg-dark text-white">О приложении</Modal.Title>
      </Modal.Header>

      <Modal.Body className="bg-dark text-white">
        <p>
          CodeCombat - это платформа, где каждый день публикуются новые задачи
          по программированию, аналогичные тем, что можно встретить на LeetCode.
          Чем лучше у тебя решение исходя из оптимальности кода и его
          эффективности тем больше токенов ты получишь
        </p>
      </Modal.Body>

      <Modal.Footer className="bg-dark text-white">
        <Button variant="primary" onClick={handleClose}>
          Понятно
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default CheckUser;
