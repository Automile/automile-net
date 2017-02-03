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
    
        [TestInitialize]
        public void Initialize()
        {
            client = new AutomileClient(@"c:\temp\token.json");
        }

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
    }
}
