import React, { Component } from "react";
import Joi from "joi-browser";
import _ from "lodash";
import Form from "./common/form";
import "survey-react/survey.css";
import auth from "../services/authService";
import http from "../services/httpService";
import axios from "axios";

class BloodDonationForm extends Form {
  state = {
    data: {
      firstName: "",
      lastName: "",
      birthDate: "",
      jmbg: "",
      gender: "",
      phoneNumber: "",
      residenceAddress: "",
      numberOfPreviousDonations: 0,
      location: "",
      question1: "",
      question2: "",
    },
    errors: {},
  };

  schema = {
    firstName: Joi.string().required().label("First Name"),
    lastName: Joi.string().required().label("Last Name"),
    birthDate: Joi.string().required().label("Birth Date"),
    gender: Joi.string().required().label("Gender"),
    jmbg: Joi.string().required().label("JMBG"),
    phoneNumber: Joi.string().required().label("Phone Number"),
    residenceAddress: Joi.string().required().label("Residence Address"),
    numberOfPreviousDonations: Joi.string()
      .required()
      .label("Number of Previous Donations"),
    location: Joi.string().required().label("Location"),

    question1: Joi.string().required(),
    question2: Joi.string().required(),
  };
  async componentDidMount() {
    const currentUser = auth.getCurrentUser();
    const user = await axios.get(
      "https://localhost:7293/api/RegUser/GetSingleRegUserByEmail?Email=" +
        currentUser.email
    );
    this.setState({ data: this.mapToViewModel(user.data) });
  }
  mapToViewModel(user) {
    return {
      phoneNumber: user.phoneNumber,
      firstName: user.firstName,
      lastName: user.lastName,
      residenceAddress: user.address,
      gender: user.gender,
      jmbg: user.jmbg,
      location: user.city,
      birthDate: "Rodjendan",
    };
  }
  doSubmit = async () => {
    const currentUser = auth.getCurrentUser();
    const user = await axios.get(
      "https://localhost:7293/api/RegUser/GetSingleRegUserByEmail?Email=" +
        currentUser.email
    );
    await axios
      .get(
        "https://localhost:7293/api/Survey/GetSingleSurvey?Id=" + user.data.id
      )
      .then(async (res) => {
        await http.put("https://localhost:7293/api/Survey/UpdateSurvey", {
          id: user.data.id,
          firstName: this.state.data.firstName,
          lastName: this.state.data.lastName,
          jmbg: this.state.data.jmbg,
          gender: this.state.data.gender,
          residenceAddress: this.state.data.residenceAddress,
          numberOfPreviousDonations: this.state.data.numberOfPreviousDonations,
          phoneNumber: this.state.data.phoneNumber,
          location: this.state.data.location,
          q1: this.state.data.question1 === "yes" ? true : false,
          q2: this.state.data.question2 === "yes" ? true : false,
        });
      })
      .catch(async (err) => {
        await http.post("https://localhost:7293/api/Survey/CreateSurvey", {
          id: user.data.id,
          firstName: this.state.data.firstName,
          lastName: this.state.data.lastName,
          jmbg: this.state.data.jmbg,
          gender: this.state.data.gender,
          residenceAddress: this.state.data.residenceAddress,
          numberOfPreviousDonations: this.state.data.numberOfPreviousDonations,
          phoneNumber: this.state.data.phoneNumber,
          location: this.state.data.location,
          q1: this.state.data.question1 === "yes" ? true : false,
          q2: this.state.data.question2 === "yes" ? true : false,
        });
      });

    console.log("Form submitted.");
  };
  handleChangeRadio = (e) => {
    this.setState({ [e.target.name]: e.target.value });
  };
  render() {
    return (
      <div>
        <h1>Blood donation form</h1>
        <form onSubmit={this.handleSubmit}>
          {this.renderInput("firstName", "First Name")}
          {this.renderInput("lastName", "Last Name")}
          {this.renderInput("birthDate", "Birth Date")}
          {this.renderInput("jmbg", "JMBG")}
          {this.renderInput("gender", "Gender")}
          {this.renderInput("location", "Location")}
          {this.renderInput("residenceAddress", "Residence Address")}
          {this.renderInput("phoneNumber", "Phone Number")}
          {this.renderInput(
            "numberOfPreviousDonations",
            "Number of Previous Donations"
          )}
          {this.renderSurvery()}
          <br />
          {this.renderButton("Submit")}
        </form>
      </div>
    );
  }
}

export default BloodDonationForm;
