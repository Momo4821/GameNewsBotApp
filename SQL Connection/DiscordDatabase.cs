using System;
using Microsoft.Data.Sqlite;

namespace GameNewsBotApp.SQL_Connection
{
    public class DiscordDatabase
    {
        
        
        public DiscordDatabase ()
        {
            var connection = new SqliteConnection("Data Source =DiscordDatabase.db");


            try
            {
               connection.Open();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        
        
     
        
        
        
        
        
    
    }
}