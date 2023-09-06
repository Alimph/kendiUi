using Carwash.Entities;
using Carwash.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Carwash.Services
{
    public interface IMainService
    {
        Task CreateService(ServiceModel model);
        Task<List<SelectListItem>> GetAllCars();
        IQueryable<ServiceModel> GetAllServices();  
        Task CompletedService(long id);  
    }

    public class MainService : IMainService
    {
        private readonly AppDbContext _context;

        public MainService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompletedService(long id)
        {
           var service=await _context.Set<Service>().FirstOrDefaultAsync(x=>x.Id==id);
            service.IsCompleted=true;
            _context.Update(service);
            await _context.SaveChangesAsync();
        }

        public async Task CreateService(ServiceModel model)
        {
            await _context.AddAsync(new Service
            {
                CarId = model.CarId,
                CustomerName = model.CustomerName,
                NumberPhone = model.NumberPhone,
                Time = DateTime.Now
            });
            await _context.SaveChangesAsync();
        }

        public async Task<List<SelectListItem>> GetAllCars()
        {
            return await _context.Set<Car>().Select(s => new SelectListItem
            {
                Text = s.Name,
                Value = s.Id.ToString()
            }).ToListAsync();
        }

        public IQueryable<ServiceModel> GetAllServices()
        {
            return _context.Set<Service>().Include(x => x.Car).Select(s => new ServiceModel
            {
                CarId = s.CarId,
                CarName = s.Car.Name,
                CustomerName = s.CustomerName,
                Id = s.Id,
                IsCompleted = s.IsCompleted,
                NumberPhone = s.NumberPhone,
                Time = ""
            });
        }
    }
}
