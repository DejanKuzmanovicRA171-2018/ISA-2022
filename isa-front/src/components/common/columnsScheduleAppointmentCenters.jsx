import { Link } from "react-router-dom";

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
    Header: "",
    accessor: "appointmentId",
    disableSortBy: true,
    Cell: (props) => (
      <Link
        to={`/scheduleAppointmentAtCenter/${props.row.original.appointmentId}`}
      >
        Schedule Appointment
      </Link>
    ),
  },
];
