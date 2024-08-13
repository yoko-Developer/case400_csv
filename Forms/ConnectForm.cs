using System;
using System.Data;
using System.Windows.Forms;
using case400_csv.DBConnection;

namespace case400_csv.Forms
{
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            // 接続確認
            string connectionString = "Server=DUE-N112; Database=kw21; User Id=sa; Password=sa";
            DatabaseConnection dbHelper = new DatabaseConnection(connectionString);

            try
            {
               
                //Helper.TestConnection();
                string query = "SELECT * FROM KA13HHKN";
                DataTable dataTable = dbHelper.GetData(query);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {

                MessageBox.Show("エラーが発生しました: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
