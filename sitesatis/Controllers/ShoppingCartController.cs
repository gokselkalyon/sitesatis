using sitesatis.Models.entity;
using sitesatis.Models.repository.manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sitesatis.Controllers
{
    public class ShoppingCartController : Controller
    {
        menumanager menum = new menumanager();
        shopcartmodel shopm = new shopcartmodel();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            shopm.menu = menum.read();
            return View(shopm);
        }
    }
    public class shopcartmodel
    {
        public IEnumerable<Models.entity.menu> menu { get; set; }
    }
}