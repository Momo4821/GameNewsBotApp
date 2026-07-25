using System.Collections.Generic;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using DSharpPlus;
using Newtonsoft.Json.Linq;


namespace GameNewsBotApp.Commands
{
    
    
    public class News_Command
    {


     private static string MarvelApiUrl = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=2767030&count=3&maxlength=300&format=json";
     private static string TF2_NewsApiUrl = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json"; 
     private static string RiskOfRainURL = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json";
     private static string PalWorldURL = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json";
     public  static HttpClient  _httpClient = new HttpClient();   
        public class Tf2Command : BaseCommandModule
        {
            [Command("TF2")]
            [Description("")]
            [Category("NewsCommand For TF2")]
            public async Task TF2_Command(CommandContext TF2Command)
            { 
               
            HttpClient  _httpClient = new HttpClient();
            var response = await _httpClient.GetStringAsync(TF2_NewsApiUrl);

            JsonDocument doc = JsonDocument.Parse(response);
            JsonElement root = doc.RootElement;
            JsonElement appnews = root.GetProperty("appnews");
            List<string> finalist =  new List<string>();
              
             
            foreach(JsonElement item in appnews.GetProperty("newsitems").EnumerateArray())
            {
                string title =  item.GetProperty("title").GetString();
                string url = item.GetProperty("url").GetString();
                
              finalist.Add($"{title} \n {url}");
              
              
            }
            
            var final = string.Join("\n\n",  finalist);
            
            await TF2Command.RespondAsync(final);
            
                
        }
            }
            
        public class MarvelRivals : BaseCommandModule
        {
            [Command("Marvel")]
            [Description("Marvel Rivals News Command that gets the latest news from Marvel Rivals")]
            [Category("NewsCommand For Marvel")]
            [RequirePrefixes("!")]
            public async Task Marvel_Command(CommandContext MarvelCommand)
            {
              
                var response = await _httpClient.GetStringAsync(MarvelApiUrl);
                JsonDocument doc = JsonDocument.Parse(response);
                JsonElement root = doc.RootElement;
                JsonElement appnews = root.GetProperty("appnews");
                List<string> finalist = new List<string>();
                foreach (JsonElement item in appnews.GetProperty("newsitems").EnumerateArray())
                {
                    string title = item.GetProperty("title").GetString();
                    string url = item.GetProperty("url").GetString();
                    finalist.Add($"{title} \n {url}");
                    
                }
                
                var final = string.Join("\n\n",  finalist);
                await MarvelCommand.RespondAsync(final);
                
            }

        }
        
        
        public class RiskOfRain: BaseCommandModule
        {
            [Description("Risk of rain NewsCommandthat gets the lastest news from Steam API")]   
            public async Task RiskOfRainCommand(CommandContext RiskOfRainCommand)
            {
             HttpClient _httpClient = new HttpClient();
             var response = await _httpClient.GetStringAsync(RiskOfRainURL);
            JsonDocument doc = JsonDocument.Parse(response);
            JsonElement root = doc.RootElement;
            JsonElement  appnews = root.GetProperty("appnews");
            List<string> finalist = new List<string>();
            foreach (JsonElement item in appnews.GetProperty("newsitems").EnumerateArray())
            {
                string title = item.GetProperty("title").GetString();
                string url = item.GetProperty("url").GetString();
                
                finalist.Add($"{title} \n {url}");
                
            }
            var final = string.Join("\n\n",  finalist);
            await RiskOfRainCommand.RespondAsync(final);
            }
            
        }
        
        public class PalWorld : BaseCommandModule
        { 
        [Description("Palword NewsCommand that gets the latest news from Palword Steam API")]
        public async Task PalWorldCommand(CommandContext PalWorldCommand)
        {
             _httpClient = new HttpClient();
            var respone = await _httpClient.GetStringAsync(PalWorldURL);
            JsonDocument doc = JsonDocument.Parse(respone);
            JsonElement appnews = doc.RootElement;
            List<string> finalist = new List<string>();
            foreach (JsonElement item in appnews.GetProperty("newsitems").EnumerateArray())
            {
                string title = item.GetProperty("title").GetString();
                string url = item.GetProperty("url").GetString();
                finalist.Add($"{title} \n {url}");
                    
            }
            var final = string.Join("\n\n",  finalist);
            await PalWorldCommand.RespondAsync(final);
        }
        
        }
    
    }
    }
    
    