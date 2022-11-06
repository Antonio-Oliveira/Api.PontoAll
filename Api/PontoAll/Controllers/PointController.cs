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
    [Authorize]
    public class PointController : ControllerBase
    {
        private readonly IPointFacade _pointFacade;

        public PointController(IPointFacade pointFacade)
        {
            _pointFacade = pointFacade;
        }


        [HttpPost]
        public async Task<ActionResult<PointViewModel>> RegisterPoint(PointInputModel pointInputModel) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("Informações inválidas");
                }

                var claims = User.Claims;

                var point = _pointFacade.RegisterPointAsync(pointInputModel, claims);

                return Created("", null);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
