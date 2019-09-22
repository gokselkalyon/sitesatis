using sitesatis.Models.entity;
using sitesatis.Models.repository.manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sitesatis.Controllers
{
    public class autorizationController : Controller
    {
        // GET: autorization

        autorizationview av = new autorizationview();
        autorizationmanger autorizationm = new autorizationmanger();
        public ActionResult Readghj()
        {
            av.autorization = autorizationm.read();
            return View(av);
        }
    }
    public class autorizationview
    {
       public IEnumerable<autorization> autorization { get; set; }
    }
}