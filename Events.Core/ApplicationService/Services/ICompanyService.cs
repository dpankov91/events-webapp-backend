using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Core.Entites;

namespace Events.Core.ApplicationService.Services
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();

        Company GetCompanyById(int id);

        Company CreateCompany(Company company);

        Company DeleteCompany(int id);

        Company UpdateCompany(Company companyToUpdate);
    }
}
