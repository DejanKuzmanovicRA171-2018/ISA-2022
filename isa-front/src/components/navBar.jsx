import React, { Component } from "react";
import { Link, NavLink } from "react-router-dom";

const NavBar = ({ user }) => {
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
          <NavLink className="nav-link" to="/centers">
            Centers
          </NavLink>
          {user && (
            <>
              <NavLink className="nav-link" to="/scheduleAppointment">
                Schedule an Appointment
              </NavLink>
              <NavLink className="nav-link" to="/futureAppointments">
                Scheduled Appointments
              </NavLink>
              <NavLink className="nav-link" to="/pastAppointments">
                Past Appointments
              </NavLink>
              <NavLink className="nav-link" to="/donationForm">
                Donate
              </NavLink>
            </>
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
          {user && (
            <>
              <NavLink className="nav-link" to="/profile">
                My profile
              </NavLink>
              <NavLink className="nav-link" to="/logout">
                Logout
              </NavLink>
            </>
          )}
        </div>
      </div>
    </nav>
  );
};

export default NavBar;
