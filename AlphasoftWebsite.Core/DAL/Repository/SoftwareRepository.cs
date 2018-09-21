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
    public class SoftwareRepository : ISoftwareRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public SoftwareRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(Software software)
        {
            if (software.SoftwareId == 0)
            {
                software.CreatedDate = DateTime.Now;
                software.UpdatedDate = DateTime.Now;
                software.CreatedBy = 1;
                software.UpdatedBy = 1;
                _dbContext.Softwares.Add(software);
            }
            else
            {
                software.UpdatedBy = 1;
                software.UpdatedDate = DateTime.Now;
                _dbContext.Entry(software).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

    

        public int Delete(int softwareId)
        {
            var software = _dbContext.Softwares.FirstOrDefault(x => x.SoftwareId == softwareId);
            if (software != null)
            {
                _dbContext.Softwares.Remove(software);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<Software> GetAllSoftware()
        {

            var softwareList = _dbContext.Softwares.Include(a => a.SoftwareCategory).ToList();
            return softwareList;
        }


        public Software GetASoftware(int softwareId)
        {
            var software = _dbContext.Softwares.Include(a => a.SoftwareCategory).FirstOrDefault(x => x.SoftwareId == softwareId);
            return software;
        }

    }
}
