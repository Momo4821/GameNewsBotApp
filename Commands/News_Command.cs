using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using GameNewsBotApp.Logging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static GameNewsBotApp.Logging.Logging;

namespace GameNewsBotApp.Commands
{
    internal class News_Command
    {




        public class News_command : BaseCommandModule
        {
            public class Appnews
            {
                public int appid { get; set; }
                public List<Newsitem> newsitems { get; set; }
                public int count { get; set; }
            }

            public class Newsitem
            {
                public string gid { get; set; }
                public string title { get; set; }
                public string url { get; set; }
                public string author { get; set; }
                public string contents { get; set; }

            }

            public class Root
            {
                public Appnews appnews { get; set; }
            }





            private static readonly HttpClient _httpClient = new HttpClient();
            private const string ChannelId = "1384707760716779651"; // Replace with your actual channel ID

            private const string NewsApiUrl =
                "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json";

            [Command("NewsTest")]
            [Description("Ping Command that pings user and dispalys latency")]
            public async Task News_Command(CommandContext _command_News)

            {
                var Discord_logger_service = new Discord_Logger_service();
                var stack_trace = new System.Diagnostics.StackTrace();



                try
                {
                    var response = await _httpClient.GetStringAsync(NewsApiUrl); 
                    var json = JObject.Parse(response);
                    var appnews = json["appnews"].ToObject<List<Newsitem>>();
                    //use string.join to format the news items
                    var newsContent = 
                        string.Join("\n\n", appnews.Select(item =>
                        $"**Title:** {item.title}\n**Author:** {item.author}\n**Contents:** {item.contents}\n**URL:** {item.url}"));

                    



                    _command_News.RespondAsync(
                        $"Here are the latest news items:\n\n{newsContent}");


                }
                catch (Exception)
                {
                    Discord_logger_service.Log_Critical($"Request Failed{stack_trace}");
                    ;
                    throw;
                }



            }



        }
    }


}

