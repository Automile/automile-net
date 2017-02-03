using System.Collections.Generic;
using System.Xml.Serialization;

namespace Automile.Net
{
    [XmlRoot(ElementName = "getJourneys")]
    public class ContractTripsModel
    {
        [XmlElement("return")]
        public List<ContractTrip> ContractTrip { get; set; }
    }

    public class ContractTrip
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("contractId")]
        public int ContractId { get; set; }
        
        [XmlElement("firstStreet")]
        public string FirstStreet { get; set; }

        [XmlElement("endStreet")]
        public string EndStreet { get; set; }

        [XmlElement("startDate")]
        public string StartDate { get; set; }

        [XmlElement("endDate")]
        public string EndDate { get; set; }

        [XmlElement("startTime")]
        public string StartTime { get; set; }

        [XmlElement("endTime")]
        public string EndTime { get; set; }

        [XmlElement("licensePlate")]
        public string LicensePlate { get; set; }

        [XmlElement("kilometers")]
        public decimal? Kilometers { get; set; }

        [XmlElement("companyId")]
        public int CompanyId { get; set; }

        [XmlElement("employeeId")]
        public string EmployeeId { get; set; }

        [XmlElement("contractNotes")]
        public string ContractNotes { get; set; }

    }

    [XmlRoot(ElementName = "getMyContractsResponse")]
    public class ContractsModel
    {
        [XmlElement("return")]
        public List<int> Contacts { get; set; }
    }
}
