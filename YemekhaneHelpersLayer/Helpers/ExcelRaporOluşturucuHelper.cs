using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using YemekhaneEntityLayer.Entities;

namespace YemekhaneHelpersLayer.Helpers
{
    public class ExcelRaporOluşturucuHelper
    {
        public static byte[] RaporuOlustur(List<Okutmalar> okutmalarListesi)
        {
            using var workbook = new XLWorkbook();
            var ws = workbook.Worksheets.Add("Rapor");

            ws.Cell(1, 1).Value = "Tarih";
            ws.Cell(1, 2).Value = "Ad ";
            ws.Cell(1, 3).Value = "Soyad";

            for (int i = 0; i < okutmalarListesi.Count; i++)
            {
                var o = okutmalarListesi[i];
                ws.Cell(i + 2, 1).Value = o.OkutmaTarihi.ToShortDateString();
                ws.Cell(i + 2, 2).Value = o.calisan?.calisanIsmi ?? "";
                ws.Cell(i + 2, 3).Value = o.calisan?.calisanSoyad ?? "";
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

    }
}
