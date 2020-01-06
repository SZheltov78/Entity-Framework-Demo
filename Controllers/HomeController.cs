using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkDemo.BLL.Interfaces;
using EntityFrameworkDemo.BLL.ViewModels;
using EntityFrameworkDemo.DAL;
using EntityFrameworkDemo.DAL.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    public class HomeController : Controller
    {       
        IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {         
            return View();
        }
       
        public JsonResult Load()
        {
            var res = _userService.Laod();
            return Json(res);
        }

        [HttpPost]        
        public JsonResult Update([FromBody] UserForm userForm)
        {
            var res = _userService.Update(userForm);
            return Json(res);
        }

        [HttpPost]
        public JsonResult Delete([FromBody] UserForm userForm)
        {
            var res = _userService.Delete(userForm);
            return Json(res);            
        }

        public JsonResult Add()
        {
            var res = _userService.AddNewEmptyRow();
            return Json(res);
        }
        
    }
}