using sitesatis.Models.entity;
using sitesatis.Models.repository.manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sitesatis.Controllers
{
    public class HomeController : Controller
    {
        homeviewmodel homeview = new homeviewmodel();
        categorymanager category = new categorymanager();
        productmanager product = new productmanager();
        menumanager menu = new menumanager();

        public ActionResult Index()
        {
            homeview.homeproduct = product.read();
            homeview.homecategoriy = category.read();
            homeview.homemenu = menu.read();


            return View(homeview);
        }
        public ActionResult filtre(int id)
        {
           var dd = product.filtre(x => x.category_id == id);
            homeview.homeproduct = dd;
            homeview.homecategoriy = category.read();
            homeview.homemenu = menu.read();
            return View(homeview);
        }
        public ActionResult search(string search)
        {
            var dd = product.filtre(x => x.product_name.Contains(search));
            homeview.homeproduct = dd;
            homeview.homecategoriy = category.read();
            homeview.homemenu = menu.read();
            return View(homeview);
        }

        public ActionResult About()
        {
            
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
    public class homeviewmodel
    {
        public IEnumerable<product> homeproduct { get; set; }
        public IEnumerable<category> homecategoriy { get; set; }
        public IEnumerable<Models.entity.menu> homemenu { get; set; }
    }
}