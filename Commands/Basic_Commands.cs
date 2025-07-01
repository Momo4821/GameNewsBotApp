using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;

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
            [Description("Display Role assigned to user")]
            public Task _Role_Command(CommandContext _Command_Role)
            {

               //get roles
               u
               
                
                return Task.CompletedTask;
            }

        }
        

     

        public class Kick_Command : BaseCommandModule
        {
         
            private GuildMemberRemoveEventArgs args;
           
            [Command("Kick")]
            [Description("Kick users from Channel")]
            public async Task _Kick_Command(CommandContext _Command_Kick)
            {
                var Discord_logger = new Logging.Logging.Discord_Logger_service();
                
                args.Member.RemoveAsync(reason: "You have violated the rules of this channel");
                        //send dm
                     var dm = await _Command_Kick.Guild.GetMemberAsync(args.Member.Id);
                    await dm.RemoveAsync(_Command_Kick.User.Mention);
                     await dm.SendMessageAsync("Hey There you have been kicked");
                     Discord_logger.Log_information("user has been kicked",new EventId(89));


            }
        }





    }



 

    }
