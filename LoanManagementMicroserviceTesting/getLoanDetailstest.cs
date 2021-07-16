using LoanManagementMicroservice.Controllers;
using LoanManagementMicroservice.Models;
using LoanManagementMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace LoanManagementMicroserviceTesting
{
    public class Tests
    {
        Customer_Loan customer_Loan = new Customer_Loan();
        List<Customer_Loan> dataObject = new List<Customer_Loan>();
        [SetUp]
        public void Setup()
        {
            dataObject = new List<Customer_Loan>()
            {
            new Customer_Loan { Loan_ProductID = 1, LoanID = 1, CustomerID = 101, LoanPrincipal = 100000, Tenure = 1, Interest = 2, EMI = 5000, CollateralID = 1 },
            new Customer_Loan { Loan_ProductID = 2, LoanID = 2, CustomerID = 102, LoanPrincipal = 200000, Tenure = 2, Interest = 4, EMI = 10000, CollateralID = 2 }
            };
        }


        [TestCase(1, 101)]
        [TestCase(2, 102)]
        public void RepositoryPassgetLoanDetails(int LoanID, int CustomerID)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            var loanRepoObject = new LoanManagementRepository(context);
            loanContextMock.Setup(x => x.getLoanDetails(LoanID, CustomerID)).Returns(dataObject);
            var loandetails = loanRepoObject.getLoanDetails(LoanID, CustomerID);
            Assert.IsNotNull(loandetails);
        }


        [TestCase(1, 102)]
        [TestCase(5, 7)]
        public void RepositoryFailgetLoanDetails(int LoanID, int CustomerID)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Customer_Loan customerLoan = new Customer_Loan();
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            var loanRepoObject = new LoanManagementRepository(context);
            loanContextMock.Setup(x => x.getLoanDetails(LoanID, CustomerID)).Returns(dataObject);
            var loanDetails = loanRepoObject.getLoanDetails(LoanID, CustomerID);
            Assert.IsEmpty(loanDetails);
        }

        [TestCase(1, 101)]
        [TestCase(2, 102)]
        public void ControllerTestPassgetLoanDetails(int LoanID, int CustomerID)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            loanContextMock.Setup(p => p.getLoanDetails(LoanID, CustomerID)).Returns(dataObject);
            LoanManagementController pc = new LoanManagementController(loanContextMock.Object);
            var loanDetails = pc.getLoanDetails(LoanID, CustomerID);
            OkObjectResult res = (OkObjectResult)loanDetails;
            Assert.IsNotNull(res);
        }

        [TestCase(-1, -11)]
        [TestCase(12, 24)]
        public void ControllerTestFailgetLoanDetails(int LoanID, int CustomerID)
        {
            var option = new DbContextOptionsBuilder<LoanDBContext>().UseInMemoryDatabase(databaseName: "LoanManagementMicroservice").Options;
            var context = new LoanDBContext(option);
            Mock<ILoanManagementRepository> loanContextMock = new Mock<ILoanManagementRepository>();
            loanContextMock.Setup(p => p.getLoanDetails(LoanID, CustomerID)).Returns(dataObject);
            LoanManagementController pc = new LoanManagementController(loanContextMock.Object);
            var result1 = pc.getLoanDetails(LoanID, CustomerID) as IEnumerable<Customer_Loan>;
            var result = pc.getLoanDetails(LoanID, CustomerID);
            //OkObjectResult res = (OkObjectResult)result;
            Assert.AreNotEqual(result, result1);
        }
    }
}