using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Http.Headers;

namespace HospitalAppointment
{
    public partial class Ana_Sayfa : Form
    {
        public Ana_Sayfa()
        {
            InitializeComponent();
        }
        readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        private void Btn_VatandasKayıt_Click(object sender, EventArgs e)
        {
            string sqlSorgusu = "insert into Tbl_Vatandaslar(Vatandas_TC,Vatandas_Ad,Vatandas_Soyad,Vatandas_Telefon,Vatandas_Sifre) values(@Vatandas_TC,@Vatandas_Ad,@Vatandas_Soyad,@Vatandas_Telefon,@Vatandas_Sifre)";

            using var baglanti = new SqlConnection(connectionString);

            try
            {
                baglanti.Open();

                using var komut = new SqlCommand(sqlSorgusu, baglanti);

                if (string.IsNullOrEmpty(Txt_VatandasTc.Text) || Txt_VatandasTc.Text.Length != 11)
                    throw new ArgumentException("T.C. Kimlik Numarası 11 karakter olmalıdır.");

                komut.Parameters.Add("@Vatandas_TC", SqlDbType.Char, 11).Value = Txt_VatandasTc.Text.Trim();
                komut.Parameters.Add("@Vatandas_Ad", SqlDbType.NVarChar, 50).Value = Txt_VatandasAd.Text.Trim();
                komut.Parameters.Add("@Vatandas_Soyad", SqlDbType.NVarChar, 50).Value = Txt_VatandasSoyad.Text.Trim();
                komut.Parameters.Add("@Vatandas_Telefon", SqlDbType.Char, 15).Value = Txt_VatandasTel.Text.Trim();
                komut.Parameters.Add("@Vatandas_Sifre", SqlDbType.NVarChar, 50).Value = Txt_VatandasSifre.Text.Trim();

                int etkilenenSatırlar = komut.ExecuteNonQuery();

                if (etkilenenSatırlar > 0)
                {
                    MessageBox.Show("Kayıt olma işlemi başarıyla gerçekleşti.");
                    Txt_VatandasTc.Clear();
                    Txt_VatandasAd.Clear();
                    Txt_VatandasSoyad.Clear();
                    Txt_VatandasTel.Clear();
                    Txt_VatandasSifre.Clear();
                }
                else
                    MessageBox.Show("Kayıt olunamadı.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata : {ex.Message}");
            }


        }

        private void Btn_VatandasGiris_Click(object sender, EventArgs e)
        {
            KullaniciGiris("Tbl_Vatandaslar", "Vatandas_TC", "Vatandas_Sifre", Txt_VatandasGirisTc, Txt_VatandasGirisSifre);
        }

        private void Btn_DoktorGiris_Click(object sender, EventArgs e)
        {
            KullaniciGiris("Tbl_Doktorlar", "Doktor_TC", "Doktor_Sifre", Txt_DoktorTc, Txt_DoktorSifre);
        }

        private void Btn_YetkiliGiris_Click(object sender, EventArgs e)
        {
            KullaniciGiris("Tbl_Yetkililer", "Kullanici_Adi", "Sifre", Txt_YetkiliKadi, Txt_YetkiliSifre);
        }

        private void KullaniciGiris(string tabloAdi, string tcParam, string sifreParam, TextBox tcTextBox, TextBox sifreTextBox)
        {
            // Geçerli tablo adlarını sabit bir liste olarak tanımlayın
            var validTables = new[] { "Tbl_Yetkililer", "Tbl_Kullanicilar", "Tbl_Doktorlar" };
            if (!validTables.Contains(tabloAdi))
            {
                MessageBox.Show("Geçersiz tablo adı!");
                return;
            }

            string sqlSorgusu = $"SELECT COUNT(*) FROM {tabloAdi} WHERE {tcParam}=@TC AND {sifreParam}=@Sifre";

            using var baglanti = new SqlConnection(connectionString);
            try
            {
                baglanti.Open();

                // TC kontrolü sadece belirli tablolar için yapılır
                if (tabloAdi != "Tbl_Yetkililer" && !TcKimlikNoKontrol(tcTextBox.Text))
                {
                    MessageBox.Show("Geçersiz T.C. NO!!");
                    return;
                }

                using var komut = new SqlCommand(sqlSorgusu, baglanti);
                komut.Parameters.AddWithValue("@TC", tcTextBox.Text.Trim());
                komut.Parameters.AddWithValue("@Sifre", sifreTextBox.Text.Trim());

                int sonuc = Convert.ToInt32(komut.ExecuteScalar());

                if (sonuc > 0)
                {
                    // Tablo türüne göre işlem yapılır
                    switch (tabloAdi)
                    {
                        case "Tbl_Yetkililer":
                            Yetkili yetkili = new();
                            yetkili.Show();
                            this.Hide();
                            break;
                        case "Tbl_Kullanicilar":
                            // Kullanıcıya özel form veya işlem
                            break;
                        default:
                            MessageBox.Show("Bilinmeyen tablo türü!");
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Bilgileriniz hatalı. Lütfen tekrar deneyiniz.");
                }
            }
            catch (Exception ex)
            {
                // Daha spesifik hata mesajı
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private static bool TcKimlikNoKontrol(string tcKimlikNo)
        {
            if (tcKimlikNo.Length != 11 || !long.TryParse(tcKimlikNo, out _))
                return false;

            if (tcKimlikNo[0] == '0')
                return false;

            int toplamTek = 0, toplamCift = 0;

            for (int i = 0; i < 10; i++)
            {
                int rakam = int.Parse(tcKimlikNo[i].ToString());
                if (i % 2 == 0)
                    toplamTek += rakam;
                else
                    toplamCift += rakam;
            }

            int hane10 = ((toplamTek * 7) - toplamCift) % 10;
            int hane11 = (toplamTek + toplamCift + hane10) % 10;

            return hane10 == int.Parse(tcKimlikNo[9].ToString()) &&
                   hane11 == int.Parse(tcKimlikNo[10].ToString());
        }

    }
}
