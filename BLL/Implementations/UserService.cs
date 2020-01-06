using EntityFrameworkDemo.BLL.Interfaces;
using EntityFrameworkDemo.BLL.ViewModels;
using EntityFrameworkDemo.DAL;
using EntityFrameworkDemo.DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.BLL.Implementations
{
    public class UserService : IUserService
    {
        private Context _context;
        public UserService(Context context)
        {
            _context = context;
        }
        public object AddNewEmptyRow()
        {
            User user = new User();
            user.Name = "";
            user.Phone = "";

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                var model = _context.Users;
                return new { result = "ok", data = model };
            }
            catch
            {
                return new { result = "Database error." };
            }

        }

        public object Delete(UserForm userForm)
        {
            if (userForm == null) return new { result = "Data is empty." };

            int id = int.Parse(userForm.Id);
            if (id <= 0) return new { result = "Id wrong." };

            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null) return new { result = "User is not found." };

            _context.Users.Remove(user);
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return new { result = "Database error." };
            }

            return new { result = "ok" };
        }

        public object Laod()
        {
            try
            {
                var model = _context.Users;
                return new { result = "ok", data = model };
            }
            catch
            {
                return new { result = "Database error.", data = "" };
            }
        }

        public object Update(UserForm userForm)
        {
            if (userForm == null) return new { result = "Parameters is empty." };

            int id = int.Parse(userForm.Id);
            if (id == 0 || id < 0) return new { result = "Id wrong." };

            var user = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null) return new { result = "User is not find." };

            if (userForm.Name == "Name")
            {
                user.Name = userForm.Value;
            }

            if (userForm.Name == "Phone")
            {
                user.Phone = userForm.Value;
            }

            try
            {
                _context.SaveChanges();
            }
            catch
            {
                return new { result = "Database error." };
            }

            return new { result = "ok" };
        }
    }
}
