import { useRef, useState } from "react";
import { Button, Card, Container, Spinner } from "react-bootstrap";
import { Swiper, SwiperSlide } from "swiper/react";
import Flashcard from "./FlashCard";
import { ArrowLeftShort, ArrowRightShort } from "react-bootstrap-icons";
import "swiper/css";
import { useSelector } from "react-redux";
import { useQuery } from "@tanstack/react-query";
import { CourseAPI } from "../../../http/CourseAPI";
const CourseTextCard = () => {
  const [isBeginning, SetIsBeginning] = useState(true);
  const [isEnd, SetIsEnd] = useState(false);
  const swiperRef = useRef(null);

  const PrevSlide = () => {
    if (swiperRef.current && swiperRef.current.swiper) {
      swiperRef.current.swiper.slidePrev();
      SetIsBeginning(swiperRef.current.swiper.isBeginning);
      SetIsEnd(swiperRef.current.swiper.isEnd);
    }
  };

  const NextSlide = () => {
    if (swiperRef.current && swiperRef.current.swiper) {
      swiperRef.current.swiper.slideNext();
      SetIsBeginning(swiperRef.current.swiper.isBeginning);
      SetIsEnd(swiperRef.current.swiper.isEnd);
    }
  };

  const ModuleID = useSelector((state) => {
    return state.activeModule.id;
  });

  const { data, isPending, error } = useQuery({
    queryKey: ["course", "moduleInfo", ModuleID],
    queryFn: () => CourseAPI.getModule(1, ModuleID),
  });

  if (error) alert(error.message);
  if (isPending) return <Spinner />;

  return (
    <Container style={{ height: "85vh" }}>
      <h2 className="m-3">{data.nameModle}</h2>
      <Swiper
        slidesPerView={1}
        allowTouchMove={false}
        ref={swiperRef}
        className="h-75"
      >
        {data.data.map((card) => (
          <SwiperSlide key={card.id}>
            {(isActive) => (
              <Flashcard isVisible={isActive} flashcard={card} key={card} />
            )}
          </SwiperSlide>
        ))}
      </Swiper>
      <div className="d-flex justify-content-center">
        <Button
          disabled={isBeginning}
          onClick={PrevSlide}
          variant="outline-light"
          className="mx-5 my-1"
        >
          <ArrowLeftShort width={50} height={50} />
        </Button>
        <Button
          disabled={isEnd}
          onClick={NextSlide}
          variant="outline-light"
          className="mx-5  my-1"
        >
          <ArrowRightShort width={50} height={50} />
        </Button>
      </div>
    </Container>
  );
};

export default CourseTextCard;
