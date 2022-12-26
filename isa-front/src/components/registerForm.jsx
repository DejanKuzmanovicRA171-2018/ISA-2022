import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";
import * as authService from "../services/authService";
import auth from "../services/authService";
import { Redirect } from "react-router-dom";

class RegisterForm extends Form {
  state = {
    data: {
      email: "",
      password: "",
      repeatedPassword: "",
      name: "",
      lastName: "",
      gender: "",
      residenceAddress: "",
      city: "",
      country: "",
      phoneNumber: "",
      jmbg: "",
      profession: "",
      workLocation: "",
    },
    errors: {},
  };
  schema = {
    email: Joi.string()
      .required()
      .email()
      .label("Email")
      .error(() => {
        return {
          message: "Please enter a valid email address.",
        };
      }),
    password: Joi.string()
      .required()
      .min(5)
      .label("Password")
      .error(() => {
        return {
          message: "Password must be at least 5 characters.",
        };
      }),
    repeatedPassword: Joi.any()
      .valid(Joi.ref("password"))
      .required()
      .options({ language: { any: { allowOnly: "must match password" } } }),
    name: Joi.string()
      .required()
      .label("Name")
      .error(() => {
        return {
          message: "Please enter your name.",
        };
      }),
    lastName: Joi.string()
      .required()
      .label("Last Name")
      .error(() => {
        return {
          message: "Please enter your last name.",
        };
      }),
    gender: Joi.string()
      .required()
      .label("Gender")
      .error(() => {
        return {
          message: "Please specify your gender.",
        };
      }),
    residenceAddress: Joi.string()
      .required()
      .label("Residence Address")
      .error(() => {
        return {
          message: "Please enter your residence address.",
        };
      }),
    city: Joi.string()
      .required()
      .label("City")
      .error(() => {
        return {
          message: "Please enter your city.",
        };
      }),
    country: Joi.string()
      .required()
      .label("Country")
      .error(() => {
        return {
          message: "Please enter your country.",
        };
      }),
    phoneNumber: Joi.string().required().label("Phone Number"),
    jmbg: Joi.string()
      .length(13)
      .regex(/^\d+$/)
      .required()
      .label("jmbg")
      .error(() => {
        return { message: "Please enter a valid JMBG." };
      }),
    profession: Joi.string()
      .required()
      .label("Profession")
      .error(() => {
        return {
          message: "Please enter your profession.",
        };
      }),
    workLocation: Joi.string()
      .required()
      .label("Work Location")
      .error(() => {
        return {
          message: "Please enter your work location.",
        };
      }),
  };
  doSubmit = async () => {
    try {
      await authService.registerRegularUser(this.state.data);
      //auth.loginWithJwt(response.data.token) //Ovde bi trebalo da sacuvas token iz responsa u local storage
      alert("Please confirm your email address.");
      window.location = "/login";
    } catch (ex) {
      if (ex.response && ex.response.status === 400) {
        const errors = { ...this.state.errors };
        errors.email = ex.response.data;
        //errors.password = ex.response.data.errors.Password[0];
        //console.log(ex);
        this.setState({ errors });
      }
    }
  };

  render() {
    if (auth.getCurrentUser()) return <Redirect to="/homePage" />;

    return (
      <div>
        <h1>Register</h1>
        <form onSubmit={this.handleSubmit}>
          {this.renderInput("email", "Email")}
          {this.renderInput("password", "Password", "password")}
          {this.renderInput("repeatedPassword", "Repeat Password", "password")}
          {this.renderInput("name", "Name")}
          {this.renderInput("lastName", "Last Name")}
          {this.renderInputRadioButton("gender", "Male", "male")}
          {this.renderInputRadioButton("gender", "Female", "female")}

          {this.renderInput("jmbg", "JMBG")}
          {this.renderInput("phoneNumber", "Phone Number")}
          {this.renderInput("country", "Country")}
          {this.renderInput("city", "City")}
          {this.renderInput("residenceAddress", "Residence Address")}
          {this.renderInput("profession", "Profession")}
          {this.renderInput("workLocation", "Work Location")}

          {this.renderButton("Register")}
        </form>
      </div>
    );
  }
}

export default RegisterForm;
