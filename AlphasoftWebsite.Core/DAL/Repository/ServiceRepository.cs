using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
 
    public class ServiceRepository : IServiceRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public ServiceRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(Service service)
        {
            if (service.ServiceId == 0)
            {
                service.CreatedDate = DateTime.Now;
                service.UpdatedDate = DateTime.Now;
                service.CreatedBy = 1;
                service.UpdatedBy = 1;
                _dbContext.Services.Add(service);
            }
            else
            {
                service.UpdatedBy = 1;
                service.UpdatedDate = DateTime.Now;
                _dbContext.Entry(service).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }


        public int Delete(int serviceId)
        {
            var service = _dbContext.Services.FirstOrDefault(x => x.ServiceId == serviceId);
            if (service != null)
            {
                _dbContext.Services.Remove(service);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<Service> GetAllService()
        {
            var serviceList = _dbContext.Services.Include(a => a.IconList).ToList();
            return serviceList;
        }

        public Service GetAService(int serviceId)
        {
            var service = _dbContext.Services.Include(a => a.IconList).FirstOrDefault(x => x.ServiceId == serviceId);
            return service;
        }
    }
}
