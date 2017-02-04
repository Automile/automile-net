using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automile.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Automile.Net.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private AutomileClient client;
        private IEnumerable<PlaceModel> places;

        [TestInitialize]
        public void Initialize()
        {
           client = new AutomileClient(@"c:\temp\token.json");
        }

        //[TestMethod]
        //public void TestSignup()
        //{
        //   var saveThisResponse = AutomileClient.SignUp("hello.developer5@automile.com");
        //   var myClient = new AutomileClient(saveThisResponse);
        //   Assert.IsNotNull(myClient);
        //}

        [TestMethod]
        public void TestGetVehicles()
        {
            IEnumerable<Vehicle2Model> vehicles = client.GetVehicles();
            Assert.IsNotNull(vehicles);
        }

        [TestMethod]
        public void TestGetVehicleById()
        {
            Vehicle2DetailModel vehicle = client.GetVehicleById(33553);
            Assert.IsNotNull(vehicle);
        }

        [TestMethod]
        public void TestGetStatusForVehicles()
        {
            IEnumerable<VehicleStatusModel> status = client.GetStatusForVehicles();
            Assert.IsNotNull(status);
        }

        [TestMethod]
        public void TestGetTrips()
        {
            IEnumerable<TripModel> trips = client.GetTrips(1);
            Assert.IsNotNull(trips);
        }

        [TestMethod]
        public void TestGetTrip()
        {
           // TripDetailModel trip = client.GetTripById(31565475);
           TripDetailModel trip = client.GetTripById(31826384);

            Assert.IsNotNull(trip);
        }

        [TestMethod]
        public void TestGetTripStartStop()
        {
            TripStartEndGeoModel tripStartStop = client.GetTripStartStopLatitudeLongitude(31826384);
            Assert.IsNotNull(tripStartStop);
        }

        [TestMethod]
        public void TestGetTripSpeed()
        {
            IEnumerable<VehicleSpeedModel> speed = client.GetTripSpeed(31826384);
            Assert.IsNotNull(speed);
        }

        [TestMethod]
        public void TestGetTripRPM()
        {
            IEnumerable<RPMModel> rpm = client.GetTripRPM(31826384);
            Assert.IsNotNull(rpm);
        }

        [TestMethod]
        public void TestGetTripAmbientTemperature()
        {
            IEnumerable<AmbientAirTemperatureModel> temp = client.GetTripAmbientTemperature(31826384);
            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void TestGetFuel()
        {
            IEnumerable<FuelLevelInputModel> fuel = client.GetTripFuelLevel(31826384);
            Assert.IsNotNull(fuel);
        }

        [TestMethod]
        public void TestGetEngineCoolantTemperature()
        {
            IEnumerable<EngineCoolantTemperatureModel> temp = client.GetTripEngineCoolantTemperature(31826384);
            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void TestGetRawPIDs()
        {
            IEnumerable<PIDModel> pidData = client.GetTripPIDRaw(31826384, 70);
            Assert.IsNotNull(pidData);
        }

        [TestMethod]
        public void TestGetTripLatitudeLongitude()
        {
            IEnumerable<TripGeoModel> geo = client.GeoTripLatitudeLongitude(31826384, 1);
            Assert.IsNotNull(geo);
        }

        [TestMethod]
        public void TestGetTripDetails()
        {
            TripConcatenation data = client.GetCompletedTripDetails(31826384);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestGetTripDetailsAdvanced()
        {
            TripConcatenation data = client.GetCompletedTripDetailsAdvanced(31826384);
            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestGetContacts()
        {
            IEnumerable<Contact2Model> drivers = client.GetContacts();
            Assert.IsNotNull(drivers);
        }

        [TestMethod]
        public void TestGetContactById()
        {
            Contact2DetailModel driver = client.GetContactById(2);
            Assert.IsNotNull(driver);
        }

        [TestMethod]
        public void TestGetMe()
        {
            Contact2DetailModel driver = client.GetMe();
            Assert.IsNotNull(driver);
        }

        [TestMethod]
        public void TestEditTrip()
        {
            client.EditTrip(31826384, new TripEditModel()
            {
                TripTags = new List<string> { "my notes" },
                TripType = ApiTripType.Business,
            });
        }

        [TestMethod]
        public void TestSetDriverOnTrip()
        {
            client.SetDriverOnTrip(31826384, 2);
        }

        [TestMethod]
        public void TestGetGeofences()
        {
            IEnumerable<GeofenceModel> geofences = client.GetGeofences();
            Assert.IsNotNull(geofences);
        }

        [TestMethod]
        public void TestGetGeofenceDetails()
        {
            GeofenceModel geofence = client.GetGeofenceById(881);
            Assert.IsNotNull(geofence);
        }

        [TestMethod]
        public void CreateGeofence()
        {
            var coordinates = new List<GeofencePolygon.GeographicPosition>();
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44666232, Longitude = -122.16905397 });
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4536707, Longitude = -122.16150999 });
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44873066, Longitude = -122.15365648 });
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4416096, Longitude = -122.16112375 });

            client.CreateGeofence(new GeofenceCreateModel()
            {
                Name = "My Palo Alto geofence",
                Description = "Outside main offfice",
                VehicleId = 33553,
                GeofencePolygon = new GeofencePolygon(coordinates),
                GeofenceType = ApiGeofenceType.Outside,
                Schedules = null // if you want to add a specific schedule
            });
        }

        [TestMethod]
        public void EditGeofence()
        {
            var coordinates = new List<GeofencePolygon.GeographicPosition>();
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44666232, Longitude = -122.16905397 });
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4536707, Longitude = -122.16150999 });
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44873066, Longitude = -122.15365648 });
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4416096, Longitude = -122.16112375 });

            client.EditGeofence(3270, new GeofenceEditModel()
            {
                Name = "My Palo Alto geofence",
                Description = "Outside main offfice",
                GeofencePolygon = new GeofencePolygon(coordinates),
                GeofenceType = ApiGeofenceType.Outside,
                Schedules = null // if you want to add a specific schedule
            });
        }

        [TestMethod]
        public void TestDeleteGeofence()
        {
            client.DeleteGeofence(3270);
        }

        [TestMethod]
        public void TestGetNotifications()
        {
            IEnumerable<TriggerModel> notifications = client.GetNotifications();
            Assert.IsNotNull(notifications);
        }

        [TestMethod]
        public void TestGetNotificationDetails()
        {
            var notification = client.GetNotificationById(25173);
            Assert.IsNotNull(notification);
        }

        [TestMethod]
        public void TestCreateNotification()
        {
            var newNotification = client.CreateNotification(new TriggerCreateModel()
            {
                IMEIConfigId = 28288,
                TriggerType = ApiTriggerType.Accident,
                DestinationType = ApiDestinationType.Sms,
                DestinationData = "+14158320378"
            });

            Assert.AreEqual("+14158320378", newNotification.DestinationData);
        }

        [TestMethod]
        public void TestEditNotification()
        {
            client.EditNotification(190914, new TriggerEditModel()
            {
                IMEIConfigId = 28288,
                TriggerType = ApiTriggerType.Accident,
                DestinationType = ApiDestinationType.Sms,
                DestinationData = "+14158320378"
            });
        }

        [TestMethod]
        public void TestDeleteNotification()
        {
            client.DeleteNotification(190914);
        }

        [TestMethod]
        public void TestMuteNotification()
        {
            client.MuteNotification(190914, 60*60);
        }

        [TestMethod]
        public void TestUnmuteNotification()
        {
            client.UnmuteNotification(190914);
        }

        [TestMethod]
        public void TestGetPlaces()
        {
            IEnumerable<PlaceModel> places = client.GetPlaces();
            Assert.IsNotNull(places);
        }

        [TestMethod]
        public void TestGetPlaceById()
        {
            PlaceModel place = client.GetPlaceById(10977);
            Assert.IsNotNull(place);
        }

        [TestMethod]
        public void TestCreatePlace()
        {
            PlaceModel place = client.CreatePlace(new PlaceCreateModel()
            {
                Name = "My place",
                Description = "My home",
                PositionPoint = new PositionPointModel() { Latitude = 37.445368, Longitude = -122.166608 },
                Radius = 100,
                TripType = ApiTripType.Business,
                TripTypeTrigger = ApiTripTypeTrigger.Start,
                VehicleId = 33553
            });
            Assert.IsNotNull(place);
        }

        [TestMethod]
        public void TestEditPlace()
        {
            client.EditPlace(11968, new PlaceEditModel()
            {
                Name = "My place",
                Description = "My home",
                PositionPoint = new PositionPointModel() { Latitude = 37.445368, Longitude = -122.166608 },
                Radius = 100,
                TripType = ApiTripType.Business,
                TripTypeTrigger = ApiTripTypeTrigger.DrivesBetween,
            });
        }

        [TestMethod]
        public void TestDeletePlace()
        {
            client.DeletePlace(11968);
        }

        [TestMethod]
        public void TestGetDevices()
        {
            IEnumerable<IMEIConfigModel> devices = client.GetDevices();
            Assert.IsNotNull(devices);
        }

        [TestMethod]
        public void TestGetDeviceById()
        {
            IMEIConfigDetailModel device = client.GetDeviceById(28288);
            Assert.IsNotNull(device);
        }

        [TestMethod]
        public void TestCreateDevice()
        {
            IMEIConfigDetailModel newDevice = client.CreateDevice(new IMEIConfigCreateModel()
            {
                IMEI = "353466073376499",
                SerialNumber = "7011261106",
                VehicleId = 33553,
                IMEIDeviceType = null // no need if you register a box
            });
            Assert.IsNotNull(newDevice);
        }

        [TestMethod]
        public void TestEditDevice()
        {
            client.EditDevice(28288, new IMEIConfigEditModel()
            {
                VehicleId = 33553
            });
        }

        [TestMethod]
        public void TestDeleteDevice()
        {
            client.DeleteDevice(11968);
        }
    }
}
