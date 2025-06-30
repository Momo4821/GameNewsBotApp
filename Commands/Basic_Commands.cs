using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

namespace GameNewsBotApp.Commands
{
    internal class Basic_Commands
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



        public class Greet_Command : BaseCommandModule
        {
            [Command("Greet")]
            [Description("Great users in Multiple Channels")]
            public Task _Greet_Command(CommandContext _Command_Greet)
            {
                _Command_Greet.RespondAsync(
                    $"Hello, {_Command_Greet.Member.Mention}! Welcome to the Game News Bot!");
                return Task.CompletedTask;
            }





        }




        public class Role_Command : BaseCommandModule
        {
            [Command("Role")]
            [Description("Display Role")]
            public Task _Role_Command(CommandContext _Command_Role)
            {

                return Task.CompletedTask;
            }

        }

        
        
        
        public class DiscordAuditLogKickEntry : DiscordAuditLogEntry
        {
            public DiscordMember target { get; set; }
        }
        
        
        
        public class Kick_Command : BaseCommandModule
        {
            
            private GuildMemberRemoveEventArgs args;

            [Command("Kick")]
            [Description("Kick users from Channel")]
            public Task _Kick_Command(CommandContext _Command_Kick)
            {
             
               DiscordMember target = _Command_Kick.Member;
                
                _Command_Kick.RespondAsync($"User {_Command_Kick.User}has been kicked from server");

            return Task.CompletedTask;
            }
        }
    
            
        }
    }
