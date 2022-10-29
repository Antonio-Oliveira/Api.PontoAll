using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoAll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserViewModel>> Login(LoginInputModel loginIM)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.Values.SelectMany(err => err.Errors));

                await _userFacade.Login(loginIM);
                var token = await _userFacade.CreateToken(loginIM.Email);

                /*
                var userVM = new UserViewModel()
                {
                    Email = loginIM.Email,
                    Token = token,
                };
                */

                return Ok(userVM);
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }

    }
}
