using sitesatis.Models.entity;
using sitesatis.Models.repository.manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sitesatis.Controllers
{
    public class ProductdetailpageController : Controller
    {
        productmanager pm = new productmanager();
        Viewmodel vm = new Viewmodel();
        // GET: Productdetailpage
        public ActionResult Index(int id)
        {
            vm.product = pm.filterread(x=>x.id == id);
            return View(vm);
        }
    }
    public class Viewmodel
    {
        public product product { get; set; }
    }
}