﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                if (!ModelState.IsValid)
                {
                    throw new Exception("Informações inválidas");
                }

                var claims = User.Claims;

                var collaborator = await _userFacade.RegisterCollaborador(collaboratorInputModel, claims);

                return Created("", collaborator);
            }
            catch (Exception err)
            {
                return NotFound(err.Message);
            }
        }

    }
}
