import React from "react";
import Joi from "joi-browser";
import Form from "./common/form";
import auth from "../services/authService";
import { Link, NavLink, Redirect } from "react-router-dom";

class LoginForm extends Form {
  state = {
    data: { email: "", password: "" },
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
      .min(8)
      .label("Password")
      .error(() => {
        return {
          message: "Password must be at least 8 characters.",
        };
      }),
  };

  doSubmit = async () => {
    try {
      const { data } = this.state;
      await auth.login(data.email, data.password);

      const { state } = this.props.location;
      window.location = state ? state.from.pathname : "/homePage";
    } catch (ex) {
      if (ex.response && ex.response.status === 400) {
        const errors = { ...this.state.errors };
        console.log(ex.response);
        switch (ex.response.data) {
          case "Password is incorrect":
            errors.password = ex.response.data;
            break;
          case "User with email: " + this.state.data.email + " doesn't exist":
            errors.email = ex.response.data;
            break;
          case "Please confirm your email address":
            errors.email = ex.response.data;
            break;
          default:
            errors.password = ex.response.data.errors.Password;
        }
        //errors.email = ex.response.data;
        //errors.password = ex.response.data;
        this.setState({ errors });
      }
    }
  };

  render() {
    if (auth.getCurrentUser()) return <Redirect to="/homePage" />;

    return (
      <div>
        <h1>Login</h1>
        <form onSubmit={this.handleSubmit}>
          {this.renderInput("email", "Email")}
          {this.renderInput("password", "Password", "password")}

          {this.renderButton("Login")}

          <NavLink className="nav-link" to="/register">
            Not registered?
          </NavLink>
        </form>
      </div>
    );
  }
}

export default LoginForm;
