import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;
  static BaseURL = 'address';

  constructor(props) {
    super(props);
    this.state = { addresses: [], loading: true, postcode: ''};

    this.handlePostCode = this.handlePostCode.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.populateAddressData();
  }

  handlePostCode(event) {
    let postcode = event.target.value;
    this.setState(_ =>({
      postcode: postcode
    }))
  }

  handleSubmit(event) {
    event.preventDefault();
    this.findAddress(this.state.postcode);
  }

  static convertKmToMiles(distance) {
    let milesCoefficcient = 0.6213711;
    return distance * milesCoefficcient;
  }

  static renderAddressTable(addresses) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>PostCode</th>
            <th>Address</th>
            <th>Distance (Km)</th>
            <th>Distance (Miles)</th>
          </tr>
        </thead>
        <tbody>
          {addresses.map((address, key) =>
            <tr key={key}>
              <td>{address.postcode}</td>
              <td>{`${address.parish || ""} ${address.admindistrict || ""} ${address.parliamentaryconstituency || ""} - ${address.region || ""}, ${address.country || ""}`}</td>
              <td>{parseFloat(address.distance.replace(',', '.')).toFixed(2)}</td>
              <td>{FetchData.convertKmToMiles(parseFloat(address.distance.replace(',', '.'))).toFixed(2) }</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading && this.state.addresses.length > 0
      ? <p><em>Loading...</em></p>
      : FetchData.renderAddressTable(this.state.addresses);

    return (
      <div>
        <h1 id="tabelLabel" >Distance to London Heathrow airport</h1>
        <form className="row g-3">
          <div className="col-auto">
            <label htmlFor="postcode" className="visually-hidden">Postcode</label>
            <input type="text" readOnly className="form-control-plaintext" id="postcode" value="Postcode" />
          </div>
          <div className="col-auto">
            <label htmlFor="inputPostCode" className="visually-hidden">Postcode</label>
            <input type="text" className="form-control" id="inputPostCode" onChange={event => this.handlePostCode(event)}/>
          </div>
          <div className="col-auto">
            <button type="submit" className="btn btn-primary mb-3" onClick={event => this.handleSubmit(event) }>Find Distance</button>
          </div>
        </form>
        {contents}
      </div>
    );
  }

  async populateAddressData() {
    const response = await fetch(FetchData.BaseURL);
    this.setAddressesState(response)
  }

  async findAddress(postcode) {
    let trimmedPostcode = postcode.trim().replaceAll(' ', '');
    const response = await fetch(`${FetchData.BaseURL}/${trimmedPostcode}`);
    this.setAddressesState(response)
  }

  async setAddressesState(response) {
    const data = response.status == 404 ? [] : await response.json();
    this.setState({ addresses: data, loading: false });
  }
}
