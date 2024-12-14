using HospitalAppointment.Model;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HospitalAppointment
{
    public class VeritabaniIslemleri
    {

        readonly static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static object? SorguCalistir(string sqlSorgusu
            , Dictionary<string, object>? parametreler = null, bool islemTuru = false, bool tekDegerMi = false)
        {
            using var baglanti = new SqlConnection(connectionString);
            using var komut = new SqlCommand(sqlSorgusu, baglanti);

            if (parametreler != null)
            {
                foreach (var param in parametreler)
                    komut.Parameters.AddWithValue(param.Key, param.Value);
            }

            try
            {
                baglanti.Open();

                if (tekDegerMi)
                {
                    return komut.ExecuteScalar(); // Tek bir değer döner
                }

                if (islemTuru)
                {
                    return komut.ExecuteNonQuery(); // INSERT, UPDATE, DELETE
                }

                using var reader = komut.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable; // SELECT için DataTable döner
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
                return null;
            }
        }

        public static bool KullaniciVarMi(string tc)
        {
            string sqlSorgusu = "select count(TC) from Tbl_Vatandaslar where TC=@TC";

            var parametreler = new Dictionary<string, object>()
            {
                {"@TC",tc}
            };

            var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, tekDegerMi: true);
            if (sonuc != null && int.TryParse(sonuc.ToString(), out _))
            {
                return true;
            }
            return false;
        }

        public static void KlinikDoldur(ComboBox comboBox, List<KlinikC> klinikler)
        {
            string sqlSorgusu = "select * from Tbl_Klinikler where aktifMi = 1 order by Klinik_Ad asc";

            if (VeritabaniIslemleri.SorguCalistir(sqlSorgusu) is DataTable sonuc)
            {
                klinikler.Clear();

                foreach (DataRow row in sonuc.Rows)
                {
                    var klinik = new KlinikC(
                        klinikAd: row["Klinik_Ad"].ToString(),
                        klinikID: Convert.ToInt32(row["Klinik_ID"])
                    );

                    klinikler.Add(klinik);
                }

                comboBox.DataSource = klinikler;
                comboBox.DisplayMember = "KlinikAd";
                comboBox.ValueMember = "KlinikID";
            }
            else
            {
                MessageBox.Show("Klinikler yüklenirken bir hata oluştu.");
            }
        }

        public static void GridDoldur(string sqlSorgusu,DataGridView dataGridView,Dictionary<string, object>? parametreler = null)
        {
            // SQL sorgusunu çalıştır
            var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler);

            if (sonuc is DataTable dataTable)
            {
                // DataGridView'e ata
                dataGridView.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Veriler yüklenirken hata oluştu!");
            }
        }

    }
}
