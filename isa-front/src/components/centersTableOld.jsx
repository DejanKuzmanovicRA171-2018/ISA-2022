import React, { Component } from "react";
import Table from "./common/table";
class CentersTable extends Component {
  columns = [
    {
      path: "name",
      label: "Name",
    },
    { path: "location", label: "Location" },
    { path: "address", label: "Address" },
    { path: "rating", label: "Rating" },
  ];
  render() {
    const { centers, onSort, sortColumn } = this.props;
    return (
      <Table
        columns={this.columns}
        data={centers}
        sortColumn={sortColumn}
        onSort={onSort}
      />
    );
  }
}
export default CentersTable;
