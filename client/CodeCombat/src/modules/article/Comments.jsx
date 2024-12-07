import { Card, Container, Spinner } from "react-bootstrap";
import Comment from "../general/Comment";
import { useQuery } from "@tanstack/react-query";

const Comments = () => {
  const { data, isPending } = useQuery({
    queryKey: ["course", "top"],
    queryFn: () =>
      Promise.resolve([
        {
          id: 1,
          firstName: "Имя",
          lastName: "Фамилия",
          text: "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Sedconsectetur neque tempora dignissimos rerum saepe quidem aliquam labore facilis ipsam rem tempore, maxime reiciendis asperiores fuga! Quam labore culpa perspiciatis.",
          time: "2ч назад",
          rating: 14,
          subComments: [
            {
              id: 3,
              firstName: "Имя",
              lastName: "Фамилия",
              text: "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Sedconsectetur neque tempora dignissimos rerum saepe quidem aliquam labore facilis ipsam rem tempore, maxime reiciendis asperiores fuga! Quam labore culpa perspiciatis.",
              time: "2ч назад",
              rating: 14,
              subComments: [
                {
                  id: 4,
                  firstName: "Имя",
                  lastName: "Фамилия",
                  text: "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Sedconsectetur neque tempora dignissimos rerum saepe quidem aliquam labore facilis ipsam rem tempore, maxime reiciendis asperiores fuga! Quam labore culpa perspiciatis.",
                  time: "2ч назад",
                  rating: 14,
                },
                {
                  id: 7,
                  firstName: "Имя",
                  lastName: "Фамилия",
                  text: "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Sedconsectetur neque tempora dignissimos rerum saepe quidem aliquam labore facilis ipsam rem tempore, maxime reiciendis asperiores fuga! Quam labore culpa perspiciatis.",
                  time: "2ч назад",
                  rating: 14,
                  subComments: [
                    {
                      id: 9,
                      firstName: "Имя",
                      lastName: "Фамилия",
                      text: "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Sedconsectetur neque tempora dignissimos rerum saepe quidem aliquam labore facilis ipsam rem tempore, maxime reiciendis asperiores fuga! Quam labore culpa perspiciatis.",
                      time: "2ч назад",
                      rating: 14,
                    },
                  ],
                },
              ],
            },
            {
              id: 5,
              firstName: "Имя",
              lastName: "Фамилия",
              text: "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Sedconsectetur neque tempora dignissimos rerum saepe quidem aliquam labore facilis ipsam rem tempore, maxime reiciendis asperiores fuga! Quam labore culpa perspiciatis.",
              time: "2ч назад",
              rating: 14,
            },
          ],
        },
        {
          id: 2,
          firstName: "Имя",
          lastName: "Фамилия",
          text: "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Sedconsectetur neque tempora dignissimos rerum saepe quidem aliquam labore facilis ipsam rem tempore, maxime reiciendis asperiores fuga! Quam labore culpa perspiciatis.",
          time: "2ч назад",
          rating: 14,
        },
      ]),
  });

  const WriteComments = (comments,deepence) => {
    return comments.map((comment) => (
      <Comment key={comment.id} deepence={deepence} data={comment}>
        {comment.subComments != undefined ? (
          WriteComments(comment.subComments, deepence + 1)
        ) : (
          <></>
        )}
      </Comment>
    ));
  };

  if (isPending) return <Spinner />;

  return (
    <Container className="px-2">
      <h3>Комментарии:</h3>
      <Container className="pb-3">{WriteComments(data, 1)}</Container>
    </Container>
  );
};

export default Comments;
