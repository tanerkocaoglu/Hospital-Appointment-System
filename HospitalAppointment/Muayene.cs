using HospitalAppointment.Models;
using System.Data;

namespace HospitalAppointment
{
    public partial class Muayene : Form
    {
        public Muayene()
        {
            InitializeComponent();
        }

        string doktorTC = Ana_Sayfa.DoktorTC;
        int doktorID = 0;

        // Doktorun TC bilgisine göre Doktor ID'sini getiren metot
        private int DoktorIdGetir()
        {
            // Doktor ID'sini almak için SQL sorgusu
            string sqlSorgusu = "select Doktor_ID from Tbl_Doktorlar where TC=@TC";
            var parametreler = new Dictionary<string, object>()
            {
                {"@TC", doktorTC}
            };

            // Veritabanı işlemini gerçekleştirir ve sonucu alır
            var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler);
            if (sonuc is DataTable dataTable && dataTable.Rows.Count > 0)
            {
                // Doktor ID'si varsa döndürür
                int doktorID = Convert.ToInt32(dataTable.Rows[0]["Doktor_ID"]);
                return doktorID;
            }
            // Doktor ID bulunamazsa varsayılan bir değer döner
            return 1903;
        }

        // Doktora ait randevuları getiren ve DataGridView'e dolduran metot
        private static void RandevularıGetir(int doktorID, DateTimePicker dateTimePicker, DataGridView dataGridView)
        {
            // Randevuları listelemek için SQL sorgusu
            string sqlSorgusu = @"
            SELECT 
                Randevu_ID AS 'Randevu ID', 
                Vatandas_TC AS 'Vatandaş TC', 
                Randevu_Tarih AS 'Randevu Tarih'
            FROM Tbl_Randevular 
            WHERE Doktor_ID = @Doktor_ID 
            AND aktifMi=1
            AND CAST(Randevu_Tarih AS DATE) = @Randevu_Tarih";

            var parametreler = new Dictionary<string, object>
            {
                { "@Doktor_ID", doktorID },
                { "@Randevu_Tarih", dateTimePicker.Value.Date }
            };

            // DataGridView'e randevu bilgilerini doldurur
            VeritabaniIslemleri.GridDoldur(sqlSorgusu, dataGridView, parametreler);
        }

        // Yeni bir muayene kaydeden metot
        private void MuayeneKaydet(MuayeneC muayene)
        {
            // Muayene bilgilerini kaydetmek için SQL sorgusu
            string sqlSorgusu = @"insert into Tbl_Muayeneler(Randevu_ID,Doktor_ID,Vatandas_TC,Tani,Ilac,Rapor_Suresi)
                         values(@Randevu_ID,@Doktor_ID,@Vatandas_TC,@Tani,@Ilac,@Rapor_Suresi)";

            var parametreler = new Dictionary<string, object>()
            {
                {"@Randevu_ID" ,muayene.RandevuID},
                {"@Doktor_ID" , muayene.DoktorID},
                {"@Vatandas_TC" , muayene.VatandasTC},
                {"@Tani" , muayene.Tani},
                {"@Ilac",muayene.Ilac },
                {"@Rapor_Suresi",muayene.RaporSuresi }
            };

            // Veritabanına kaydı gerçekleştirir
            var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);

            // İşlem başarılıysa kullanıcıya bilgi verir ve randevuları günceller
            if (sonuc is int etkilenenSatirlar && etkilenenSatirlar > 0)
            {
                MessageBox.Show("Muayene başarılı.");
                RandevularıGetir(doktorID, Date_Randevu, Grid_Randevular);
            }
            else
                MessageBox.Show("Başarısız.");
        }

        // Muayene formu yüklendiğinde çalışacak metot
        private void Muayene_Load(object sender, EventArgs e)
        {
            // Doktor ID'sini alır
            doktorID = DoktorIdGetir();

            // Doktor bilgilerini ilgili etiketlere doldurur
            Lbl_DoktorTC.Text = doktorTC;
            Lbl_DoktorID.Text = doktorID.ToString();

            // Randevu tarihini bugünden bir gün sonrasıyla sınırlar
            Date_Randevu.MinDate = DateTime.Today.AddDays(1);
            Date_Randevu.MaxDate = DateTime.Today.AddDays(1);
            Date_Randevu.Value = DateTime.Today.AddDays(1);

            // DataGridView'in tasarımını özelleştirir
            _ = new GridView_Tasarim(Grid_Randevular);
        }

        // Randevu tarihi değiştiğinde randevuları günceller
        private void Date_Randevu_ValueChanged(object sender, EventArgs e)
        {
            RandevularıGetir(doktorID, Date_Randevu, Grid_Randevular);
        }

        // Randevu tablosunda bir hücreye tıklandığında çalışacak metot
        private void Grid_Randevular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili randevuya ait vatandaş TC'sini etikete doldurur
            Lbl_VatandasTC.Text = Grid_Randevular.CurrentRow.Cells[1].Value.ToString();
        }

        // Muayene kaydet butonuna tıklandığında çalışacak metot
        private void Btn_MuayeneKaydet_Click(object sender, EventArgs e)
        {
            // Formdaki bilgilerle yeni bir muayene nesnesi oluşturur
            var muayene = new MuayeneC(
                        Convert.ToInt32(Grid_Randevular.CurrentRow.Cells[0].Value),
                        doktorID,
                        Lbl_VatandasTC.Text,
                        Rich_Tanı.Text,
                        Rich_Ilac.Text,
                        (int)Nmrc_Rapor.Value);

            // Muayene kaydeder ve randevuları günceller
            MuayeneKaydet(muayene);
            RandevularıGetir(doktorID, Date_Randevu, Grid_Randevular);
        }

    }
}
