namespace HospitalAppointment.Models;
public class RandevuC
{
    public string VatandasTC { get; private set; }
    public int DoktorID { get; private set; }
    public DateTime RandevuTarih { get; private set; }
    public RandevuC(string vatandasTC, int doktorID, DateTime randevuTarih)
    {
        VatandasTC = vatandasTC;
        DoktorID = doktorID;
        RandevuTarih = randevuTarih;

    }
}
