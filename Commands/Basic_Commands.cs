using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

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


     /*   public class Reminder_Command : BaseCommandModule
        {
            [Command("Reminder")]
            [Description("Set a reminder for yourself")]
            public Task _Reminder_Command(CommandContext _Command_Reminder)
            {

                //timer for reminder
                var reminderTime = TimeSpan.FromMinutes(15) // Set reminder for 15 minute later//remindfer for 4 days
                    .Add(TimeSpan.FromHours(6)) //add 6 hours
                    .Add(TimeSpan.FromMinutes(30)) //add 30 minutes
                    .Add(TimeSpan.FromDays(7)); //days
                                                //user sets reminder for 7 days later
                                                var reminderMessage = $"Reminder set for {_Command_Reminder.User.Username} in {reminderTime.TotalMinutes} minutes!";
                                                _Command_Reminder.RespondAsync(reminderMessage);
                                                //remove remin


                return Task.CompletedTask;
            }*/

      /*      public class othercommands : BaseCommandModule

            {
        [Command("Say")]
            public async Task Say(string choice)
            {
               
            }


            }*/
            
        }
    }
}