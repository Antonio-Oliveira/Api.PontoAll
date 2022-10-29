using PontoAll.Facade.Interfaces;
using PontoAll.Models;
using PontoAll.Models.Companys;
using PontoAll.Models.User;
using PontoAll.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade
{
    public class CompanyFacade : ICompanyFacade
    {
        private readonly ICompanyService _companyService;

        public CompanyFacade(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<Guid> RegisterCompany(CompanyInputModel companyInputModel)
        {
            var companies = await _companyService.FindCompanyByIdentityData(companyInputModel);

            if (companies.Count != default(int)) 
            {
                throw new Exception(Constants.ERRO_COMPANY_DATA_EXISTS);
            }

            var company = new Company()
            {
                CNPJ = companyInputModel.CNPJ,
                CorporateName = companyInputModel.CorporateName,
                FantasyName = companyInputModel.FantasyName,
                Email = companyInputModel.Email,
                PhoneNumber = companyInputModel.PhoneNumber,
                CompanyId = Guid.NewGuid()
            };
            
            var companyId = await _companyService.RegisterCompany(company);

            return companyId;
        }
    }
}
