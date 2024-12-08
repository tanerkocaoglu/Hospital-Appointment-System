namespace HospitalAppointment.Models
{
    public class MuayeneC(int randevuID, int doktorID, string vatandasTC, string tani, string ilac, TimeSpan raporSuresi)
    {
        public int RandevuID { get; private set; } = randevuID;
        public int DoktorID { get; private set; } = doktorID;
        public string VatandasTC { get; private set; } = vatandasTC;
        public string Tani { get; private set; } = tani;
        public string Ilac { get; private set; } = ilac;
        public TimeSpan RaporSuresi { get; private set; } = raporSuresi;
    }

}
