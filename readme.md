[![LinkedIn][linkedin-shield]][linkedin-url]

<h3 align="center">Distance to London Heathrow airport .NET 6 + ReactJS</h3>
<p align="center">
    It is an application to compute your distance to London Heathrow airport. 
    The application will find your address and display the distance in a straight line, given a postcode in UK.
    The Postcodes.io API requests, storage (EF Core in memory), and distance computation are handled in the backend (.NET 6 Web API), while the frontend (ReactJS) is responsible to display the information requested.
</p>

### ENDPOINTS

`GET: /GetAddressByPostCode` verifies whether there is a saved address in the in-memory EF Core database. If the address was already searched and return it. Otherwise, make an API call to [Postcodes.io](http://api.postcodes.io/postcodes/) with the postcode, compute the distance, and save it in the in-memory EF Core database

`GET: /GetLastThreeAddresses` retrieves the last three searched addresses from the in-memory EF Core database

## A few examples of valid postcodes in the UK are:

| Index | Postcode |     |
| ----- | -------- | --- |
| #1    | N76RS    |     |
| #2    | SW46TA   |     |
| #3    | SW1A     |     |
| #4    | W1B3AG   |     |
| #5    | PO63TD   |     |

##### A working example for the web service is: http://api.postcodes.io/postcodes/N76RS

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/mateuszanatta/
