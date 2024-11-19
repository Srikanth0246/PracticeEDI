using Microsoft.Data.SqlClient;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read();
            //Update();
            Delete();
            Read();
        }
        public static void Create()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(@"server=(localdb)\mssqllocaldb;database=mydb;trusted_connection=yes");
                sqlConnection.Open();
                Console.WriteLine("Connection Opened");

                SqlCommand sqlCommand = new SqlCommand("insert into Product(Id,Name,Price) values(1,'pen',25)", sqlConnection);
                sqlCommand.ExecuteNonQuery();


                sqlConnection.Close();
                Console.WriteLine("Connection Closed");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Read()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString= @"server=(localdb)\mssqllocaldb;database=mydb;trusted_connection=yes";
            sqlConnection.Open();
            Console.WriteLine("Connection Opened");

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select *from Product";
            sqlCommand.Connection = sqlConnection;
            SqlDataReader sqlDataReader=sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Console.WriteLine($"Id:{sqlDataReader["Id"].ToString()} Name:{sqlDataReader[1]} Price:{sqlDataReader["Price"]}");
            }
            sqlConnection.Close();
            Console.WriteLine("Connection Closed");
        }

        public static void Update()
        {
            SqlConnection sqlConnection = new SqlConnection(@"server=(localdb)\mssqllocaldb;database=mydb;trusted_connection=yes");
            sqlConnection.Open();
            Console.WriteLine("Connection Opened");

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Update Product set Price=30 where Id=1";
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            Console.WriteLine("Connection Closed");
        }
        public static void Delete()
        {
            SqlConnection sqlConnection = new SqlConnection(@"server=(localdb)\mssqllocaldb;database=mydb;trusted_connection=yes");
            sqlConnection.Open();
            Console.WriteLine("Connection Opened");

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "delete from Product where Id=1";
            sqlCommand.Connection = sqlConnection;
            sqlCommand.ExecuteNonQuery();

           
            sqlConnection.Close();
            Console.WriteLine("Connection Closed");
        }
        }
}
