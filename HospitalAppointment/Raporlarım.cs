using System.Windows.Forms;

namespace HospitalAppointment
{
    public partial class Raporlarım : Form
    {
        public Raporlarım()
        {
            InitializeComponent();
        }


        private void Raporlarım_Load(object sender, EventArgs e)
        {
            string sqlSorgusu = @"SELECT 
            m.Randevu_ID AS [Randevu No],
            CONCAT(d.Ad, ' ', d.Soyad) AS [Doktor Adı], 
            m.Vatandas_TC AS [TC Kimlik No], 
            m.Tani AS [Tanı Kodu], 
            m.Ilac AS [İlaç Adı],
            m.Rapor_Suresi AS [Rapor Süresi]
            FROM [dbo].[Tbl_Muayeneler] AS m
            INNER JOIN [dbo].[Tbl_Doktorlar] AS d
            ON m.Doktor_ID = d.Doktor_ID";

            var parametreler = new Dictionary<string, object>()
            {
                {"@Vatandas_TC" , Ana_Sayfa.VatandasTC}
            };

            VeritabaniIslemleri.GridDoldur(sqlSorgusu, Grid_Raporlar, parametreler);
            _ = new GridView_Tasarim(Grid_Raporlar);
        }

        private void Btn_GeriDon_Click(object sender, EventArgs e)
        {
            var vatandasIslemleri = new VatandasIslemleri();
            vatandasIslemleri.Show();
            this.Close();
        }
    }
}
