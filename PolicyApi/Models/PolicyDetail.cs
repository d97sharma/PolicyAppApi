using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyApi.Models
{
    public class PolicyDetail
    {
        [Key]
        public int Policy_Id { get; set; }
        public string DateOfPurchase { get; set; }
        public int Customer_Id { get; set; }
        public string Fuel { get; set; }
        public string VehicleSegment { get; set; }
        [Range(0, 1000000, ErrorMessage = "Premium should be less than 1000000")]
        public int Premium { get; set; }
        public bool InjuryLiability { get; set; }
        public bool Personal { get; set; }
        public bool Property { get; set; }
        public bool Collision { get; set; }
        public bool Comprehensive { get; set; }
        public string Gender { get; set; }
        public string IncomeGroup { get; set; }
        public string CustomerRegion { get; set; }
        public bool MaritalStatus { get; set; }
    }
}
