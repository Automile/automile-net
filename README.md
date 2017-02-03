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
// if you want to save the token (recommended)
client.SaveToken(@"token.json");
// next time you can create the client from the saved token
var client = new AutomileClient(@"token.json"));
```

Hard :sweat_drops:

**Note:** Automile is currentley accepting username and password authentication for users belonging to clients you are creating. To access Automile all users please contact support@automile.com to discuss granting access.

## Methods

* [Vehicle](#vehicle-methods)  
* [Trip](#trip-methods)  

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

### Trip Methods

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

#### Edit trip tags and category
```C#
client.EditTrip(31826384, new TripEditModel()
            {
                TripTags = new List<string> { "my notes" },
                TripType = ApiTripType.Business
            });
```

#### Set specific contact / driver for a trip
```C#
client.SetDriverOnTrip(31826384, 2);
```

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

### Geofence Methods

#### Get all geofences
```C#
var geofences =  client.GetGeofences();
```

#### Get details for a specific geofence
```C#
var geofenceDetails =  client.GetGeofenceById(881);
```

#### Create a geofence
```C#
var coordinates = new List<GeofencePolygon.GeographicPosition>();
coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44666232, Longitude = -122.16905397 });
coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4536707, Longitude = -122.16150999 });
coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44873066, Longitude = -122.15365648 });
coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4416096, Longitude = -122.16112375 });

client.CreateGeofence(new GeofenceCreateModel()
{
    Name = "My Palo Alto geofence",
    Description = "Outside main offfice",
    // if you want to associate additional vehicles check CreateVehicleGeofence 
	// that adds an existing geofence to a vehicle
    VehicleId = 33553,
    GeofencePolygon = new GeofencePolygon(coordinates),
    GeofenceType = ApiGeofenceType.Outside, // supports inside, outside or both
    Schedules = null // if you want to add a specific schedule
});
```

![To see the created geofence visit the web or mobile app](https://content.automile.com/sdk/CreateGeofence.png "The created geofence")

