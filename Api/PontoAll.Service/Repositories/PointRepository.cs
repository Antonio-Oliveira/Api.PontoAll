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

        public async Task<List<Point>> GetCollaboratorPointsAsync(string collaboratorEmail)
        {
            var points = await _context.Points.Include(p => p.ApplicationUser).Where(p => p.ApplicationUser.Email == collaboratorEmail).OrderByDescending(p => p.DatePoint).ToListAsync();

            return points;
        }

        public async Task<Point> GetCurrentPointAsync(DateTime dateNow, string userId)
        {
            var point = await _context.Points.Where(p => p.UserId == userId && p.DatePoint.Date == dateNow.Date).OrderByDescending(p => p.DatePoint).FirstOrDefaultAsync();

            return point;
        }

        public async Task<List<Point>> GetPointsAsync(string userId)
        {
            var points = await _context.Points.Where(p => p.UserId == userId).OrderByDescending(p => p.DatePoint).ToListAsync();

            return points;
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

        public async Task<Point> VerifyLastPointCurrentDateAsync(DateTime datePoint, string userId)
        {
            var currentPoints = await _context.Points.Where(p => p.DatePoint.Date == datePoint.Date && p.UserId == userId).OrderByDescending(p => p.DatePoint).FirstOrDefaultAsync();

            return currentPoints;
        }
    }
}
