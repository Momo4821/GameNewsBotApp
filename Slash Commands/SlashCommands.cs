using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace GameNewsBotApp.Slash_Commands
{
    public class SlashCommands
    {
        
        
        
        public class mostusedcommand_byuser : BaseCommandModule
        {
            [Command("mostused")]
            [Description("Most used commands that the user has used within a certain amount of time")]
            [RequirePrefixes("/")]
            public async Task _mostusedcommand(CommandContext _commandcontext)
            {
                
                
                
            }
            
            
        }
        
        
        public class mostusedcommand : BaseCommandModule
        {
            [Command("mostusedcommands")]
            [Description("Most used commands that the bot has used within a certain amount of time")]
            [RequirePrefixes("/")]
            public async Task _mostusedcommand(CommandContext _commandcontext)
            {
                
                
                
            }
        
        
        }
        
        
    public class testcommand : BaseCommandModule
    {
        [Command("test")]
        [Description("A test command to check if the bot is working")]
        [RequirePrefixes("/")]
        [Category("Database Commands")]// This attribute ensures that the command can only be executed with the specified prefix
        public async Task _testcommand(CommandContext _commandcontext)
        {
          //requirePrefixesAttribute.ShowInHelp = true; // This will make the command show up in the help command
       
          
          
          //await requirePrefixesAttribute.ExecuteCheckAsync(_commandcontext, true); // This will check if the command is being executed with the correct prefix
          
          
          
         await _commandcontext.RespondAsync($"Test command executed successfully by {_commandcontext.User.Username}!");


         
         
        }
        

        
        
        

    }
    
    
    }

    }
   
   
   