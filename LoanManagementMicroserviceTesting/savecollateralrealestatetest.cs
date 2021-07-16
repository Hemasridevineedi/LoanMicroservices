using LoanManagementMicroservice.Controllers;
using LoanManagementMicroservice.Models;
using LoanManagementMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementMicroserviceTesting
{
    public class savecollateralrealestatetest
    {
        Task<string> s;
        static List<Collateral_Realestate> obj1 = new List<Collateral_Realestate>()
        {
            new Collateral_Realestate{ LoanID = 8, CollateralId = 8 , CollateralType = "CashDeposit", OwnerName = "Amaira", Address = "Chennai", CurrentValue = 10000, Rate = 1, DepreciationRate = 100000}
        };
        static List<Collateral_Realestate> obj2 = new List<Collateral_Realestate>()
        {
                        new Collateral_Realestate{ LoanID = 9, CollateralId = 9 , CollateralType = "CashDeposit", OwnerName = "Aman", Address = "SBI", CurrentValue = 1000, Rate = 10, DepreciationRate = 10000}
        };
        static List<Collateral_Realestate> obj3 = new List<Collateral_Realestate>()
        {
            new Collateral_Realestate{ LoanID = -1, CollateralId = 8 , CollateralType = "CashDeposit", OwnerName = "Amaira", Address = "Chennai", CurrentValue = 10000, Rate = 1, DepreciationRate = 100000}
        };
        static List<Collateral_Realestate> obj4 = new List<Collateral_Realestate>()
        {
            new Collateral_Realestate{ LoanID = -2, CollateralId = 9 , CollateralType = "CashDeposit", OwnerName = "Aman",  Address = "SBI", CurrentValue = 1000, Rate = 10, DepreciationRate = 10000}
        };
        [SetUp]
        public void Setup()
        {

        }
        [TestCaseSource("obj1")]
        [TestCaseSource("obj2")]
        public void RepositoryPasssaverealestatecollateral(Collateral_Realestate r)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            var loanRepoObject = new LoanManagementRepository(context);
            _ = loanContextMock.Setup(x => x.saveCollaterals_RealEstate(r)).Returns(s);
            var loandetails = loanRepoObject.saveCollaterals_RealEstate(r);
            Assert.IsNotNull(loandetails);
        }

        [TestCaseSource("obj3")]
        [TestCaseSource("obj4")]
        public void RepositoryFailsaverealestatecollateral(Collateral_Realestate r)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            var loanRepoObject = new LoanManagementRepository(context);
            loanContextMock.Setup(x => x.saveCollaterals_RealEstate(r)).Returns(s);
            var loandetails = loanRepoObject.saveCollaterals_RealEstate(r);
            Assert.IsNotNull(loandetails);
        }

        [TestCaseSource("obj1")]
        [TestCaseSource("obj2")]
        public void ControllerTestPasssaverealestateCollateral(Collateral_Realestate r)
        {

            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            loanContextMock.Setup(p => p.saveCollaterals_RealEstate(r)).Returns(s);
            LoanManagementController pc = new LoanManagementController(loanContextMock.Object);
            var loanDetails = pc.saveCollaterals_RealEstate(r);
            Assert.IsNotNull(loanDetails);
        }

        [TestCaseSource("obj3")]
        [TestCaseSource("obj4")]
        public void ControllerTestFailsaverealestateCollateral(Collateral_Realestate r)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            loanContextMock.Setup(p => p.saveCollaterals_RealEstate(r)).Returns(s);
            LoanManagementController pc = new LoanManagementController(loanContextMock.Object);
            var loanDetails1 = pc.saveCollaterals_RealEstate(r) as IActionResult;
            var loanDetails = pc.saveCollaterals_RealEstate(r);
            Assert.AreNotEqual(loanDetails, loanDetails1);
        }
    }
}
