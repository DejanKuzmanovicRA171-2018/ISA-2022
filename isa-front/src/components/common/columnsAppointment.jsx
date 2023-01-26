import { format } from "date-fns";
import { ColumnFilter } from "./columnFilter";
import { Link } from "react-router-dom";

export const COLUMNS = [
  {
    Header: "Date",
    accessor: "dateTime",
    /*
    Cell: ({ value }) => {
      return format(new Date(value), "yyyy-MM-dd hh:mm");
    },*/
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
      <Link
        to={`/scheduleAppointmentAtCenter/${props.row.original.id},xxxxxx,1970-3-2`}
      >
        Schedule Appointment
      </Link>
    ),
  },
];
