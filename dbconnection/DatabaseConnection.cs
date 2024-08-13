using System;
using System.Data;
using System.Data.SqlClient;

namespace case400_csv.DBConnection
{
    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // �ڑ��e�X�g�p���\�b�h
        public void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("�ڑ�����");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("�ڑ����s: " + ex.Message);
                }

                // �������I����Ă������ɃR���\�[������Ȃ�
                Console.ReadKey(true);
            }
        }

        // �f�[�^�擾�p���\�b�h
        public DataTable GetData(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("�f�[�^�擾���s: " + ex.Message);
                }
            }

            return dataTable;
        }
    }
}
