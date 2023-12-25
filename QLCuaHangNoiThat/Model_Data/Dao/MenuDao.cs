using Model_Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Data.Dao
{
    public class MenuDao
    {
        BanNoiThatDbContext1 db = null;
        public MenuDao()
        {
            db = new BanNoiThatDbContext1();
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menu.Where(x => x.TypeID == groupId).ToList();
        }

    }
}
