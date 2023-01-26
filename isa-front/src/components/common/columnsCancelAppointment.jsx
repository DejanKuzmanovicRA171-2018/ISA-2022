import { format } from "date-fns";
import { ColumnFilter } from "./columnFilter";
import { Link } from "react-router-dom";

export const COLUMNS = [
  {
    Header: "Date",
    accessor: "dateTime",
  },
  {
    Header: "Duration",
    accessor: "duration",
  },

  {
    Header: "",
    accessor: "id",
    disableSortBy: true,
    disableFilters: true,

    Cell: (props) => (
      <Link to={`/cancelAppointment/${props.row.original.id}`}>
        Cancel Appointment
      </Link>
    ),
  },
];
