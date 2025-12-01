using System;
using System.Runtime.CompilerServices;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;


namespace GameNewsBotApp.Commands
{
    public class Basic_Commands
    {
        
        public class Ping_command : BaseCommandModule
        {
            [Command("Ping")]
            [Description("Ping Command that pings user and dispalys latency")]
            public async Task Ping_Command(CommandContext _command_Ping)
            {
                

                await _command_Ping.RespondAsync(
                    $"Pong! latency is {_command_Ping.Client.Ping}ms. From {_command_Ping.User.Username}");
                
                
            }

        }
        
        
        // Greet Command
        public class Greet_Command : BaseCommandModule
        {
            [Command("Greet")]
            [Description("Great users in Multiple Channels")]
            public async Task _Greet_Command(CommandContext _Command_Greet)
            {

                var My_Button = new DiscordButtonComponent(ButtonStyle.Primary, "greet_button", "Greet Me!", false);
                    
                
                
                if (_Command_Greet.Member != null)
                    await _Command_Greet.RespondAsync(
                        $"Hello, {_Command_Greet.Member.Mention}! Welcome to the Game News Bot!");

            }
        }
        
    }

}

        
