import React, { Component } from "react";
import { getCenters } from "../fakeCenters";
import { CentersTable } from "./centersTable";
import Pagination from "./common/pagination";
import SearchBox from "./common/searchBox";
import _ from "lodash";
import { paginate } from "../paginate";

class Centers extends Component {
  state = {
    centers: [],
    currentPage: 1,
    pageSize: 4,
    searchQuery: "",
    sortColumn: { path: "name", order: "asc" },
  };
  componentDidMount() {
    this.setState({ centers: getCenters() });
  }
  handleSort = (sortColumn) => {
    this.setState({ sortColumn });
  };
  handlePageChange = (page) => {
    this.setState({ currentPage: page });
  };
  handleSearch = (query) => {
    this.setState({ searchQuery: query, currentPage: 1 });
  };
  getPagedData = () => {
    const {
      pageSize,
      currentPage,
      sortColumn,
      searchQuery,
      centers: allCenters,
    } = this.state;

    let filtered = allCenters;
    if (searchQuery)
      filtered = allCenters.filter((c) =>
        c.name.toLowerCase().startsWith(searchQuery.toLowerCase())
      );

    const sorted = _.orderBy(filtered, [sortColumn.path], [sortColumn.order]);
    const centers = paginate(sorted, currentPage, pageSize);

    return { totalCount: filtered.length, data: centers };
  };

  render() {
    const { length: count } = this.state.centers;
    const { pageSize, currentPage, sortColumn, searchQuery } = this.state;
    if (count === 0) return <p>There are no centers in the database.</p>;

    const { totalCount, data: centers } = this.getPagedData();
    return (
      <div className="row">
        <div className="col">
          <p>
            Showing {totalCount} donations centers that are in the database.
          </p>
          <SearchBox value={searchQuery} onChange={this.handleSearch} />
          <CentersTable
            centers={centers}
            sortColumn={sortColumn}
            onSort={this.handleSort}
          />
          <Pagination
            itemsCount={totalCount}
            pageSize={pageSize}
            currentPage={currentPage}
            onPageChange={this.handlePageChange}
          />
        </div>
      </div>
    );
  }
}

export default Centers;
