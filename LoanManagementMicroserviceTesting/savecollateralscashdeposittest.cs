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
    public class savecollateralscashdeposittest
    {
        Task<string> s;
        static List<Collateral_CashDeposits> obj1 = new List<Collateral_CashDeposits>()
        {
            new Collateral_CashDeposits{ LoanID = 8, Collateralid = 8 , CollateralType = "CashDeposit", ownername = "Amaira", BankName = "SBI", CurrentValue = 10000, InterestRate = 1, DepositAmount = 100000, LockPeriod = 4 }
        };
        static List<Collateral_CashDeposits> obj2 = new List<Collateral_CashDeposits>()
        {
            new Collateral_CashDeposits{ LoanID = 9, Collateralid = 9 , CollateralType = "CashDeposit", ownername = "Aman", BankName = "SBI", CurrentValue = 1000, InterestRate = 10, DepositAmount = 10000, LockPeriod = 2 }
        };
        static List<Collateral_CashDeposits> obj3 = new List<Collateral_CashDeposits>()
        {
            new Collateral_CashDeposits{ LoanID = -1, Collateralid = 8 , CollateralType = "CashDeposit", ownername = "Amaira", BankName = "SBI", CurrentValue = 10000, InterestRate = 1, DepositAmount = 100000, LockPeriod = 4 }
        };
        static List<Collateral_CashDeposits> obj4 = new List<Collateral_CashDeposits>()
        {
            new Collateral_CashDeposits{ LoanID = -2, Collateralid = 9 , CollateralType = "CashDeposit", ownername = "Aman", BankName = "SBI", CurrentValue = 1000, InterestRate = 10, DepositAmount = 10000, LockPeriod = 2 }
        };
        [SetUp]
        public void Setup()
        {
        }
        [TestCaseSource("obj1")]
        [TestCaseSource("obj2")]
        public void RepositoryPasssavecashcollateral(Collateral_CashDeposits c)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            var loanRepoObject = new LoanManagementRepository(context);
            loanContextMock.Setup(x => x.saveCollaterals_CashDeposit(c)).Returns(s);
            var loandetails = loanRepoObject.saveCollaterals_CashDeposit(c);
            Assert.IsNotNull(loandetails);
        }

        [TestCaseSource("obj3")]
        [TestCaseSource("obj4")]
        public void RepositoryFailsavecashcollateral(Collateral_CashDeposits c)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            var loanRepoObject = new LoanManagementRepository(context);
            loanContextMock.Setup(x => x.saveCollaterals_CashDeposit(c)).Returns(s);
            var loandetails = loanRepoObject.saveCollaterals_CashDeposit(c);
            Assert.IsNotNull(loandetails);
        }

        [TestCaseSource("obj1")]
        [TestCaseSource("obj2")]
        public void ControllerTestPasssavecashCollateral(Collateral_CashDeposits c)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            loanContextMock.Setup(p => p.saveCollaterals_CashDeposit(c)).Returns(s);
            LoanManagementController pc = new LoanManagementController(loanContextMock.Object);
            var loanDetails = pc.saveCollaterals_CashDeposit(c);
            Assert.IsNotNull(loanDetails);
        }

        [TestCaseSource("obj3")]
        [TestCaseSource("obj4")]
        public void ControllerTestFailsavecashCollateral(Collateral_CashDeposits c)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            loanContextMock.Setup(p => p.saveCollaterals_CashDeposit(c)).Returns(s);
            LoanManagementController pc = new LoanManagementController(loanContextMock.Object);
            var loanDetails1 = pc.saveCollaterals_CashDeposit(c) as IActionResult;
            var loanDetails = pc.saveCollaterals_CashDeposit(c);
            Assert.AreNotEqual(loanDetails, loanDetails1);
        }
    }
}
