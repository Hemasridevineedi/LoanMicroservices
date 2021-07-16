using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementMicroservice.Models
{
    public class Loan
    {
        [Key]
        public string LoanProducts{ get; set; }
        public double MaximumLoaneligible { get; set; }
        public int interest { get; set; }
        public int Tenure { get; set; }
        public string TypeofCollateralAccepted { get; set; }
    }
}
