﻿using HospitalAppointment.Models;
using System.Data;
namespace HospitalAppointment
{
    public partial class Randevu : Form
    {
        public Randevu()
        {
            InitializeComponent();
        }

        private void DoktorDoldur(int klinikID)
        {
            string sqlSorgusu = @"
            SELECT 
                Doktor_ID, 
                CONCAT(Ad, ' ', Soyad) AS AdSoyad 
            FROM Tbl_Doktorlar 
            WHERE Klinik_ID = @Klinik_ID AND aktifMi = 1";

            var parametreler = new Dictionary<string, object>()
            {
                {"@Klinik_ID", klinikID} // Klinik ID'yi parametre olarak geçiyoruz
            };

            if (VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler) is DataTable sonuc)
            {
                List_Doktor.DataSource = sonuc;
                List_Doktor.ValueMember = "Doktor_ID";
                List_Doktor.DisplayMember = "AdSoyad";
            }
            else
            {
                MessageBox.Show("İşlem başarısız");
            }
        }

        private void RandevuEkle(RandevuC randevu)
        {
            // Tam tarih ve saat birleşimi
            DateTime randevuTarihSaat = randevu.RandevuTarih.Date.Add(
                TimeSpan.Parse(Cmb_RandevuSaat.SelectedItem.ToString()));

            string sqlSorgusu = @"insert into Tbl_Randevular(Vatandas_TC, Doktor_ID, Randevu_Tarih) 
                          values(@Vatandas_TC, @Doktor_ID, @Randevu_Tarih)";

            var parametreler = new Dictionary<string, object>()
            {
                { "@Vatandas_TC", randevu.VatandasTC },
                { "@Doktor_ID", randevu.DoktorID },
                { "@Randevu_Tarih", randevuTarihSaat } // Tarih ve saat birleştirildi
            };

            var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);

