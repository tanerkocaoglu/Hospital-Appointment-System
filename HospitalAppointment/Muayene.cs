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

        private int DoktorIdGetir()
        {
            string sqlSorgusu = "select Doktor_ID from Tbl_Doktorlar where TC=@TC";
            var parametreler = new Dictionary<string, object>()
            {
                {"@TC", doktorTC}
            };

            var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler);
            if (sonuc is DataTable dataTable && dataTable.Rows.Count > 0)
            {
                int doktorID = Convert.ToInt32(dataTable.Rows[0]["Doktor_ID"]);
                return doktorID;
            }
            return 1903;
        }

        private static void RandevularıGetir(int doktorID, DateTimePicker dateTimePicker, DataGridView dataGridView)
        {
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

            VeritabaniIslemleri.GridDoldur(sqlSorgusu, dataGridView, parametreler);
        }


        private void MuayeneKaydet(MuayeneC muayene)
        {
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

            var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);

            if (sonuc is int etkilenenSatirlar && etkilenenSatirlar > 0)
            {
                MessageBox.Show("Muayene başarılı.");
                RandevularıGetir(doktorID, Date_Randevu, Grid_Randevular);
            }
            else
                MessageBox.Show("Başarısız.");

        }
        private static void GridTasarim(DataGridView gridView)
        {
            // GridView Tasarımı
            gridView.EnableHeadersVisualStyles = false;

            // Başlık Ayarları
            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridView.ColumnHeadersHeight = 35;

            // Satır Ayarları
            gridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            gridView.DefaultCellStyle.BackColor = Color.White;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            gridView.RowTemplate.Height = 30;

            // Seçim Renkleri
            gridView.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            gridView.DefaultCellStyle.SelectionForeColor = Color.White;

            // Kenarlık ve Hücre Ayarları
            gridView.BorderStyle = BorderStyle.FixedSingle;
            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridView.GridColor = Color.LightGray;

            gridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void Muayene_Load(object sender, EventArgs e)
        {
            doktorID = DoktorIdGetir();

            Lbl_DoktorTC.Text = doktorTC;
            Lbl_DoktorID.Text = doktorID.ToString();
            Date_Randevu.MinDate = DateTime.Today;
            Date_Randevu.Value = DateTime.Today;
            _ = new GridView_Tasarim(Grid_Randevular);
        }

        private void Date_Randevu_ValueChanged(object sender, EventArgs e)
        {
            RandevularıGetir(doktorID, Date_Randevu, Grid_Randevular);
        }

        private void Grid_Randevular_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Lbl_VatandasTC.Text = Grid_Randevular.CurrentRow.Cells[1].Value.ToString();
        }

        private void Btn_MuayeneKaydet_Click(object sender, EventArgs e)
        {
            var muayene = new MuayeneC(
                        Convert.ToInt32(Grid_Randevular.CurrentRow.Cells[0].Value),
                        doktorID,
                        Lbl_VatandasTC.Text,
                        Rich_Tanı.Text,
                        Rich_Ilac.Text,
                        (int)Nmrc_Rapor.Value);

            MuayeneKaydet(muayene);
            RandevularıGetir(doktorID, Date_Randevu, Grid_Randevular);
        }


    }
}
