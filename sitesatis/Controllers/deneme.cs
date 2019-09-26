
/*/using SungurTek.Helpers.Raporlar;
//using SungurTek.Models.ViewModels.HastaAcezeTakip;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Web;
//using AcezeSevk = SungurTek.Entities.Models.HastaAcezeTakip.AcezeSevk;
using System.Threading;
using System.Globalization;
using sitesatis.Models.entity;
using NPOI.HSSF.UserModel;

namespace SungurTek.Helpers.BakimHizmetleri
{
    public class AnaRapor
    {
        public DateTime Gun { get; set; }
        public List<product> SevkHareketleri { get; set; }
        //public List<AcezeSevk> YatanHareketleri { get; set; }
        //public List<DaireMevcutlari> Mevcutlar { get; set; }

        public MemoryStream Save()
        {
            string ExcelTemplatePath = HttpContext.Current.Server.MapPath("~/Content/reports/BakimHizmetleriRapor.xls");

            HSSFWorkbook finalWorkbook = new HSSFWorkbook();
            HSSFSheet finalSheet = finalWorkbook.CreateSheet("RAPOR") as HSSFSheet;

            HSSFWorkbook templateWorkbook;
            using (FileStream fs = new FileStream(ExcelTemplatePath, FileMode.Open, FileAccess.Read))
            {
                templateWorkbook = new HSSFWorkbook(fs);
            }

            int destinationRow = 0;

            ExcelHelpers.FillDraftAndCopyToFinal(templateWorkbook.GetSheet("BASLIK"), finalSheet, true, ref destinationRow, new Dictionary<string, Func<string, string>>()
            {
                { "A1", a => string.Format(a, Gun.ToString("dd.MM.yyyy")) }
            });

            ExcelHelpers.FillDraftRowsAndCopyToFinal(templateWorkbook.GetSheet("SEVK"), finalSheet, ref destinationRow, SevkHareketleri, 2, true, 15, true,
                null,
                (i, a) => (i + 1).ToString(),
                (i, a) => a.CocukMu ? a.Cocuk.Adi + " " + a.Cocuk.Soyadi + " (" + a.Cocuk.Yasi + ")" : a.Sakin.Adi + " " + a.Sakin.Soyadi + " (" + a.Sakin.Yasi + ")",
                (i, a) => a.CocukMu ? a.Cocuk.TCNO : a.Sakin.TCNO,
                (i, a) => a.CocukMu ? a.Cocuk.Dairesi.DaireAdi : a.Sakin.Daire.DaireAdi,
                (i, a) => a.Hastane.Adi,
                (i, a) => a.Bolum.Adi
            );

            ExcelHelpers.FillDraftRowsAndCopyToFinal(templateWorkbook.GetSheet("YATIS"), finalSheet, ref destinationRow, YatanHareketleri, 2, true, 10, true,
                a => new
                {
                    FillForegroundColor = ExcelHelpers.GetSimilarColor(finalWorkbook.GetCustomPalette(), a.Bolum.Rengi),
                    FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground
                },
                (i, a) => (i + 1).ToString(),
                (i, a) => a.CocukMu ? a.Cocuk.Adi + " " + a.Cocuk.Soyadi + " (" + a.Cocuk.Yasi + ")" : a.Sakin.Adi + " " + a.Sakin.Soyadi + " (" + a.Sakin.Yasi + ")",
                (i, a) => a.CocukMu ? a.Cocuk.TCNO : a.Sakin.TCNO,
                (i, a) => a.CocukMu ? a.Cocuk.Dairesi.DaireAdi : a.Sakin.Daire.DaireAdi,
                (i, a) => a.Hastane.Adi,
                (i, a) => a.Bolum.Adi,
                (i, a) => a.YatisTarihi.Value.ToString("dd.MM.yyyy")
            );

            ExcelHelpers.FillDraftRowsAndCopyToFinal(templateWorkbook.GetSheet("MEVCUTLAR"), finalSheet, ref destinationRow, Mevcutlar, 2, true, 0, true,
                null,
                (i, a) => (i + 1).ToString(),
                (i, a) => a.Daire.DaireAdi,
                (i, a) => a.Kapasite.ToString(),
                (i, a) => a.Mevcut.ToString()
            );

            ExcelHelpers.FillDraftAndCopyToFinal(templateWorkbook.GetSheet("MEVCUTLAR_TOPLAM"), finalSheet, false, ref destinationRow, new Dictionary<string, Func<string, string>>()
            {
                { "D1", a => Mevcutlar.Sum(m => m.Kapasite).ToString()},
                { "F1", a => Mevcutlar.Sum(m => m.Mevcut).ToString()},
            });

            ExcelHelpers.FillDraftAndCopyToFinal(templateWorkbook.GetSheet("OZET"), finalSheet, false, ref destinationRow, new Dictionary<string, Func<string, string>>()
            {
                { "F2", a => SevkHareketleri.Count.ToString()},
                { "F3", a => YatanHareketleri.Count.ToString()},
            });

            using (MemoryStream output = new MemoryStream())
            {
                finalWorkbook.Write(output);
                return output;
            }
        }
    }
}*/