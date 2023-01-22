import React, { Component } from "react";
import auth from "../services/authService";
import http from "../services/httpService";

class CancelAppointment extends Component {
  state = {
    user: {},
    errors: {},
  };
  async componentDidMount() {
    const currentUser = auth.getCurrentUser();
    const { data: regUser } = await http.get(
      "https://localhost:7293/api/RegUser/GetSingleRegUserByEmail?Email=" +
        currentUser.email
    );
    this.setState({ user: regUser });
  }
  doSubmit = async () => {
    const appointmentId = this.props.match.params.id;
    try {
      await http.put(
        "https://localhost:7293/api/Appointment/CancelAnAppointment?appointmentId=" +
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
        <button className="btn btn-primary" onClick={this.doSubmit}>
          Cancel appointment
        </button>
      </>
    );
  }
}

export default CancelAppointment;