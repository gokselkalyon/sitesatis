using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using System.IO;
using NPOI.XSSF.UserModel;

namespace sitesatis.business.NPOI
{
    public class Excelhelper
    {
        
        public void icerik()
        {
            var newFile = @"C:\Users\göksel\Downloads\newboo2k122.core.xlsx";

            using (var fs = new FileStream(newFile, FileMode.Create, FileAccess.Write))
            {

                IWorkbook workbook = new XSSFWorkbook();
                //deneme excel 

                ISheet sheet1 = workbook.CreateSheet("SAYFA 1");

                sheet1.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));
                var rowIndex = 0;

                IRow row = sheet1.CreateRow(rowIndex);
                row.CreateCell(0).SetCellValue("BAŞLIK");

                rowIndex++;

                IRow row2 = sheet1.CreateRow(rowIndex);
                row2.CreateCell(1).SetCellValue("denem");


                IRow row3 = sheet1.CreateRow(3);
                row3.CreateCell(0).SetCellValue("değer");
                sheet1.AutoSizeColumn(0);
                rowIndex++;

                #region deneme sheet
                //var sheet2 = workbook.CreateSheet("SAYFA 2");

                //var style1 = workbook.CreateCellStyle();
                //style1.FillForegroundColor = HSSFColor.Blue.Index2;
                //style1.FillPattern = FillPattern.SolidForeground;

                //var style2 = workbook.CreateCellStyle();
                //style2.FillForegroundColor = HSSFColor.Yellow.Index2;
                //style2.FillPattern = FillPattern.SolidForeground;

                //var cell2 = sheet2.CreateRow(0).CreateCell(0);
                //cell2.CellStyle = style1;
                //cell2.SetCellValue(0);

                //cell2 = sheet2.CreateRow(1).CreateCell(0);
                //cell2.CellStyle = style2;
                //cell2.SetCellValue(1);
                #endregion

                workbook.Write(fs);
            }

        }
    }
}