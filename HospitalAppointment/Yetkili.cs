using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace HospitalAppointment
{
    public partial class Yetkili : Form
    {
        public Yetkili()
        {
            InitializeComponent();
        }

        readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;


        public void KlinikDoldur()
        {
            Cmb_Klinik.Items.Clear();
            string sqlSorgusu = "select * from Tbl_Klinikler order by Klinik_Ad asc";

            using var baglanti = new SqlConnection(connectionString);

            try
            {
                baglanti.Open();

                using var komut = new SqlCommand(sqlSorgusu, baglanti);
                using var reader = komut.ExecuteReader();

                var dt = new DataTable();
                dt.Load(reader);

                Cmb_Klinik.DataSource = dt;
                Cmb_Klinik.DisplayMember = "Klinik_Ad";
                Cmb_Klinik.ValueMember = "Klinik_Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata : {ex.Message}");
            }
        }

        public void KlinikSayısı()
        {
            string sqlSorgusu = "select count(*) from Tbl_Klinikler";

            using var baglanti = new SqlConnection(connectionString);

            try
            {
                baglanti.Open();

                using var komut = new SqlCommand(sqlSorgusu, baglanti);
                var klinikSayisi = komut.ExecuteScalar();

                Lbl_KlinikSayisi.Text = klinikSayisi.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata : {ex.Message}");
            }
        }

        private void Yetkili_Load(object sender, EventArgs e)
        {
            KlinikDoldur();
            KlinikSayısı();
        }

        private void Btn_KlinikEkle_Click(object sender, EventArgs e)
        {
            string sqlSorgusu = "insert into Tbl_Klinikler(Klinik_Ad) values(@Klinik_Ad)";
            using var baglanti = new SqlConnection(connectionString);

            try
            {
                baglanti.Open();

                using var komut = new SqlCommand(sqlSorgusu, baglanti);
                komut.Parameters.Add("", SqlDbType.NVarChar, 50).Value = Txt_KlinikEkle.Text.Trim();
                int etkilenenSatirlar = komut.ExecuteNonQuery();

                if (etkilenenSatirlar > 0)
                {
                    MessageBox.Show("Başarıyla klinik eklendi.");
                    Txt_KlinikEkle.Clear();
                }
                else
                    MessageBox.Show("Klinik eklenemedi.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata : {ex.Message}");
            }

        }

    }
}
