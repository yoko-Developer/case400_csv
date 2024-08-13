using System;
using System.Data;
using System.Data.SqlClient;
using case400_csv.DBConnection;

namespace case400_csv.DBConnection
{
    public class DatabaseConnection
    {
        private String connectionString;

        public DatabaseConnection(String connectionString)
        {
            this.connectionString = connectionString;
        }

        // 接続テスト用メソッド
        public void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try
                {
                    connection.Open();
                    Console.WriteLine("接続成功");
                }
                catch (Exception ex) {
                    Console.WriteLine("接続失敗: " + ex.Message);
                }

                // 処理が終わってもすぐにコンソールを閉じない
                Console.ReadKey(true);
            }
        }

        // データ取得用メソッド
        public DataTable GetData(String query)
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
                    Console.WriteLine("データ取得失敗: " + ex.Message);
                }
            }

            return dataTable;
        }
    }
}
