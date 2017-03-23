![Automile](https://content.automile.com/automile_logo_symbol_64x64.png "Automile 291 Alma Street, Palo Alto, California 943 01, US")

# Official Automile REST API for .NET
Automile offers a simple, smart, cutting-edge telematics solution for businesses to track and manage their business vehicles. Automile is a next-gen IoT solution and the overall experience is unmatched. Business of all sizes love to use Automile to get fleet intelligence whether it is understanding driving behavior, recording vehicle defects and expenses, tracking vehicles real time or securing vehicles from un-authorized use. 

Automile gives developers a simple way to build services and applications through its unique application program interface (API).  Our simple REST based API support more than 400 core features empowering developers to access more data and enabling tighter integration to build apps for the connected ecosystem. 

API information can be found at https://api.automile.com. If you need any help, we are here to help. Simply email us at support@automile.com or chat with us.

The latest OpenAPI (fka Swagger) specification may be found at: https://api.automile.com/swagger/docs/v1

:yum:

**This library allows you to quickly and easily use the Automile API via C# with .NET.**

**This SDK is currently in beta. If you need help:**

* **Use the [Issue Tracker](https://github.com/Automile/automile-net/issues) to report bugs or missing functionality in this library.**
* **Send an email to support@automile.com to request help with our API or your account.**

## Prerequisites

- .NET version 4.5 or newer

## Dependencies

- [Newtonsoft.Json](http://www.newtonsoft.com/json)

## Quickstart :running:

Installing via NuGet

```C#
Install-Package Automile.Net -prerelease
```

Add the Automile namespace were you want to use the code.

```C#
using Automile.Net;
```

```C#
// Have no account ? Well that's easy - you can signup directly from 
// this call and be given access to a demo vehicle
var savedThis = AutomileClient.SignUp("your@email.com");
// remember to savethis property - it contains your login information

// create the client directly from your signup
var client = new AutomileClient(savedThis);

// or
var client = new AutomileClient("username", "password", "api client identifier", "api secret");

// if you want to save the token (recommended)
client.SaveToken(@"token.json");

// next time you can create the client from the saved token
var client = new AutomileClient(@"token.json"));
```

That's shouldn't have been too hard :sweat_drops:

**Note:** Automile is currentley accepting username and password authentication for users belonging to private clients you are creating.

## Methods

* [Vehicle](#vehicle-methods)  
* [Trip](#trip-methods)  
* [Driver](#contact-methods)  
* [Geofence](#geofence-methods)  
* [Notification (webhooks, e-mail, text, inbox and push)](#notification-methods)  
* [Notification Messages](#notification-message-methods)  
* [Places (automation)](#place-methods)
* [Devices](#device-methods)
* [Fleets](#fleet-methods)
* [Attach Geofences to Vehicles](#attach-geofence-methods)
* [Attach Places to Vehicles](#attach-places-methods)
* [Attach Vehicles to Fleets](#attach-vehicles-methods)
* [Attach Drivers to Fleets](#attach-drivers-methods)
* [Device Events](#device-events-methods)
* [Publish Subscribe](#publish-subscribe-methods)


### Vehicle Methods

All these methods are used to retrieve one or multiple vehicles and their current locations.
You can also create, edit and delete vehicles.

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

### Contact Methods

All these methods are used to retrieve one or multiple contacts (drivers). Contacts is are considered
a driver if they are checked-in into a vehicle.

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

#### Create a geofence and associating it with the first vehicle
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

#### Edit a geofence
```C#
var coordinates = new List<GeofencePolygon.GeographicPosition>();
coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44666232, Longitude = -122.16905397 });
coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4536707, Longitude = -122.16150999 });
coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44873066, Longitude = -122.15365648 });
coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4416096, Longitude = -122.16112375 });

client.EditGeofence(3319, new GeofenceEditModel()
{
    Name = "Another name",
    Description = "Outside main offfice",
    // if you want to associate additional vehicles check CreateVehicleGeofence 
	// that adds an existing geofence to a vehicle
    GeofencePolygon = new GeofencePolygon(coordinates),
    GeofenceType = ApiGeofenceType.Outside, // supports inside, outside or both
    Schedules = null // if you want to add a specific schedule
});
```

#### Delete a geofence
```C#
client.DeleteGeofence(881);
```

### Notification Methods

All these methods are used to retrieve one or multiple notifications.
You can also create, edit, mute, unmute and delete notifications. Notifications was earlier
called Triggers.

With notifications you can also easily add webhooks, the destination for a notification could be:
* Webhook (HTTP Post)
* Text
* E-mail
* Inbox (in Automile UI)

#### Webhook format
```json
{
    "triggerMessageHistoryId": 0,
    "triggerId": 0,
    "triggerType": 0,
    "vehicleId": 0,
    "messageData1": "",
    "messageData2": ""
}
```

The message data 1 and 2 will contains data relating to the actual used notification type. If you for
example use a notificiation for trip start or trip end the messageData1 will contain the actual trip id.

#### Get all notifications (earlier called triggers)
```C#
var notifications =  client.GetNotifications();
```

#### Get details for a specific notification (earlier called triggers)
```C#
var notificationDetails =  client.GetNotificationById(25173);
```

#### Create a notification
```C#
var newNotification = client.CreateNotification(new TriggerCreateModel()
{
    IMEIConfigId = 28288, // What is this ?
	// IMEIConfigId is today called DeviceId and is the device identifier 
	// connected to the vehicle, you can get this id from the vehicle (GetVehicleById method)
    TriggerType = ApiTriggerType.Accident,
    DestinationType = ApiDestinationType.Sms,
    DestinationData = "+14158320378"
});
```

**Why  using a different identifier for notifications ?** The reasons is that there are two 
objects, the vehicle contains all properties for a vehicle while a device (earlier called IMEIConfig)
is connected to the vehicle. If you move the device to another vehicle the notifications
are still valid.

#### Edit a notification
```C#
client.EditNotification(190914, new TriggerEditModel()
{
    IMEIConfigId = 28288, // See note above, this is the DeviceId
    TriggerType = ApiTriggerType.Accident,
    DestinationType = ApiDestinationType.Sms,
    DestinationData = "+14158320378"
});
```

#### Mute a notification
```C#
client.MuteNotification(190913,60*60); // mutes for 1 hour
```

#### Unmute a notification
```C#
client.UnmuteNotification(190913);
```

#### Delete a notification
```C#
client.DeleteNotification(190913);
```

### Notification Message Methods

This is used to get historic messages that have been sent to the destination configured.

#### Get all notifications messages
```C#
var notificationMessages =  client.GetNotificationMessages();
```

#### Get all notifications messages for a specific notification
```C#
var forSpecificNotification =  client.GetNotificationMessagesByNotificationId(148638);
```

### Place Methods

With places you can track visits (stops) to locations and carry out certain automation
rules. A place is a position (latitude and longitude) and a radius (given in metric meters).

#### Get all places
```C#
var places =  client.GetPlaces();
```

#### Get details for a specific place
```C#
var placeDetails =  client.GetPlaceById(10977);
```

#### Create a place for automation and associate it with the first vehicle
```C#
var newPlace = client.CreatePlace(new PlaceCreateModel()
{
    Name = "My place",
    Description = "My home",
    PositionPoint = new PositionPointModel() { Latitude = 37.445368, Longitude = -122.166608 },
    Radius = 100, //metric meters
	//This will whenever the vehicle starts at this location set it to business
    TripType = ApiTripType.Business, 
    TripTypeTrigger = ApiTripTypeTrigger.Start,
    VehicleId = 33553
});
```

#### Edit a place
```C#
client.EditPlace(11968, new PlaceEditModel()
{
    Name = "My place",
    Description = "My home",
    PositionPoint = new PositionPointModel() { Latitude = 37.445368, Longitude = -122.166608 },
    Radius = 100,
    TripType = ApiTripType.Business,
    TripTypeTrigger = ApiTripTypeTrigger.DrivesBetween,
});
```

#### Delete a place
```C#
client.DeletePlace(11968);
```

### Device Methods

Devices are smartphones or/and Automile's smart boxes. Every box is attached to a vehicle.
Notifications are attached to devices while places and geofences are attached to vehicles.

#### Get all devices
```C#
var devices =  client.GetDevices();
```

#### Get details for a specific device
```C#
var deviceDetails =  client.GetDeviceById(28288);
```

#### Register a device and associate it to a vehicle
```C#
var newDevice = client.CreateDevice(new IMEIConfigCreateModel()
{
    IMEI = "353466072332998",
    SerialNumber = "6070763210",
    VehicleId = 33553,
    IMEIDeviceType = null // no need if you register a box
});
```

#### Edit a device
```C#
client.EditDevice(28288, new IMEIConfigEditModel()
{
    VehicleId = 33553
});
```
**What do I use this for ?** This method is used to move a device to another vehicle.
Automile still apply automatic creation of vehicles and moving devices when they are 
moved to new vehicles. But in a cases you may want to move the device manually to another
vehicle.

#### Delete a device
```C#
client.DeleteDevice(11968);
```

### Fleet Methods

Fleets are used to divide vehicles into groups that can apply different security priviligies.

#### Get all fleets
```C#
var fleets =  client.GetFleets();
```

#### Get details for a specific fleet
```C#
var fleetDetails =  client.GetFleetById(3331);
```

#### Create a fleet and associate it with me (in this case)
```C#
var newFleet = client.CreateFleet(new CompanyCreateModel()
{
    CreateRelationshipToContactId = 2,
    Description = "Some good description for the fleet",
    RegisteredCompanyName = "My new fleet"
});
```

#### Edit a fleet
```C#
client.EditFleet(3331, new CompanyEditModel()
{
    Description = "Test",
    RegisteredCompanyName = "Automile Palo Alto Fleet"
});
```

#### Delete a fleet
```C#
client.DeleteFleet(3331);
```

### Attach Geofence Methods

A geofence can have one or many included vehicles which are called relationships. These methods
allows you to list, get, create, edit and delete these relationships.

#### Get all vehicle geofences - relationships between a vehicle and a geofence
```C#
var vehicleGeofencesRelationships =  client.GetVehicleGeofencesByGeofenceId(3276);
```

#### Get all relationships to vehicles for a specific geofence
```C#
var vehicleGeofenceRelationships =  client.GetVehicleGeofenceById(44251);
```

#### Create a relationship between a vehicle and a geofence
```C#
var newVehicleGeofenceRelationship = client.CreateVehicleGeofence(new VehicleGeofenceCreateModel()
{
    GeofenceId = 3276,
    VehicleId = 33553,
	// Restrict when this geofence should be valid from and to if needed
    ValidFrom = null,
    ValidTo = null
});
```

#### Edit a vehicle geofence relationship
```C#
client.EditVehicleGeofence(44251, new VehicleGeofenceEditModel()
{
	ValidFrom = DateTime.UtcNow,
	ValidTo = DateTime.UtcNow.AddDays(30)
});
```

#### Delete a vehicle geofence relationship
```C#
client.DeleteVehicleGeofence(44251);
```

### Attach Places Methods

A place can have one or many included vehicles which are called relationships. These methods
allows you to list, get, create, edit and delete these relationships. A vehicle that has
a relationship to a place also have it's own radius and automation settings.

#### Get all vehicle places - relationships between a vehicle and a place
```C#
var vehiclePlacesRelationships =  client.GetVehiclePlaceById(10977);
```

#### Get all relationships to vehicles for a specific place
```C#
var vehiclePlaceRelationships =  client.GetVehiclePlacesByPlaceId(44251);
```

#### Create a relationship between a vehicle and a geofence
```C#
var newVehiclePlace = client.CreateVehiclePlace(new VehiclePlaceCreateModel()
{
    PlaceId = 10977,
    VehicleId = 33553,
    Description = "Some description",
    Radius = 100,
    TripType = ApiTripType.Business,
    TripTypeTrigger = ApiTripTypeTrigger.Start
});
```

#### Edit a vehicle place relationship
```C#
client.EditVehiclePlace(30567, new VehiclePlaceEditModel()
{
    Description = "Some description",
    Radius = 100,
    TripType = ApiTripType.Business,
    TripTypeTrigger = ApiTripTypeTrigger.DrivesBetween,
    DrivesBetweenAnotherPlaceId = 10979
});
```

#### Delete a vehicle place relationship
```C#
client.DeleteVehiclePlace(36405);
```

### Attach Driver Methods

A fleet can have one or multiple drivers (contacts) and one or multiple vehicles.

#### Get all drivers - relationships between all fleets and all drivers
```C#
var allFleetDrivers =  client.GetFleetContacts();
```

#### Get specific driver relationships
```C#
var specificDriverRelationship =  client.GetFleetContactById(2);
```

#### Get all drivers for specific fleet - relationships between specific fleet and all drivers
```C#
var allDriversForSpecificFleet =  client.GetFleetContactsByFleetId(10);
```

#### Create a relationship between a driver and a fleet
```C#
var newFleetContact = client.CreateFleetContact(new CompanyContactCreateModel()
{
    CompanyId = 10,
    ContactId = 2
});
```

#### Edit a driver and fleet relationship
```C#
client.EditFleetContact(10398, new CompanyContactEditModel()
{
    CompanyId = 11,
    ContactId = 2
});
```

#### Delete a driver fleet relationship
```C#
client.DeleteFleetContact(10398);
```

### Device Events Methods

Device events are a number of events like connect, disconnect, mileage indicator lamp (MIL on/off), 
diagnostic trouble codes (DTC).

#### Get all device events
```C#
var deviceEvents =  client.GetDeviceEvents();
```

#### Getting details about a status event (connected or disconnected)
```C#
var deviceStatusEvent =  client.GetDeviceEventStatusById(1138161);
```

#### Getting details about a mileage indicator lamp (MIL) event (on or off)
```C#
var deviceMILEvent =  client.GetDeviceEventMILById(1138162);
```

#### Getting details about a diagnostic trouble code (DTC) event
```C#
var deviceDTCEvent =  client.GetDeviceEventDTCById(1138213);
```

### Publish Subscribe Methods

**Note:** Currentley in alpha. 

Publish subscribe mimics a message queuing system that allows you to create subscribers that whenever a message 
is published will repost the message to your endpoint. The publish subscribe framework is more resilient compared
to simpler web hooks (that are available as part of our notifications) and allows for anonymous, basic, bearer
and Salesforce specific authentication. It also allows for configurable retries and also extends to cover 
modification and creation of certain objects.

Publish subscribe guranteee that messages received have been fully processed in Automile's microservice architecture
which means you can assume all properties have been set and calculated. 

All published messages contains two common properties called PublishMessageType and PublishMessageDateTimeUtc.

PublishMessageType will contain information what kind of message you are receiving:
* TripStartMessage = 0,
* TripEndMessage = 1,
* VehicleModified = 2,
* VehicleCreated = 3,
* DriverModified = 4,
* DriverCreated = 5

PublishMessageDateTimeUtc is the date and time (UTC) when the message was published.

#### Get all publish subscribe records
```C#
var publishSubscribeRecords =  client.GetPublishSubscribe();
```

#### Get details about a specific publish subscribe record
```C#
var detailsPublishSubscribeRecord =  client.GetPublishSubscribeById(1);
```

#### Create a new subscription with anonymous authentication (several overloads available)
```C#
var newSubscription = client.CreatePublishSubscribe("http://requestb.in/pwimfapw");
```

#### Edit a subscription (pointing to an endpoint requiring basic authentication)
```C#
var newSubscription = client.CreatePublishSubscribe("http:/your_basic_auth_endpoint", 
new PublishSubscribeAuthenticationData_Basic() 
{
Username = "username",
Password = "password"
});
```
#### Delete a subscription (will also delete queued messages)
```C#
client.DeletePublishSubscribe(1);
```

#### Format for Trip End message

```json
{
  "PublishMessageType": 1,
  "PublishMessageDateTimeUtc": "2017-02-11T04:04:36.926967Z",
  "TripId": 32575162,
  "VehicleId": 33553,
  "DriverContactId": null,
  "TripStartDateTime": "2017-02-11T01:14:44",
  "TripStartTimeZone": -8,
  "TripEndDateTime": "2017-02-11T01:21:40",
  "TripEndTimeZone": -8,
  "TripStartFormattedAddress": "2809-2811 Middlefield Rd, Palo Alto, CA 94306, USA",
  "TripEndFormattedAddress": "829 Thornwood Dr, Palo Alto, CA 94303, USA",
  "TripStartCustomAddress": null,
  "TripEndCustomAddress": null,
  "TripLengthInKilometers": 2,
  "TripType": 0,
  "TripTags": null,
  "FuelInLiters": null,
  "IdleTimeInSecondsAllTrip": 123,
  "IdleTimeInSecondsFromStart": 30,
  "CustomCategory": null,
  "TripLengthInMinutes": 7,
  "TripStartLongitude": -122.127766666667,
  "TripStartLatitude": 37.4326833333333,
  "TripEndLongitude": -122.114066666667,
  "TripEndLatitude": 37.4287666666667
}
```

#### Format for Trip Start message

```json
{
  "PublishMessageType": 0,
  "PublishMessageDateTimeUtc": "2017-02-11T03:48:12.0845446Z",
  "TripId": 32575162,
  "VehicleId": 33553,
  "DriverContactId": null,
  "TripStartDateTime": "2017-02-11T01:14:44",
  "TripStartTimeZone": -8,
  "TripStartFormattedAddress": "2809-2811 Middlefield Rd, Palo Alto, CA 94306, USA",
  "TripStartLongitude": -122.127766666667,
  "TripStartLatitude": 37.4326833333333
}
```

#### Format for Vehicle modified and created

For modified PublishMessageType will be 2.

```json
{
  "PublishMessageType": 3,
  "PublishMessageDateTimeUtc": "2017-02-11T03:50:46.284724Z",
  "VehicleId": 33553,
  "VehicleIdentificationNumber": "WA1DGAFE5FD019516",
  "NumberPlate": "7GDC324",
  "Make": "Audi",
  "Model": "Q7",
  "OwnerContactId": null,
  "OwnerCompanyId": null,
  "CurrentOdometerInKilometers": 1558.06,
  "UserVehicleIdentificationNumber": null,
  "ModelYear": 2015,
  "BodyStyle": null,
  "FuelType": 1,
  "DefaultTripType": 0,
  "AllowAutomaticUpdates": true,
  "DefaultPrivacyPolicyType": null,
  "CheckedInContactId": null,
  "MakeImageUrl": "https://content.automile.com/vinlogo/audi.png",
  "AllowSpeedRecording": true,
  "Nickname": "Jens",
  "CategoryColor": 2591227,
  "Tags": "Oakland clients, test"
}
```
#### The task message details are returned By taskMessageId
```C#
var TaskMessage =  client.GetByTaskMessageId(7194);
```

#### Create a task Message
```C#
   var newTaskMessage = client.CreateTaskMessage(new TaskMessageCreateModel()
            {
                TaskId = 1546,
                MessageText = "Hello World",
                Position = new PositionModel
                {
                    Latitude = 37.44,
                    Longitude = -122.143
                }
            });
```
#### Edit task Message
```C#
   int testTaskMessageId = 7194;
   TaskMessageModel TaskMessage = client.GetByTaskMessageId(testTaskMessageId);
            client.EditTaskMessage(TaskMessage.TaskMessageId, new TaskMessageEditModel()
            {
                IsRead = false
            });
```
#### Get Trip Summary Report
```C#
   IEnumerable<TripSummaryReportModel> TripSummaryReport = client.GetTripSummaryReport(2014);
          
```
#### Get Trip Summary Report By VehicleId
```C#
  IEnumerable<TripSummaryReportModel> TripSummaryReportByVehicleId = client.GetTripSummaryReportByVehicleId(2014, 19);
           
```
#### Get Vehicles Summary Report
```C#
   VehiclesSummaryModel VehiclesSummary = client.GetVehiclesSummaryReport(2014);
           
```

#### Get Vehicle Summary Report By VehicleId
```C#
   VehicleSummaryModel VehicleSummary = client.GetVehicleSummaryReportByVehicleId(2014, 19);
           
```
#### Email Trip Report
```C#
  client.EmailTripReport(new EmailTripReportModel()
            {
                VehicleId = 19,
                Period = 201401,
                ToEmail = "avinash.oruganti@automile.com",
                ISO639LanguageCode = "en",
                ExcludeDetailsForPersonalTrips = true,
                ExcludeEnvironmentalAndFuelData = true
            });
           
```
#### Get Log of GeoFences the user is authorized to. GetGeofenceLog
```C#
  GeofenceReportModel GeofenceReport = client.GetGeofenceLog(19,3561,DateTime.UtcNow.AddDays(1),DateTime.UtcNow.AddDays(2));
           
```

#### Get  Expense Reports
```C#
  IEnumerable<ExpenseReportModel> ExpenseReports = client.GetExpenseReports();
           
```
#### Get a Expense Report
```C#
   ExpenseReportModel ExpenseReport = client.GetExpenseReportById(ExpenseReports.First().ExpenseReportId);
           
```






