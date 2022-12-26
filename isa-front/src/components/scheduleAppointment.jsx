import React, { useState } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import setHours from "date-fns/setHours";
import setMinutes from "date-fns/setMinutes";
import { addMonths } from "date-fns";
import { ScheduleAppointmentCentersTable } from "./scheduleAppointmentCentersTable";

const ScheduleAppointment = () => {
  const [startDate, setStartDate] = useState(
    setHours(setMinutes(new Date(), 0), 7)
  );

  return (
    <React.Fragment>
      <DatePicker
        selected={startDate}
        onChange={(date) => setStartDate(date)}
        minDate={new Date()}
        maxDate={addMonths(new Date(), 12)}
        showDisabledMonthNavigation
        showTimeSelect
        minTime={setHours(setMinutes(new Date(), 0), 7)}
        maxTime={setHours(setMinutes(new Date(), 0), 21)}
        dateFormat="MMMM d, yyyy h:mm aa"
        inline
      />
      <button className="btn btn-primary">Search</button>
      <ScheduleAppointmentCentersTable />
    </React.Fragment>
  );
};

export default ScheduleAppointment;
