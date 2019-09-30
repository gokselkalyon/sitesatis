using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using System.IO;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using sitesatis.Models.entity;
using sitesatis.Models.repository.manager;

namespace sitesatis.business.NPOI
{
    public class Excelhelper<T>
    {

        public static void FillDraftAndCopyToFinal(IWorkbook _workbook, ISheet _sheet, string _title,MemoryStream sss)//IEnumerable<T> list)//verilen class'a göre listeleme yapması için IEnumerable kullanıcam ama kesin depil 
        {
            IWorkbook workbook = _workbook;
            ISheet sheet1 = _sheet;
            productmanager pm = new productmanager();

            var newFile = @"C:\Users\göksel\Downloads\newboo2k122sonis222288822123.core.xlsx";

            //using(var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            using(var fs = new MemoryStream())
            {

                var style =  workbook.CreateCellStyle();
                style.FillForegroundColor = HSSFColor.Blue.Index2;
                style.Alignment = HorizontalAlignment.Center;
                style.VerticalAlignment = VerticalAlignment.Center;
                style.FillPattern = FillPattern.SolidForeground;

                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
                var rowIndex = 0;
                var row = sheet1.CreateRow(rowIndex).CreateCell(0);
                row.CellStyle = style;
                row.SetCellValue(_title);

                rowIndex++;
                foreach(var item in pm.read())
                {
                    var row1 = sheet1.CreateRow(rowIndex);
                    row1.CreateCell(0).SetCellValue(item.product_name);
                    row1.CreateCell(1).SetCellValue(item.cargo.cargo_company);
                    row1.CreateCell(2).SetCellValue(item.category.category_name);
                    row1.CreateCell(3).SetCellValue(item.cargo_type.cargo_type1);
                    row1.CreateCell(4).SetCellValue(item.product_content);
                    row1.CreateCell(5).SetCellValue(item.product_add_time.ToString());
                    row1.CreateCell(6).SetCellValue(item.product_price.ToString());
                    row1.CreateCell(7).SetCellValue(item.product_quantity.ToString());
                    row1.CreateCell(8).SetCellValue(item.prouct_image_path);
                    row1.CreateCell(9).SetCellValue(item.repository.repository_name);
                    sheet1.AutoSizeColumn(0);
                    sheet1.AutoSizeColumn(1);
                    sheet1.AutoSizeColumn(2);
                    sheet1.AutoSizeColumn(3);
                    sheet1.AutoSizeColumn(4);
                    sheet1.AutoSizeColumn(5);
                    sheet1.AutoSizeColumn(6);
                    sheet1.AutoSizeColumn(7);
                    sheet1.AutoSizeColumn(8);
                    sheet1.AutoSizeColumn(9);
                    rowIndex++;

                }



                workbook.Write(fs);

                
            }

        }
    }
    class deneme
    {
        public void d1eneme()
        {
            IWorkbook workbook = new XSSFWorkbook();
            //deneme excel 

            ISheet sheet1 = workbook.CreateSheet("SAYFA deneme");
            productmanager ddd = new productmanager();

            //Excelhelper<product>.FillDraftAndCopyToFinal(workbook, sheet1, "goksel denemesi ego aley",ddd.read());


        }
    }
}