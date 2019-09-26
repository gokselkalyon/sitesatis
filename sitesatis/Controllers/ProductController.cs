using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
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

        // GET: Product
        
        public ActionResult Index()
        {
            Excelhelper d = new Excelhelper();
            d.icerik();
            pv.product = pm.read();
            return View(pv);
        }
        [Authorize(Roles ="admin",Users ="deneme")]
        public FileResult excel()
        {
            IWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("product");
            foreach (var item in pm.read())
            {
                for (int i = 0; i < pm.count(); i++)
                {
                    var row = sheet.CreateRow(i);

                    var cell = row.CreateCell(0); cell.SetCellValue(item.product_name.ToString());
                    var cell1 = row.CreateCell(1); cell.SetCellValue(item.product_name.ToString());



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
        public ActionResult create()
        {
            pv.category = cm.read();
            pv.cargotype = ctm.read();
            pv.repository = rm.read();
            pv.cargo = carm.read();
            return View(pv);
        }

        [HttpPost]
        public ActionResult Create(product _product)
        {
            try
            {
                pm.create(new product
                {
                    id = 1,
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
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(product _product)
        {
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
    }

}
