namespace HospitalAppointment
{
    partial class VatandasIslemleri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VatandasIslemleri));
            Btn_RandevuEkranYonlendir = new Button();
            Btn_Raporlarım = new Button();
            SuspendLayout();
            // 
            // Btn_RandevuEkranYonlendir
            // 
            Btn_RandevuEkranYonlendir.BackColor = SystemColors.ControlLightLight;
            Btn_RandevuEkranYonlendir.FlatStyle = FlatStyle.Flat;
            Btn_RandevuEkranYonlendir.Location = new Point(12, 12);
            Btn_RandevuEkranYonlendir.Name = "Btn_RandevuEkranYonlendir";
            Btn_RandevuEkranYonlendir.Size = new Size(254, 163);
            Btn_RandevuEkranYonlendir.TabIndex = 0;
            Btn_RandevuEkranYonlendir.Text = "RANDEVU AL";
            Btn_RandevuEkranYonlendir.UseVisualStyleBackColor = false;
            Btn_RandevuEkranYonlendir.Click += Btn_RandevuEkranYonlendir_Click;
            // 
            // Btn_Raporlarım
            // 
            Btn_Raporlarım.BackColor = SystemColors.ControlLightLight;
            Btn_Raporlarım.FlatStyle = FlatStyle.Flat;
            Btn_Raporlarım.Location = new Point(312, 12);
            Btn_Raporlarım.Name = "Btn_Raporlarım";
            Btn_Raporlarım.Size = new Size(254, 163);
            Btn_Raporlarım.TabIndex = 1;
            Btn_Raporlarım.Text = "RAPORLARIM";
            Btn_Raporlarım.UseVisualStyleBackColor = false;
            Btn_Raporlarım.Click += Btn_Raporlarım_Click;
            // 
            // VatandasIslemleri
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(582, 190);
            Controls.Add(Btn_Raporlarım);
            Controls.Add(Btn_RandevuEkranYonlendir);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "VatandasIslemleri";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VatandasIslemleri";
            ResumeLayout(false);
        }

        #endregion

        private Button Btn_RandevuEkranYonlendir;
        private Button Btn_Raporlarım;
    }
}