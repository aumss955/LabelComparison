using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace TraceabilityNew
{
    public class SQLiteManager
    {
        private string dbPath;

        public SQLiteManager(string DBpath)
        {
            dbPath = DBpath;
        }
        public SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source="+dbPath+"; Version = 3; New = True; Compress = True; ");
         // Open the connection:
         try
            {
                sqlite_conn.Open();
            }
         catch (Exception ex)
            {

            }
            return sqlite_conn;
        }

        public int countRow(SQLiteConnection conn, string sQuery)
      {
             int row;
             SQLiteDataReader sqlite_datareader;
             SQLiteCommand sqlite_cmd;
             sqlite_cmd = conn.CreateCommand();
             sqlite_cmd.CommandText = sQuery;
             sqlite_cmd.CommandType = CommandType.Text;
             sqlite_cmd.ExecuteNonQuery();
         

             row = Convert.ToInt32(sqlite_cmd.ExecuteScalar());

            //Console.WriteLine(row);
            conn.Close();
            return row;
            
      }



        public void ReadData(SQLiteConnection conn, string sQuery)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sQuery;

            sqlite_datareader = sqlite_cmd.ExecuteReader();

            Console.WriteLine(sqlite_datareader.FieldCount.ToString());

            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }

        //static void CreateTable(SQLiteConnection conn)
        //{

        //    SQLiteCommand sqlite_cmd;
        //    string Createsql = "CREATE TABLE SampleTable
        //       (Col1 VARCHAR(20), Col2 INT)";
        // string Createsql1 = "CREATE TABLE SampleTable1
        //    (Col1 VARCHAR(20), Col2 INT)";
        // sqlite_cmd = conn.CreateCommand();
        //    sqlite_cmd.CommandText = Createsql;
        //    sqlite_cmd.ExecuteNonQuery();
        //    sqlite_cmd.CommandText = Createsql1;
        //    sqlite_cmd.ExecuteNonQuery();

        //}

        public void InsertData(SQLiteConnection conn,string sQuery)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sQuery;
           
           sqlite_cmd.ExecuteNonQuery();

        }

    }
}
