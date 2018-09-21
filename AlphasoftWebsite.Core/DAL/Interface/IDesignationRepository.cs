using System.Collections.Generic;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface IDesignationRepository
    {
        int AddOrEdit(Designation designation);
        IEnumerable<Designation> GetAllDesignations();
        int Delete(int designationId);
        Designation GetADesignation(int designationId);
    }
}