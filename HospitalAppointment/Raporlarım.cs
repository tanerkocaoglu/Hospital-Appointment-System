namespace HospitalAppointment;

public partial class Raporlarım : Form
{
    public Raporlarım()
    {
        InitializeComponent();
    }

    // Raporlar formu yüklendiğinde çalışacak metot
    private void Raporlarım_Load(object sender, EventArgs e)
    {
        // Vatandaşın rapor bilgilerini getiren SQL sorgusu
        string sqlSorgusu = @"SELECT 
                            m.Randevu_ID AS [Randevu No],
                            CONCAT(d.Ad, ' ', d.Soyad) AS [Doktor Adı], 
                            m.Vatandas_TC AS [TC Kimlik No], 
                            m.Tani AS [Tanı Kodu], 
                            m.Ilac AS [İlaç Adı],
                            m.Rapor_Suresi AS [Rapor Süresi]
                        FROM 
                            [dbo].[Tbl_Muayeneler] AS m
                        INNER JOIN 
                            [dbo].[Tbl_Doktorlar] AS d
                        ON 
                            m.Doktor_ID = d.Doktor_ID
                        WHERE 
                            m.Vatandas_TC = @Vatandas_TC";

        // SQL sorgusuna gönderilecek parametreler
        var parametreler = new Dictionary<string, object>()
        {
            {"@Vatandas_TC" , Ana_Sayfa.VatandasTC} // Giriş yapan vatandaşın TC kimlik numarası
        };

        // GridView'e sorgu sonuçlarını doldurur
        VeritabaniIslemleri.GridDoldur(sqlSorgusu, Grid_Raporlar, parametreler);

        // GridView tasarımını özelleştirir
        _ = new GridView_Tasarim(Grid_Raporlar);
    }

    // Geri dön butonuna tıklandığında çalışacak metot
    private void Btn_GeriDon_Click(object sender, EventArgs e)
    {
        // Vatandaş işlemleri formunu açar
        var vatandasIslemleri = new VatandasIslemleri();
        vatandasIslemleri.Show();

        // Mevcut formu kapatır
        this.Close();
    }

}
