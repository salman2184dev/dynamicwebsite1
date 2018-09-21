using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.BLL.Interface;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.DAL.Repository;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Manager
{
    public class FactorHeaderManager : IFactorHeaderManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IFactorHeaderRepository _iFactorHeaderRepository;

        public FactorHeaderManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iFactorHeaderRepository = new FactorHeaderRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(FactorHeader factorHeader)
        {
            var message = new Message();
            var ID = factorHeader.FactorHeaderId;
            int result = _iFactorHeaderRepository.AddOrEdit(factorHeader);
            try
            {
                if (result > 0)
                {
                    if (Convert.ToInt32(ID) > 0)
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Updated Successfully!");
                    }
                    else
                    {
                        message = Message.SetMessages.SetSuccessMessage("Submission Successful!");
                    }

                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Could not be submitted!");
                }
            }
            catch (Exception e)
            {
                message = Message.SetMessages.SetWarningMessage(e.Message.ToString());
            }

            return message;
        }

        public Message Delete(int factorHeaderId)
        {
            var message = new Message();
            try
            {

                int result = _iFactorHeaderRepository.Delete(factorHeaderId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("factorHeader Deleted Successfully.");
                }
                else
                {
                    message = Message.SetMessages.SetErrorMessage("Failed to Delete Data.");
                }

            }
            catch (Exception ex)
            {
                message = Message.SetMessages.SetErrorMessage(ex.Message);
            }

            return message;
        }

        public IEnumerable<FactorHeader> GetAllFactorHeader()
        {

            try
            {

                var factorHeader = _iFactorHeaderRepository.GetAllFactorHeader();
                return factorHeader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FactorHeader GetFactorHeader(int factorHeaderId)
        {
            try
            {

                var factorHeader = _iFactorHeaderRepository.GetAFactorHeader(factorHeaderId);
                return factorHeader;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
