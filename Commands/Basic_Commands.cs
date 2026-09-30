using System;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using GameNewsBotApp.Logging;
using Microsoft.Extensions.Logging;
using Serilog;

namespace GameNewsBotApp.Commands
{
    

    
    
    
    public class Basic_Commands
    { 
        
        public class Ping_command : BaseCommandModule
        {
            [Command("Ping")]
            [Description("Ping Command that pings user and dispalys latency")]
            [RequirePrefixes("!")]

            public async Task Ping_Command(CommandContext _command_Ping)
            {

           

                await _command_Ping.RespondAsync(
                    $"Pong! latency is {_command_Ping.Client.Ping}ms. From {_command_Ping.User.Username}");
                Log.Information($"{_command_Ping.User} has used the Ping Command");

            }

        }
        
        // Greet Command
        public class Greet_Command : BaseCommandModule
        {
            [Command("Greet")]
            [Description("Great users in Multiple Channels")]
            [RequirePrefixes("!")]
            
            public async Task _Greet_Command(CommandContext _Command_Greet)
            {
                if (_Command_Greet.Member != null)
                    await _Command_Greet.RespondAsync(
                        $"Hello, {_Command_Greet.Member.Mention}! Welcome to the Game News Bot!");
                Log.Information($"{_Command_Greet.User} has used the Greet Commmand");
                
            }
            
        }
        
        public class BotInfo : BaseCommandModule
        {
            [Command("BotInfo")]
            [Description("BotInfo Command that displays bot information")]
            [RequirePrefixes("!")]
            public async Task BotInfoAsync (CommandContext ctxServerInfo)
            {
                
                var msg = new DiscordEmbedBuilder()
                    .WithAuthor("Game News Bot")
                    .WithTitle("Game News Bot Information")
                    .WithDescription(@"Discord Bot that will retrieve the latest game news. If you want a specific Game please let me know :)")
                    .WithFooter("Powered by DSharpPlus")
                    .WithColor(DiscordColor.DarkBlue);
                await  ctxServerInfo.RespondAsync(msg);
                Log.Information($"{ctxServerInfo.User} has used the BotInfo Command");
            }
            
        }
    }
}