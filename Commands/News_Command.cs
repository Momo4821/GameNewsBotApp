using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
//using GameNewsBotApp.Logging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DSharpPlus;
using static GameNewsBotApp.Logging.Logging;
using static System.Net.WebRequestMethods;

namespace GameNewsBotApp.Commands
{
    internal class News_Command
    {

        public class Newsitem // created a class for the news item to deserialize the JSON response
            // from the Steam API
            // each property corresponds to a field in the JSON response
        {
            public string title { get; set; }
            public string url { get; set; }

        }

        public class TF2_command : BaseCommandModule
        {
            
            private static readonly HttpClient
                _httpClient =
                    new HttpClient(); // HttpClient instance to make requests to the Steam API. URL will be the same for this call

            private const ulong ChannelId_News = 1390944612750852250;


            private const string TF2_NewsApiUrl =
                "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json"; // URL for the Steam News API for Team Fortress 2 (appid=440) with parameters for count and maxlength

            [Command("TF2")]
            [Description("Ping Command that pings user and dispalys latency")]
            public async Task TF2_Command(CommandContext _command_News)
            {
                var logger = new Discord_Logger_service();
                var response = await _httpClient.GetStringAsync(TF2_NewsApiUrl);
                var json = JObject.Parse(response);
                var app_news =
                    json["appnews"]["newsitems"]
                        .ToObject<List<Newsitem>>(); // Deserialize the JSON response into a list of Newsitem object
                var news_Content = string.Join("\n\n", app_news.Select(item =>
                    $"{item.title}\n{item.url}")); // Format the news content with title and URL


                try
                {


                    if (_command_News.Channel.Id != ChannelId_News)
                    {
                        await _command_News.RespondAsync(
                            "This command can only be used in the designated news channel.");
                        return;
                    }
                   await _command_News.RespondAsync(news_Content);
              
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }





              

            }


        }










        public class Marvel_rivals : BaseCommandModule
        {

            HttpClient _httpClient = new HttpClient();
            //using jsontext


            [Command("Marvel")]
            [Description("Marvel Rivals News Command that gets the latest news from Marvel Rivals")]
            public async Task Marvel_Command(CommandContext _command_Marvel, DiscordMember _member)
            {
                var response = await _httpClient.GetStringAsync(
                    "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=2767030&count=3&maxlength=300&format=json");


                using (JsonDocument doc = JsonDocument.Parse(response))
                {

                    JsonElement root = doc.RootElement;
                    JsonElement newsItems = root.GetProperty("appnews").GetProperty("newsitems");




                    foreach (JsonElement url in newsItems.EnumerateArray())
                    {

                     await  _command_Marvel.RespondAsync(
                            $"**Title:** {url.GetProperty("title").GetString()}\n**URL:** {url.GetProperty("url").GetString()}");
                       await _member.SendMessageAsync($"{url.GetProperty("Title")} \n {url.GetProperty("url")}");
                    }



                }
            }

        }

    }
}