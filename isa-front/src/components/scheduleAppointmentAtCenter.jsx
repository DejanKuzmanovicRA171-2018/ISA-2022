import React, { Component } from "react";
import auth from "../services/authService";
import http from "../services/httpService";
import { addDays, addMonths } from "date-fns";
import { NavLink } from "react-router-dom";
import { SurveyWindowModel } from "survey-react-ui";

class ScheduleAppointmentAtCenter extends Component {
  state = {
    user: {},
    hasSurvey: true,
    hasAppointment: true,
    threePenalties: false,
    hasDonatedInLastSix: false,
    errors: {},
  };
  async componentDidMount() {
    const currentUser = auth.getCurrentUser();
    if (currentUser.role !== "RegUser") {
      window.location = "/homePage";
    }
    const { data: regUser } = await http.get(
      "https://localhost:7293/api/RegUser/GetSingleRegUserByEmail?Email=" +
        currentUser.email
    );
    if (regUser.penalties >= 3) {
      this.setState({ threePenalties: true });
    }
    const userLastDonation = new Date(regUser.lastBloodDonation);
    const sixMonthsBeforeNow = addMonths(new Date(), -6);

    if (userLastDonation.getTime() > sixMonthsBeforeNow.getTime()) {
      this.setState({ hasDonatedInLastSix: true });
    }

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
    const centerName = this.props.match.params.name;
    const startDate = this.props.match.params.startDate;

    console.log(startDate);

    try {
      await http.put(
        "https://localhost:7293/api/Appointment/ScheduleAnAppointment?appointmentId=" +
          appointmentId +
          "&centerName=" +
          centerName +
          "&startDate=" +
          startDate,
        this.state.user
      );
      alert("You have successfully scheduled an appointment");
      window.location = "/homePage";
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
        <div>
          <button
            className="btn btn-primary"
            onClick={this.doSubmit}
            disabled={
              !this.state.hasSurvey ||
              this.state.hasAppointment ||
              this.state.threePenalties ||
              this.state.hasDonatedInLastSix
                ? true
                : false
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
          {this.state.threePenalties ? (
            <label>You exceeded penalty limit.</label>
          ) : null}
          {this.state.hasDonatedInLastSix ? (
            <label>You have already donated in the last six months.</label>
          ) : null}
        </div>
      </>
    );
  }
}

export default ScheduleAppointmentAtCenter;
