using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automile.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Automile.Net.Tests
{

    [TestClass]
    public class UnitTest1
    {
        private AutomileClient client;
        private int testVehicleId = 33553;
        private int testTripId = 31331100;
        private int testIMEIConfigId = 28288;
        private int testContactId = 2;
        private int testGeofenceId = 3276;
        private int testPlaceId = 2245;
        private int testCompanyId = 1;
        private int testTaskMessageId = 7194;
      

        [TestInitialize]
        public void Initialize()
        {
            //jens test pahome
            client = new AutomileClient(@"c:\temp\tokenavinash.json");
            
            // jens test paoffice
            //client = new AutomileClient(@"c:\temp\token_dev.json");

            // prod
           // client = new AutomileClient(@"c:\temp\token.json");

            
           
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

            Vehicle2DetailModel vehicle = client.GetVehicleById(vehicles.First().VehicleId);
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
            IEnumerable<TripModel> tripsLastDay = client.GetTrips(100);
            Assert.IsNotNull(tripsLastDay);
        }

        [TestMethod]
        public void TestGetTrip()
        {
            TripDetailModel trip = client.GetTripById(testTripId);
            Assert.IsNotNull(trip);
        }

        [TestMethod]
        public void TestGetTripStartStop()
        {
            TripStartEndGeoModel tripStartStop = client.GetTripStartStopLatitudeLongitude(testTripId);
            Assert.IsNotNull(tripStartStop);
        }

        [TestMethod]
        public void TestGetTripSpeed()
        {
            IEnumerable<VehicleSpeedModel> speed = client.GetTripSpeed(testTripId);
            Assert.IsNotNull(speed);
        }

        [TestMethod]
        public void TestGetTripRPM()
        {
            IEnumerable<RPMModel> rpm = client.GetTripRPM(testTripId);
            Assert.IsNotNull(rpm);
        }

        [TestMethod]
        public void TestGetTripAmbientTemperature()
        {
            IEnumerable<AmbientAirTemperatureModel> temp = client.GetTripAmbientTemperature(testTripId);
            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void TestGetFuel()
        {
            IEnumerable<FuelLevelInputModel> fuel = client.GetTripFuelLevel(testTripId);
            Assert.IsNotNull(fuel);
        }

        [TestMethod]
        public void TestGetEngineCoolantTemperature()
        {
            IEnumerable<EngineCoolantTemperatureModel> temp = client.GetTripEngineCoolantTemperature(testTripId);
            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void TestGetRawPIDs()
        {
            IEnumerable<PIDModel> pidData = client.GetTripPIDRaw(testTripId, 70);
            Assert.IsNotNull(pidData);
        }

        [TestMethod]
        public void TestGetTripLatitudeLongitude()
        {
            IEnumerable<TripGeoModel> geo = client.GeoTripLatitudeLongitude(testTripId, 1);
            Assert.IsNotNull(geo);
        }

        [TestMethod]
        public void TestGetTripDetails()
        {
            TripConcatenation tripCat = client.GetCompletedTripDetails(testTripId);
            Assert.IsNotNull(tripCat);
        }

        [TestMethod]
        public void TestGetTripDetailsAdvanced()
        {
            TripConcatenation tripCat = client.GetCompletedTripDetailsAdvanced(testTripId);
            Assert.IsNotNull(tripCat);
        }

        [TestMethod]
        public void TestGetContacts()
        {
            IEnumerable<Contact2Model> drivers = client.GetContacts();
            Assert.IsNotNull(drivers);

            Contact2DetailModel driver = client.GetContactById(drivers.First().ContactId);
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
            client.EditTrip(testTripId, new TripEditModel()
            {
                TripTags = new List<string> { "my notes" },
                TripType = ApiTripType.Business,
            });
        }

        [TestMethod]
        public void TestSetDriverOnTrip()
        {
            client.SetDriverOnTrip(testTripId, testContactId);
        }

        [TestMethod]
        public void TestGetGeofences()
        {
            IEnumerable<GeofenceModel> geofences = client.GetGeofences();
            Assert.IsNotNull(geofences);

            GeofenceModel geofence = client.GetGeofenceById(geofences.First().GeofenceId);
            Assert.IsNotNull(geofence);
        }

        [TestMethod]
        public void CreateGeofence()
        {
            GeofenceModel newGeofence = null;
            {
                var coordinates = new List<GeofencePolygon.GeographicPosition>();
                coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44666232, Longitude = -122.16905397 });
                coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4536707, Longitude = -122.16150999 });
                coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44873066, Longitude = -122.15365648 });
                coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4416096, Longitude = -122.16112375 });

                newGeofence = client.CreateGeofence(new GeofenceCreateModel()
                {
                    Name = "My Palo Alto geofence",
                    Description = "Outside main offfice",
                    VehicleId = 33553,
                    GeofencePolygon = new GeofencePolygon(coordinates),
                    GeofenceType = ApiGeofenceType.Outside,
                    Schedules = null // if you want to add a specific schedule
                });

                Assert.IsNotNull(newGeofence);
            }

            {
                var coordinates = new List<GeofencePolygon.GeographicPosition>();
                coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44666232, Longitude = -122.16905397 });
                coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4536707, Longitude = -122.16150999 });
                coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.44873066, Longitude = -122.15365648 });
                coordinates.Add(new GeofencePolygon.GeographicPosition() { Latitude = 37.4416096, Longitude = -122.16112375 });

                client.EditGeofence(newGeofence.GeofenceId, new GeofenceEditModel()
                {
                    Name = "My Palo Alto geofence",
                    Description = "Outside main offfice",
                    GeofencePolygon = new GeofencePolygon(coordinates),
                    GeofenceType = ApiGeofenceType.Outside,
                    Schedules = null // if you want to add a specific schedule
                });
            }

            client.DeleteGeofence(newGeofence.GeofenceId);
        }
        
        [TestMethod]
        public void TestGetNotifications()
        {
            IEnumerable<TriggerModel> notifications = client.GetNotifications();
            Assert.IsNotNull(notifications);

            var notification = client.GetNotificationById(notifications.First().TriggerId);
            Assert.IsNotNull(notification);
        }

     
        [TestMethod]
        public void TestCreateNotification()
        {
            var newNotification = client.CreateNotification(new TriggerCreateModel()
            {
                IMEIConfigId = testIMEIConfigId,
                TriggerType = ApiTriggerType.Accident,
                DestinationType = ApiDestinationType.Sms,
                DestinationData = "+14158320378"
            });

            Assert.AreEqual("+14158320378", newNotification.DestinationData);

            client.EditNotification(newNotification.TriggerId, new TriggerEditModel()
            {
                IMEIConfigId = testIMEIConfigId,
                TriggerType = ApiTriggerType.Accident,
                DestinationType = ApiDestinationType.Sms,
                DestinationData = "+14158320378"
            });

            client.MuteNotification(newNotification.TriggerId, 60 * 60);

            client.UnmuteNotification(newNotification.TriggerId);

            client.DeleteNotification(newNotification.TriggerId);
        }
      
        [TestMethod]
        public void TestGetPlaces()
        {
            IEnumerable<PlaceModel> places = client.GetPlaces();
            Assert.IsNotNull(places);

            PlaceModel place = client.GetPlaceById(places.First().PlaceId);
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

            client.EditPlace(place.PlaceId, new PlaceEditModel()
            {
                Name = "My place",
                Description = "My home",
                PositionPoint = new PositionPointModel() { Latitude = 37.445368, Longitude = -122.166608 },
                Radius = 100,
                TripType = ApiTripType.Business,
                TripTypeTrigger = ApiTripTypeTrigger.End
            });

            client.DeletePlace(place.PlaceId);
        }

    
        [TestMethod]
        public void TestGetDevices()
        {
            IEnumerable<IMEIConfigModel> devices = client.GetDevices();
            Assert.IsNotNull(devices);

            IMEIConfigDetailModel device = client.GetDeviceById(devices.First().IMEIConfigId);
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

            client.EditDevice(newDevice.IMEIConfigId, new IMEIConfigEditModel()
            {
                VehicleId = 33553
            });

            client.DeleteDevice(newDevice.IMEIConfigId);
        }


        [TestMethod]
        public void TestGetFleets()
        {
            IEnumerable<CompanyModel> fleets = client.GetFleets();
            Assert.IsNotNull(fleets);

            CompanyDetailModel fleetDetail = client.GetFleetById(fleets.First().CompanyId);
            Assert.IsNotNull(fleetDetail);
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

            client.EditFleet(newFleet.CompanyId, new CompanyEditModel()
            {
                Description = "Test",
                RegisteredCompanyName = "Automile Palo Alto Fleet"
            });

            client.DeleteFleet(newFleet.CompanyId);
        }


        [TestMethod]
        public void TestGetNotificationMessages()
        {
            IEnumerable<TriggerMessageHistoryModel> messages = client.GetNotificationMessages();
            Assert.IsNotNull(messages);

            IEnumerable<TriggerMessageHistoryModel> messagesForNotification = client.GetNotificationMessagesByNotificationId(messages.First().TriggerId);
            Assert.IsNotNull(messagesForNotification);
        }

     
        [TestMethod]
        public void TestGetVehicleGeofences()
        {
            IEnumerable<VehicleGeofenceModel> vehicleGeofences = client.GetVehicleGeofencesByGeofenceId(testGeofenceId);
            Assert.IsNotNull(vehicleGeofences);

            VehicleGeofenceModel vehicleGeofence = client.GetVehicleGeofenceById(vehicleGeofences.First().VehicleGeofenceId);
            Assert.IsNotNull(vehicleGeofence);
        }

        [TestMethod]
        public void TestCreateVehicleGeofence()
        {
            VehicleGeofenceModel newVehicleGeofence = client.CreateVehicleGeofence(new VehicleGeofenceCreateModel()
            {
                GeofenceId = testGeofenceId,
                VehicleId = testVehicleId,
                ValidFrom = null,
                ValidTo = null
            });

            Assert.IsNotNull(newVehicleGeofence);

            client.EditVehicleGeofence(newVehicleGeofence.VehicleGeofenceId, new VehicleGeofenceEditModel()
            {
                ValidFrom = DateTime.UtcNow,
                ValidTo = DateTime.UtcNow.AddDays(30)
            });

            client.DeleteVehicleGeofence(newVehicleGeofence.VehicleGeofenceId);
        }

    
        [TestMethod]
        public void TestGetVehiclePlaces()
        {
            IEnumerable<VehiclePlaceModel> vehiclePlaces = client.GetVehiclePlacesByPlaceId(testPlaceId);
            Assert.IsNotNull(vehiclePlaces);

            VehiclePlaceModel vehiclePlace = client.GetVehiclePlaceById(vehiclePlaces.First().VehiclePlaceId);
            Assert.IsNotNull(vehiclePlace);
        }

        [TestMethod]
        public void TestCreateVehiclePlace()
        {
            VehiclePlaceModel newVehiclePlace = client.CreateVehiclePlace(new VehiclePlaceCreateModel()
            {
                PlaceId = testPlaceId,
                VehicleId = testVehicleId,
                Description = "Some description",
                Radius = 100,
                TripType = ApiTripType.Business,
                TripTypeTrigger = ApiTripTypeTrigger.Start
            });

            Assert.IsNotNull(newVehiclePlace);

            client.EditVehiclePlace(newVehiclePlace.VehiclePlaceId, new VehiclePlaceEditModel()
            {
                Description = "Some description",
                Radius = 100,
                TripType = ApiTripType.Business,
                TripTypeTrigger = ApiTripTypeTrigger.Start
            });

            client.DeleteVehiclePlace(newVehiclePlace.VehiclePlaceId);
        }

      
        [TestMethod]
        public void TestGetDeviceEvents()
        {
            var events = client.GetDeviceEvents().ToList();
            Assert.IsNotNull(events);

            var first = events.First(i => i.EventType == "status");

            var ev = client.GetDeviceEventStatusById(first.IMEIEventId);
            Assert.IsNotNull(ev);
        }
        
        [TestMethod]
        public void TestGetFleetContacts()
        {
            IEnumerable<CompanyContactDetailModel> fleetContacts = client.GetFleetContacts();
            Assert.IsNotNull(fleetContacts);
            CompanyContactDetailModel details = client.GetFleetContactById(fleetContacts.First().CompanyContactId);
            Assert.IsNotNull(details);
            IEnumerable<CompanyContactDetailModel> fleetContactsForFleet = client.GetFleetContactsByFleetId(fleetContacts.First().CompanyId);
            Assert.IsNotNull(fleetContactsForFleet);
        }

        [TestMethod]
        public void TestCreateEditDeleteFleetContacts()
        {
            var newFleetContact = client.CreateFleetContact(new CompanyContactCreateModel()
            {
                CompanyId = testCompanyId,
                ContactId = 23
            });

            client.EditFleetContact(newFleetContact.CompanyContactId, new CompanyContactEditModel()
            {
                CompanyId = testCompanyId,
                ContactId = 23
            });

            client.DeleteFleetContact(newFleetContact.CompanyContactId);
        }
        [TestMethod]
        public void TestGetTaskMessage()
        {
            TaskMessageModel TaskMessage = client.GetByTaskMessageId(testTaskMessageId);
            Assert.IsNotNull(TaskMessage);
        }

    }
}
