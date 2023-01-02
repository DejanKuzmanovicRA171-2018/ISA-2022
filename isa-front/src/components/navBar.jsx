import React, { Component, useEffect, useState } from "react";
import { Link, NavLink } from "react-router-dom";
import http from "../services/httpService";
import axios from "axios";
import { addDays } from "date-fns";

const NavBar = ({ user }) => {
  const [hasCompletedSurvey, setHasCompletedSurvey] = useState(false);
  const [navigated, setNavigated] = useState(false);
  const [userRole, setUserRole] = useState("");

  useEffect(() => {
    const hasUserCompletedSurvey = async () => {
      if (user === undefined) {
        setHasCompletedSurvey(false);
        return;
      }
      setUserRole(user.role);
      const regUser = await axios.get(
        "https://localhost:7293/api/RegUser/GetSingleRegUserByEmail?Email=" +
          user.email
      );
      const survey = await axios
        .get(
          "https://localhost:7293/api/Survey/GetSingleSurvey?Id=" +
            regUser.data.id
        )
        .then((survey) => {
          const submitionDate = new Date(survey.data.dateOfSubmition);
          const expirationDate = addDays(submitionDate, 7);
          if (expirationDate.getTime() <= new Date().getTime()) {
            setHasCompletedSurvey(false);
            return;
          }
          setHasCompletedSurvey(true);
        })
        .catch(function (error) {
          if (error.response.status === 404) {
            setHasCompletedSurvey(false);
            return;
          }
        });
    };
    hasUserCompletedSurvey();
  }, [user, navigated]);
  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
      <Link className="navbar-brand" to="/">
        Home page
      </Link>
      <button
        className="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navbarNavAltMarkup"
        aria-controls="navbarNavAltMarkup"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span className="navbar-toggler-icon"></span>
      </button>
      <div className="collapse navbar-collapse" id="navbarNavAltMarkup">
        <div className="navbar-nav">
          <NavLink
            className="nav-link"
            to="/centers"
            onClick={() => setNavigated(!navigated)}
          >
            Centers
          </NavLink>
          {user && userRole === "RegUser" && (
            <>
              <NavLink
                className="nav-link"
                to="/scheduleAppointment"
                onClick={() => setNavigated(!navigated)}
              >
                Schedule an Appointment
              </NavLink>
              <NavLink
                className="nav-link"
                to="/futureAppointments"
                onClick={() => setNavigated(!navigated)}
              >
                Scheduled Appointments
              </NavLink>
              <NavLink
                className="nav-link"
                to="/pastAppointments"
                onClick={() => setNavigated(!navigated)}
              >
                Past Appointments
              </NavLink>
              {!hasCompletedSurvey && (
                <NavLink
                  className="nav-link"
                  to="/donationForm"
                  onClick={() => setNavigated(!navigated)}
                >
                  Donate
                </NavLink>
              )}
            </>
          )}
          {user && userRole === "Employee" && (
            <NavLink className="nav-link" to="/createAppointment">
              Create Appointment
            </NavLink>
          )}

          {!user && (
            <>
              <NavLink className="nav-link" to="/login">
                Login
              </NavLink>
              <NavLink className="nav-link" to="/register">
                Register
              </NavLink>
            </>
          )}
          {user && userRole === "RegUser" && (
            <NavLink className="nav-link" to="/profile">
              My profile
            </NavLink>
          )}
          {user && (
            <NavLink className="nav-link" to="/logout">
              Logout
            </NavLink>
          )}
        </div>
      </div>
    </nav>
  );
};

export default NavBar;
