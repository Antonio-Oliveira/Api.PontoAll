using PontoAll.Models.Dtos;
using PontoAll.Models.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Facade.Interfaces
{
    public interface IPointFacade
    {
        Task<PointViewModel> RegisterPointAsync(PointInputModel pointInputModel, IEnumerable<Claim> claims);

        Task<PointViewModel> GetCurrentPointAsync(IEnumerable<Claim> claims);

        Task<List<PointViewModel>> GetPointsAsync(IEnumerable<Claim> claims);
    }
}
