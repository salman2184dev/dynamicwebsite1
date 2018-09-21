using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlphasoftWebsite.Core.DAL.Interface;
using AlphasoftWebsite.Core.Model;

namespace AlphasoftWebsite.Core.DAL.Repository
{
    public class IconListRepository : IIconListRepository
    {
        public static AlphasoftWebsiteContext _dbContext;

        public IconListRepository(AlphasoftWebsiteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int AddOrEdit(IconList iconList)
        {
            if (iconList.IconId == 0)
            {
                iconList.CreatedDate = DateTime.Now;
                iconList.UpdatedDate = DateTime.Now;
                iconList.CreatedBy = 1;
                iconList.UpdatedBy = 1;
                _dbContext.IconLists.Add(iconList);
            }
            else
            {
                iconList.UpdatedBy = 1;
                iconList.UpdatedDate = DateTime.Now;
                _dbContext.Entry(iconList).State = EntityState.Modified;
            }

            return _dbContext.SaveChanges();
        }

        public int Delete(int iconId)
        {
            var iconList = _dbContext.IconLists.FirstOrDefault(x => x.IconId == iconId);
            if (iconList != null)
            {
                _dbContext.IconLists.Remove(iconList);
            }

            return _dbContext.SaveChanges();
        }

        public IEnumerable<IconList> GetAllIconList()
        {
            var iconList = _dbContext.IconLists.ToList();
            return iconList;
        }

        public IconList GetAnIconList(int iconId)
        {
            var iconList = _dbContext.IconLists.FirstOrDefault(x => x.IconId == iconId);
            return iconList;
        }
    }
}
