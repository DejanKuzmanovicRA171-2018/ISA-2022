import React, { Component, useEffect, useState } from "react";
import auth from "../services/authService";
import http from "../services/httpService";
import axios from "axios";
import { addMinutes } from "date-fns";
import {
  ScheduleComponent,
  Inject,
  Day,
  Week,
  WorkWeek,
  Month,
  Agenda,
  EventSettingsModel,
} from "@syncfusion/ej2-react-schedule";

export const WorkCalendar = () => {
  const [appointments, setAppointments] = useState([{}]);
  const [isEmployee, setIsEmployee] = useState(false);
  useEffect(() => {
    const isUserEmployee = async () => {
      const currentUser = auth.getCurrentUser();
      if (currentUser.role !== "Employee") {
        window.location = "/homePage";
      }
    };
    setIsEmployee(true);
    var tempAppointments = [{}];
    const load = async () => {
      const user = auth.getCurrentUser();
      let centerId = "";
      const employee = await axios
        .get(
          "https://localhost:7293/api/Employee/GetSingleEmployeeByEmail?Email=" +
            user.email
        )
        .catch((err) => {
          centerId = "error";
          console.log(err);
        });
      if (centerId === "") {
        centerId = employee.data.transfusionCenterId;
      }
      const center = await axios
        .get(
          "https://localhost:7293/api/TransfusionCenter/GetSingleTransfusionCenterById?Id=" +
            centerId
        )
        .catch((err) => {
          console.log(err);
        });
      axios
        .get(
          "https://localhost:7293/api/Appointment/GetAllAppointmentsCenter?centerName=" +
            center.data.name
        )
        .then((res) => {
          for (let i = 0; i < res.data.length; i++) {
            let tempAppointment = {
              Id: i,
              EndTime: addMinutes(
                new Date(res.data[i].dateTime),
                res.data[i].duration
              ),
              StartTime: new Date(res.data[i].dateTime),
              IsReadonly: true,
              Subject: "Donation",
            };
            tempAppointments.push(tempAppointment);
          }
          setAppointments(tempAppointments);
        })
        .catch((err) => console.log(err));
    };
    isUserEmployee();
    load();

    console.log(appointments);
  }, []);

  return (
    <>
      {isEmployee ? (
        <ScheduleComponent
          currentView="Month"
          readonly={true}
          eventSettings={{ dataSource: appointments }}
        >
          <Inject services={[Day, Week, WorkWeek, Month, Agenda]} />
        </ScheduleComponent>
      ) : null}
    </>
  );
};

export default WorkCalendar;
