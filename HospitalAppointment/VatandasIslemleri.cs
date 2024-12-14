namespace HospitalAppointment
{
    public partial class VatandasIslemleri : Form
    {
        public VatandasIslemleri()
        {
            InitializeComponent();
        }

        private void Btn_RandevuEkranYonlendir_Click(object sender, EventArgs e)
        {
            var randevu = new Randevu();
            randevu.Show();
            this.Close();
        }

        private void Btn_Raporlarım_Click(object sender, EventArgs e)
        {
            var raporlarım = new Raporlarım();
            raporlarım.Show();
            this.Close();
        }
    }
}
