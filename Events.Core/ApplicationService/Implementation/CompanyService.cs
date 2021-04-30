using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.ApplicationService.Services;
using Events.Core.DomainService;
using Events.Core.Entites;

namespace Events.Core.ApplicationService.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepo = companyRepository;
        }

        public List<Company> GetAllCompanies()
        {
            return _companyRepo.GetAllCompanies();
        }

        public Company GetCompanyById(int id)
        {
            return _companyRepo.GetCompanyById(id);
        }

        public Company CreateCompany(Company company)
        {
            return _companyRepo.CreateCompany(company);
        }

        public Company DeleteCompany(int id)
        {
            return _companyRepo.DeleteCompany(id);
        }

        public Company UpdateCompany(Company companyToUpdate)
        {
            return _companyRepo.UpdateCompany(companyToUpdate);
        }
    }
}
