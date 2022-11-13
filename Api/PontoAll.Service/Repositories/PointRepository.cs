using Microsoft.EntityFrameworkCore;
using PontoAll.Models.Points;
using PontoAll.Service.Data.Context;
using PontoAll.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoAll.Service.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly AppDbContext _context;

        public PointRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> RegisterAddressPointAsync(AddressPoint addressPoint)
        {
            var result = _context.AddressPoint.Add(addressPoint);

            await _context.SaveChangesAsync();

            return result.Entity.AddressPointId;
        }

        public async Task RegisterPointAsync(Point point)
        {
            _context.Points.Add(point);

            await _context.SaveChangesAsync();
        }

        public async Task<Point> VerifyLastPointCurrentDateAsync(DateTime datePoint)
        {
            var currentPoints = await _context.Points.Where(p => p.DatePoint.Date == datePoint.Date).OrderByDescending(p => p.DatePoint).FirstOrDefaultAsync();

            return currentPoints;
        }
    }
}
