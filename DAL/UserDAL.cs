using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : IUserDAL
    {
        BartersDBContext bartersDBContext = new BartersDBContext();
        public List<User> GetAllUsers()
        {
            //select * from Users; 
            try
            {
                var Users = bartersDBContext.Users.ToList();
                return Users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserById(int id)
        {
            //select * from Users; 
            try
            {
                var User = bartersDBContext.Users.SingleOrDefault(x => x.Id == id);
                return User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public User GetUserByEmail(string email)
        {
            //select * from Users; 
            try
            {
                var User = bartersDBContext.Users.SingleOrDefault(x => x.Email == email);
                return User;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            //select * from Users; 
            try
            {
                var User = bartersDBContext.Users.SingleOrDefault(x => x.Email == email && x.Password == password);
                return User;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int AddUser(User user)
        {
            try
            {
                bartersDBContext.Users.Add(user);
                bartersDBContext.SaveChanges();
                return user.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteUser(int id)
        {
            try
            {
                CategoryUser CU = bartersDBContext.CategoryUsers.SingleOrDefault(x => x.UserId == id);
                bartersDBContext.CategoryUsers.Remove(CU);
                User user = bartersDBContext.Users.SingleOrDefault(x => x.Id == id);
                bartersDBContext.Users.Remove(user);
                bartersDBContext.SaveChanges();
                return true;
            }
                catch (Exception ex)
            {
                return false;
            }
        }
        public bool saveCategoryUserList(List<CategoryUser> CategoryUserList)
        {
            try
            {
                CategoryUserList.ForEach(cu => bartersDBContext.CategoryUsers.Add(cu));
                bartersDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUsers(int id, User user)
        {
            try
            {
                User user1 = bartersDBContext.Users.SingleOrDefault(x => x.Id == id);
                bartersDBContext.Entry(user1).CurrentValues.SetValues(user);
                bartersDBContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}

