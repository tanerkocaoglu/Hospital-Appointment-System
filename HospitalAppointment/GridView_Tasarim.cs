namespace HospitalAppointment;

public class GridView_Tasarim
{
    public GridView_Tasarim(DataGridView gridView)
    {
        // GridView Tasarımı
        gridView.EnableHeadersVisualStyles = false;

        // Başlık Ayarları
        gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
        gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        gridView.ColumnHeadersHeight = 35;

        // Satır Ayarları
        gridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        gridView.DefaultCellStyle.BackColor = Color.White;
        gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        gridView.RowTemplate.Height = 30;

        // Seçim Renkleri
        gridView.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
        gridView.DefaultCellStyle.SelectionForeColor = Color.White;

        // Kenarlık ve Hücre Ayarları
        gridView.BorderStyle = BorderStyle.FixedSingle;
        gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        gridView.GridColor = Color.LightGray;

        gridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

    }
}
