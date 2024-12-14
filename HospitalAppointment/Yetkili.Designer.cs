namespace HospitalAppointment
{
    partial class Yetkili
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Yetkili));
            Cmb_Klinik = new ComboBox();
            label1 = new Label();
            Txt_KlinikEkle = new TextBox();
            Btn_KlinikEkle = new Button();
            label2 = new Label();
            groupBox1 = new GroupBox();
            Lbl_KlinikSayisi = new Label();
            Btn_KlinikSil = new Button();
            groupBox2 = new GroupBox();
            Btn_DoktorSil = new Button();
            Btn_DoktorGuncelle = new Button();
            Btn_DoktorEkle = new Button();
            Grid_Doktorlar = new DataGridView();
            Txt_DoktorSifre = new TextBox();
            Txt_DoktorTelefon = new TextBox();
            Txt_DoktorSoyad = new TextBox();
            Txt_DoktorAd = new TextBox();
            Txt_DoktorTC = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label8 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            Cmb_DoktorKlinik = new ComboBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Grid_Doktorlar).BeginInit();
            SuspendLayout();
            // 
            // Cmb_Klinik
            // 
            Cmb_Klinik.FormattingEnabled = true;
            Cmb_Klinik.Location = new Point(1009, 32);
            Cmb_Klinik.Name = "Cmb_Klinik";
            Cmb_Klinik.Size = new Size(151, 28);
            Cmb_Klinik.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(900, 35);
            label1.Name = "label1";
            label1.Size = new Size(102, 20);
            label1.TabIndex = 1;
            label1.Text = "Klinik Seçiniz :";
            // 
            // Txt_KlinikEkle
            // 
            Txt_KlinikEkle.Location = new Point(167, 31);
            Txt_KlinikEkle.Multiline = true;
            Txt_KlinikEkle.Name = "Txt_KlinikEkle";
            Txt_KlinikEkle.Size = new Size(157, 28);
            Txt_KlinikEkle.TabIndex = 2;
            // 
            // Btn_KlinikEkle
            // 
            Btn_KlinikEkle.Location = new Point(37, 75);
            Btn_KlinikEkle.Name = "Btn_KlinikEkle";
            Btn_KlinikEkle.Size = new Size(287, 43);
            Btn_KlinikEkle.TabIndex = 3;
            Btn_KlinikEkle.Text = "Klinik Ekle";
            Btn_KlinikEkle.UseVisualStyleBackColor = true;
            Btn_KlinikEkle.Click += Btn_KlinikEkle_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 35);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 1;
            label2.Text = "Klinik Adı Giriniz :";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(Lbl_KlinikSayisi);
            groupBox1.Controls.Add(Cmb_Klinik);
            groupBox1.Controls.Add(Btn_KlinikSil);
            groupBox1.Controls.Add(Btn_KlinikEkle);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Txt_KlinikEkle);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(11, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1210, 148);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Klinik İşlemleri";
            // 
            // Lbl_KlinikSayisi
            // 
            Lbl_KlinikSayisi.AutoSize = true;
            Lbl_KlinikSayisi.Location = new Point(1177, 36);
            Lbl_KlinikSayisi.Name = "Lbl_KlinikSayisi";
            Lbl_KlinikSayisi.Size = new Size(17, 20);
            Lbl_KlinikSayisi.TabIndex = 4;
            Lbl_KlinikSayisi.Text = "0";
            // 
            // Btn_KlinikSil
            // 
            Btn_KlinikSil.Location = new Point(900, 75);
            Btn_KlinikSil.Name = "Btn_KlinikSil";
            Btn_KlinikSil.Size = new Size(261, 43);
            Btn_KlinikSil.TabIndex = 3;
            Btn_KlinikSil.Text = "Klinik Sil";
            Btn_KlinikSil.UseVisualStyleBackColor = true;
            Btn_KlinikSil.Click += Btn_KlinikSil_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ActiveCaption;
            groupBox2.Controls.Add(Btn_DoktorSil);
            groupBox2.Controls.Add(Btn_DoktorGuncelle);
            groupBox2.Controls.Add(Btn_DoktorEkle);
            groupBox2.Controls.Add(Grid_Doktorlar);
            groupBox2.Controls.Add(Txt_DoktorSifre);
            groupBox2.Controls.Add(Txt_DoktorTelefon);
            groupBox2.Controls.Add(Txt_DoktorSoyad);
            groupBox2.Controls.Add(Txt_DoktorAd);
            groupBox2.Controls.Add(Txt_DoktorTC);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(Cmb_DoktorKlinik);
            groupBox2.Location = new Point(11, 172);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1210, 307);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Doktor İşlemleri";
            // 
            // Btn_DoktorSil
            // 
            Btn_DoktorSil.Location = new Point(368, 251);
            Btn_DoktorSil.Name = "Btn_DoktorSil";
            Btn_DoktorSil.Size = new Size(826, 36);
            Btn_DoktorSil.TabIndex = 8;
            Btn_DoktorSil.Text = "Seçili Doktoru Sil";
            Btn_DoktorSil.UseVisualStyleBackColor = true;
            Btn_DoktorSil.Click += Btn_DoktorSil_Click;
            // 
            // Btn_DoktorGuncelle
            // 
            Btn_DoktorGuncelle.Location = new Point(185, 251);
            Btn_DoktorGuncelle.Name = "Btn_DoktorGuncelle";
            Btn_DoktorGuncelle.Size = new Size(139, 36);
            Btn_DoktorGuncelle.TabIndex = 8;
            Btn_DoktorGuncelle.Text = "Doktor Güncelle";
            Btn_DoktorGuncelle.UseVisualStyleBackColor = true;
            Btn_DoktorGuncelle.Click += Btn_DoktorGuncelle_Click;
            // 
            // Btn_DoktorEkle
            // 
            Btn_DoktorEkle.Location = new Point(37, 251);
            Btn_DoktorEkle.Name = "Btn_DoktorEkle";
            Btn_DoktorEkle.Size = new Size(139, 36);
            Btn_DoktorEkle.TabIndex = 7;
            Btn_DoktorEkle.Text = "Doktor Ekle";
            Btn_DoktorEkle.UseVisualStyleBackColor = true;
            Btn_DoktorEkle.Click += Btn_DoktorEkle_Click;
            // 
            // Grid_Doktorlar
            // 
            Grid_Doktorlar.AllowUserToOrderColumns = true;
            Grid_Doktorlar.BackgroundColor = Color.White;
            Grid_Doktorlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            Grid_Doktorlar.DefaultCellStyle = dataGridViewCellStyle1;
            Grid_Doktorlar.Location = new Point(368, 43);
            Grid_Doktorlar.Name = "Grid_Doktorlar";
            Grid_Doktorlar.RowHeadersWidth = 51;
            Grid_Doktorlar.Size = new Size(826, 193);
            Grid_Doktorlar.TabIndex = 6;
            Grid_Doktorlar.CellClick += Grid_Doktorlar_CellClick;
            // 
            // Txt_DoktorSifre
            // 
            Txt_DoktorSifre.Location = new Point(170, 209);
            Txt_DoktorSifre.Name = "Txt_DoktorSifre";
            Txt_DoktorSifre.Size = new Size(154, 27);
            Txt_DoktorSifre.TabIndex = 2;
            // 
            // Txt_DoktorTelefon
            // 
            Txt_DoktorTelefon.Location = new Point(170, 175);
            Txt_DoktorTelefon.Name = "Txt_DoktorTelefon";
            Txt_DoktorTelefon.Size = new Size(154, 27);
            Txt_DoktorTelefon.TabIndex = 2;
            // 
            // Txt_DoktorSoyad
            // 
            Txt_DoktorSoyad.Location = new Point(170, 142);
            Txt_DoktorSoyad.Name = "Txt_DoktorSoyad";
            Txt_DoktorSoyad.Size = new Size(154, 27);
            Txt_DoktorSoyad.TabIndex = 2;
            // 
            // Txt_DoktorAd
            // 
            Txt_DoktorAd.Location = new Point(170, 109);
            Txt_DoktorAd.Name = "Txt_DoktorAd";
            Txt_DoktorAd.Size = new Size(154, 27);
            Txt_DoktorAd.TabIndex = 2;
            // 
            // Txt_DoktorTC
            // 
            Txt_DoktorTC.Location = new Point(170, 76);
            Txt_DoktorTC.Name = "Txt_DoktorTC";
            Txt_DoktorTC.Size = new Size(154, 27);
            Txt_DoktorTC.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(37, 207);
            label7.Name = "label7";
            label7.Size = new Size(96, 20);
            label7.TabIndex = 1;
            label7.Text = "Doktor Şifre :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 178);
            label6.Name = "label6";
            label6.Size = new Size(115, 20);
            label6.TabIndex = 1;
            label6.Text = "Doktor Telefon :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(37, 145);
            label8.Name = "label8";
            label8.Size = new Size(100, 20);
            label8.TabIndex = 1;
            label8.Text = "Doktor Soyad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 112);
            label5.Name = "label5";
            label5.Size = new Size(78, 20);
            label5.TabIndex = 1;
            label5.Text = "Doktor Ad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 79);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 1;
            label4.Text = "Doktor T.C. :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 45);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 1;
            label3.Text = "Klinik Seç :";
            // 
            // Cmb_DoktorKlinik
            // 
            Cmb_DoktorKlinik.FormattingEnabled = true;
            Cmb_DoktorKlinik.Location = new Point(170, 43);
            Cmb_DoktorKlinik.Name = "Cmb_DoktorKlinik";
            Cmb_DoktorKlinik.Size = new Size(154, 28);
            Cmb_DoktorKlinik.TabIndex = 0;
            // 
            // Yetkili
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(1233, 491);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Yetkili";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yetkili";
            Load += Yetkili_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Grid_Doktorlar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox Cmb_Klinik;
        private Label label1;
        private TextBox Txt_KlinikEkle;
        private Button Btn_KlinikEkle;
        private Label label2;
        private GroupBox groupBox1;
        private Button Btn_KlinikSil;
        private Label Lbl_KlinikSayisi;
        private GroupBox groupBox2;
        private Label label3;
        private ComboBox Cmb_DoktorKlinik;
        private TextBox Txt_DoktorSifre;
        private TextBox Txt_DoktorTelefon;
        private TextBox Txt_DoktorAd;
        private TextBox Txt_DoktorTC;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button Btn_DoktorEkle;
        private DataGridView Grid_Doktorlar;
        private Button Btn_DoktorSil;
        private Button Btn_DoktorGuncelle;
        private TextBox Txt_DoktorSoyad;
        private Label label8;
    }
}