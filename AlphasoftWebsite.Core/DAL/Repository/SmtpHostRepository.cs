using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class SmtpHostRepository: ISmtpHostRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public SmtpHostRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddOrEdit(SmtpHost smtpHost)
        {
            if (smtpHost.SmtpHostId == 0)
            {
                string password = new EncryptionDecryption().Encrypt(smtpHost.UserName,smtpHost.Password);
                smtpHost.Password = password;

                smtpHost.CreatedBy = "Ayesha";
                smtpHost.CreatedDate = DateTime.Now;
                _dbContext.SmtpHosts.Add(smtpHost);
            }
            else
            {
                string password = new EncryptionDecryption().Encrypt(smtpHost.UserName, smtpHost.Password);
                smtpHost.Password = password;

                smtpHost.UpdatedBy = "Ayesha";
                smtpHost.UpdatedDate = DateTime.Now;
                _dbContext.Entry(smtpHost).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int smtpHostId)
        {
            var smtpHost = _dbContext.SmtpHosts.FirstOrDefault(x => x.SmtpHostId == smtpHostId);
            if (smtpHost != null)
            {
                _dbContext.SmtpHosts.Remove(smtpHost);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<SmtpHost> GetAllSmtpHost()
        {
            var smtpHostList = _dbContext.SmtpHosts.ToList();
            return smtpHostList;
        }

        public SmtpHost GetASmtpHost(int smtpHostId)
        {
            var smtpHost = _dbContext.SmtpHosts.Include(a=>a.HostType).FirstOrDefault(x => x.SmtpHostId == smtpHostId);
            if (smtpHost != null)
            {
                string encryptedPassword = smtpHost.Password;
                string password = new EncryptionDecryption().Decrypt(smtpHost.UserName, encryptedPassword);
                smtpHost.Password = password;
            }
            return smtpHost;
        }
    }
}
