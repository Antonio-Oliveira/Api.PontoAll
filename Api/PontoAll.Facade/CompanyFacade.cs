using PontoAll.Facade.Interfaces;
using PontoAll.Models;
using PontoAll.Models.Companys;
using PontoAll.Models.Dtos;
using PontoAll.Models.User;
using PontoAll.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            var cleanCNPJ = ClearDocument(companyInputModel.CNPJ);

            var company = new Company()
            {
                CNPJ = cleanCNPJ,
                CorporateName = companyInputModel.CorporateName,
                FantasyName = companyInputModel.FantasyName,
                Email = companyInputModel.Email,
                PhoneNumber = companyInputModel.PhoneNumber,
                CompanyId = Guid.NewGuid()
            };
            
            var companyId = await _companyService.RegisterCompany(company);

            return companyId;
        }

        private string ClearDocument(string document)
        {
            string pattern = @"(?i)[\-*\.*\\*\/*\s*]";

            string replacement = string.Empty;

            Regex rgx = new Regex(pattern);

            string cleanDocument = rgx.Replace(document, replacement);

            return cleanDocument;
        }
    }
}
