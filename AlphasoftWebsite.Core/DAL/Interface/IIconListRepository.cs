using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Interface
{
   public interface IIconListRepository
    {
        int AddOrEdit(IconList iconList);
        IEnumerable<IconList> GetAllIconList();
        int Delete(int iconId);
        IconList GetAnIconList(int iconId);
    }
}
