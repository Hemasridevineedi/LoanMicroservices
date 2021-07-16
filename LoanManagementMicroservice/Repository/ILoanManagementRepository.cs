using LoanManagementMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagementMicroservice.Repository
{
    public interface ILoanManagementRepository 
    {
        public IEnumerable<Customer_Loan> getLoanDetails(int LoanID, int CustomerID);
        public Task<string> saveCollaterals_RealEstate(Collateral_Realestate c);
        public Task<string> saveCollaterals_CashDeposit(Collateral_CashDeposits c);
    }
}
