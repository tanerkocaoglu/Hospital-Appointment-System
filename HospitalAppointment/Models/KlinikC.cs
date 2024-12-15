namespace HospitalAppointment.Models;
public class KlinikC
{
    public int? KlinikID { get; private set; }
    public string? KlinikAd { get; private set; }

    public KlinikC(string? klinikAd = "", int? klinikID = null)
    {
        if (string.IsNullOrEmpty(klinikAd) && klinikID == null)
        {
            KlinikAd = "";
            KlinikID = null;
        }
        else
        {
            KlinikAd = klinikAd;
            KlinikID = klinikID;
        }
    }


}
