using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.ApplicationService.Implementation;
using Events.Core.DomainService;
using Events.Core.Entites;
using Moq;
using Xunit;

namespace Events.Core.Test
{
    public class CompanyTest
    {
        [Fact]
        public void PassNullAsICompanyRepository_ThrowsNullRefException()
        {
            ICompanyRepository cRepo = null;
            Assert.Throws<NullReferenceException>(() => new CompanyService(cRepo));
        }

        [Fact]
        public void TestCreateCompanyBehaviour()
        {
            Mock<ICompanyRepository> mock = new Mock<ICompanyRepository>();

            CompanyService cService = new CompanyService(mock.Object);

            Company c = new Company
            {
                CompanyName = "Test Company",
                CompanyCode = 123,
                isCash = true,
                EventId = 1,
                AdditionalInfo = "First Test Company"
            };
            cService.CreateCompany(c);

            mock.Verify(mock => mock.CreateCompany(c), Times.Once);
        }

        [Fact]
        public void TestGetAllCompaniesBehaviour()
        {
            Mock<ICompanyRepository> mock = new Mock<ICompanyRepository>();

            Company[] returnValue = {
                        new Company
                        {
                        CompanyName = "Test Company",
                        CompanyCode = 123,
                        isCash = true,
                        EventId = 1,
                        AdditionalInfo = "First Test Company"
                        },
                        new Company
                        {
                        CompanyName = "Test Company",
                        CompanyCode = 123,
                        isCash = true,
                        EventId = 1,
                        AdditionalInfo = "First Test Company"
                        }};

            mock.Setup(mock => mock.GetAllCompanies()).Returns(() => returnValue.ToList());

            CompanyService cService = new CompanyService(mock.Object);
            
            cService.GetAllCompanies();

            mock.Verify(mock => mock.GetAllCompanies(), Times.Once);
        }

        [Fact]
        public void TestGetCompanyByIdBehaviour()
        {
            Mock<ICompanyRepository> mock = new Mock<ICompanyRepository>();

            Company[] companyList = {
                        new Company{
                        Id = 2,
                        CompanyName = "Test Company",
                        CompanyCode = 123,
                        isCash = true,
                        EventId = 1,
                        AdditionalInfo = "First Test Company"
                        },
                        new Company
                        {
                        Id = 3,
                        CompanyName = "Second Test Company",
                        CompanyCode = 12345,
                        isCash = true,
                        EventId = 1,
                        AdditionalInfo = "Second Test Company"
                        }};

            mock.Setup(mock => mock.GetCompanyById(2)).Returns(() => companyList[0]);

            CompanyService cService = new CompanyService(mock.Object);

            cService.GetCompanyById(2);

            mock.Verify(mock => mock.GetCompanyById(2), Times.Once);
        }

        [Fact]
        public void TestDeleteCompanyBehaviour()
        {
            Mock<ICompanyRepository> mock = new Mock<ICompanyRepository>();

            Company[] companyList = {
                        new Company{
                        Id = 2,
                        CompanyName = "Test Company",
                        CompanyCode = 123,
                        isCash = true,
                        EventId = 1,
                        AdditionalInfo = "First Test Company"
                        },
                        new Company
                        {
                        Id = 3,
                        CompanyName = "Second Test Company",
                        CompanyCode = 12345,
                        isCash = true,
                        EventId = 1,
                        AdditionalInfo = "Second Test Company"
                        }};

            mock.Setup(mock => mock.DeleteCompany(2)).Returns(() => companyList[0]);

            CompanyService cService = new CompanyService(mock.Object);

            Company companyToDelete = cService.DeleteCompany(2);

            mock.Verify(mock => mock.DeleteCompany(2), Times.Once);
        }
    }
}
