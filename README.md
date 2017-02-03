# Official Automile REST API for .NET
Automile offers a simple, smart, cutting-edge telematics solution for businesses to track and manage their business vehicles. Automile is a next-gen IoT solution and the overall experience is unmatched. Business of all sizes love to use Automile to get fleet intelligence whether it is understanding driving behavior, recording vehicle defects and expenses, tracking vehicles real time or securing vehicles from un-authorized use. 

Automile gives developers a simple way to build services and applications through its unique application program interface (API).  Our simple REST based API support more than 400 core features empowering developers to access more data and enabling tighter integration to build apps for the connected ecosystem. 

API information can be found at https://api.automile.com. If you need any help, we are here to help. Simply email us at support@automile.com or chat with us.

:yum:

**This library allows you to quickly and easily use the Automile API via C# with .NET.**

**This SDK is currently in beta. If you need help:**

* **Use the [Issue Tracker](https://github.com/Automile/automile-net/issues) to report bugs or missing functionality in this library.**
* **Send an email to support@automile.com to request help with our API or your account.**

## Prerequisites

- .NET version 4.5 or newer
- Automile subscription or developer account, starting from [$5.90 per month](https://automile.com)

## Dependencies

- [Newtonsoft.Json](http://www.newtonsoft.com/json)

## Quickstart :running:

Add the Automile namespace were you want to use the code.

```C#
using Automile.Net;
```

```C#
var client = new AutomileClient("username", "password", "api client identifier", "api secret");
// or if you saved the token earlier
var client = new AutomileClient(System.IO.File.ReadAllText(@"c:\<path>\token.json"));
```

Hard :sweat_drops:

**Note:** Automile is currentley accepting username and password authentication for users belonging to clients you are creating. To access Automile all users please contact support@automile.com to discuss granting access.

### Vehicle Methods

#### Get all vehicles
```C#
var vehicles =  client.GetVehicles();
```

#### Get details for a specific vehicle
```C#
var vehicleDetails =  client.GetVehicleById(33553);
```
#### Get status for all vehicles which will include the position of the actual vehicles
```C#
var vehicleStatus =  client.GetStatusForVehicles();
```
#### Check-in driver to vehicle
```C#
client.CheckInToVehicle(new VehicleCheckInModel()
            {
                ContactId = 2,
                VehicleId = 33553,
                DefaultTripType = ApiTripType.Auto, //Use the users schedule, place or other automation rules
                CheckOutAtUtc = DateTime.UtcNow.AddDays(7) //Use to schedule future auto-checkout, leave empty for permanent check-in
            });
```

#### Check-out yourself
```C#
client.CheckOut();
```

### Trip/s Methods

#### Get all trips for the last days
```C#
var trips =  client.GetTrips(lastNumberOfDays:1);
```
#### Get overview for a specific trip
```C#
var tripOverview =  client.GetTripById(31826384);
```
**Note:** This call contains overview details of a trip, if you want all datapoints you can instead use GetTripDetails or GetTripDetailsAdvanced.

#### Get the start and stop latitude and longitude positions of the trip
```C#
var tripStartStopPosition =  client.GetTripStartStopLatitudeLongitude(31826384);
```
#### Get all latituide and longitude locations during the trip 
```C#
var tripPositions =  client.GeoTripLatitudeLongitude(tripId:31826384,everyNthRecord:5);
```
#### Get trip details for a trip
```C#
var tripDetails =  client.GetTripDetails(31826384);
```
#### Get advanced trip details for a trip
```C#
var tripAdvanced =  client.GetTripDetailsAdvanced(31826384);
```
#### Get all RPM values during a trip
```C#
var rpmValues =  client.GetTripRPM(31826384);
```
#### Get all ambient temperature values during a trip
```C#
var ambientTemperatures =  client.GetTripAmbientTemperature(31826384);
```
#### Get all engine coolant temperature values during a trip
```C#
var coolantTemperatures =  client.GetTripEngineCoolantTemperature(31826384);
```
#### Get all fuel values during a trip
```C#
var fuelLevels = client.GetTripFuelLevel(31826384);
```
**Note:** Only specific US makes and models are supporting fuel levels reporting

### Contact/s (Driver/s) Methods

#### Get all contacts/drivers
```C#
var contacts =  client.GetContacts();
```
#### Get contact details by it's id
```C#
var contactDetail =  client.GetContactById(2);
```
#### Get details around your self
```C#
var me =  client.GetMe();
```

