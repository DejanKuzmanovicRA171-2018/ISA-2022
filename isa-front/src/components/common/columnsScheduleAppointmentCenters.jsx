import { Link } from "react-router-dom";
import { format, addHours } from "date-fns";

export const COLUMNS = [
  {
    Header: "Name",
    accessor: "name",
  },
  {
    Header: "Location",
    accessor: "location",
  },
  {
    Header: "Address",
    accessor: "address",
  },
  {
    Header: "Rating",
    accessor: "rating",
  },
  {
    Header: "Date",
    accessor: "startDate",
  },
  {
    Header: "",
    accessor: "appointmentId",
    disableSortBy: true,
    disableFilters: true,
    Cell: (props) => (
      <Link
        to={`/scheduleAppointmentAtCenter/${props.row.original.appointmentId},${
          props.row.original.name
        },${addHours(new Date(props.row.original.startDate), 1).toISOString()}`}
      >
        Schedule Appointment
      </Link>
    ),
  },
];
