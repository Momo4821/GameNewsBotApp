using System;
using System.Runtime.CompilerServices;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using GameNewsBotApp.Commands;
using GameNewsBotApp.config;
//using GameNewsBotApp.Logging;
using Microsoft.Extensions.Logging;
using System.Reflection;
using  GameNewsBotApp.Logging;
using Serilog;
using  GameNewsBotApp.Slash_Commands;
namespace GameNewsBotApp.Slash_Commands
{
    public class SlashCommands
    {
        
        
        public class Ping_command_Slash : BaseCommandModule
        {
            [Command("Ping")]
            [Description("Ping Command that pings user and dispalys latency")]
            public async Task Ping_Command_Slash(CommandContext _command_Ping_Slash)
            {
                
                
                await _command_Ping_Slash.RespondAsync(
                    $"Pong! latency is {_command_Ping_Slash.Client.Ping}ms. From {_command_Ping_Slash.User.Username}");
                
                
            }

        }
        
        
        
        
        
    }
}