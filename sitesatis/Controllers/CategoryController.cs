using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
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
    public class CategoryController : Controller
    {
        categoryview cv = new categoryview();
        categorymanager cm = new categorymanager();
        // GET: Product

        public ActionResult Index()
        {
            cv.category = cm.read();
            return View(cv);
        }

        public FileResult excel()
        {
            IWorkbook workbook = new HSSFWorkbook(); //döküman
            ISheet sheet1 = workbook.CreateSheet("Category"); //sayfa

            var style =  workbook.CreateCellStyle();//sitil dosyası
            style.FillForegroundColor = HSSFColor.Blue.Index2; //renk
            style.Alignment = HorizontalAlignment.Center;// metin hizalama
            style.VerticalAlignment = VerticalAlignment.Center;//metin hzalama
            style.FillPattern = FillPattern.SolidForeground;// renk doldurma

            sheet1.AddMergedRegion(new CellRangeAddress(0, 1, 0, 2));//birleştirme
            var rowIndex = 0;
            var row = sheet1.CreateRow(rowIndex).CreateCell(0);
            row.CellStyle = style;
            row.SetCellValue("Başlık");

            rowIndex += 2;
            foreach(var item in cm.read())
            {
                var row1 = sheet1.CreateRow(rowIndex);
                row1.CreateCell(0).SetCellValue(item.id);//hücre değerleri
                sheet1.AutoSizeColumn(0);// hücre veriye göre boyutlandırma
                row1.CreateCell(1).SetCellValue(item.category_name);
                sheet1.AutoSizeColumn(1);
                rowIndex++;

            }
            var stream = new MemoryStream();
            workbook.Write(stream);

            return File(new MemoryStream(stream.GetBuffer()), "application/vdn.ms-excel", "CategoryTable.xls");

        }

        // POST: Product/Create
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string category_name)
        {
            try
            {
                cm.create(new category
                {
                    category_name = category_name.ToString()
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(category _category)
        {
            cm.update(new category
            {
                id = _category.id,
                category_name = _category.category_name
            });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                cv._category = cm.filterread(x => x.id == id);
                return View(cv);
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
                cm.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
    public class categoryview
    {
        public IEnumerable<category> category { get; set; }
        public category _category { get; set; }
    }
}