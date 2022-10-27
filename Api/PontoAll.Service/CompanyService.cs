using PontoAll.Models.Companys;
using PontoAll.Models.User;
using PontoAll.Service.Interfaces;
using PontoAll.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service
{

    public class CompanyService : ICompanyService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }

        public async Task RegisterCompany(Company company)
        {
            await _companyRepository.RegisterCompany(company);
        }

        public async Task RegisterCompanyAdmin(ApplicationUser admin, string password)
        {
            await _userRepository.RegisterAdmin(admin, password);
        }

        public async Task<List<Company>> FindCompanyByIdentityData(CompanyInputModel companyInputModel)
        {
            var companies = await _companyRepository.FindCompanyByIdentityData(companyInputModel);

            return companies;
        }
    }

}
