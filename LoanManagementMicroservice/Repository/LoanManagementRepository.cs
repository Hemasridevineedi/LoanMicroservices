using LoanManagementMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
namespace LoanManagementMicroservice.Repository
{
    public class LoanManagementRepository : ILoanManagementRepository
    {
        private static LoanDBContext _context;

        public LoanManagementRepository(LoanDBContext context)
        {
            _context = context;
            if (_context.customerLoans.Any())
            {
                return;
            }
            _context.customerLoans.AddRange(

            new Customer_Loan { Loan_ProductID = 1, LoanID = 1, CustomerID = 101, LoanPrincipal = 100000, Tenure = 1, Interest = 2, EMI = 5000, CollateralID = 1},
            new Customer_Loan { Loan_ProductID = 2, LoanID = 2, CustomerID = 102, LoanPrincipal = 200000, Tenure = 2, Interest = 4, EMI = 10000, CollateralID = 2 },
            new Customer_Loan { Loan_ProductID = 3, LoanID = 3, CustomerID = 103, LoanPrincipal = 300000, Tenure = 3, Interest = 6, EMI = 15000, CollateralID = 3 },
            new Customer_Loan { Loan_ProductID = 4, LoanID = 4, CustomerID = 104, LoanPrincipal = 400000, Tenure = 4, Interest = 8, EMI = 20000, CollateralID = 4 },
            new Customer_Loan { Loan_ProductID = 5, LoanID = 5, CustomerID = 105, LoanPrincipal = 500000, Tenure = 5, Interest = 10, EMI = 25000, CollateralID = 5 },
            new Customer_Loan { Loan_ProductID = 6, LoanID = 6, CustomerID = 106, LoanPrincipal = 600000, Tenure = 6, Interest = 12, EMI = 30000, CollateralID = 6 }

                );
            _context.customers.AddRange(
            new Customer { CustomerID = 1, Name = "Sean", Address = "New York", PhoneNumber = "1234567890"},
            new Customer { CustomerID = 2, Name = "Alice", Address = "Mumbai", PhoneNumber = "1334567890" },
            new Customer { CustomerID = 3, Name = "Kiara", Address = "guntur", PhoneNumber = "1224567890" },
            new Customer { CustomerID = 4, Name = "Skylar", Address = "London", PhoneNumber = "1244567890" },
            new Customer { CustomerID = 5, Name = "Nick", Address = "Paris", PhoneNumber = "1235567890" },
            new Customer { CustomerID = 6, Name = "Nathan", Address = "US", PhoneNumber = "1234667890" }

                );
            _context.loans.AddRange(
            new Loan { LoanProducts = "Car-Loan", MaximumLoaneligible = 100000, interest = 5, Tenure = 1, TypeofCollateralAccepted = "Real Estate"},
            new Loan { LoanProducts = "Credit-Card", MaximumLoaneligible = 200000, interest = 10, Tenure = 2, TypeofCollateralAccepted = "Deposit" },
            new Loan { LoanProducts = "Home-Loan", MaximumLoaneligible = 300000, interest = 15, Tenure = 3, TypeofCollateralAccepted = "Real Estate" }
            //new Loan { Loan_Products = "Deposit", Maximum_Loan_eligible = 400000, interest = 20, Tenure = 4, Type_of_Collateral_Accepted = "Deposit" },
            //new Loan { Loan_Products = "Real-estate", Maximum_Loan_eligible = 500000, interest = 25, Tenure = 5, Type_of_Collateral_Accepted = "Real Estate" },
            //new Loan { Loan_Products = "Deposit", Maximum_Loan_eligible = 600000, interest = 30, Tenure = 6, Type_of_Collateral_Accepted = "Deposit" }
                );
            _context.SaveChanges();
        }
        public IEnumerable<Customer_Loan> getLoanDetails(int LoanID, int CustomerID)
        {
            var a = _context.customerLoans.Where(p => p.LoanID == LoanID && p.CustomerID == CustomerID);
            if (a != null)
            {
                    return a;
            }
            return null;
        }
        public async Task<string> saveCollaterals_CashDeposit(Collateral_CashDeposits c)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    //client.BaseAddress = new Uri("https://localhost:44357/api/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = new HttpResponseMessage();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");
                    response = await client.PostAsJsonAsync(new Uri("https://localhost:44357/api/Collateral/saveColletral_CashDeposit/"), c);
                    string collateralStatus = response.Content.ReadAsStringAsync().Result;
                    return collateralStatus;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public async Task<string> saveCollaterals_RealEstate(Collateral_Realestate c)
        {
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(clientHandler))
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = new HttpResponseMessage();
                    StringContent content = new StringContent(JsonConvert.SerializeObject(null), Encoding.UTF8, "application/json");
                    response = await client.PostAsJsonAsync(new Uri("https://localhost:44357/api/Collateral/saveColletral_Realestate/"), c);
                    string collateralStatus = response.Content.ReadAsStringAsync().Result;

                    return collateralStatus;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
