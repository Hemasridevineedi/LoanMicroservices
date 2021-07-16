using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementMicroservice.Models
{
    public class Collateral_Realestate
    {
        [Key] 
        public int LoanID { get; set; }
        public int CollateralId { get; set; }
        public string CollateralType { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public double CurrentValue { get; set; }
        public double Rate { get; set; }
        public double DepreciationRate { get; set; }
    }
}
