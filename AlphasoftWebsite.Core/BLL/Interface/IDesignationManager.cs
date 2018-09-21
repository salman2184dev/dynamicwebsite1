using System.Collections.Generic;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IDesignationManager
    {
        Message AddOrEdit(Designation designation);
        IEnumerable<Designation> GetAllDesignations();
        Message Delete(int designationId);
        Designation GetADesignation(int designationId);
    }
}