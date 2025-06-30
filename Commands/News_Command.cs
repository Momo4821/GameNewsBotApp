using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using GameNewsBotApp.Logging;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using static GameNewsBotApp.Logging.Logging;

namespace GameNewsBotApp.Commands
{



    //string formate




    internal class News_Command
    {











        public class News_command : BaseCommandModule
        {


            public class Newsitem // created a class for the news item to deserialize the JSON response
                // from the Steam API
                // each property corresponds to a field in the JSON response
            {
                public string title { get; set; }
                public string url { get; set; }
                public string author { get; set; }
                public string contents { get; set; }

            }



            private static readonly HttpClient
                _httpClient =
                    new HttpClient(); // HttpClient instance to make requests to the Steam API. URL will be the same for this call

            private const ulong ChannelId_News = 1384707760716779651;


            private const string NewsApiUrl =
                "https://api.steampowered.com/ISteamNews/GetNewsForApp/v0002/?appid=440&count=3&maxlength=300&format=json"; // URL for the Steam News API for Team Fortress 2 (appid=440) with parameters for count and maxlength

            [Command("TF2")]
            [Description("Ping Command that pings user and dispalys latency")]
            public async Task News_Command(CommandContext _command_News)

            {
                var Discord_logger_service = new Discord_Logger_service();
                var stack_trace = new System.Diagnostics.StackTrace();



                if (_command_News.Channel.Id !=
                    ChannelId_News) //ONLY WANT TO SEND TO NEWS CHANNEL BECUASE DON'T SPAM OTHER GENERAL CHANNELS 
                {
                    await _command_News.RespondAsync("Inccorect Channel");
                }
                else
                {


                    try
                    {
                        var response =
                            await _httpClient.GetStringAsync(NewsApiUrl);
                        var json = JObject.Parse(response);
                        var appnews =
                            json["appnews"]["newsitems"]
                                .ToObject<
                                    List<Newsitem>>(); // Deserialize the news items into a list of Newsitem objects
                        //use string.join to format the news items
                        var newsContent = // Format the news items into a string for display
                            string.Join("\n\n", appnews.Select(item =>
                                $"**Title:** {item.title}\n**Author:** {item.author}\n**Contents:** {item.contents}\n**URL:** {item.url}"));





                        await _command_News.RespondAsync(
                            $"Here are the latest news items:\n\n{newsContent}"); // Respond to the command with the formatted news items


                    }
                    catch (Exception)
                    {
                        var time_stamp = new TimestampAttribute();
                        /*Discord_logger_service.Log_Critical($"Request Failed{stack_trace}");*/
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
            public Task Marvel_Comamnd(CommandContext _command_Marvel)
            {





                return Task.CompletedTask;




            }

        }


    }
}
