import React, { Component } from "react";
import http from "../services/httpService";
import Form from "./common/form";
import Joi from "joi-browser";
import auth from "../services/authService";

class RegisteredUserProfile extends Form {
  state = {
    user: {},
    unchangableData: { id: "", userId: "", email: "", jmbg: "", penalties: 0 },
    data: {
      phoneNumber: "",
      firstName: "",
      lastName: "",
      address: "",
      city: "",
      country: "",
      career: "",
      companyName: "",
    },
    errors: {},
  };
  schema = {
    phoneNumber: Joi.number().required().label("Phone Number"),
    firstName: Joi.string().required().label("First Name"),
    lastName: Joi.string().required().label("Last Name"),
    address: Joi.string().required().label("Address"),
    city: Joi.string().required().label("City"),
    country: Joi.string().required().label("Country"),
    career: Joi.string().required().label("Career"),
    companyName: Joi.string().required().label("Company Name"),
  };
  async componentDidMount() {
    const currentUser = auth.getCurrentUser();
    if (currentUser.role !== "RegUser") {
      window.location = "/homePage";
    }

    const { data: userInfo } = await http.get(
      "https://localhost:7293/api/RegUser/GetSingleRegUserByEmail?Email=" +
        currentUser.email
    );
    console.log(userInfo);

    this.setState({
      user: this.props.user,
      data: this.mapToViewModel(userInfo),
      unchangableData: this.mapUnchangableDataToViewModel(userInfo),
    });
  }
  mapUnchangableDataToViewModel(userInfo) {
    return {
      email: userInfo.user.email,
      id: userInfo.id,
      userId: userInfo.user.id,
      jmbg: userInfo.jmbg,
      penalties: userInfo.penalties,
    };
  }
  mapToViewModel(userInfo) {
    return {
      phoneNumber: userInfo.phoneNumber,
      firstName: userInfo.firstName,
      lastName: userInfo.lastName,
      address: userInfo.address,
      city: userInfo.city,
      country: userInfo.country,
      career: userInfo.career,
      companyName: userInfo.companyName,
    };
  }
  doSubmit = async () => {
    await http.put("https://localhost:7293/api/RegUser/UpdateRegUser", {
      id: this.state.unchangableData.id,
      userId: this.state.unchangableData.userId,
      //jmbg: this.state.unchangableData.jmbg,
      phone: this.state.data.phoneNumber,
      name: this.state.data.firstName,
      lastName: this.state.data.lastName,
      address: this.state.data.address,
      city: this.state.data.city,
      country: this.state.data.country,
      career: this.state.data.career,
      companyName: this.state.data.companyName,
    });
    alert("Successfully updated profile information.");
    console.log("Profile info saved.");
  };
  render() {
    return (
      <React.Fragment>
        <h1>My profile:</h1>
        <div>
          <label>
            Profile type:{" "}
            {this.state.user.role === "RegUser" ? "Regular user" : "Employee"}
          </label>
          <br />
          <label>Penalties: {this.state.unchangableData.penalties}</label>
          <br />
          <label>Email: {this.state.unchangableData.email}</label>
          <br />
          <label>JMBG: {this.state.unchangableData.jmbg}</label>
          <br />

          <form onSubmit={this.handleSubmit}>
            {this.renderInput("firstName", "First Name")}
            {this.renderInput("lastName", "Last Name")}
            {this.renderInput("phoneNumber", "Phone Number")}
            {this.renderInput("address", "Address")}
            {this.renderInput("city", "City")}
            {this.renderInput("country", "Country")}
            {this.renderInput("career", "Career")}
            {this.renderInput("companyName", "Company Name")}
            {this.renderButton("Save changes")}
          </form>
        </div>
      </React.Fragment>
    );
  }
}

export default RegisteredUserProfile;
