using PontoAll.Models.Points;
using PontoAll.Service.Interfaces;
using PontoAll.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service
{
    public class PointService : IPointService
    {
        private readonly IPointRepository _pointRepository;

        public PointService(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        public async Task<Point> GetCurrentPointAsync(DateTime dateNow)
        {
            throw new Exception("");
        }

        public async Task<Guid> RegisterAddressPointAsync(AddressPoint addressPoint)
        {
            var addressPointId = await _pointRepository.RegisterAddressPointAsync(addressPoint);

            return addressPointId;
        }

        public async Task RegisterPointAsync(Point point)
        {
            await _pointRepository.RegisterPointAsync(point);
        }

        public async Task<Point> VerifyLastPointCurrentDateAsync(DateTime datePoint)
        {
            var lastPointCurrentDate = await _pointRepository.VerifyLastPointCurrentDateAsync(datePoint);

            return lastPointCurrentDate;
        }
    }
}
