namespace HospitalAppointment
{
    partial class Randevu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Lbl_VatandasTC = new Label();
            label1 = new Label();
            List_Doktor = new ListBox();
            Cmb_Klinik = new ComboBox();
            Date_RandevuTarih = new DateTimePicker();
            Btn_RandevuEkle = new Button();
            label2 = new Label();
            label3 = new Label();
            Cmb_RandevuSaat = new ComboBox();
            SuspendLayout();
            // 
            // Lbl_VatandasTC
            // 
            Lbl_VatandasTC.AutoSize = true;
            Lbl_VatandasTC.Location = new Point(129, 44);
            Lbl_VatandasTC.Name = "Lbl_VatandasTC";
            Lbl_VatandasTC.Size = new Size(15, 20);
            Lbl_VatandasTC.TabIndex = 0;
            Lbl_VatandasTC.Text = "*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 1;
            label1.Text = "T.C. Numaranız : ";
            // 
            // List_Doktor
            // 
            List_Doktor.FormattingEnabled = true;
            List_Doktor.Location = new Point(132, 158);
            List_Doktor.Name = "List_Doktor";
            List_Doktor.Size = new Size(150, 104);
            List_Doktor.TabIndex = 2;
            List_Doktor.SelectedIndexChanged += List_Doktor_SelectedIndexChanged;
            // 
            // Cmb_Klinik
            // 
            Cmb_Klinik.FormattingEnabled = true;
            Cmb_Klinik.Location = new Point(132, 95);
            Cmb_Klinik.Name = "Cmb_Klinik";
            Cmb_Klinik.Size = new Size(151, 28);
            Cmb_Klinik.TabIndex = 3;
            Cmb_Klinik.SelectedIndexChanged += Cmb_Klinik_SelectedIndexChanged;
            // 
            // Date_RandevuTarih
            // 
            Date_RandevuTarih.Location = new Point(311, 96);
            Date_RandevuTarih.Name = "Date_RandevuTarih";
            Date_RandevuTarih.Size = new Size(250, 27);
            Date_RandevuTarih.TabIndex = 4;
            Date_RandevuTarih.ValueChanged += Date_RandevuTarih_ValueChanged;
            // 
            // Btn_RandevuEkle
            // 
            Btn_RandevuEkle.Location = new Point(578, 95);
            Btn_RandevuEkle.Name = "Btn_RandevuEkle";
            Btn_RandevuEkle.Size = new Size(250, 167);
            Btn_RandevuEkle.TabIndex = 5;
            Btn_RandevuEkle.Text = "RANDEVU OLUŞTUR";
            Btn_RandevuEkle.UseVisualStyleBackColor = true;
            Btn_RandevuEkle.Click += Btn_RandevuEkle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 99);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 6;
            label2.Text = "Klinik Seçiniz :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 158);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 6;
            label3.Text = "Doktor Seçiniz :";
            // 
            // Cmb_RandevuSaat
            // 
            Cmb_RandevuSaat.FormattingEnabled = true;
            Cmb_RandevuSaat.Location = new Point(311, 158);
            Cmb_RandevuSaat.Name = "Cmb_RandevuSaat";
            Cmb_RandevuSaat.Size = new Size(250, 28);
            Cmb_RandevuSaat.TabIndex = 7;
            // 
            // Randevu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 328);
            Controls.Add(Cmb_RandevuSaat);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Btn_RandevuEkle);
            Controls.Add(Date_RandevuTarih);
            Controls.Add(Cmb_Klinik);
            Controls.Add(List_Doktor);
            Controls.Add(label1);
            Controls.Add(Lbl_VatandasTC);
            Name = "Randevu";
            Text = "Randevu";
            Load += Randevu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_VatandasTC;
        private Label label1;
        private ListBox List_Doktor;
        private ComboBox Cmb_Klinik;
        private DateTimePicker Date_RandevuTarih;
        private Button Btn_RandevuEkle;
        private Label label2;
        private Label label3;
        private ComboBox Cmb_RandevuSaat;
    }
}