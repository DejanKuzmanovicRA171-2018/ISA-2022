import React, { useState, useEffect, Component } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import setHours from "date-fns/setHours";
import setMinutes from "date-fns/setMinutes";
import { addMonths } from "date-fns";
import { ScheduleAppointmentCentersTable } from "./scheduleAppointmentCentersTable";
import { format } from "date-fns";

export const ScheduleAppointment = () => {
  return <ScheduleAppointmentCentersTable />;
};
export default ScheduleAppointment;
