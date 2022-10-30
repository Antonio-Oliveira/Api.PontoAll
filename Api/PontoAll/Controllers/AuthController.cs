using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoAll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthFacade _authFacade;

        public AuthController(IAuthFacade authFacade)
        {
            _authFacade = authFacade;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginInputModel loginInputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(err => err.Errors));

                var token = await _authFacade.Login(loginInputModel);

                return Ok(token);
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }

    }
}
