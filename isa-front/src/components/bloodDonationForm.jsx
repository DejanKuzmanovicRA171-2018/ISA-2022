import React, { Component } from "react";
import Joi from "joi-browser";
import _ from "lodash";
import Form from "./common/form";
import "survey-react/survey.css";

class BloodDonationForm extends Form {
  state = {
    data: {
      name: "",
      lastName: "",
      birthDate: "",
      jmbg: "",
      gender: "",
      phoneNumber: "",
      residenceAddress: "",
      numberOfPreviousDonations: "",
      location: "",
      question1: "",
      question2: "",
    },
    errors: {},
  };

  schema = {
    name: Joi.string().required().label("Name"),
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
  doSubmit = () => {
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
          {this.renderInput("name", "Name")}
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
