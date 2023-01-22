import React, { Component } from "react";
import auth from "../services/authService";
import http from "../services/httpService";
import { addDays } from "date-fns";
import { NavLink } from "react-router-dom";

class ScheduleAppointmentAtCenter extends Component {
  state = {
    user: {},
    hasSurvey: true,
    hasAppointment: true,
    errors: {},
  };
  async componentDidMount() {
    const currentUser = auth.getCurrentUser();
    const { data: regUser } = await http.get(
      "https://localhost:7293/api/RegUser/GetSingleRegUserByEmail?Email=" +
        currentUser.email
    );
    const appointment = await http
      .get(
        "https://localhost:7293/api/Appointment/GetAllUpcomingAppointmentsUser?email=" +
          currentUser.email
      )
      .then((appointment) => {
        if (appointment.data.length === 0) {
          this.setState({ hasAppointment: false });
        } else {
          this.setState({ hasAppointment: true });
        }
      });

    const survey = await http
      .get("https://localhost:7293/api/Survey/GetSingleSurvey?Id=" + regUser.id)
      .then((survey) => {
        const submitionDate = new Date(survey.data.dateOfSubmition);
        const expirationDate = addDays(submitionDate, 7);
        if (expirationDate.getTime() <= new Date().getTime()) {
          this.setState({ hasSurvey: false });
        } else {
          this.setState({ hasSurvey: true });
        }
      })
      .catch((error) => {
        this.setState({ hasSurvey: false });
      });

    this.setState({ user: regUser });
  }
  doSubmit = async () => {
    const appointmentId = this.props.match.params.id;

    try {
      await http.put(
        "https://localhost:7293/api/Appointment/ScheduleAnAppointment?appointmentId=" +
          appointmentId,
        this.state.user
      );
    } catch (ex) {
      if (ex.response && ex.response.status === 400) {
        const errors = { ...this.state.errors };
        errors = ex.response.data;
        alert("error:");
        //errors.password = ex.response.data.errors.Password[0];
        //console.log(ex);
        this.setState({ errors });
      }
    }
  };
  render() {
    return (
      <>
        <div className="appointmentConfirmation">
          <button
            className="appointmentConfirmationButton"
            onClick={this.doSubmit}
            disabled={
              !this.state.hasSurvey || this.state.hasAppointment ? true : false
            }
          >
            Confirm appointment
          </button>
          {!this.state.hasSurvey ? (
            <NavLink className="nav-link" to="/donationForm">
              Please complete donation survey.
            </NavLink>
          ) : null}
          {this.state.hasAppointment ? (
            <label>You can only schedule one appointment.</label>
          ) : null}
        </div>
      </>
    );
  }
}

export default ScheduleAppointmentAtCenter;
