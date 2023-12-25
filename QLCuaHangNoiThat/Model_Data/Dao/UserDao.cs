using Common;
using Model_Data.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Data.Dao
{
    public class UserDao
    { 
        BanNoiThatDbContext1 db = null;
        public UserDao()
        {
            db = new BanNoiThatDbContext1();
        }
        public long Insert (User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page,int pageSize)
        {
            IQueryable<User> model = db.User;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public User GetById(string userName)
        {
            return db.User.SingleOrDefault(x=>x.UserName==userName);
        }

        public User ViewDetail(long id)
        {
            return db.User.Find(id);
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.ID);
                user.UserName = entity.UserName;
                user.Name = entity.Name;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                db.SaveChanges();

                return true;
            }
            catch(Exception )
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();

                return true;
            }
            catch(Exception )
            {
                return false;
            }
        }

        //public int Login(string userName, string passWord)
        //{
        //    var result = db.User.SingleOrDefault(x=> x.UserName == userName);
        //    if(result.PassWord == passWord) //result == null
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        if(result == null) //result.Status == null
        //        {
        //            return 1;
        //        }
        //        else
        //        {
        //            //if (result.Status == null) //result.PassWord == passWord
        //            return -1;
                    
        //        }
        //    }
        //}

        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP  )
                    {
                        if (result.PassWord == passWord) //result == null
                        {
                            return 1;
                        }
                        if (result == null) //result.Status == null
                        {
                            return 1;
                        }
                        else
                        {
                            //if (result.Status == null) //result.PassWord == passWord
                            return -1;

                        }
                    }
                    else if (result.GroupID == CommonConstants.MOD_GROUP)
                    {
                        if (result.PassWord == passWord) //result == null
                        {
                            return 1;
                        }
                        if (result == null) //result.Status == null
                        {
                            return 1;
                        }
                        else
                        {
                            //if (result.Status == null) //result.PassWord == passWord
                            return -1;

                        }
                    }
                    else
                    {
                        return -2;
                    }
                }
                else if(isLoginAdmin ==false)
                {
                    if (result.PassWord == passWord) //result == null
                    {
                        return 1;
                    }
                    if (result == null) //result.Status == null
                    {
                        return 1;
                    }
                    else
                    {
                        //if (result.Status == null) //result.PassWord == passWord
                        return -1;

                    }
                }
                else 
                {
                    if (result.PassWord == passWord) //result == null
                    {
                        return 1;
                    }
                    if (result == null) //result.Status == null
                    {
                        return 1;
                    }
                    else
                    {
                        //if (result.Status == null) //result.PassWord == passWord
                        return -1;

                    }
                }
            }
        }

        public bool CheckUserName(string userName)
        {
            return db.User.Count(x => x.UserName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.User.Count(x => x.Email == email) > 0;
        }

        public List<string> GetListCredential(string userName)
        {
            var user = db.User.Single(x => x.UserName == userName);
            var data = (from a in db.Credential
                        join b in db.UserGroup on a.UserGroupID equals b.ID
                        join c in db.Role on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }

    }
}
