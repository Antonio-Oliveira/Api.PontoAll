using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Companys;
using PontoAll.Models.Dtos;
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
        private readonly IUserFacade _userFacade;

        public CompanyController(ICompanyFacade companyFacade, IUserFacade userFacade)
        {
            _companyFacade = companyFacade;
            _userFacade = userFacade;
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

                var companyId = await _companyFacade.RegisterCompany(companyInputModel);
                await _userFacade.RegisterAdminForCompanyAsync(companyInputModel, companyId);

                return Ok();
            }
            catch (Exception err)
            {
                return Conflict(err.Message);
            }
        }

    }
}
