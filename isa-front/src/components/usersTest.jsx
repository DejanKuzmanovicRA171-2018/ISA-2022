import React from "react";
import axios from "axios";
import { useEffect, useState } from "react";

function UsersTest() {
  const [users, setUsers] = useState([]);
  useEffect(() => {
    axios
      .get("https://localhost:7293/api/User/GetAllUsers")
      .then((res) => {
        console.log(res);
        setUsers(res.data);
      })
      .catch((err) => console.log(err));
  }, []);

  return (
    <div>
      <ul>
        {users.map((user) => (
          <li key={user.id}>{user.email}</li>
        ))}
      </ul>
    </div>
  );
}

export default UsersTest;
