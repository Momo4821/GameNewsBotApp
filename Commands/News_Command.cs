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

        public class News_command : BaseCommandModule
        {
            private static readonly HttpClient
                _httpClient =
                    new HttpClient(); // HttpClient instance to make requests to the Steam API. URL will be the same for this call


            private const ulong ChannelId_News = 1390944612750852250;


            private const string NewsApiUrl =
                "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json"; // URL for the Steam News API for Team Fortress 2 (appid=440) with parameters for count and maxlength

            [Command("TF2")]
            [Description("Ping Command that pings user and dispalys latency")]
            public async Task News_Command(CommandContext _command_News, DiscordMember _member)
            {
                //  var Discord_logger_service = new Discord_Logger_service();

                var response =
                    await _httpClient.GetStringAsync(NewsApiUrl);
                var json = JObject.Parse(response);
                var appnews =
                    json["appnews"]["newsitems"]
                        .ToObject<
                            List<Newsitem>>(); // Deserialize the news items into a list of Newsitem objects

                var newsContent = // Format the news items into a string for display
                    string.Join("\n\n", appnews.Select(item =>
                        $"**Title:** " +
                        $"{item.title}\n" +
                        $"**URL:** " +
                        $"{item.url}"));

             
              



                if (_command_News.Channel.Id !=
                    ChannelId_News) //ONLY WANT TO SEND TO NEWS CHANNEL BECUASE DON'T SPAM OTHER GENERAL CHANNELS 
                {
                    await _member.SendMessageAsync("Wrong Channel");

                }
                else
                {


                    try
                    {
                        /*await _command_News.RespondAsync(
                            $"Here are the latest news items:\n\n{str}");*/
                        // Respond to the command with the formatted news items


                    }
                    catch (Exception)
                    {
                        var time_stamp = new TimestampAttribute();

                        // stacktrace not neded here but can be used for debugging
                        /*   var log_file = new StreamWriter(File.Create($"C:/Log{time_stamp}")*/
                        ;
                        throw new ArgumentException("Access Denied");
                    }

                }

            }

        }

        public class Marvel_rivals : BaseCommandModule
        {
            HttpClient _httpClient = new HttpClient();
            //using jsontext
            private const ulong Channel_id = 1391284909485588542;

            [Command("Marvel")]
            [Description("Marvel Rivals News Command that gets the latest news from Marvel Rivals")]
            public async Task Marvel_Command(CommandContext _command_Marvel, DiscordChannel _channel, DiscordMember _member)
            {
                var response = await _httpClient.GetStringAsync(
                    "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=2767030&count=3&maxlength=300&format=json");


                using (JsonDocument doc = JsonDocument.Parse(response))
                {

                    JsonElement root = doc.RootElement;
                    JsonElement newsItems = root.GetProperty("appnews").GetProperty("newsitems");



                    if (_command_Marvel.Channel.Id == Channel_id) // Check if the command is in the correct channel
                    {
                        foreach (JsonElement url in newsItems.EnumerateArray())
                        {

                                await _command_Marvel.RespondAsync(
                                $"{url.GetProperty("Title").GetString()} {url.GetProperty("url").GetString()}");

                        }



                    }
                    else
                    {
                        await _member.SendMessageAsync("Wrong Channel");
                        // Respond to the user in DM if the command is not in the correct channel
                    }

                }

            }
            }

            }


        }
    
