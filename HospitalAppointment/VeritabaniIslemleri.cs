using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HospitalAppointment
{
    public class VeritabaniIslemleri
    {

        readonly static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static object SorguCalistir(string sqlSorgusu
            , Dictionary<string, object> parametreler = null, bool islemTuru = false, bool tekDegerMi = false)
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
    }
}
