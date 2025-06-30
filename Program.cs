using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using GameNewsBotApp.Commands;
using GameNewsBotApp.config;
using GameNewsBotApp.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;






namespace GameNewsBotApp
{


    internal class Program
    {


        private static DiscordClient Client { get; set; }


        private static CommandsNextExtension commands { get; set; }

        static async Task Main(string[] args)


        {
            var Discord_Logger_service = new Logging.Logging.Discord_Logger_service();


            var Tokenprovider = new Get_Token();
            var token = Tokenprovider?.token;
            var todelete = new Get_Token().delete;
            Environment.SetEnvironmentVariable("BOT_TOKEN", "Token");
            if (string.IsNullOrEmpty(token))
            {

                Discord_Logger_service.Log_Error("String is Empty");

                return; //application exit if token is null/empty

            }


            /*
                        var jsonreader = new JSONReader();
                        await jsonreader.ReadJson();*/





            /* var token_bot = new JSONReader().Get_Token;*/


            var discordconifig = new DiscordConfiguration()
            {

                Intents = DiscordIntents.All,
                Token = token,
                TokenType = TokenType.Bot,
                AutoReconnect = true




            };

            Client = new DiscordClient(discordconifig);

            Client.Ready += Client_Ready;



            //setup commands
            var Discord_Bot_Commands = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" },
                CaseSensitive = false,
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = true,
                DmHelp = true,



            };

            commands = Client.UseCommandsNext(Discord_Bot_Commands);
            //commands.RegisterCommands<Action_Command>();
            commands.RegisterCommands<Basic_Commands.Ping_command>();
            commands.RegisterCommands<Basic_Commands.Greet_Command>();
            commands.RegisterCommands<Basic_Commands.Role_Command>();
            commands.RegisterCommands<News_Command.News_command>();
            










            await Client.ConnectAsync();
            await Task.Delay(-1);



            ;





        }








        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {

            var Discord_Logger_service = new Logging.Logging.Discord_Logger_service();
            var readyeventid = new EventId(10, "Online");
            var time_stamp = DateTime.Now.ToString("u");
            Discord_Logger_service.Log_information($"Client is ready and Online {time_stamp}", readyeventid);


            /* string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                 "C:\\Users\\malan\\tesfolder");
             Directory.CreateDirectory(directoryPath); // Ensure the directory exists
             string filePath = Path.Combine(directoryPath, "Test.txt");
             using (StreamWriter test = new StreamWriter(File.Create(filePath))) ;*/
            return Task.CompletedTask;

        }
    }

}

/*private static async Task Client_Action_News(DiscordClient sender, ReadyEventArgs args)
{
    ulong channelid_action = 1382840332898668554;
    var channel = await Client.GetChannelAsync(channelid_action);

    await channel.SendMessageAsync("test for only action channel");

}
*/
