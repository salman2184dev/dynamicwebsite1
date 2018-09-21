using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
    public interface ISmtpHostRepository
    {
        int AddOrEdit(SmtpHost smtpHost);
        IEnumerable<SmtpHost> GetAllSmtpHost();
        int Delete(int smtpHostId);
        SmtpHost GetASmtpHost(int smtpHostId);
    }
}
