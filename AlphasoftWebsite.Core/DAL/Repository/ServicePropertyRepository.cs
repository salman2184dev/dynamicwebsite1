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
    public class ServicePropertyRepository : IServicePropertyRepository
    {

        public static AlphasoftWebsiteContext _dbContext;

        public ServicePropertyRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddOrEdit(ServiceProperty serviceProperty)
        {
            if (serviceProperty.ServicePropertyId == 0)
            {
                serviceProperty.CreatedDate = DateTime.Now;
                serviceProperty.UpdatedDate = DateTime.Now;
                serviceProperty.CreatedBy = 1;
                serviceProperty.UpdatedBy = 1;
                _dbContext.ServiceProperties.Add(serviceProperty);
            }
            else
            {
                serviceProperty.UpdatedBy = 1;
                serviceProperty.UpdatedDate = DateTime.Now;
                _dbContext.Entry(serviceProperty).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int servicePropertyId)
        {
            var serviceProperty = _dbContext.ServiceProperties.FirstOrDefault(x => x.ServicePropertyId == servicePropertyId);
            if (serviceProperty != null)
            {
                _dbContext.ServiceProperties.Remove(serviceProperty);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<ServiceProperty> GetAllServiceProperty()
        {
            var servicePropertiesList = _dbContext.ServiceProperties.Include(a => a.Service).ToList();
            return servicePropertiesList;
        }

        public ServiceProperty GetAServiceProperty(int servicePropertyId)
        {
            var service = _dbContext.ServiceProperties.Include(a => a.Service).FirstOrDefault(x => x.ServicePropertyId == servicePropertyId);
            return service;
        }
    }
}
