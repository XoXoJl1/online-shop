using System.Data.SqlClient;

namespace OnlineShop
{
    internal class DataBase
    {
        readonly SqlConnection sqlConnection = new SqlConnection(@"Data Source=LEGION;Initial Catalog=OnlineShop;Integrated Security=True");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed) { sqlConnection.Open(); }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open) { sqlConnection.Close(); }
        }
        public SqlConnection getConnection() { return sqlConnection; }
    }
}
