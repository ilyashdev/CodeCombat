import React from "react";
import { Form, FormControl, Button, InputGroup } from "react-bootstrap";
import { Search } from "react-bootstrap-icons";

const SearchBar = () => {
  return (
    <InputGroup data-bs-theme="dark" className="rounded-5">
      <InputGroup.Text className="rounded-start-5">
        <Button
          variant="link"
          className=""
          style={{ textDecoration: "none", color: "#eee" }}
        >
          <Search />
        </Button>
      </InputGroup.Text>
      <Form.Control
        type="text"
        placeholder="Search here.."
        className="rounded-end-5"
        onChange={console.log(12121)}
      />
    </InputGroup>
  );
};

export default SearchBar;
