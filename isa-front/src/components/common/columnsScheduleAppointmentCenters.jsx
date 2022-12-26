import { Link } from "react-router-dom";

export const COLUMNS = [
  {
    Header: "Name",
    accessor: "name",
    disableFilters: true,
    disableSortBy: true,
  },
  {
    Header: "Location",
    accessor: "location",
    disableFilters: true,
    disableSortBy: true,
  },
  {
    Header: "Address",
    accessor: "address",
    disableFilters: true,
    disableSortBy: true,
  },
  {
    Header: "Rating",
    accessor: "rating",
    disableFilters: true,
    enableSortingRemoval: false,
  },
];
