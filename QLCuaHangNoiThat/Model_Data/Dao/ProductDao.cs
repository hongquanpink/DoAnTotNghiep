using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_Data.Framework;
using PagedList;

namespace Model_Data.Dao
{
    public class ProductDao
    {
        BanNoiThatDbContext1 db = null;
        public ProductDao()
        {
            db = new BanNoiThatDbContext1();
        }

        public List<Product> ListFeatureProduct(int top)
        {
            return db.Product.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Product.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public Product ViewDetail(long id)
        {
            return db.Product.Find(id);
        }

        public List<Product> ListRelateProduct(long productId)
        {
            var product = db.Product.Find(productId);
            return db.Product.Where(x=>x.ID != productId && x.CategoryID ==productId).ToList();
        }

        public List<Product> ListByCategoryId(long categoryId)
        {
            return db.Product.Where(x => x.CategoryID == categoryId).ToList();
        }

        public long Insert(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
            return product.ID;
        }

        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Product;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Product.Find(entity.ID);
                product.Name = entity.Name;
                product.MetaTitle = entity.MetaTitle;
                product.Discription = entity.Discription;
                product.Image = entity.Image;
                product.Price = entity.Price;
                product.Quantity = entity.Quantity;
                product.Status = entity.Status;
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
                var product = db.Product.Find(id);
                db.Product.Remove(product);
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
