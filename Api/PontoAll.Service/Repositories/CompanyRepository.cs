using Microsoft.EntityFrameworkCore;
using PontoAll.Models.Companys;
using PontoAll.Service.Data.Context;
using PontoAll.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> FindCompanyByIdentityData(CompanyInputModel companyInputModel)
        {
            var companies = await _context.Companies 
                .Where(c => c.CNPJ == companyInputModel.CNPJ || c.CorporateName == companyInputModel.CorporateName || c.FantasyName == companyInputModel.FantasyName || c.Email == companyInputModel.Email)
                .ToListAsync();

            return companies;
        }

        public async Task<Guid> RegisterCompany(Company company)
        {
            _context.Companies.Add(company);

            await _context.SaveChangesAsync();

            return company.CompanyId;
        }
    }
}
