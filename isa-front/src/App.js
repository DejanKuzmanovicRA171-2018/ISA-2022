import './App.css';
import NavBar from './components/navBar';
import LoginForm from "./components/loginForm";
import Logout from './components/logout';
import RegisterForm from "./components/registerForm"; 
import NotFound from "./components/notFound";
import React, { Component } from 'react';
import { Redirect, Route, Switch } from "react-router-dom";
import BloodDonationForm from './components/bloodDonationForm';
import Centers from './components/centers';
import CenterDetails from './components/centerDetails';
import RegisteredUserProfile from './components/registeredUserProfile';
import RegisteredUserFutureAppointments from './components/registeredUserFutureAppointments';
import RegisteredUserPastAppointments from './components/registeredUserPastAppointments';
import RegisteredUserHomepage from './components/registeredUserHomePage';
import ScheduleAppointment from './components/scheduleAppointment';
import auth from "./services/authService"
import ProtectedRoute from './components/common/protectedRoute';
import ScheduleAppointmentAtCenter from './components/scheduleAppointmentAtCenter';
import CancelAppointment from './components/cancelAppointment';
import CreateAppointment from './components/createAppointment';

class App extends Component {
  state = {};

  componentDidMount() {
    const user = auth.getCurrentUser();
    this.setState({user});
  }

  render(){
    const {user} = this.state;
  return (
    <React.Fragment>
      <NavBar user={user}/>
      <main className="container">
        <Switch>
          <Route path="/register" component={RegisterForm}></Route>
          <Route path="/login" component={LoginForm}></Route>
          <Route path="/logout" component={Logout}></Route>
          <ProtectedRoute path="/donationForm" component={BloodDonationForm}/>
          <Route path="/centers/:id" component={CenterDetails}></Route>
          <Route path="/centers" component={Centers}></Route>
          <ProtectedRoute path="/pastAppointments" component={RegisteredUserPastAppointments}/>
          <ProtectedRoute path="/futureAppointments" component={() => <RegisteredUserFutureAppointments user={user}/>}/>
          <ProtectedRoute path="/profile" component={() => <RegisteredUserProfile user={user}/> } />
          <ProtectedRoute path="/cancelAppointment/:id" component={CancelAppointment}/>
          <ProtectedRoute path="/scheduleAppointmentAtCenter/:id" component={ScheduleAppointmentAtCenter}/>
          <ProtectedRoute path="/scheduleAppointment" component={ScheduleAppointment}/>
          <ProtectedRoute path="/createAppointment" component={CreateAppointment}/>
          <Route path="/homePage" component={RegisteredUserHomepage}></Route>
          <Route path="/not-found" component={NotFound}></Route>
          <Redirect from="/" exact to="/homePage" />
          <Redirect to="/not-found" />
        </Switch>
      </main>
    </React.Fragment>
  );
  }
}

export default App;
