using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Automile.Net
{
    public class VehicleCreateModel
    {
        public string NumberPlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public short? ModelYear { get; set; }
        public string BodyStyle { get; set; }
        public int? OwnerContactId { get; set; }
        public int? OwnerCompanyId { get; set; }

        [Required]
        public int? CreateRelationshipToId { get; set; }

        [Required]
        public VehicleRelationshipType? VehicleRelationshipType { get; set; }
   }


    public enum VehicleRelationshipType
    {
        VehicleToContact = 0,
        VehicleToCompany = 1
    }
}
