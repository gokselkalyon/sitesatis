using sitesatis.business.helper;
using sitesatis.Models.entity;
using sitesatis.Models.repository.manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace sitesatis.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(user _user)
        {
            Session["log_in"] = new Login().login_successfull(_user.user_name, _user.user_password);
            if (Session["log_in"].ToString() == "basarili_giris")
            {
               usermanager User = new usermanager();
               user userinfo = User.filterread(x=> x.user_name == _user.user_name && x.user_password == _user.user_password);
                if (userinfo !=null)
                {
                    Session["usernanme"] = userinfo.user_name;
                    Session["userautorization"] = userinfo.autorization.autorization_name;
                    if (Session["kullaniniadi"].ToString() == "admin")
                    {

                    }
                    else
                        return RedirectToAction("profile");
                }
                
                
            }
            else
            return RedirectToAction("Index");
        }
        
        public ActionResult login()
        {
            return RedirectToAction("Index");
        }

        public class loginAttribute : Attribute
        {
            public loginAttribute(string ss)
            {

            }
        }

        public ActionResult profile()
        {
            string isim = "0";
            if (Session["kullaniniadi"] != null && Session["log_in"].ToString() == "true")
            {
                isim = Session["kullaniniadi"].ToString();
            }
            
            return View(model:isim);
        }
    }
}