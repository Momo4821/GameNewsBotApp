using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using GameNewsBotApp.Commands;
using GameNewsBotApp.config;
//using GameNewsBotApp.Logging;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Threading.Tasks;
using  GameNewsBotApp.Logging;
using Serilog;
using GameNewsBotApp.Logging;
using GameNewsBotApp.Slash_Commands;

namespace GameNewsBotApp.Slash_Commands
{
 

public class SlashcommandsConfig
{
 
    private static CommandsNextExtension slashcommands { get; set; }
    private static DiscordClient Slash_Client { get; set; }
    
    public async Task InitializeAsync(CommandsNextExtension slashcommands)
    {

        var Discord_Bot_Commands_slash = new CommandsNextConfiguration()
        {
            StringPrefixes = new string[] { "/" },
            CaseSensitive = false,
            EnableMentionPrefix = true,
            EnableDms = true,
            EnableDefaultHelp = false,
            DmHelp = true,
                
        };
        
        slashcommands = Slash_Client.UseCommandsNext(Discord_Bot_Commands_slash);
        
        
            //slash db commands
                slashcommands.RegisterCommands.;
        
       
    }
    
    
    
 
}
}