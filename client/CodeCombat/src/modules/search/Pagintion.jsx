import { useState } from "react";
import { Pagination } from "react-bootstrap";
import { redirect, useParams } from "react-router-dom";

const Pagintion = ({ baseURL = "/courses/" }) => {
  const { page } = useParams();
  const max = 2;

  const returnItems = (max) => {
    const arr = [];
    for (let i = 1; i <= max; i++) {
      arr[i - 1] = i;
    }
    return arr;
  };

  return (
    <Pagination data-bs-theme="dark" className="d-flex justify-content-center">
      <Pagination.First href={baseURL + "1"} />
      <Pagination.Prev
        href={page == 1 ? baseURL + page : baseURL + (page - 1)}
      />
      {returnItems(max).map((index) => (
        <Pagination.Item
          key={index}
          active={index == page}
          href={baseURL + index}
        >
          {index}
        </Pagination.Item>
      ))}
      <Pagination.Next
        href={page == max ? baseURL + page : baseURL + (1 + Number(page))}
      />
      <Pagination.Last href={baseURL + max} />
    </Pagination>
  );
};
export default Pagintion;
