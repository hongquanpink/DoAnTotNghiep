using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Data.Framework;

namespace Model_Data.Dao
{
    public class ProductCategoryDao
    {
        BanNoiThatDbContext1 db = null;
        public ProductCategoryDao()
        {
            db = new BanNoiThatDbContext1();
        }

        public List<ProductCategory> ListAll()
        {
            return db.ProductCategory.Where(x => x.Status == true).OrderBy(x => x.DisPlayOrder).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategory.Find(id);
        }


    }
}
