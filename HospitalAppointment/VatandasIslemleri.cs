namespace HospitalAppointment
{
    public partial class VatandasIslemleri : Form
    {
        public VatandasIslemleri()
        {
            InitializeComponent();
        }

        // Randevu ekranına yönlendiren butonun tıklama olayı
        private void Btn_RandevuEkranYonlendir_Click(object sender, EventArgs e)
        {
            // Randevu formunu gösterir ve mevcut formu kapatır.
            var randevu = new Randevu();
            randevu.Show();
            Close();
        }

        // Raporlarım ekranına yönlendiren butonun tıklama olayı
        private void Btn_Raporlarım_Click(object sender, EventArgs e)
        {
            // Raporlarım formunu gösterir ve mevcut formu kapatır.
            var raporlarım = new Raporlarım();
            raporlarım.Show();
            Close();
        }

    }
}
