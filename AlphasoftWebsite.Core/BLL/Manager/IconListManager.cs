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
    public class IconListManager : IIconListManager
    {
        private readonly AlphasoftWebsiteContext _AlphasoftWebsiteContext;
        private readonly IIconListRepository _iIconListRepository;

        public IconListManager()
        {
            _AlphasoftWebsiteContext = new AlphasoftWebsiteContext();
            _iIconListRepository = new IconListRepository(_AlphasoftWebsiteContext);
        }

        public Message AddOrEdit(IconList iconList)
        {
            var message = new Message();
            var ID = iconList.IconId;
            int result = _iIconListRepository.AddOrEdit(iconList);
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

        public Message Delete(int iconId)
        {
            var message = new Message();
            try
            {

                int result = _iIconListRepository.Delete(iconId);

                if (result > 0)
                {
                    message = Message.SetMessages.SetSuccessMessage("IconList Deleted Successfully.");
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

        public IconList GetAnIconList(int iconId)
        {
            try
            {

                var icon = _iIconListRepository.GetAnIconList(iconId);
                return icon;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<IconList> GetAllIconList()
        {
            try
            {

                var iconList = _iIconListRepository.GetAllIconList();
                return iconList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
