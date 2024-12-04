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
            Cmb_Klinik = new ComboBox();
            label1 = new Label();
            Txt_KlinikEkle = new TextBox();
            Btn_KlinikEkle = new Button();
            label2 = new Label();
            groupBox1 = new GroupBox();
            Lbl_KlinikSayisi = new Label();
            Btn_KlinikSil = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Cmb_Klinik
            // 
            Cmb_Klinik.FormattingEnabled = true;
            Cmb_Klinik.Location = new Point(538, 31);
            Cmb_Klinik.Name = "Cmb_Klinik";
            Cmb_Klinik.Size = new Size(151, 28);
            Cmb_Klinik.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(429, 34);
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
            Btn_KlinikEkle.Location = new Point(37, 74);
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
            label2.Location = new Point(36, 34);
            label2.Name = "label2";
            label2.Size = new Size(125, 20);
            label2.TabIndex = 1;
            label2.Text = "Klinik Adı Giriniz :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Lbl_KlinikSayisi);
            groupBox1.Controls.Add(Cmb_Klinik);
            groupBox1.Controls.Add(Btn_KlinikSil);
            groupBox1.Controls.Add(Btn_KlinikEkle);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Txt_KlinikEkle);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(770, 148);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Klinik İşlemleri";
            // 
            // Lbl_KlinikSayisi
            // 
            Lbl_KlinikSayisi.AutoSize = true;
            Lbl_KlinikSayisi.Location = new Point(706, 35);
            Lbl_KlinikSayisi.Name = "Lbl_KlinikSayisi";
            Lbl_KlinikSayisi.Size = new Size(17, 20);
            Lbl_KlinikSayisi.TabIndex = 4;
            Lbl_KlinikSayisi.Text = "0";
            // 
            // Btn_KlinikSil
            // 
            Btn_KlinikSil.Location = new Point(429, 74);
            Btn_KlinikSil.Name = "Btn_KlinikSil";
            Btn_KlinikSil.Size = new Size(260, 43);
            Btn_KlinikSil.TabIndex = 3;
            Btn_KlinikSil.Text = "Klinik Sil";
            Btn_KlinikSil.UseVisualStyleBackColor = true;
            // 
            // Yetkili
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 688);
            Controls.Add(groupBox1);
            Name = "Yetkili";
            Text = "Yetkili";
            Load += Yetkili_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
    }
}