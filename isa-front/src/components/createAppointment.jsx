import React, { useState } from "react";
import setHours from "date-fns/setHours";
import setMinutes from "date-fns/setMinutes";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { addHours, addMonths, format } from "date-fns";
import { useEffect } from "react";
import axios from "axios";
import http from "../services/httpService";
import auth from "../services/authService";

const CreateAppointment = () => {
  const [startDate, setStartDate] = useState(
    setHours(setMinutes(new Date(), 0), new Date().getHours() + 1)
  );
  const [duration, setDuration] = useState(15);
  const [isEmployee, setIsEmployee] = useState(false);
  useEffect(() => {
    const isUserEmployee = async () => {
      const currentUser = auth.getCurrentUser();
      if (currentUser.role !== "Employee") {
        window.location = "/homePage";
      }
      setIsEmployee(true);
    };
    isUserEmployee();
  }, []);

  const onSubmit = async () => {
    const currentUser = auth.getCurrentUser();
    console.log(currentUser);
    console.log(duration);
    if (
      startDate.getTime() < new Date().getTime() ||
      duration < 15 ||
      duration > 30
    ) {
      alert("Please select a future date/time.");
      return;
    } else {
      try {
        await http.post(
          "https://localhost:7293/api/Appointment/CreateAppointment",
          {
            email: currentUser.email,
            //dateTime: format(startDate, "yyyy-MM-ddTHH:mm:ss"),
            dateTime: addHours(startDate, 1),
            duration: duration,
          }
        );
        alert("Successfully created an appointment.");
      } catch (ex) {
        alert("Please fill all the fields before creating an appointment.");
      }
    }
  };
  return (
    <>
      {isEmployee ? (
        <div className="createAppointment">
          <DatePicker
            selected={startDate}
            onChange={(date) => setStartDate(date)}
            minDate={new Date()}
            maxDate={addMonths(new Date(), 12)}
            showDisabledMonthNavigation
            showTimeSelect
            minTime={setHours(setMinutes(new Date(), 0), 7)}
            maxTime={setHours(setMinutes(new Date(), 0), 21)}
            dateFormat="MM/dd/yyyy HH:mm:ss"
            inline
          />
          <label className="createAppointmentInput">
            Appointment Duration:
          </label>{" "}
          <br></br>
          <input
            className="createAppointmentInput"
            type="number"
            min={15}
            max={30}
            value={duration}
            onChange={(e) => setDuration(e.target.value)}
          ></input>{" "}
          <br /> <br />
          <button className="btn btn-primary" onClick={onSubmit}>
            Create appointment
          </button>
        </div>
      ) : null}
    </>
  );
};

export default CreateAppointment;
