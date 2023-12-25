using Model_Data.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Data.Dao
{
    public class CategoryDao
    {
        BanNoiThatDbContext1 db = null;
        public CategoryDao()
        {
            db = new BanNoiThatDbContext1();
        }

        public IEnumerable<ProductCategory> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<ProductCategory> model = db.ProductCategory;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public long Insert(ProductCategory cate)
        {
            db.ProductCategory.Add(cate);
            db.SaveChanges();
            return cate.ID;
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategory.Find(id);
        }

        public bool Update(ProductCategory entity)
        {
            try
            {
                var category = db.ProductCategory.Find(entity.ID);
                category.Name = entity.Name;
                category.MetaTitle = entity.MetaTitle;
                category.CreatedBy=entity.CreatedBy;
                category.Status = entity.Status;
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var category = db.ProductCategory.Find(id);
                db.ProductCategory.Remove(category);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
