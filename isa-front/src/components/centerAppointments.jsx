import React, { useMemo, useEffect, useState } from "react";
import {
  useTable,
  useSortBy,
  useGlobalFilter,
  useFilters,
  usePagination,
} from "react-table";

import { COLUMNS } from "./common/columnsAppointment";
import "./table.css";
import { GlobalFilter } from "./common/globalFilter";
import { ColumnFilter } from "./common/columnFilter";
import http from "../services/httpService";
import auth from "../services/authService";
import axios from "axios";

export const CenterAppointmentTable = (props) => {
  const [data, setAppointments] = useState([]);
  const [numberOfAppointments, setNumberOfAppointmets] = useState(0);
  const [center, setCenter] = useState([]);
  useEffect(() => {
    http
      .get(
        "https://localhost:7293/api/TransfusionCenter/GetSingleTransfusionCenterByName?Name=" +
          props.centerId
      )
      .then((res) => {
        console.log(res);

        setCenter(res.data);
      })
      .catch((err) => console.log(err));
  }, []);
  useEffect(() => {
    const user = auth.getCurrentUser();
    axios
      .get(
        "https://localhost:7293/api/Appointment/GetAllUpcomingAppointmentsUser?email=" +
          user.email
      )
      .then((res) => {
        setNumberOfAppointmets(res.data.length);
      })
      .catch((err) => console.log(err));
  }, []);
  useEffect(() => {
    console.log(props.centerId);
    http
      .get(
        "https://localhost:7293/api/Appointment/GetAllAppointmentsCenter?centerName=" +
          props.centerId
      )
      .then((res) => {
        console.log(res);

        setAppointments(res.data);
      })
      .catch((err) => console.log(err));
  }, []);
  const columns = useMemo(() => COLUMNS, []);

  //const data = useMemo(() => centers, []);
  const defaultColumn = useMemo(() => {
    return {
      Filter: ColumnFilter,
    };
  }, []);

  const {
    getTableProps,
    getTableBodyProps,
    headerGroups,
    page,
    nextPage,
    previousPage,
    canNextPage,
    canPreviousPage,
    pageOptions,
    gotoPage,
    pageCount,
    setPageSize,
    state,
    setGlobalFilter,
    prepareRow,
  } = useTable(
    {
      columns,
      data,
      defaultColumn,
    },
    useFilters,
    useGlobalFilter,
    useSortBy,
    usePagination
  );

  const { globalFilter, pageIndex, pageSize } = state;

  return (
    <>
      Transfusion center name: {center.name}
      <br />
      Center info: {center.description}
      <br />
      Rating: {center.rating}
      <br />
      {numberOfAppointments >= 1 ? (
        "You can only schedule 1 appointment."
      ) : (
        <>
          <GlobalFilter filter={globalFilter} setFilter={setGlobalFilter} />
          <table {...getTableProps()}>
            <thead>
              {headerGroups.map((headerGroup) => (
                <tr {...headerGroup.getHeaderGroupProps()}>
                  {headerGroup.headers.map((column) => (
                    <th
                      {...column.getHeaderProps(column.getSortByToggleProps())}
                    >
                      {column.render("Header")}
                      <div>
                        {column.canFilter ? column.render("Filter") : null}
                      </div>
                      <div>
                        {column.isSorted
                          ? column.isSortedDesc
                            ? " 🔽"
                            : " 🔼"
                          : " ⏹️"}
                      </div>
                    </th>
                  ))}
                </tr>
              ))}
            </thead>
            <tbody {...getTableBodyProps()}>
              {page.map((row) => {
                prepareRow(row);
                return (
                  <tr {...row.getRowProps()}>
                    {row.cells.map((cell) => {
                      return (
                        <td {...cell.getCellProps()}>{cell.render("Cell")}</td>
                      );
                    })}
                  </tr>
                );
              })}
            </tbody>
          </table>
          <div>
            <span>
              Page{" "}
              <strong>
                {pageIndex + 1} of {pageOptions.length}
              </strong>{" "}
            </span>
            <select
              className="btn btn-primary m-2"
              value={pageSize}
              onChange={(e) => setPageSize(Number(e.target.value))}
            >
              {[10, 25, 50].map((pageSize) => (
                <option key={pageSize} value={pageSize}>
                  Show {pageSize}
                </option>
              ))}
            </select>

            <button
              className="btn btn-primary"
              onClick={() => gotoPage(0)}
              disabled={!canPreviousPage}
            >
              {"<<"}
            </button>
            <button
              className="btn btn-primary m-2"
              onClick={() => previousPage()}
              disabled={!canPreviousPage}
            >
              Previous
            </button>
            <button
              className="btn btn-primary m-2"
              onClick={() => nextPage()}
              disabled={!canNextPage}
            >
              Next
            </button>
            <button
              className="btn btn-primary"
              onClick={() => gotoPage(pageCount - 1)}
              disabled={!canNextPage}
            >
              {">>"}
            </button>
          </div>
        </>
      )}
    </>
  );
};
