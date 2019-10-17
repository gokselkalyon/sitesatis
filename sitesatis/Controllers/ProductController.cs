using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using sitesatis.business.NPOI;
using sitesatis.business.rolemanager;
using sitesatis.Models.attribute;
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
        categorymanager cm = new categorymanager();
        cargotypemanager ctm = new cargotypemanager();
        cargomanager carm = new cargomanager();
        repositorymanager rm = new repositorymanager();
        // GET: category

        
        public ActionResult Index(int? id)
        {
            int page;
            if(id != null)
            {
                page = id.Value;
            }
            else
            { page = 0; }

            pv.product = pm.read().Skip(page).Take(10).ToList();//.Skip(page).ToList();
            pv.pagelist = pv.product.Count() / 10;

            return View(pv);
        }

        public FileResult excel()
        {
            IWorkbook workbook = new HSSFWorkbook(); //döküman
            ISheet sheet1 = workbook.CreateSheet("product 12"); //sayfa

            productmanager pm = new productmanager();//

            var style =  workbook.CreateCellStyle();//sitil dosyası
            style.FillForegroundColor = HSSFColor.Blue.Index2; //renk
            style.Alignment = HorizontalAlignment.Center;// metin hizalama
            style.VerticalAlignment = VerticalAlignment.Center;//metin hzalama
            style.FillPattern = FillPattern.SolidForeground;// renk doldurma

            sheet1.AddMergedRegion(new CellRangeAddress(0, 1, 0, 9));//birleştirme
            var rowIndex = 0;
            var row = sheet1.CreateRow(rowIndex).CreateCell(0);
            row.CellStyle = style;
            row.SetCellValue("deneme son vol:3");

            rowIndex+=2;
            foreach(var item in pm.read())
            {
                var row1 = sheet1.CreateRow(rowIndex);
                row1.CreateCell(0).SetCellValue(item.product_name);//hücre değerleri
                sheet1.AutoSizeColumn(0);// hücre veriye göre boyutlandırma
                row1.CreateCell(1).SetCellValue(item.cargo.cargo_company);
                sheet1.AutoSizeColumn(1);
                row1.CreateCell(2).SetCellValue(item.category.category_name);
                sheet1.AutoSizeColumn(8);
                row1.CreateCell(3).SetCellValue(item.cargo_type.cargo_type1);
                sheet1.AutoSizeColumn(2);
                row1.CreateCell(4).SetCellValue(item.product_content);
                sheet1.AutoSizeColumn(3);
                row1.CreateCell(5).SetCellValue(item.product_add_time.ToString());
                sheet1.AutoSizeColumn(4);
                row1.CreateCell(6).SetCellValue(item.product_price.ToString());
                sheet1.AutoSizeColumn(5);
                row1.CreateCell(7).SetCellValue(item.product_quantity.ToString());
                sheet1.AutoSizeColumn(6);
                row1.CreateCell(8).SetCellValue(item.prouct_image_path);
                sheet1.AutoSizeColumn(7);
                row1.CreateCell(9).SetCellValue(item.repository.repository_name);
                sheet1.AutoSizeColumn(9);
                rowIndex++;

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
        public ActionResult create()
        {
            pv.category = cm.read();
            pv.cargotype = ctm.read();
            pv.repository = rm.read();
            pv.cargo = carm.read();
            return View(pv);
        }

        [HttpPost]
        public ActionResult Create(product _product,HttpPostedFileBase prouct_image_path)
        {
            if(prouct_image_path != null)
            {
                string dosyaYolu = Path.GetFileName(prouct_image_path.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/image/"), dosyaYolu);
                prouct_image_path.SaveAs(yuklemeYeri);
                _product.prouct_image_path = prouct_image_path.FileName;
            }
            try
            {
                pm.create(new product
                {
                    product_name = _product.product_name,
                    product_content = _product.product_content,
                    category_id = _product.category_id,
                    cargo_type_id = _product.cargo_type_id,
                    cargo_id = _product.cargo_type_id,
                    product_price = _product.product_price,
                    prouct_image_path = _product.prouct_image_path.ToString(),
                    publisher = 1,
                    product_quantity = _product.product_quantity,
                    repository_id = _product.repository_id,
                    product_add_time = DateTime.Now
                });
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(product _product, HttpPostedFileBase prouct_image_path)
        {
            if(prouct_image_path != null)
            {
                string dosyaYolu = Path.GetFileName(prouct_image_path.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/image/"), dosyaYolu);
                prouct_image_path.SaveAs(yuklemeYeri);
                _product.prouct_image_path = prouct_image_path.FileName;
            }
            pm.update(new product {
                id = _product.id,
                product_name = _product.product_name,
                product_content = _product.product_content,
                category_id = _product.category_id,
                cargo_type_id = _product.cargo_type_id,
                cargo_id = _product.cargo_type_id,
                product_price = _product.product_price,
                prouct_image_path = _product.prouct_image_path,
                publisher = 1,
                product_quantity = _product.product_quantity,
                repository_id = _product.repository_id,
                product_add_time = DateTime.Now
            });
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                pv.cargo = carm.read();
                pv.cargotype = ctm.read();
                pv._product = pm.filterread(x=>x.id == id);
                pv.repository = rm.read();
                pv.product = pm.read();
                pv.category = cm.read();
                return View(pv);
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
                pm.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
    public class productview
    {
        public IEnumerable<product> product { get; set; }
        public IEnumerable<category> category { get; set; }
        public IEnumerable<cargo_type> cargotype { get; set; }
        public IEnumerable<cargo> cargo { get; set; }
        public IEnumerable<repository> repository { get; set; }
        public product _product { get; set; }
        public int pagelist { get; set; }
    }

}
