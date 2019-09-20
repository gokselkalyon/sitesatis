using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using sitesatis.Models.entity;
using sitesatis.Models.repository.manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sitesatis.Controllers
{
    public class ProductController : Controller
    {
        productmanager pm = new productmanager();
        productview pv = new productview();
        // GET: Product
        public ActionResult Index()
        {
            pv.product = pm.read();
            return View(pv);
        }

        public FileResult excel()
        {
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("product");
            foreach (var item in pm.read())
            {
                for (int i = 0; i < pm.count(); i++)
                {
                    var row = sheet.CreateRow(i);

                    var cell = row.CreateCell(0);cell.SetCellValue(item.product_name.ToString());



                }
            }
            var stream = new MemoryStream();
            workbook.Write(stream);

            return File(new MemoryStream(stream.GetBuffer()), "application/vdn.ms-excel", "producttable.xls");
        }
        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product product)
        {
            try
            {
               
                pm.create(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult Delete(int id)
        {
            try
            {
                pm.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
    public class productview
    {
        public IEnumerable<product> product { get; set; }
    }
   
}
