using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Companys;
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


        [HttpPost("RegisterCompany")]
        public async Task<IActionResult> RegisterCompany([FromBody] CompanyInputModel companyInputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Informações inválidas");
                }

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
