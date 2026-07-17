using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Net.Http;

using System.Threading.Tasks;




namespace GameNewsBotApp.Commands
{
    internal class News_Command
    {
        
     private const string MarvelApiUrl = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=2767030&count=3&maxlength=300&format=json";
     private const string TF2_NewsApiUrl = "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json"; 
        
        public class Tf2Command : BaseCommandModule
        {
            [Command("TF2")]
            [Description("")]
            [Category("NewsCommand For TF2")]
            public async Task TF2_Command(CommandContext marvelCommand)
            { 
               
            HttpClient  _httpClient = new HttpClient();
          
            
            
            
            /*
            var response = await _httpClient.GetStringAsync(TF2_NewsApiUrl);
            var json = JObject.Parse(response);
            var items = json["appnews"]["newsitems"].ToObject<List<root>>();
            var contents = string.Format("Ttile {0} \n Url: {1}" , items[0].Title,items[1].Url);
            
            await marvelCommand.RespondAsync(contents);
            
                if(marvelCommand.Member.IsBot)
                {
                    await
                    
                }
                */
            
                
        }
            }
            
        public class MarvelRivals : BaseCommandModule
        {

            HttpClient _httpClient = new HttpClient();


            [Command("Marvel")]
            [Description("Marvel Rivals News Command that gets the latest news from Marvel Rivals")]
            [Category("NewsCommand For Marvel")]
            [RequirePrefixes("!")]
            public async Task Marvel_Command(CommandContext _command_Marvel)
            {
         
                
                
                
            }

        }
        
        
        public class RiskOfRain: BaseCommandModule
        {
            [Description("Risk of rain NewsCommandthat gets the lastest news from Steam API")]   
         
            public async Task RiskOfRainCommand(CommandContext CommandRiskOfRain)
            {
             
             
             
            }
            
        }
        
        public class PalWorld : BaseCommandModule
        [Description("Palword NewsCommand that gets the latest news from Palword Steam API")]
        
        public async Task PalWorldCommand(CommandContext CommandPalWorld)
        {
            
            
        }
        
        }
    
    
    
    }
    
    