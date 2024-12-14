namespace HospitalAppointment
{
    partial class Muayene
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Muayene));
            Lbl_DoktorTC = new Label();
            Date_Randevu = new DateTimePicker();
            Grid_Randevular = new DataGridView();
            label1 = new Label();
            Lbl_DoktorID = new Label();
            label3 = new Label();
            Rich_Tanı = new RichTextBox();
            label2 = new Label();
            Lbl_VatandasTC = new Label();
            label5 = new Label();
            Rich_Ilac = new RichTextBox();
            label6 = new Label();
            Nmrc_Rapor = new NumericUpDown();
            label7 = new Label();
            Btn_MuayeneKaydet = new Button();
            ((System.ComponentModel.ISupportInitialize)Grid_Randevular).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Nmrc_Rapor).BeginInit();
            SuspendLayout();
            // 
            // Lbl_DoktorTC
            // 
            Lbl_DoktorTC.AutoSize = true;
            Lbl_DoktorTC.Location = new Point(98, 25);
            Lbl_DoktorTC.Name = "Lbl_DoktorTC";
            Lbl_DoktorTC.Size = new Size(15, 20);
            Lbl_DoktorTC.TabIndex = 0;
            Lbl_DoktorTC.Text = "*";
            // 
            // Date_Randevu
            // 
            Date_Randevu.Location = new Point(335, 36);
            Date_Randevu.Name = "Date_Randevu";
            Date_Randevu.Size = new Size(214, 27);
            Date_Randevu.TabIndex = 1;
            Date_Randevu.ValueChanged += Date_Randevu_ValueChanged;
            // 
            // Grid_Randevular
            // 
            Grid_Randevular.BackgroundColor = Color.White;
            Grid_Randevular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_Randevular.Location = new Point(27, 106);
            Grid_Randevular.Name = "Grid_Randevular";
            Grid_Randevular.RowHeadersWidth = 51;
            Grid_Randevular.Size = new Size(522, 219);
            Grid_Randevular.TabIndex = 2;
            Grid_Randevular.CellClick += Grid_Randevular_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 25);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 3;
            label1.Text = "T.C. NO :";
            // 
            // Lbl_DoktorID
            // 
            Lbl_DoktorID.AutoSize = true;
            Lbl_DoktorID.Location = new Point(133, 54);
            Lbl_DoktorID.Name = "Lbl_DoktorID";
            Lbl_DoktorID.Size = new Size(15, 20);
            Lbl_DoktorID.TabIndex = 0;
            Lbl_DoktorID.Text = "*";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 54);
            label3.Name = "label3";
            label3.Size = new Size(100, 20);
            label3.TabIndex = 3;
            label3.Text = "DOKTOR NO :";
            // 
            // Rich_Tanı
            // 
            Rich_Tanı.Location = new Point(27, 385);
            Rich_Tanı.Name = "Rich_Tanı";
            Rich_Tanı.Size = new Size(226, 72);
            Rich_Tanı.TabIndex = 4;
            Rich_Tanı.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 331);
            label2.Name = "label2";
            label2.Size = new Size(143, 20);
            label2.TabIndex = 6;
            label2.Text = "VATANDAŞ T.C. NO :";
            // 
            // Lbl_VatandasTC
            // 
            Lbl_VatandasTC.AutoSize = true;
            Lbl_VatandasTC.Location = new Point(176, 331);
            Lbl_VatandasTC.Name = "Lbl_VatandasTC";
            Lbl_VatandasTC.Size = new Size(15, 20);
            Lbl_VatandasTC.TabIndex = 5;
            Lbl_VatandasTC.Text = "*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 362);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 7;
            label5.Text = "TANI /TEHŞİS: ";
            // 
            // Rich_Ilac
            // 
            Rich_Ilac.Location = new Point(303, 385);
            Rich_Ilac.Name = "Rich_Ilac";
            Rich_Ilac.Size = new Size(246, 72);
            Rich_Ilac.TabIndex = 4;
            Rich_Ilac.Text = "";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(303, 362);
            label6.Name = "label6";
            label6.Size = new Size(72, 20);
            label6.TabIndex = 7;
            label6.Text = "İLAÇLAR: ";
            // 
            // Nmrc_Rapor
            // 
            Nmrc_Rapor.Location = new Point(27, 526);
            Nmrc_Rapor.Name = "Nmrc_Rapor";
            Nmrc_Rapor.Size = new Size(226, 27);
            Nmrc_Rapor.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 488);
            label7.Name = "label7";
            label7.Size = new Size(114, 20);
            label7.TabIndex = 7;
            label7.Text = "RAPOR SÜRESİ :";
            // 
            // Btn_MuayeneKaydet
            // 
            Btn_MuayeneKaydet.BackColor = SystemColors.ControlLightLight;
            Btn_MuayeneKaydet.FlatStyle = FlatStyle.Flat;
            Btn_MuayeneKaydet.Location = new Point(303, 468);
            Btn_MuayeneKaydet.Name = "Btn_MuayeneKaydet";
            Btn_MuayeneKaydet.Size = new Size(246, 85);
            Btn_MuayeneKaydet.TabIndex = 9;
            Btn_MuayeneKaydet.Text = "KAYDET";
            Btn_MuayeneKaydet.UseVisualStyleBackColor = false;
            Btn_MuayeneKaydet.Click += Btn_MuayeneKaydet_Click;
            // 
            // Muayene
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(589, 589);
            Controls.Add(Btn_MuayeneKaydet);
            Controls.Add(Nmrc_Rapor);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(Lbl_VatandasTC);
            Controls.Add(Rich_Ilac);
            Controls.Add(Rich_Tanı);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(Grid_Randevular);
            Controls.Add(Lbl_DoktorID);
            Controls.Add(Date_Randevu);
            Controls.Add(Lbl_DoktorTC);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Muayene";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Muayene";
            Load += Muayene_Load;
            ((System.ComponentModel.ISupportInitialize)Grid_Randevular).EndInit();
            ((System.ComponentModel.ISupportInitialize)Nmrc_Rapor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lbl_DoktorTC;
        private DateTimePicker Date_Randevu;
        private DataGridView Grid_Randevular;
        private Label label1;
        private Label Lbl_DoktorID;
        private Label label3;
        private RichTextBox Rich_Tanı;
        private Label label2;
        private Label Lbl_VatandasTC;
        private Label label5;
        private RichTextBox Rich_Ilac;
        private Label label6;
        private NumericUpDown Nmrc_Rapor;
        private Label label7;
        private Button Btn_MuayeneKaydet;
    }
}