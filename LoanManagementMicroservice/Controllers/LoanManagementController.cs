using LoanManagementMicroservice.Models;
using LoanManagementMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanManagementController : ControllerBase
    {
        public readonly ILoanManagementRepository _LoanRepository;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoanManagementController));
        public LoanManagementController(ILoanManagementRepository LoanRepository)
        {
            _LoanRepository = LoanRepository;
        }
        [HttpGet]
        [Route("getLoanDetails/{LoanID}/{CustomerID}")]
        public IActionResult getLoanDetails(int LoanID, int CustomerID)
        {
            try
            {
                if (LoanID > 0)
                {
                    var loanlist = _LoanRepository.getLoanDetails(LoanID, CustomerID);
                    return new OkObjectResult(loanlist);
                }
                else
                {
                    return BadRequest();
                }
                

            }
            catch (Exception)
            {
                return new NoContentResult();
            }
        }
        [HttpPost]
        [Route("saveCollaterals_CashDeposit")]
        public async Task<IActionResult> saveCollaterals_CashDeposit(Collateral_CashDeposits c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("saveCollaterals_CashDeposit Accesed");
                    string s = await _LoanRepository.saveCollaterals_CashDeposit(c);
                    return new OkObjectResult(s);
                }
                else
                {
                    _log4net.Info("Inputs given are not valid");
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in saveCollaterals_CashDeposit" + e.Message);
                return new NoContentResult();
            }
        }
        [HttpPost]
        [Route("saveCollaterals_RealEstate")]
        public async Task<IActionResult> saveCollaterals_RealEstate(Collateral_Realestate c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("saveCollaterals_RealEstate Accesed");
                    string s = await _LoanRepository.saveCollaterals_RealEstate(c);
                    return new OkObjectResult(s);
                }
                else
                {
                    _log4net.Info("Inputs given are not valid");
                    return BadRequest();
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in saveCollaterals_RealEstate" + e.Message);
                return new NoContentResult();
            }
        }
    }
}
