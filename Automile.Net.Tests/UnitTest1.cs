using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automile.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Automile.Net.Tests
{
    public class TestData
    {
        public int? GeofenceId { get; set; }

        public int? PlaceId { get; set; }

        public int? NotificationId { get; set; }

        public int VehicleId { get; set; }

        public int TripId { get; set; }

        public int ContactId { get; set; }

        public int IMEIConfigId { get; set; }

        public void Save()
        {
            var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText("testdata.json", jsonData);
        }

        public static TestData Load()
        {
            if (System.IO.File.Exists("testdata.json") == false)
                return null;

            var jsonData = System.IO.File.ReadAllText("testdata.json");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TestData>(jsonData);
        }
    }


    [TestClass]
    public class UnitTest1
    {
        private AutomileClient client;
        private TestData data = null;


        [TestInitialize]
        public void Initialize()
        {
            client = new AutomileClient(@"c:\temp\token.json");
            data = TestData.Load();
            data.VehicleId = 33553;
            data.TripId = 31826384;
            data.IMEIConfigId = 28288;
            data.ContactId = 2;
            data.Save();
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
            Vehicle2DetailModel vehicle = client.GetVehicleById(data.VehicleId);
            Assert.IsNotNull(vehicle);
        }

        [TestMethod]
        public void TestGetStatusForVehicles()
        {
            IEnumerable<VehicleStatusModel> status = client.GetStatusForVehicles();
            Assert.IsTrue(status.Count() > 0);
        }

        [TestMethod]
        public void TestGetTrips()
        {
            IEnumerable<TripModel> tripsLastDay = client.GetTrips(1);
            Assert.IsNotNull(tripsLastDay);
        }

        [TestMethod]
        public void TestGetTrip()
        {
            TripDetailModel trip = client.GetTripById(data.TripId);
            Assert.IsNotNull(trip);
        }

        [TestMethod]
        public void TestGetTripStartStop()
        {
            TripStartEndGeoModel tripStartStop = client.GetTripStartStopLatitudeLongitude(data.TripId);
            Assert.IsNotNull(tripStartStop);
        }

        [TestMethod]
        public void TestGetTripSpeed()
        {
            IEnumerable<VehicleSpeedModel> speed = client.GetTripSpeed(data.TripId);
            Assert.IsNotNull(speed);
        }

        [TestMethod]
        public void TestGetTripRPM()
        {
            IEnumerable<RPMModel> rpm = client.GetTripRPM(data.TripId);
            Assert.IsNotNull(rpm);
        }

        [TestMethod]
        public void TestGetTripAmbientTemperature()
        {
            IEnumerable<AmbientAirTemperatureModel> temp = client.GetTripAmbientTemperature(data.TripId);
            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void TestGetFuel()
        {
            IEnumerable<FuelLevelInputModel> fuel = client.GetTripFuelLevel(data.TripId);
            Assert.IsNotNull(fuel);
        }

        [TestMethod]
        public void TestGetEngineCoolantTemperature()
        {
            IEnumerable<EngineCoolantTemperatureModel> temp = client.GetTripEngineCoolantTemperature(data.TripId);
            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void TestGetRawPIDs()
        {
            IEnumerable<PIDModel> pidData = client.GetTripPIDRaw(data.TripId, 70);
            Assert.IsNotNull(pidData);
        }

        [TestMethod]
        public void TestGetTripLatitudeLongitude()
        {
            IEnumerable<TripGeoModel> geo = client.GeoTripLatitudeLongitude(data.TripId, 1);
            Assert.IsNotNull(geo);
        }

        [TestMethod]
        public void TestGetTripDetails()
        {
            TripConcatenation tripCat = client.GetCompletedTripDetails(data.TripId);
            Assert.IsNotNull(tripCat);
        }

        [TestMethod]
        public void TestGetTripDetailsAdvanced()
        {
            TripConcatenation tripCat = client.GetCompletedTripDetailsAdvanced(data.TripId);
            Assert.IsNotNull(tripCat);
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
            Contact2DetailModel driver = client.GetContactById(data.ContactId);
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
            client.EditTrip(data.TripId, new TripEditModel()
            {
                TripTags = new List<string> { "my notes" },
                TripType = ApiTripType.Business,
            });
        }

        [TestMethod]
        public void TestSetDriverOnTrip()
        {
            client.SetDriverOnTrip(data.TripId, data.ContactId);
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
            if (data.GeofenceId.HasValue == false)
                throw new Exception("There is no geofence id in the test data to use for this test");

            GeofenceModel geofence = client.GetGeofenceById(data.GeofenceId.Value);
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

            var newGeofence = client.CreateGeofence(new GeofenceCreateModel()
            {
                Name = "My Palo Alto geofence",
                Description = "Outside main offfice",
                VehicleId = 33553,
                GeofencePolygon = new GeofencePolygon(coordinates),
                GeofenceType = ApiGeofenceType.Outside,
                Schedules = null // if you want to add a specific schedule
            });

            var testData = new TestData() { GeofenceId = newGeofence.GeofenceId };
            testData.Save();
        }

        [TestMethod]
        public void EditGeofence()
        {
            if (data.GeofenceId.HasValue == false)
                throw new Exception("There is no geofence id in the test data to use for this test");
               
            var coordinates = new List<GeofencePolygon.GeographicPosition>();
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44666232, Longitude = -122.16905397 });
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4536707, Longitude = -122.16150999 });
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44873066, Longitude = -122.15365648 });
            coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4416096, Longitude = -122.16112375 });

            client.EditGeofence(data.GeofenceId.Value, new GeofenceEditModel()
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
            if (data.GeofenceId.HasValue == false)
                throw new Exception("There is no geofence id in the test data to use for this test");

            client.DeleteGeofence(data.GeofenceId.Value);
            data.GeofenceId = null;
            data.Save();
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
                IMEIConfigId = data.IMEIConfigId,
                TriggerType = ApiTriggerType.Accident,
                DestinationType = ApiDestinationType.Sms,
                DestinationData = "+14158320378"
            });

            Assert.AreEqual("+14158320378", newNotification.DestinationData);

            data.NotificationId = newNotification.TriggerId;
            data.Save();
        }

        [TestMethod]
        public void TestEditNotification()
        {
            if (data.NotificationId.HasValue == false)
                throw new Exception("There is no notification id in the test data to use for this test");

            client.EditNotification(data.NotificationId.Value, new TriggerEditModel()
            {
                IMEIConfigId = data.IMEIConfigId,
                TriggerType = ApiTriggerType.Accident,
                DestinationType = ApiDestinationType.Sms,
                DestinationData = "+14158320378"
            });
        }

        [TestMethod]
        public void TestDeleteNotification()
        {
            if (data.NotificationId.HasValue == false)
                throw new Exception("There is no notification id in the test data to use for this test");

            client.DeleteNotification(data.NotificationId.Value);

            data.NotificationId = null;
            data.Save();
        }

        [TestMethod]
        public void TestMuteNotification()
        {
            if (data.NotificationId.HasValue == false)
                throw new Exception("There is no notification id in the test data to use for this test");

            client.MuteNotification(data.NotificationId.Value, 60*60);
        }

        [TestMethod]
        public void TestUnmuteNotification()
        {
            if (data.NotificationId.HasValue == false)
                throw new Exception("There is no notification id in the test data to use for this test");

            client.UnmuteNotification(data.NotificationId.Value);
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
            if (data.PlaceId.HasValue == false)
                throw new Exception("There is no place id in the test data to use for this test");

            PlaceModel place = client.GetPlaceById(data.PlaceId.Value);
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
            data.PlaceId = place.PlaceId;
            data.Save();
            Assert.IsNotNull(place);
        }

        [TestMethod]
        public void TestEditPlace()
        {
            if (data.PlaceId.HasValue == false)
                throw new Exception("There is no place id in the test data to use for this test");

            client.EditPlace(data.PlaceId.Value, new PlaceEditModel()
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
            if (data.PlaceId.HasValue == false)
                throw new Exception("There is no place id in the test data to use for this test");

            client.DeletePlace(data.PlaceId.Value);
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
            IMEIConfigDetailModel device = client.GetDeviceById(data.IMEIConfigId);
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


        [TestMethod]
        public void TestGetFleets()
        {
            IEnumerable<CompanyModel> fleets = client.GetFleets();
            Assert.IsNotNull(fleets);
        }

        [TestMethod]
        public void TestGetFleetById()
        {
            CompanyDetailModel fleetDetail = client.GetFleetById(3331);
            Assert.IsNotNull(fleetDetail);
        }

        [TestMethod]
        public void TestEditFleet()
        {
            client.EditFleet(3331, new CompanyEditModel()
            {
                Description = "Test",
                RegisteredCompanyName = "Automile Palo Alto Fleet"
            });
        }

        [TestMethod]
        public void TestCreateFleet()
        {
           var newFleet = client.CreateFleet(new CompanyCreateModel()
            {
                CreateRelationshipToContactId = 2,
                Description = "Some good description for the fleet",
                RegisteredCompanyName = "My new fleet"
            });

            Assert.IsNotNull(newFleet);
        }


        [TestMethod]
        public void TestGetNotificationMessages()
        {
            IEnumerable<TriggerMessageHistoryModel> messages = client.GetNotificationMessages();
            Assert.IsNotNull(messages);
        }

        [TestMethod]
        public void TestGetNotificationMessageById()
        {
            IEnumerable<TriggerMessageHistoryModel> messages = client.GetNotificationMessagesByNotificationId(148638);
            Assert.IsNotNull(messages);
        }


        [TestMethod]
        public void TestGetVehicleGeofences()
        {
            IEnumerable<VehicleGeofenceModel> vehicleGeofences = client.GetVehicleGeofencesByGeofenceId(3276);
            Assert.IsNotNull(vehicleGeofences);
        }

        [TestMethod]
        public void TestGetVehicleGeofenceById()
        {
            VehicleGeofenceModel vehicleGeofence = client.GetVehicleGeofenceById(44251);
            Assert.IsNotNull(vehicleGeofence);
        }

        [TestMethod]
        public void TestCreateVehicleGeofence()
        {
            VehicleGeofenceModel newVehicleGeofence = client.CreateVehicleGeofence(new VehicleGeofenceCreateModel()
            {
                GeofenceId = 3276,
                VehicleId = data.VehicleId,
                ValidFrom = null,
                ValidTo = null
            });

            Assert.IsNotNull(newVehicleGeofence);
        }

        [TestMethod]
        public void TestEditVehicleGeofence()
        {
            client.EditVehicleGeofence(44251, new VehicleGeofenceEditModel()
            {
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddDays(30)
            });
        }

        [TestMethod]
        public void TestDeleteVehicleGeofence()
        {
            client.DeleteVehicleGeofence(46942);
        }



        [TestMethod]
        public void TestGetVehiclePlaces()
        {
            IEnumerable<VehiclePlaceModel> vehiclePlaces = client.GetVehiclePlacesByPlaceId(10977);
            Assert.IsNotNull(vehiclePlaces);
        }

        [TestMethod]
        public void TestGetVehiclePlaceById()
        {
            VehiclePlaceModel vehiclePlace = client.GetVehiclePlaceById(30567);
            Assert.IsNotNull(vehiclePlace);
        }

        [TestMethod]
        public void TestCreateVehiclePlace()
        {
            VehiclePlaceModel newVehiclePlace = client.CreateVehiclePlace(new VehiclePlaceCreateModel()
            {
                PlaceId = 10977,
                VehicleId = data.VehicleId,
                Description = "Some description",
                Radius = 100,
                TripType = ApiTripType.Business,
                TripTypeTrigger = ApiTripTypeTrigger.Start
            });

            Assert.IsNotNull(newVehiclePlace);
        }

        [TestMethod]
        public void TestEditVehiclePlace()
        {
            client.EditVehiclePlace(35575, new VehiclePlaceEditModel()
            {
                Description = "Some description",
                Radius = 100,
                TripType = ApiTripType.Business,
                TripTypeTrigger = ApiTripTypeTrigger.Start
            });
        }

        [TestMethod]
        public void TestDeleteVehiclePlace()
        {
            client.DeleteVehiclePlace(35575);
        }

    }
}
