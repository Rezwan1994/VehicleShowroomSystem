using Demo.Entity;
using Demo.Facade;
using Demo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {

        Demo.Facade.UserFacade userFacade = null;
        public HomeController()
        {
            DataContext Context = DataContext.getInstance();

            userFacade = new Demo.Facade.UserFacade(Context);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
        public ActionResult SuccessLogIn()
        {
            return View();
        }
        public JsonResult LoginAjax(LoginUserModel loginModel)
        {
            bool result = false;
            try
            {
                List<User> userlist = userFacade.GetAll();
                if (!string.IsNullOrEmpty(loginModel.Email) || !string.IsNullOrEmpty(loginModel.Password))
                {
                    foreach (var item in userlist)
                    {
                        if ((item.Email == loginModel.Email) && (item.Password == loginModel.Password))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Json(new { result = result });
        }
    }
}