            if (sonuc is int etkilenenSatirlar && etkilenenSatirlar > 0)
            {
                MessageBox.Show("Randevu başarıyla alındı.");
                DateTime secilenTarih = Date_RandevuTarih.Value.Date; // Kullanıcının seçtiği tarih
                int doktorID = Convert.ToInt32(List_Doktor.SelectedValue); // Seçili doktorun ID'si
                SaatleriDoldur(secilenTarih, Cmb_RandevuSaat, doktorID);
            }
            else
            {
                MessageBox.Show("Randevu alınırken sorun oluştu.");
            }
        }

        private static void SaatleriDoldur(DateTime secilenTarih, ComboBox comboBox, int doktorID)
        {
            // Dolu saatleri getir
            var doluSaatler = DoluSaatleriGetir(secilenTarih, doktorID);

            // 08:00'dan 17:00'a kadar olan saatleri oluştur (30 dakika aralıklarla)
            List<DateTime> tumSaatler = [];
            DateTime baslangicSaat = secilenTarih.Date.AddHours(8); // 08:00
            DateTime bitisSaat = secilenTarih.Date.AddHours(17);   // 17:00

            while (baslangicSaat <= bitisSaat)
            {
                tumSaatler.Add(baslangicSaat);
                baslangicSaat = baslangicSaat.AddMinutes(30);
            }

            // ComboBox'ı temizle
            comboBox.Items.Clear();

            // Boş saatleri filtrele ve ComboBox'a ekle
            foreach (var saat in tumSaatler)
            {
                // Eğer saat dolu değilse, ComboBox'a ekle
                if (!doluSaatler.Contains(saat))
                {
                    comboBox.Items.Add(saat.ToString("HH:mm"));
                }
            }

            // Eğer boş saat varsa ilkini seç
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Seçilen tarihte uygun randevu saati bulunmamaktadır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private static List<DateTime> DoluSaatleriGetir(DateTime selectedDate, int doktorID)
        {
            // SQL sorgusu: Belirli bir tarihteki ve doktorun dolu randevularını al
            string sqlSorgusu = @"
            SELECT Randevu_Tarih 
            FROM Tbl_Randevular 
            WHERE CAST(Randevu_Tarih AS DATE) = @SelectedDate 
              AND Doktor_ID = @Doktor_ID 
              AND aktifMi = 1";

            // Parametreler
            var parametreler = new Dictionary<string, object>
            {
                { "@SelectedDate", selectedDate.Date }, // Sadece tarihi alıyoruz
                { "@Doktor_ID", doktorID }
            };

            // Dolu saatleri tutacak liste
            List<DateTime> doluSaatler = [];

            // Veritabanı sorgusu
            if (VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler) is DataTable sonuc)
            {
                foreach (DataRow row in sonuc.Rows)
                {
                    doluSaatler.Add(Convert.ToDateTime(row["Randevu_Tarih"]));
                }
            }

            return doluSaatler;
        }

        private void Date_RandevuTarih_ValueChanged(object sender, EventArgs e)
        {
            DateTime secilenTarih = Date_RandevuTarih.Value.Date; // Kullanıcının seçtiği tarih
            int doktorID = Convert.ToInt32(List_Doktor.SelectedValue); // Seçili doktorun ID'si

            SaatleriDoldur(secilenTarih, Cmb_RandevuSaat, doktorID);
        }

        // Randevu formu yüklendiğinde çalışacak metot
        private void Randevu_Load(object sender, EventArgs e)
        {
            // Vatandaşın TC kimlik numarası Ana_Sayfa'dan alınarak etikete yazılır
            Lbl_VatandasTC.Text = Ana_Sayfa.VatandasTC;

            // Klinik listesini tutacak bir liste oluşturulur
            List<KlinikC> klinikler = [];

            // Klinik bilgileri veritabanından alınır ve ComboBox'a doldurulur
            VeritabaniIslemleri.KlinikDoldur(Cmb_Klinik, klinikler);

            // Randevu tarihinin minimum ve maksimum değerleri belirlenir
            Date_RandevuTarih.MinDate = DateTime.Today.AddDays(1); // Bugünden bir gün sonrası minimum tarih
            Date_RandevuTarih.MaxDate = DateTime.Today.AddDays(14); // Bugünden iki hafta sonrası maksimum tarih

            // Varsayılan olarak randevu tarihi bugünden bir gün sonrası olarak ayarlanır
            Date_RandevuTarih.Value = DateTime.Today.AddDays(1);
        }

        private void Cmb_Klinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Klinik.SelectedItem is KlinikC selectedKlinik && selectedKlinik.KlinikID.HasValue)
            {
                int klinikID = selectedKlinik.KlinikID.Value;  // KlinikID'yi al
                DoktorDoldur(klinikID);  // Seçilen klinikteki doktorları listele
            }
            else
            {
                MessageBox.Show("Geçerli bir klinik seçmelisiniz.");
            }
        }

        private void List_Doktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime secilenTarih = Date_RandevuTarih.Value.Date;

            // Seçili doktorun ID'si

            if (List_Doktor.SelectedItem is DataRowView selectedDoktor)
            {
                int doktorID = Convert.ToInt32(selectedDoktor["Doktor_ID"]);

                // Saatleri doldur
                SaatleriDoldur(secilenTarih, Cmb_RandevuSaat, doktorID);
            }
            else
            {
                MessageBox.Show("Bir doktor seçin.");
            }
        }

        // "Randevu Ekle" butonuna tıklanıldığında çalışacak metot
        private void Btn_RandevuEkle_Click(object sender, EventArgs e)
        {
            // Yeni bir RandevuC nesnesi oluşturulur ve kullanıcının girdiği bilgiler atanır
            var randevu = new RandevuC(
                vatandasTC: Lbl_VatandasTC.Text, // Vatandaşın TC kimlik numarası
                doktorID: Convert.ToInt32(List_Doktor.SelectedValue), // Seçilen doktorun ID'si
                randevuTarih: Date_RandevuTarih.Value // Seçilen randevu tarihi
            );

            // Randevuyu eklemek için yardımcı metoda gönderilir
            RandevuEkle(randevu);
        }

        // "Geri Dön" butonuna tıklanıldığında çalışacak metot
        private void Btn_GeriDon_Click(object sender, EventArgs e)
        {
            // Vatandaş işlemleri ekranını açar
            var vatandasIslemleri = new VatandasIslemleri();
            vatandasIslemleri.Show();

            // Mevcut formu kapatır
            Close();
        }

    }
}
