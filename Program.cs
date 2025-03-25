using MySqlConnector;
using System.Data;

namespace MySQLClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;database=membership;password=32873287";
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand();

            connection.Open();

            //DataTable userTable = connection.GetSchema("membership");

            //foreach (DataColumn col in userTable.Columns)
            //{
            //    Console.WriteLine(col.ColumnName);
            //}

            command.Connection = connection;
            command.CommandText = "SELECT * FROM users WHERE user_id = @user_id and user_password = @user_password";
            command.Prepare();
            command.Parameters.AddWithValue("@user_id", "testID");
            command.Parameters.AddWithValue("@user_password", "test");

            MySqlDataReader dataReader = command.ExecuteReader();
            while(dataReader.Read())
            {
                Console.WriteLine(dataReader["name"]);
            }

            connection.Close();
        }
    }
}
