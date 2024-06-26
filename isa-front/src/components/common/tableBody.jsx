import React, { Component } from "react";
import _ from "lodash";
class TableBody extends Component {
  RenderCell = (item, column) => {
    if (column.content) return column.content(item);

    return _.get(item, column.path);
  };
  CreateKey = (item, column) => {
    return item._id + (column.path || column.key);
  };
  render() {
    const { data, columns } = this.props;
    return (
      <tbody>
        {data.map((item) => (
          <tr key={item._id}>
            {columns.map((column) => (
              <td key={this.CreateKey(item, column)}>
                {this.RenderCell(item, column)}
              </td>
            ))}
          </tr>
        ))}
      </tbody>
    );
  }
}

export default TableBody;
