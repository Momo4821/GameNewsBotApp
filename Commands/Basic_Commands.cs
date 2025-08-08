using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;


namespace GameNewsBotApp.Commands
{
    internal class Basic_Commands
    {

        
        
        //button command
     public class Button_Command : BaseCommandModule
     {
      [Command("Button")]   
      [Description("Button Command that pings user and dispalys latency")]
      public async Task Button_Style_Command(CommandContext _command_Button)
      {
       var Help_Button = new DiscordButtonComponent(ButtonStyle.Primary, "help_button", "Help!", true,new DiscordComponentEmoji());
      }
         
     }
        
        
        

     /
     
        public class Ping_command : BaseCommandModule
        {
            [Command("Ping")]
            [Description("Ping Command that pings user and dispalys latency")]
            public async Task Ping_Command(CommandContext _command_Ping)
            {

             
                var builder = new DiscordMessageBuilder();
                builder.WithContent("Ping");
                
                
                var my_button = new DiscordButtonComponent(ButtonStyle.Primary, "ping_button", "Ping Me!");

                
                await _command_Ping.RespondAsync(
                    $"Pong! latency is {_command_Ping.Client.Ping}ms. From {_command_Ping.User.Username}");

            }
            
        }



        public class Greet_Command : BaseCommandModule
        {
            [Command("Greet")]
            [Description("Great users in Multiple Channels")]
            public async Task _Greet_Command(CommandContext _Command_Greet)
            {
                if (_Command_Greet.Member != null)
                  await  _Command_Greet.RespondAsync(
                        $"Hello, {_Command_Greet.Member.Mention}! Welcome to the Game News Bot!");
            }





        }




        public class Role_Command : BaseCommandModule
        {
            [Command("Role")]
            [Description("Display Role assigned to user")]
            public Task _Role_Command(CommandContext _Command_Role, DiscordRole _DiscordRole, DiscordChannel _channel)
            {


                if (!_channel.IsPrivate)
                {
                    // don't display roles
                    
                    
                }

                
                
                


                return Task.CompletedTask;
            }

        }

    }
}