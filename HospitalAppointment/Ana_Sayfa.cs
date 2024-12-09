using HospitalAppointment.Models;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace HospitalAppointment
{
    public partial class Ana_Sayfa : Form
    {
        public Ana_Sayfa()
        {
            InitializeComponent();
        }
        public static string vatandasTC = "";
        public static string doktorTC = "";

        private void Btn_VatandasKayıt_Click(object sender, EventArgs e)
        {
            string sqlSorgusu = "insert into Tbl_Vatandaslar(TC,Ad,Soyad,Telefon,Sifre) values(@TC,@Ad,@Soyad,@Telefon,@Sifre)";

            try
            {
                VatandasC vatandas = new(Txt_VatandasTc.Text.Trim(), Txt_VatandasAd.Text.Trim(), Txt_VatandasSoyad.Text.Trim(), Txt_VatandasTel.Text.Trim(), Txt_VatandasSifre.Text.Trim());

                var parametreler = new Dictionary<string, object>()
                {
                    {"@TC", vatandas.TC},
                    {"@Ad",vatandas.Ad },
                    {"@Soyad",vatandas.Soyad},
                    {"@Telefon",vatandas.Telefon},
                    {"@Sifre", vatandas.Sifre}
                };

                var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);

                if (sonuc is int etkilenenSatir && etkilenenSatir > 0)
                {
                    MessageBox.Show("Kayıt işlemi başarılı");
                }
                else
                    MessageBox.Show("Kayıt olunurken bir hata oluştu!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Btn_VatandasGiris_Click(object sender, EventArgs e)
        {
            KullaniciGiris("Tbl_Vatandaslar", Txt_VatandasGirisTc, Txt_VatandasGirisSifre);
        }

        private void Btn_DoktorGiris_Click(object sender, EventArgs e)
        {
            KullaniciGiris("Tbl_Doktorlar", Txt_DoktorTc, Txt_DoktorSifre);
        }

        private void Btn_YetkiliGiris_Click(object sender, EventArgs e)
        {

            KullaniciGiris("Tbl_Yetkililer", Txt_YetkiliTc, Txt_YetkiliSifre);
        }

        private void KullaniciGiris(string tabloAdi, TextBox tcTextBox, TextBox sifreTextBox)
        {
            var tcNo = tcTextBox.Text.Trim();
            var sifre = sifreTextBox.Text.Trim();

            if (!TcKimlikNoKontrol(tcNo))
            {
                MessageBox.Show("Geçersiz T.C. NO!!");
                return;
            }

            var sqlSorgusu = $"SELECT COUNT(*) FROM {tabloAdi} WHERE TC=@TC AND Sifre=@Sifre";

            try
            {
                var parametreler = new Dictionary<string, object>()
                {
                    {"@TC" ,tcNo},
                    {"@Sifre", sifre}
                };
                var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, tekDegerMi: true);

                vatandasTC = tcTextBox.Text;
                doktorTC = tcTextBox.Text;

                if (sonuc is int etkilenenSatir && etkilenenSatir > 0)
                    TabloyaGoreGirisYap(tabloAdi);
                else
                    MessageBox.Show("Bilgileriniz hatalı. Lütfen tekrar deneyiniz.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void TabloyaGoreGirisYap(string tabloAdi)
        {
            switch (tabloAdi)
            {
                case "Tbl_Yetkililer":
                    YetkiliGiris();
                    break;
                case "Tbl_Vatandaslar":
                    VatandasGiris();
                    break;
                case "Tbl_Doktorlar":
                    DoktorGiris();
                    break;
                default:
                    MessageBox.Show("Bilinmeyen tablo türü!");
                    break;
            }
        }

        private void VatandasGiris()
        {
            var randevu = new Randevu();
            randevu.Show();
            this.Hide();
        }

        private void YetkiliGiris()
        {
            var yetkili = new Yetkili();
            yetkili.Show();
            this.Hide();
        }

        private void DoktorGiris()
        {
            var muayene = new Muayene();
            muayene.Show();
            this.Hide();
        }

        public static bool TcKimlikNoKontrol(string tcKimlikNo)
        {
            // 1. Uzunluk kontrolü (11 karakter ve sadece rakamlardan oluşmalı)
            if (string.IsNullOrEmpty(tcKimlikNo) || tcKimlikNo.Length != 11 || !tcKimlikNo.All(char.IsDigit))
                return false;

            // 2. İlk hanesi 0 olamaz
            if (tcKimlikNo[0] == '0')
                return false;

            // 3. İlk 10 hanenin toplamının mod 10'u 11. haneye eşit olmalı
            int toplam = 0;
            for (int i = 0; i < 10; i++)
            {
                toplam += int.Parse(tcKimlikNo[i].ToString());
            }
            if (toplam % 10 != int.Parse(tcKimlikNo[10].ToString()))
                return false;

            // 4. 1, 3, 5, 7, 9. hanelerin toplamının 7 katından
            // 2, 4, 6, 8. hanelerin toplamı çıkarıldığında kalan 10. haneye eşit olmalı
            int tekToplam = 0, ciftToplam = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 0) // 1, 3, 5, 7, 9
                    tekToplam += int.Parse(tcKimlikNo[i].ToString());
                else // 2, 4, 6, 8
                    ciftToplam += int.Parse(tcKimlikNo[i].ToString());
            }
            int onuncuHane = int.Parse(tcKimlikNo[9].ToString());
            if ((tekToplam * 7 - ciftToplam) % 10 != onuncuHane)
                return false;

            // Tüm kurallardan geçtiyse geçerlidir
            return true;
        }
    }
}
