using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        // GET: Designation        
        public static AlphasoftWebsiteContext _dbContext;

        public DesignationRepository(AlphasoftWebsiteContext dbContext)
        {           
            _dbContext = dbContext;
        }

        public IEnumerable<Designation> GetAllDesignations()
        {
            var designationList = _dbContext.Designations.ToList();
            return designationList;
        }

        public int AddOrEdit(Designation designation)
        {
            if (designation.DesignationId == 0)
            {
                designation.CreatedDate = DateTime.Now;
                designation.UpdatedDate = DateTime.Now;
                designation.CreatedBy = 1;
                designation.UpdatedBy = 1;
                _dbContext.Designations.Add(designation);
            }
            else
            {
                designation.UpdatedBy = 1;
                designation.UpdatedDate = DateTime.Now;
                _dbContext.Entry(designation).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int designationId)
        {
            var designation = _dbContext.Designations.FirstOrDefault(x => x.DesignationId == designationId);
            if (designation != null)
            {
                _dbContext.Designations.Remove(designation);
            }

            return _dbContext.SaveChanges();
            ;
        }

        public Designation GetADesignation(int designationId)
        {
            var designation = _dbContext.Designations.FirstOrDefault(x => x.DesignationId == designationId);
            return designation;
        }
    }
}