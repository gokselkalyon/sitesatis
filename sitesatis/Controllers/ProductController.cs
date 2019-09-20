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
                    var cell1 = row.CreateCell(1);cell.SetCellValue(item.product_name.ToString());
                    var cell2 = row.CreateCell(2);cell.SetCellValue(item.product_name.ToString());
                    var cell3 = row.CreateCell(3);cell.SetCellValue(item.product_name.ToString());
                    var cell4 = row.CreateCell(4);cell.SetCellValue(item.product_name.ToString());
                    var cell5 = row.CreateCell(5);cell.SetCellValue(item.product_name.ToString());
                    var cell6 = row.CreateCell(6);cell.SetCellValue(item.product_name.ToString());
                    var cell7 = row.CreateCell(7);cell.SetCellValue(item.product_name.ToString());
                    var cell8 = row.CreateCell(8);cell.SetCellValue(item.product_name.ToString());
                    var cell9 = row.CreateCell(9);cell.SetCellValue(item.product_name.ToString());
                    var cell10 = row.CreateCell(10);cell.SetCellValue(item.product_name.ToString());
                    var cell11 = row.CreateCell(11);cell.SetCellValue(item.product_name.ToString());



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

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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
