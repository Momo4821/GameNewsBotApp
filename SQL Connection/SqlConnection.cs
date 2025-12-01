using System;
using Microsoft.Data.Sqlite;


namespace GameNewsBotApp.SQL_Connection
{
    public class SqlConnection
    {

        static SqliteConnection createconnection()
        {
            SqliteConnection sqlitecon;
            sqlitecon = new SqliteConnection("Data Source=GameNewsBotDB.db");


            
            


            
            return sqlitecon;
        }


    }
}
