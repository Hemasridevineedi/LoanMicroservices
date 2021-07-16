using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementMicroservice.Models
{
    public class Customer_Loan
    {
        public int Loan_ProductID { get; set; }

        [Key]
        public int LoanID { get; set; }
        public int CustomerID { get; set; }
        public double LoanPrincipal { get; set; }
        public int Tenure { get; set; }
        public int Interest { get; set; }
        public double EMI { get; set; }
        public int CollateralID { get; set; }
    }
}
