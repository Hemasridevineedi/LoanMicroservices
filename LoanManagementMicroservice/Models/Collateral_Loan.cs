using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CollateralsManagement.Models
{
    public class Collateral_Loan
    {
        
        [Key]
        public int LoanID { get; set; }
        public int CustomerID { get; set; }
        public int CollateralID { get; set; }
        public double CollateralValue { get; set; } 
        public DateTime  PledgedDate { get; set; }
    }
}
