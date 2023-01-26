import React, { Component } from "react";
import axios from "axios";
import { CenterAppointmentTable } from "./centerAppointments";
class CenterDetails extends Component {
  state = {
    data: {
      id: "",
      name: "",
      location: "",
      address: "",
      rating: "",
      appointments: [],
    },
  };
  async componentDidMount() {
    const centerName = this.props.match.params.id;

    const { data: center } = await axios.get(
      "https://localhost:7293/api/TransfusionCenter/GetSingleTransfusionCenterByName?Name=" +
        centerName
    );

    console.log(center);
    //const center = getCenter(centerId);
    if (!center) return this.props.history.replace("/not-found");

    this.setState({ data: this.mapToViewModel(center) });
  }
  mapToViewModel(center) {
    return {
      id: center.id,
      name: center.name,
      location: center.location,
      address: center.address,
      rating: center.rating,
      appointments: center.appointments,
    };
  }
  render() {
    return (
      <React.Fragment>
        <CenterAppointmentTable centerId={this.props.match.params.id} />
      </React.Fragment>
    );
  }
}

export default CenterDetails;
