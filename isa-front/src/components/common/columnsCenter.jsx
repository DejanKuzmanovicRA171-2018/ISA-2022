import { format } from "date-fns";
import { ColumnFilter } from "./columnFilter";
import { Link } from "react-router-dom";

export const COLUMNS = [
  {
    Header: "Name",
    accessor: "name",
    Cell: (props) => (
      <Link to={`/centers/${props.row.original.name}`}>{props.value}</Link>
    ),
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
];
