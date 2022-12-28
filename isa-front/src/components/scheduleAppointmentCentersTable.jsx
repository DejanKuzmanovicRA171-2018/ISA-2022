import React, { useMemo, useEffect, useState } from "react";
import { useTable, useSortBy, useFilters, usePagination } from "react-table";

import { COLUMNS } from "./common/columnsScheduleAppointmentCenters";
import "./table.css";
import { ColumnFilter } from "./common/columnFilter";
import axios from "axios";
import { format } from "date-fns";
import setHours from "date-fns/setHours";
import setMinutes from "date-fns/setMinutes";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import { addMonths } from "date-fns";
import auth from "../services/authService";

export const ScheduleAppointmentCentersTable = () => {
  const [startDate, setStartDate] = useState(
    setHours(setMinutes(new Date(), 0), 7)
  );
  const [data, setAppointments] = useState([]);

  const [numberOfAppointments, setNumberOfAppointmets] = useState(0);

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
  const doSubmit = () => {
    setStartDate(startDate);
    axios
      .get(
        "https://localhost:7293/api/TransfusionCenter/GetAllTCsAppointmentDateTime?dateTime=" +
          format(startDate, "MM/dd/yyyy HH:mm:ss")
      )
      .then((res) => {
        console.log(res);

        setAppointments(res.data);
        if (res.data.length === 0) {
          alert(
            "No center has an available appointment for the selected date and time."
          );
        }
      })
      .catch((err) => console.log(err));
  };
  /*
  useEffect(() => {
    axios
      .get(
        "https://localhost:7293/api/Appointment/GetAllAppointmentsDateTime?dateTime=" +
          format(startDate, "MM/dd/yyyy HH:mm:ss")
      )
      .then((res) => {
        console.log(res);

        setAppointments(res.data);
      })
      .catch((err) => console.log(err));
  }, []);*/
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
    prepareRow,
  } = useTable(
    {
      columns,
      data,
      defaultColumn,
    },
    useFilters,
    useSortBy,
    usePagination
  );

  const { pageIndex, pageSize } = state;

  return (
    <>
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
          dateFormat="MM/dd/yyyy HH:mm:ss"
          inline
        />
        {numberOfAppointments <= 0 ? (
          <button className="btn btn-primary" onClick={doSubmit}>
            Search
          </button>
        ) : (
          <>
            <button className="btn btn-primary" disabled={true}>
              Search
            </button>{" "}
            You can only schedule 1 appointment.
          </>
        )}
        <br /> <br />
      </React.Fragment>
      <table {...getTableProps()}>
        <thead>
          {headerGroups.map((headerGroup) => (
            <tr {...headerGroup.getHeaderGroupProps()}>
              {headerGroup.headers.map((column) => (
                <th {...column.getHeaderProps(column.getSortByToggleProps())}>
                  {column.render("Header")}
                  <div>{column.canFilter ? column.render("Filter") : null}</div>
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
  );
};
