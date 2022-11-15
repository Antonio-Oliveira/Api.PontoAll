using PontoAll.Models.Points;
using PontoAll.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Interfaces
{
    public interface IPointService
    {
        Task<Point> VerifyLastPointCurrentDateAsync(DateTime datePoint);

        Task RegisterPointAsync(Point point);

        Task<Guid> RegisterAddressPointAsync(AddressPoint addressPoint);

        Task<Point> GetCurrentPointAsync(DateTime dateNow, string userId);

        Task<List<Point>> GetPointsAsync(string userId);

        Task<List<Point>> GetCollaboratorPointsAsync(string collaboratorEmail);
    }
}
