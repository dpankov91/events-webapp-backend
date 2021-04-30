using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.DomainService;
using Events.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Data.Repositories
{
    public class CompanySQLRepository : ICompanyRepository
    {
        private readonly EventAppDBContext _ctx;

        public CompanySQLRepository(EventAppDBContext eventAppDBContext)
        {
            _ctx = eventAppDBContext;
        }

        public List<Company> GetAllCompanies()
        {
            return _ctx.Companies.ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _ctx.Companies.FirstOrDefault(company => company.Id == id);
        }

        public Company CreateCompany(Company company)
        {
            _ctx.Companies.Attach(company).State = EntityState.Added;
            _ctx.SaveChanges();
            return company;
        }

        public Company DeleteCompany(int id)
        {
            var companyToDelete = _ctx.Companies.Remove(new Company { Id = id });
            _ctx.SaveChanges();
            return companyToDelete.Entity;
        }

        public Company UpdateCompany(Company companyToUpdate)
        {
            _ctx.Companies.Attach(companyToUpdate).State = EntityState.Modified;
            _ctx.SaveChanges();
            return companyToUpdate;
        }
    }
}
