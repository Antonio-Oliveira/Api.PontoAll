using PontoAll.Models.Companys;
using PontoAll.Models.Dtos;
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

        public async Task<Guid> RegisterCompany(Company company)
        {
            var companyId = await _companyRepository.RegisterCompany(company);

            return companyId;
        }

        public async Task<List<Company>> FindCompanyByIdentityData(CompanyInputModel companyInputModel)
        {
            var companies = await _companyRepository.FindCompanyByIdentityData(companyInputModel);

            return companies;
        }
    }

}
