using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PontoAll.Facade.Interfaces;
using PontoAll.Models.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PontoAll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PointController : ControllerBase
    {
        private readonly IPointFacade _pointFacade;

        public PointController(IPointFacade pointFacade)
        {
            _pointFacade = pointFacade;
        }


        [HttpPost("RegisterPoint")]
        public async Task<ActionResult<PointViewModel>> RegisterPoint(IFormFile photo, [FromForm] string jsonData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Informações inválidas");
                }

                var pointInputModel = JsonConvert.DeserializeObject<PointInputModel>(jsonData);

                pointInputModel.UserPhotograph = photo;

                var claims = User.Claims;

                var point = await _pointFacade.RegisterPointAsync(pointInputModel, claims);

                return Created("", point);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("GetCurrentPoint")]
        public async Task<ActionResult<PointViewModel>> GetCurrentPoint()
        {
            try
            {
                var claims = User.Claims;

                var point = await _pointFacade.GetCurrentPointAsync(claims);

                return Ok(point);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("GetPoints")]
        public async Task<ActionResult<UserPointViewModel>> GetPoints()
        {
            try
            {
                var claims = User.Claims;

                var point = await _pointFacade.GetPointsAsync(claims);

                return Ok(point);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("GetCollaboratorPoints")]
        public async Task<ActionResult<UserPointViewModel>> GetCollaboratorPoint([FromQuery][EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")] string collaboratorEmail)
        {
            try
            {
                var collaboratorPoints = await _pointFacade.GetCollaboratorPointsAsync(collaboratorEmail);

                return Ok(collaboratorPoints);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }


    }
}
