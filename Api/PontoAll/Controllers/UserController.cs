using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Dtos;
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
        public async Task<ActionResult> RegisterCollaborator(CollaboratorInputModel collaboratorInputModel)
        {
            try
            {
                
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }

    }
}
