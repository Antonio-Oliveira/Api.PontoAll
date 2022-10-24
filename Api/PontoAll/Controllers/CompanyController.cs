using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoAll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyFacade _companyFacade;

        public CompanyController(ICompanyFacade companyFacade)
        {
            _companyFacade = companyFacade;
        }


        public async Task<IActionResult> RegisterCompany(CompanyInputModel companyInputModel)
        {
            try
            {
                await _companyFacade.RegisterCompany(companyInputModel);
                return Ok();
            }
            catch (Exception err)
            {
                return Conflict(err.Message);
            }
        }

    }
}
