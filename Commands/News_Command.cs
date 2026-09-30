
using System.Collections.Generic;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GameNewsBotApp.CreateChannels;
using Serilog;


namespace GameNewsBotApp.Commands
{
    
    
    public class News_Command
    
    {
     
     private static string MarvelApiUrl = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=2767030&count=3&maxlength=300&format=json";
     private static string TF2_NewsApiUrl = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json"; 
     private static string RiskOfRainURL = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json";
     private static string PalWorldURL = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json";
     private static HttpClient  _httpClient = new HttpClient();   
     
        public class Tf2Command : BaseCommandModule
        {
            [Command("TF2")]
            [Description("")]
            [Category("NewsCommand For TF2")]
            [RequirePrefixes("!")]
            public async Task TF2_Command(CommandContext ctxTF2Command)
            { 
            if (CreateChannelsService.CreateChannelsServiceInstance.CreatedChannelInformation.TryGetValue("game-news-tf2", out ulong channelid))
            {
                if(ctxTF2Command.Channel.Id == channelid)
                {
                    await ParseJson(TF2_NewsApiUrl,ctxTF2Command);
                    Log.Information($"User {ctxTF2Command.User} has used the TF2 Command");
                    
                }
                else
                {
                   await ctxTF2Command.RespondAsync("This command can only be used in the designated channel for Team Fortress 2 news");
                   Log.Warning($"Bot has warned User {ctxTF2Command.User} that this command can't be used in {ctxTF2Command.Channel}");
                   
                }
                
            }
                
            
        }
            }
            
        public class MarvelRivals : BaseCommandModule
        {
         [Command("Marvel")]
         [Description("Marvel Rivals News")]
            public async Task MarvelRivalsCommand(CommandContext ctxMarvelRivalsCommand)
            {
                
                if(CreateChannelsService.CreateChannelsServiceInstance.CreatedChannelInformation.TryGetValue("game-news-marvel", out ulong channelId))
                 if(ctxMarvelRivalsCommand.Channel.Id == channelId)
                 {
                     await ParseJson(MarvelApiUrl, ctxMarvelRivalsCommand);
                     Log.Information($"{ctxMarvelRivalsCommand.User} has used the MarvelRivals Command in channel {ctxMarvelRivalsCommand.Channel}");
                 }
                 else
                 {
                     await ctxMarvelRivalsCommand.RespondAsync("This command can only be used in the designated channel for Marvel Rivals news");
                     Log.Warning($"Bot has warned user {ctxMarvelRivalsCommand.User} that this command can't be used in {ctxMarvelRivalsCommand.Channel}");
                 }
                    
              
                
            }

        }
        
        
        public class RiskOfRain: BaseCommandModule
        {
            [Description("Risk of rain NewsCommand that gets the lastest news from Steam API")]   
            public async Task RiskOfRainCommand(CommandContext ctxRiskOfRainCommand)
            {
                if(CreateChannelsService.CreateChannelsServiceInstance.CreatedChannelInformation.TryGetValue("game-news-risk-of-rain", out ulong channelid))
                if(ctxRiskOfRainCommand.Channel.Id == channelid)
                {
                    await ParseJson(RiskOfRainURL, ctxRiskOfRainCommand);
                    Log.Information($"{ctxRiskOfRainCommand.User} has used the Risk Of Rains Command in the channel {ctxRiskOfRainCommand.Channel}");
                }
                else
                {
                    await ctxRiskOfRainCommand.RespondAsync("This command can only be used in the designated channel for Risk Of Rain");
                    Log.Warning($"Bot has warned user {ctxRiskOfRainCommand.User} that his command can't be used in {ctxRiskOfRainCommand.Channel}");
                }
                    
          
            
        }
        }
        
        public class PalWorld : BaseCommandModule
        { 
        [Description("Palword NewsCommand that gets the latest news from Palword Steam API")]
        public async Task PalWorldCommand(CommandContext ctxPalWorldCommand)
        {
            if(CreateChannelsService.CreateChannelsServiceInstance.CreatedChannelInformation.TryGetValue("game-news-palworld", out ulong channelid))
            
                if(ctxPalWorldCommand.Channel.Id == channelid)
                {
                    await ParseJson(PalWorldURL, ctxPalWorldCommand);
                    Log.Information($"User {ctxPalWorldCommand.User} has used the Palword Command");           
                    
                }
                else
                {
                
                    await ctxPalWorldCommand.RespondAsync("");
                    Log.Warning($"Bot has warned user {ctxPalWorldCommand.User} that this command can't be used in {ctxPalWorldCommand.Channel}");
                    
                    
                }
         
        }
        }
        
        
        public static async Task ParseJson(string httpurl, CommandContext ctx)
        {
            
           var response = await _httpClient.GetStringAsync(httpurl);
            JsonDocument doc = JsonDocument.Parse(response);
            JsonElement appnews = doc.RootElement;
            List<string>finalList = new List<string>();
            
            foreach (JsonElement item in appnews.GetProperty("newsitems").EnumerateArray())
            {
                string title = item.GetProperty("title").GetString();
                string url = item.GetProperty("url").GetString();
                finalList.Add($"{title} \n {url}");
                
            }
            
            var final = string.Join("\n\n", finalList);
            await ctx.RespondAsync(final);
            
        }
    }
    }
    
    