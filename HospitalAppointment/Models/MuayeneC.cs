namespace HospitalAppointment.Models
{
    public class MuayeneC(int randevuID, int doktorID, string vatandasTC, string tani, string ilac, int raporSuresi)
    {
        public int RandevuID { get; private set; } = randevuID;
        public int DoktorID { get; private set; } = doktorID;
        public string VatandasTC { get; private set; } = vatandasTC;
        public string Tani { get; private set; } = tani;
        public string Ilac { get; private set; } = ilac;
        public int RaporSuresi { get; private set; } = raporSuresi;
    }

}
