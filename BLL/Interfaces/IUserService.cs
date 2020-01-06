using EntityFrameworkDemo.BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.BLL.Interfaces
{
    public interface IUserService
    {
        public object AddNewEmptyRow();
        public object Update(UserForm userForm);
        public object Delete(UserForm userForm);
        public object Laod();
    }
}
