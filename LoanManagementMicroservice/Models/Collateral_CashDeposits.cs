using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementMicroservice.Models
{
    public class Collateral_CashDeposits
    {
        [Key] 
        public int LoanID { get; set; }
        public int Collateralid { get; set; }
        public string CollateralType { get; set; }
        public string ownername { get; set; }
        public string BankName { get; set; }
        public double CurrentValue { get; set; }
        public int InterestRate { get; set; }
        public double DepositAmount { get; set; }
        public int LockPeriod { get; set; }
    }
}
