import React, { Component } from "react";
import axios from "axios";
import { useEffect, useState } from "react";

function Test() {
  const [centers, setCenters] = useState([]);
  useEffect(() => {
    axios
      .get("https://localhost:44303/api/centers")
      .then((res) => {
        console.log(res);
        setCenters(res.data);
      })
      .catch((err) => console.log(err));
  }, []);

  return (
    <div>
      <h1>Cao mama</h1>
      <ul>
        {centers.map((center) => (
          <li key={center.id}>{center.name}</li>
        ))}
      </ul>
    </div>
  );
}

export default Test;
