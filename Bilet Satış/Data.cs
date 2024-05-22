using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Bilet_Satış
{
    class Data
    {
        public static DataTable table;
        public static DataTable DataTable_Yolcular()
        {
            table = new DataTable("Yolcular");
            table.Columns.Add(new DataColumn("Row", typeof(int)));
            table.Columns.Add(new DataColumn("Koltuk Numrası", typeof(int)));
            table.Columns.Add(new DataColumn("Koltuk Durumu", typeof(string))); // 0 boş, 1 satış, 2 rezerve
            table.Columns.Add(new DataColumn("Yolcu Adı Soyadı", typeof(string)));
            table.Columns.Add(new DataColumn("Yolcu Cinsiyet", typeof(string)));
            //table.Columns.Add(new DataColumn("yol_Koltuk_Islem_Tarih", typeof(DateTime)));
            table.Columns.Add(new DataColumn("Görevli", typeof(string)));
            return table;
        }
        public static void DataTable_Yolcular_Insert(int koltuk_no, string ddurum, string ad_soyad, string cinsiyet,string gorevli)
        {
            int recno = 0;
            try
            {
                recno = table.Rows.Count + 1;
            }
            catch (NullReferenceException)
            {
                recno = 1;
            }
            table.Rows.Add(recno, koltuk_no, ddurum, ad_soyad, cinsiyet, gorevli);
        }
    }
}
