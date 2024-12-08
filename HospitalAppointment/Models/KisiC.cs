namespace HospitalAppointment.Model
{
    public abstract class KisiC
    {
        public string TC { get; private set; }
        public string Ad { get; private set; }
        public string Soyad { get; private set; }
        public string Telefon { get; private set; }
        public string Sifre { get; private set; }



        protected KisiC(string tc, string ad, string soyad, string telefon, string sifre)
        {
            if (!TcKimlikNoKontrol(tc))
                throw new ArgumentException("Geçersiz T.C. Kimlik numarası.");
            if (string.IsNullOrWhiteSpace(ad))
                throw new ArgumentException("Ad boş bırakılamaz.");
            if (string.IsNullOrWhiteSpace(soyad))
                throw new ArgumentException("Soyad boş bırakılamaz.");
            if (string.IsNullOrEmpty(telefon) || !telefon.All(char.IsDigit))
                throw new ArgumentException("Telefon sadece rakamlardan oluşmalıdır.");
            if (string.IsNullOrWhiteSpace(sifre))
                throw new ArgumentException("Şifre boş bırakılamaz.");

            TC = tc;
            Ad = ad;
            Soyad = soyad;
            Telefon = telefon;
            Sifre = sifre;
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

}
