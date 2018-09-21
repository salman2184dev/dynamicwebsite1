using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface ISmtpHostManager
    {
        Message AddOrEdit(SmtpHost smtpHost);
        IEnumerable<SmtpHost> GetAllSmtpHost();
        Message Delete(int smtpHostId);
        SmtpHost GetASmtpHost(int smtpHostId);
    }
}
