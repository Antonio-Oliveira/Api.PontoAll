using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost("RegisterCollaborator")]
        public async Task<ActionResult<CollaboratorViewModel>> RegisterCollaborator(CollaboratorInputModel collaboratorInputModel)
        {
            try
            {
                //or if u want the list of claims
                var claims = User.Claims;

                //string[] rolesuserbelongto = Roles.GetRolesForUser();

                var collaborator = await _userFacade.RegisterCollaborador(collaboratorInputModel);



                return Created("", collaborator);
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }

    }
}
