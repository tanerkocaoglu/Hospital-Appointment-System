using HospitalAppointment.Models;

namespace HospitalAppointment;

public partial class Ana_Sayfa : Form
{
    public Ana_Sayfa()
    {
        InitializeComponent();
    }
    private static string vatandasTC = "";
    private static string doktorTC = "";

    public static string VatandasTC { get => vatandasTC; set => vatandasTC = value; }
    public static string DoktorTC { get => doktorTC; set => doktorTC = value; }

    // Kullanıcı giriş işlemini gerçekleştiren metot
    private void KullaniciGiris(string tabloAdi, TextBox tcTextBox, TextBox sifreTextBox)
    {
        // T.C. kimlik numarası ve şifreyi metin kutularından alıp düzenler
        var tcNo = tcTextBox.Text.Trim();
        var sifre = sifreTextBox.Text.Trim();

        // T.C. kimlik numarasının geçerliliğini kontrol eder
        if (!TcKimlikNoKontrol(tcNo))
        {
            // Geçersiz T.C. kimlik numarası için uyarı mesajı gösterir
            MessageBox.Show("Geçersiz T.C. NO!!");
            return;
        }

        // Veritabanı sorgusu: Kullanıcının giriş bilgilerini kontrol eder
        var sqlSorgusu = $"SELECT COUNT(*) FROM {tabloAdi} WHERE TC=@TC AND Sifre=@Sifre";

        try
        {
            // SQL sorgusu için gerekli parametrelerin hazırlanması
            var parametreler = new Dictionary<string, object>()
            {
                {"@TC", tcNo},
                {"@Sifre", sifre}
            };

            // Veritabanı sorgusunu çalıştırır ve sonucu alır
            var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, tekDegerMi: true);

            // Kullanıcı giriş yaparsa TC bilgilerini global değişkenlere atar
            VatandasTC = tcTextBox.Text;
            DoktorTC = tcTextBox.Text;

            // Eğer sorgu sonucu giriş bilgileri doğruysa
            if (sonuc is int etkilenenSatir && etkilenenSatir > 0)
            {
                // Tablo adına göre uygun giriş işlemini gerçekleştirir
                TabloyaGoreGirisYap(tabloAdi);
            }
            else
            {
                // Giriş bilgileri hatalıysa uyarı mesajı gösterir
                MessageBox.Show("Bilgileriniz hatalı. Lütfen tekrar deneyiniz.");
            }
        }
        catch (Exception ex)
        {
            // Beklenmeyen bir hata oluştuğunda hata mesajı gösterir
            MessageBox.Show($"Bir hata oluştu: {ex.Message}");
        }
    }

    // Verilen tablo adına göre uygun giriş işlemini gerçekleştiren metot
    private void TabloyaGoreGirisYap(string tabloAdi)
    {
        switch (tabloAdi)
        {
            // Yetkililer tablosu seçildiyse, yetkili giriş işlemi yapılır
            case "Tbl_Yetkililer":
                YetkiliGiris();
                break;

            // Vatandaşlar tablosu seçildiyse, vatandaş giriş işlemi yapılır
            case "Tbl_Vatandaslar":
                VatandasGiris();
                break;

            // Doktorlar tablosu seçildiyse, doktor giriş işlemi yapılır
            case "Tbl_Doktorlar":
                DoktorGiris();
                break;

            // Bilinmeyen tablo türü için uyarı mesajı gösterilir
            default:
                MessageBox.Show("Bilinmeyen tablo türü!");
                break;
        }
    }

    // Yetkili giriş işlemini gerçekleştiren metot
    private void YetkiliGiris()
    {
        // Yetkili formu açılır ve mevcut form gizlenir
        var yetkili = new Yetkili();
        yetkili.Show();
        Hide();
    }

    // Doktor giriş işlemini gerçekleştiren metot
    private void DoktorGiris()
    {
        // Muayene formu açılır ve mevcut form gizlenir
        var muayene = new Muayene();
        muayene.Show();
        Hide();
    }

    // Vatandaş giriş işlemini gerçekleştiren metot
    private void VatandasGiris()
    {
        // Vatandaş işlemleri formu açılır ve mevcut form gizlenir
        var vatandasIslemleri = new VatandasIslemleri();
        vatandasIslemleri.Show();
        Hide();
    }

    // Vatandaş kayıt işlemini gerçekleştiren metot
    private static void VatandasKayit(VatandasC vatandas)
    {
        // SQL sorgusu: Vatandaş bilgilerini veritabanına eklemek için
        string sqlSorgusu = "insert into Tbl_Vatandaslar(TC,Ad,Soyad,Telefon,Sifre) values(@TC,@Ad,@Soyad,@Telefon,@Sifre)";
        try
        {
            // Vatandaşın daha önce kayıtlı olup olmadığını kontrol ediyor
            var kullaniciVarMi = VeritabaniIslemleri.KullaniciVarMi(vatandas.TC);

            // Eğer vatandaş kayıtlı değilse
            if (!kullaniciVarMi)
            {
                // SQL sorgusu için gerekli parametrelerin hazırlanması
                var parametreler = new Dictionary<string, object>()
                {
                    {"@TC", vatandas.TC},
                    {"@Ad",vatandas.Ad },
                    {"@Soyad",vatandas.Soyad},
                    {"@Telefon",vatandas.Telefon},
                    {"@Sifre", vatandas.Sifre}
                };

                // Veritabanı işlemini gerçekleştiriyor (kayıt ekleme)
                var sonuc = VeritabaniIslemleri.SorguCalistir(sqlSorgusu, parametreler, islemTuru: true);

                // Eğer işlem başarılıysa
                if (sonuc is int etkilenenSatir && etkilenenSatir > 0)
                {
                    MessageBox.Show("Kayıt işlemi başarılı");
                }
                else
                {
                    // İşlem başarısız olduğunda hata mesajı gösteriliyor
                    MessageBox.Show("Kayıt olunurken bir hata oluştu!!");
                }
            }
            else
            {
                // Vatandaş zaten kayıtlıysa uyarı mesajı gösteriliyor
                MessageBox.Show("Vatandaş zaten kayıtlı.");
            }
        }
        catch (Exception ex)
        {
            // Beklenmeyen bir hata oluştuğunda hata mesajı gösteriliyor
            MessageBox.Show(ex.Message);
        }
    }

    // "Kayıt" butonuna tıklama olayını yöneten metot
    private void Btn_VatandasKayıt_Click(object sender, EventArgs e)
    {
        try
        {
            // Formdan alınan verilerle yeni bir vatandaş nesnesi oluşturuluyor
            var vatandas = new VatandasC(
                Txt_VatandasTc.Text.Trim(),
                Txt_VatandasAd.Text.Trim(),
                Txt_VatandasSoyad.Text.Trim(),
                Txt_VatandasTel.Text.Trim(),
                Txt_VatandasSifre.Text.Trim()
            );

            // Oluşturulan vatandaş nesnesi kayıt metotuna gönderiliyor
            VatandasKayit(vatandas);
        }
        catch (Exception ex)
        {
            // Form işlemlerinde oluşabilecek hatalar için mesaj gösteriliyor
            MessageBox.Show(ex.Message);
        }
    }

    // Vatandaş giriş butonuna tıklama olayını yöneten metot
    private void Btn_VatandasGiris_Click(object sender, EventArgs e)
    {
        // Vatandaş giriş bilgilerini kullanarak giriş işlemini gerçekleştirir
        KullaniciGiris("Tbl_Vatandaslar", Txt_VatandasGirisTc, Txt_VatandasGirisSifre);
    }

    // Doktor giriş butonuna tıklama olayını yöneten metot
    private void Btn_DoktorGiris_Click(object sender, EventArgs e)
    {
        // Doktor giriş bilgilerini kullanarak giriş işlemini gerçekleştirir
        KullaniciGiris("Tbl_Doktorlar", Txt_DoktorTc, Txt_DoktorSifre);
    }

    // Yetkili giriş butonuna tıklama olayını yöneten metot
    private void Btn_YetkiliGiris_Click(object sender, EventArgs e)
    {
        // Yetkili giriş bilgilerini kullanarak giriş işlemini gerçekleştirir
        KullaniciGiris("Tbl_Yetkililer", Txt_YetkiliTc, Txt_YetkiliSifre);
    }

    private static bool TcKimlikNoKontrol(string tcKimlikNo)
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
