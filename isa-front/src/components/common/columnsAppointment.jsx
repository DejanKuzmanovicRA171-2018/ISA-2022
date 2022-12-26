import { format } from "date-fns";
import { ColumnFilter } from "./columnFilter";
import { Link } from "react-router-dom";

export const COLUMNS = [
  {
    Header: "Date",
    accessor: "dateTime",
    Cell: ({ value }) => {
      return format(new Date(value), "dd/MM/yyyy");
    },
  },
  {
    Header: "Duration",
    accessor: "duration",
  },
  {
    Header: "Price",
    accessor: "price",
  },
];
