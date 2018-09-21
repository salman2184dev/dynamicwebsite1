using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Utility;

namespace AlphasoftWebsite.Core.BLL.Interface
{
    public interface IIconListManager
    {
        Message AddOrEdit(IconList iconList);
        IEnumerable<IconList> GetAllIconList();
        Message Delete(int iconId);
        IconList GetAnIconList(int iconId);
    }
}
