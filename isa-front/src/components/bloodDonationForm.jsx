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
      numberOfPreviousDonations: null,
      location: "",
      question1: "",
      question2: "",
      question3: "",
      question4: "",
      question5: "",
      question6: "",
      question7: "",
      question8: "",
      question9: "",
      question10: "",
      question11: "",
      question12: "",
      question13: "",
      question14: "",
      question15: "",
      question16: "",
      question17: "",
      question18: "",
      question19: "",
      question20: "",
      question21: "",
      question22: "",
      question23: "",
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
    numberOfPreviousDonations: Joi.number()
      .required()
      .label("Number of Previous Donations"),
    location: Joi.string().required().label("Location"),

    question1: Joi.string().required(),
    question2: Joi.string().required(),
    question3: Joi.string().required(),
    question4: Joi.string().required(),
    question5: Joi.string().required(),
    question6: Joi.string().required(),
    question7: Joi.string().required(),
    question8: Joi.string().required(),
    question9: Joi.string().required(),
    question10: Joi.string().required(),
    question11: Joi.string().required(),
    question12: Joi.string().required(),
    question13: Joi.string().required(),
    question14: Joi.string().required(),
    question15: Joi.string().required(),
    question16: Joi.string().required(),
    question17: Joi.string().required(),
    question18: Joi.string().required(),
    question19: Joi.string().required(),
    question20: Joi.string().required(),
    question21: Joi.string().required(),
    question22: Joi.string().required(),
    question23: Joi.string().required(),
  };
  async componentDidMount() {
    const currentUser = auth.getCurrentUser();
    if (currentUser.role !== "RegUser") {
      window.location = "/homePage";
    }
    const user = await http.get(
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
      gender: user.gender === "male" ? "male" : "female",
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
          q3: this.state.data.question3 === "yes" ? true : false,
          q4: this.state.data.question4 === "yes" ? true : false,
          q5: this.state.data.question5 === "yes" ? true : false,
          q6: this.state.data.question6 === "yes" ? true : false,
          q7: this.state.data.question7 === "yes" ? true : false,
          q8: this.state.data.question8 === "yes" ? true : false,
          q9: this.state.data.question9 === "yes" ? true : false,
          q10: this.state.data.question10 === "yes" ? true : false,
          q11: this.state.data.question11 === "yes" ? true : false,
          q12: this.state.data.question12 === "yes" ? true : false,
          q13: this.state.data.question13 === "yes" ? true : false,
          q14: this.state.data.question14 === "yes" ? true : false,
          q15: this.state.data.question15 === "yes" ? true : false,
          q16: this.state.data.question16 === "yes" ? true : false,
          q17: this.state.data.question17 === "yes" ? true : false,
          q18: this.state.data.question18 === "yes" ? true : false,
          q19: this.state.data.question19 === "yes" ? true : false,
          q20: this.state.data.question20 === "yes" ? true : false,
          q21: this.state.data.question21 === "yes" ? true : false,
          q22: this.state.data.question22 === "yes" ? true : false,
          q23: this.state.data.question23 === "yes" ? true : false,
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
          q3: this.state.data.question3 === "yes" ? true : false,
          q4: this.state.data.question4 === "yes" ? true : false,
          q5: this.state.data.question5 === "yes" ? true : false,
          q6: this.state.data.question6 === "yes" ? true : false,
          q7: this.state.data.question7 === "yes" ? true : false,
          q8: this.state.data.question8 === "yes" ? true : false,
          q9: this.state.data.question9 === "yes" ? true : false,
          q10: this.state.data.question10 === "yes" ? true : false,
          q11: this.state.data.question11 === "yes" ? true : false,
          q12: this.state.data.question12 === "yes" ? true : false,
          q13: this.state.data.question13 === "yes" ? true : false,
          q14: this.state.data.question14 === "yes" ? true : false,
          q15: this.state.data.question15 === "yes" ? true : false,
          q16: this.state.data.question16 === "yes" ? true : false,
          q17: this.state.data.question17 === "yes" ? true : false,
          q18: this.state.data.question18 === "yes" ? true : false,
          q19: this.state.data.question19 === "yes" ? true : false,
          q20: this.state.data.question20 === "yes" ? true : false,
          q21: this.state.data.question21 === "yes" ? true : false,
          q22: this.state.data.question22 === "yes" ? true : false,
          q23: this.state.data.question23 === "yes" ? true : false,
        });
      });
    alert("Form submitted.");
    window.location = "/homePage";
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
          {this.renderInputRadioButton("gender", "Male", "male")}
          {this.renderInputRadioButton("gender", "Female", "female")}
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
