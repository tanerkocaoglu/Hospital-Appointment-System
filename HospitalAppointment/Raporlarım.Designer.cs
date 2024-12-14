namespace HospitalAppointment
{
    partial class Raporlarım
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Raporlarım));
            Grid_Raporlar = new DataGridView();
            Btn_GeriDon = new Button();
            ((System.ComponentModel.ISupportInitialize)Grid_Raporlar).BeginInit();
            SuspendLayout();
            // 
            // Grid_Raporlar
            // 
            Grid_Raporlar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Grid_Raporlar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Grid_Raporlar.BackgroundColor = Color.White;
            Grid_Raporlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_Raporlar.Location = new Point(12, 12);
            Grid_Raporlar.Name = "Grid_Raporlar";
            Grid_Raporlar.RowHeadersWidth = 51;
            Grid_Raporlar.Size = new Size(894, 267);
            Grid_Raporlar.TabIndex = 0;
            // 
            // Btn_GeriDon
            // 
            Btn_GeriDon.BackColor = SystemColors.ControlLightLight;
            Btn_GeriDon.FlatStyle = FlatStyle.Flat;
            Btn_GeriDon.Location = new Point(821, 297);
            Btn_GeriDon.Name = "Btn_GeriDon";
            Btn_GeriDon.Size = new Size(85, 29);
            Btn_GeriDon.TabIndex = 1;
            Btn_GeriDon.Text = "Geri Dön";
            Btn_GeriDon.UseVisualStyleBackColor = false;
            Btn_GeriDon.Click += Btn_GeriDon_Click;
            // 
            // Raporlarım
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(918, 338);
            Controls.Add(Btn_GeriDon);
            Controls.Add(Grid_Raporlar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Raporlarım";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Raporlarım";
            Load += Raporlarım_Load;
            ((System.ComponentModel.ISupportInitialize)Grid_Raporlar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Grid_Raporlar;
        private Button Btn_GeriDon;
    }
}