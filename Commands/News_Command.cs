using System;
using System.Collections.Generic;
using System.Linq;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using DSharpPlus;
using DSharpPlus.Entities;
using GameNewsBotApp.CreateChannels;
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
            [RequirePrefixes("!")]
            public async Task TF2_Command(CommandContext TF2Command)
            { 
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
         [Description("Marvel Rivals News")]
            public async Task MarvelRivalsCommand(CommandContext MarvelRivalsCommand)
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
                if(CreateChannelsService.CreateChannelsServiceInstance.CreatedChannelInformation.TryGetValue("game-news-marvel-rivals", out ulong channelId))
                {
              
                    if(MarvelRivalsCommand.Channel.Id == channelId)
                    {
                        var final = string.Join("\n\n",  finalist);
                        await MarvelRivalsCommand.RespondAsync(final);
                    }
                    else
                    {
                        await MarvelRivalsCommand.RespondAsync("This command can only be used in the designated channel for Marvel Rivals news.");
                    }
                    
                    
                }

              
                
            }

        }
        
        
        public class RiskOfRain: BaseCommandModule
        {
            [Description("Risk of rain NewsCommand that gets the lastest news from Steam API")]   
            public async Task RiskOfRainCommand(CommandContext RiskOfRainCommand)
            {
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
            /*
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
            */
            
            
        
        }
        
        }
        
        
        public static async Task ParseJson(string json,string response)
        {
        
        }
    }
    }
    
    