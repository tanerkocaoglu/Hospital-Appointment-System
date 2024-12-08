using HospitalAppointment.Model;

namespace HospitalAppointment.Models
{
    public class DoktorC : KisiC
    {
        public int Doktor_ID { get; set; }
        public int Klinik_ID { get; set; }
        public DoktorC(string tc, string ad, string soyad, string telefon, string sifre, int klinik_ID, int doktor_ID = 0)
         : base(tc, ad, soyad, telefon, sifre)
        {
            if (klinik_ID <= 0)
                throw new ArgumentException("Klinik hatalı kral.");
            Klinik_ID = klinik_ID;
            Doktor_ID = doktor_ID;
        }

    }

}
