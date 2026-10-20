using System;
using System.IO;
using Serilog;
using System.Data.SQLite;
namespace GameNewsBotApp.SQLConnection
{
    public class DiscordDatabase 
    {
  
        public static DiscordDatabase DiscordDatabaseInstance { get;} = new DiscordDatabase();
        
    private DiscordDatabase()
    {
        string direcotry = Path.Combine( AppContext.BaseDirectory, "Database","GameNewsBot.Db");
        
        string connectionString = $"Data Source={direcotry};Version=3;";
        
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            Log.Information("Connected to database");
            
            
            
            
        }
    }
     
        
 
    
    }
}