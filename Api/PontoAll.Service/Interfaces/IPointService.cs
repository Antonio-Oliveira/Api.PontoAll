using PontoAll.Models.Points;
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

        Task<Point> GetCurrentPointAsync(DateTime dateNow);
    }
}
