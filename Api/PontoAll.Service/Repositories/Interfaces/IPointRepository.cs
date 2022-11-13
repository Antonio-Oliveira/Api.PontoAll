using PontoAll.Models.Points;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Repositories.Interfaces
{
    public interface IPointRepository
    {
        Task RegisterPointAsync(Point point);

        Task<Point> VerifyLastPointCurrentDateAsync(DateTime datePoint);

        Task<Guid> RegisterAddressPointAsync(AddressPoint addressPoint);
    }
}
