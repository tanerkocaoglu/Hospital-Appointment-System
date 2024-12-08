using HospitalAppointment.Model;

namespace HospitalAppointment.Models
{
    public class YetkiliC : KisiC
    {
        public string Gorev { get; private set; }

        public YetkiliC(string tc, string ad, string soyad, string telefon, string sifre, string gorev)
            : base(tc, ad, soyad, telefon, sifre)
        {
            if (string.IsNullOrWhiteSpace(gorev))
                throw new ArgumentException("Görev boş bırakılamaz.");
            Gorev = gorev;
        }
    }



}
