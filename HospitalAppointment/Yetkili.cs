using HospitalAppointment.Model;
using HospitalAppointment.Models;

namespace HospitalAppointment;

public partial class Yetkili : Form
{
    public Yetkili()
    {
        InitializeComponent();
    }

    short doktorId;

    private void KlinikSayısı()
    {
        string sqlSorgusu = "SELECT COUNT(*) FROM Tbl_Klinikler WHERE aktifMi = '1'";
        var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, tekDegerMi: true);

        if (sonuc != null && int.TryParse(sonuc.ToString(), out int klinikSayisi))
        {
            Lbl_KlinikSayisi.Text = klinikSayisi.ToString();
        }
        else
        {
            MessageBox.Show("Klinik sayısı alınırken hata oluştu.");
        }
    }

    private void KlinikIslemleri()
    {
        List<KlinikC> klinikler = [];
        VeritabaniIslemleri.KlinikDoldur(Cmb_Klinik, klinikler);
        VeritabaniIslemleri.KlinikDoldur(Cmb_DoktorKlinik, klinikler);
        KlinikSayısı();
    }

    private void KlinikEkle(KlinikC klinik)
    {
        if (string.IsNullOrWhiteSpace(klinik.KlinikAd))
        {
            MessageBox.Show("Klinik adı boş olamaz.");
            return;
        }

        string sqlSorgusu = "insert into Tbl_Klinikler(Klinik_Ad) values(@Klinik_Ad)";
        var parametreler = new Dictionary<string, object>()
        {
            { "@Klinik_Ad", klinik.KlinikAd }
        };

        var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);

        if (sonuc is int etkilenenSatir && etkilenenSatir > 0)
        {
            MessageBox.Show("Klinik başarıyla eklendi.");
            KlinikIslemleri();
        }
        else
            MessageBox.Show("Klinik eklenirken bir hata oluştu.");
    }

    private void KlinikSil(KlinikC klinik)
    {
        string sqlSorgusu = "update Tbl_Klinikler set aktifMi='0' where Klinik_ID=@Klinik_ID";

        var parametreler = new Dictionary<string, object>()
        {
            {"@Klinik_ID", klinik.KlinikID}
        };

        var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);

        if (sonuc is int etilenenSatir && etilenenSatir > 0)
        {
            MessageBox.Show("Klinik başarıyla silindi.");
            KlinikIslemleri();
        }
        else
            MessageBox.Show("Klinik silinemedi.");
    }

    private static void DoktorGridDoldur(DataGridView dataGridView)
    {
        string sqlSorgusu = @"
            SELECT 
                d.Doktor_ID AS 'ID',
                d.TC AS 'T.C. NO',
                d.Ad AS 'Ad',
                d.Soyad AS 'Soyad',
                d.Telefon AS 'Telefon',
                d.Sifre AS 'Sifre',
                k.Klinik_Ad AS 'Klinik'
            FROM 
                Tbl_Doktorlar d
            INNER JOIN 
                Tbl_Klinikler k ON d.Klinik_ID = k.Klinik_ID
            WHERE
                d.aktifMi = '1'";

        VeritabaniIslemleri.GridDoldur(sqlSorgusu, dataGridView);
    }

    private void DoktorEkle(DoktorC doktor)
    {
        string sqlSorgusu = @"
            insert into Tbl_Doktorlar(TC,Ad,Soyad,Telefon,Sifre,Klinik_ID)
            values(@TC,@Ad,@Soyad,@Telefon,@Sifre,@Klinik_ID)";

        var doktorVarMi = VeritabaniIslemleri.KullaniciVarMi(doktor.TC);

        if (!doktorVarMi)
        {
            var parametreler = new Dictionary<string, object>()
            {
            {"@TC", doktor.TC },
            {"@Ad",doktor.Ad },
            {"@Soyad",doktor.Soyad },
            {"@Telefon",doktor.Telefon },
            {"@Sifre",doktor.Sifre },
            {"@Klinik_ID",doktor.Klinik_ID }
            };

            var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);
            if (sonuc is int etkilenenSatir && etkilenenSatir > 0)
            {
                MessageBox.Show("Doktor başarıyla etkilendi.");
                DoktorGridDoldur(Grid_Doktorlar);
            }
            else
                MessageBox.Show("Doktor eklenirken bir sorun oluştu.");
        }
        else
            MessageBox.Show("Doktor zaten kayıtlı.");
    }

    private void DoktorGuncelle(DoktorC doktor)
    {
        string sqlSorgusu = @"
                        UPDATE Tbl_Doktorlar
                        SET
                            TC = @TC, 
                            Ad = @Ad,
                            Soyad = @Soyad,
                            Telefon = @Telefon,
                            Sifre = @Sifre,
                            Klinik_ID = @Klinik_ID
                        WHERE 
                            Doktor_ID = @Doktor_ID";

        var parametreler = new Dictionary<string, object>()
        {
            {"@Doktor_ID",doktor.Doktor_ID},
            {"@TC", doktor.TC },
            {"@Ad",doktor.Ad },
            {"@Soyad",doktor.Soyad },
            {"@Telefon",doktor.Telefon },
            {"@Sifre",doktor.Sifre },
            {"@Klinik_ID",doktor.Klinik_ID }
        };
        var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);

        if (sonuc is int etkilenenSatir && etkilenenSatir > 0)
        {
            MessageBox.Show("Doktor başarıyla güncellendi.");
            DoktorGridDoldur(Grid_Doktorlar);
        }
        else
            MessageBox.Show("Doktor güncellenirken bir sorun oluştu.");
    }

    private void DoktorSil()
    {
        if (doktorId == 0)
        {
            MessageBox.Show("Doktor seçsene dostum");
            return;
        }
        string sqlSorgusu = "update Tbl_Doktorlar set aktifMi='0' where Doktor_ID=@Doktor_ID";

        var parametreler = new Dictionary<string, object>()
        {
            {"@Doktor_ID", doktorId}
        };

        var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);

        if (sonuc is int etilenenSatir && etilenenSatir > 0)
        {
            MessageBox.Show("Doktor başarıyla silindi.");
            DoktorGridDoldur(Grid_Doktorlar);
            doktorId = 0;
        }
        else
            MessageBox.Show("Doktor silinemedi.");
    }

    private void Yetkili_Load(object sender, EventArgs e)
    {
        _ = new GridView_Tasarim(Grid_Doktorlar);
        KlinikIslemleri();
        DoktorGridDoldur(Grid_Doktorlar);
    }

    private void Btn_KlinikEkle_Click(object sender, EventArgs e)
    {
        var klinik = new KlinikC(klinikAd: Txt_KlinikEkle.Text.Trim());
        KlinikEkle(klinik);
    }

    private void Btn_KlinikSil_Click(object sender, EventArgs e)
    {
        if (Cmb_Klinik.SelectedValue != null)
        {
            var klinik = new KlinikC(klinikID: Convert.ToInt32(Cmb_Klinik.SelectedValue));
            KlinikSil(klinik);
        }
        else
            MessageBox.Show("Lütfen silmek istediğiniz kliniği seçiniz.");
    }

    private void Btn_DoktorEkle_Click(object sender, EventArgs e)
    {
        try
        {
            if (Cmb_DoktorKlinik.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir klinik seçiniz.");
                return;
            }
            var doktor = new DoktorC(Txt_DoktorTC.Text.Trim(), Txt_DoktorAd.Text.Trim(), Txt_DoktorSoyad.Text.Trim(), Txt_DoktorTelefon.Text.Trim(), Txt_DoktorSifre.Text.Trim(), (int)Cmb_DoktorKlinik.SelectedValue);

            DoktorEkle(doktor);

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Btn_DoktorGuncelle_Click(object sender, EventArgs e)
    {
        try
        {
            if (Cmb_DoktorKlinik.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir klinik seçiniz.");
                return;
            }
            var doktor = new DoktorC(Txt_DoktorTC.Text.Trim(), Txt_DoktorAd.Text.Trim(), Txt_DoktorSoyad.Text.Trim(), Txt_DoktorTelefon.Text.Trim(), Txt_DoktorSifre.Text.Trim(), (int)Cmb_DoktorKlinik.SelectedValue, doktorId);
            DoktorGuncelle(doktor);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void Btn_DoktorSil_Click(object sender, EventArgs e)
    {
        DoktorSil();
    }

    private void Grid_Doktorlar_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0) // Satır seçildiyse
        {
            using var selectedRow = Grid_Doktorlar.Rows[e.RowIndex];

            doktorId = (short)selectedRow.Cells["ID"].Value;

            string doktorTc = (string)selectedRow.Cells["T.C. NO"].Value;
            string doktorAd = (string)selectedRow.Cells["Ad"].Value;
            string doktorSoyad = (string)selectedRow.Cells["Soyad"].Value;
            string doktorTelefon = (string)selectedRow.Cells["Telefon"].Value;
            string doktorSifre = (string)selectedRow.Cells["Sifre"].Value;
            string klinikAd = (string)selectedRow.Cells["Klinik"].Value;

            // Textbox'lara doktor bilgilerini doldur
            Txt_DoktorTC.Text = doktorTc;
            Txt_DoktorAd.Text = doktorAd;
            Txt_DoktorSoyad.Text = doktorSoyad;
            Txt_DoktorTelefon.Text = doktorTelefon;
            Txt_DoktorSifre.Text = doktorSifre;

            // ComboBox'ta klinik adını seçili hale getir
            foreach (var item in Cmb_DoktorKlinik.Items)
            {
                var klinik = (KlinikC)item;
                if (klinik != null && klinik.KlinikAd == klinikAd)
                {
                    Cmb_DoktorKlinik.SelectedItem = item;
                    break;
                }
            }
        }
    }

}