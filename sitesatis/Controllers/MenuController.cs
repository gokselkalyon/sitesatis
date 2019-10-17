using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using sitesatis.business.helper;
using sitesatis.Models.entity;
using sitesatis.Models.repository.abstracti;
using sitesatis.Models.repository.manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sitesatis.Controllers
{
    public class MenuController : Controller
    {
        menumanager menum = new menumanager();
        menuview mv = new menuview();
        // GET: category


        public ActionResult Index(int? id)
        {
            int page;
            if (id != null)
            {
                page = id.Value;
            }
            else
            { page = 0; }

            mv._Menu = menum.read().Skip(page).Take(10).ToList();//.Skip(page).ToList();
            mv.pagelist1 = mv._Menu.Count() / 10;

            return View(mv);
        }



        // POST: Product/Create
        public ActionResult create()
        {
            mv._Menu = menum.read();
            return View(mv);
        }
        public ActionResult tara()
        {
            var td = filehelper.sitepagecreate(Server.MapPath("~/Views/"),new sitepage { });
            return View(td);
        }

        [HttpPost]
        public ActionResult Create(menu _menu)
        {

            try
            {
                menum.create(new menu
                {
                    menu_link_name = _menu.menu_link_name,
                    sitepage = _menu.sitepage
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(menu _menu)
        {

            menum.update(new menu
            {
                menu_link_name = _menu.menu_link_name,
                sitepage = _menu.sitepage
            });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                mv._Menu = menum.read();
                return View(mv);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                menum.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
    public class menuview
    {
        public IEnumerable<menu> _Menu { get; set; }
        public menu _menu { get; set; }
        public int pagelist1 { get; set; }
    }

}