using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;

namespace GameNewsBotApp.Commands
{
    public class Administrator_Commands
    {
        public class Kick_Rules : BaseCommandModule
        {
            [Command("!kickRules")]
            [System.ComponentModel.Description("Display the rules for kicking users")]

            public Task Kick_Rules_Command(CommandContext _Command_Kick_Rules, DiscordMember _memeber)
            {


                var rules = new StringBuilder();
                rules.AppendLine("**Kick Rules:**");
                rules.AppendLine("1. You must have permission to kick members.");
                rules.AppendLine("2. You cannot kick yourself.");
                rules.AppendLine("3. You cannot kick bots.");
                rules.AppendLine("4. Specify a valid reason for kicking.");
                rules.AppendLine("5. Use the command as follows: `!kick @member reason_index`");
                rules.ToString();

                string rules_message = rules.ToString();

                if (_memeber.Permissions.HasPermission(Permissions.KickMembers))
                {
                    _memeber.SendMessageAsync(rules_message);
                }
                else
                {
                    _Command_Kick_Rules.RespondAsync("You do not have permission to view the kick rules.");

                }



                return Task.CompletedTask;
            }




        }




        // Kick Command
        public class Kick_Command : BaseCommandModule
        {

            private static readonly List<string> Kick_reasons = new List<string>
            {
                "You have violated the rules of this channel", //index  0 
                "You have been kicked for spamming", //index 1
                "You have been kicked for being rude", //index 2
                "You have been kicked for being toxic", //index 3
                "You have been kicked for being disrespectful", //index 4
                "You have been kicked for being a troll", //index 5

            };

            [Command("Kick")]
            [System.ComponentModel.Description("Kick users from Channel")]
            public async Task _Kick_Command(CommandContext _Command_Kick, DiscordMember member, DiscordChannel _Channel,
                int reason_indxed = -1)
            {
                var logger = new Logging.Logging.Discord_Logger_service();
                //check if user has permission to kick
                if (!_Command_Kick.Member.Permissions.HasPermission(Permissions.KickMembers))
                {
                    await member.SendMessageAsync("You do not have permission to kick members.");
                    logger.Log_information("User does not have permission to kick members", new EventId(88));
                    //only send message to user in dm 

                }

                if (member == null)
                {
                    await _Command_Kick.RespondAsync("Please specify a member to kick.");
                    logger.Log_information("No member specified for kick command", new EventId(87));

                }


                if (member.IsBot)
                {
                    await member.SendMessageAsync("This Memeber is a bot. You can't kick a bot");

                }

                if (member.Id == _Command_Kick.Member.Id)
                {
                    await member.SendMessageAsync("You cannot kick yourself.");
                    logger.Log_information("User tried to kick themselves", new EventId(86));
                }

                if (reason_indxed < 0 || reason_indxed >= Kick_reasons.Count)

                {
                    var reasonsList = string.Join("\n", Kick_reasons.Select((r, i) => $"{i}: {r}"));
                    await _Command_Kick.RespondAsync(
                        $"Invalid reason index. Please choose a valid reason from the list:");
                    logger.Log_information("Invalid reason index for kick command", new EventId(85));
                    return;

                }

                string reason = Kick_reasons[reason_indxed];
                try
                {
                    await member.SendMessageAsync($"You have been kicked for the following reason {reason}");

                }
                catch
                {

                    //nothing happens
                }

                if (_Channel.IsPrivate == _Command_Kick.Channel.IsPrivate)
                {

                    await member.RemoveAsync(
                        $"You have kicked{member.DisplayName} from {_Channel.Guild.Name} for the following reasons {reason}");
                    logger.Log_information($"{member.DisplayName} has been kicked {reason}", new EventId(8492));
                }
            }
        }






        public class Ban_Command : BaseCommandModule
        {
            
            private readonly List<string> ban_reasons = new List<string>
            {
                "You have violated the rules of this channel", //index  0 
                "You have been banned for spamming", //index 1
                "You have been banned for being rude", //index 2
                "You have been banned for being toxic", //index 3
                "You have been banned for being disrespectful", //index 4
                "You have been banned for being a troll", //index 5

            };

            private ulong _ChannelId = 1394896421211209799;
            [Command("Ban")]
            [System.ComponentModel.Description("Ban users from Channel")]
            public Task _Ban_Command(CommandContext _Command_Context, DiscordMember member, DiscordChannel Channel)
            {
                if (member == null)
                {
                    member.SendMessageAsync("Please specify a member to ban.");
                    
                }
                
                //check if user has permission to ban
                if(!_Command_Context.Member.Permissions.HasPermission(Permissions.BanMembers))
                {
                  member.SendMessageAsync("You do not have permission to ban members.");
                    
                    return Task.CompletedTask;
                }
                if (member.IsBot)
                {
                    _Command_Context.RespondAsync("You cannot ban a bot.");
                    
                }
                if (member.Id == _Command_Context.Member.Id)
                {
                    _Command_Context.RespondAsync("You cannot ban yourself.");
                    
                }

                if (Channel.Id != _ChannelId)
                {
                    _Command_Context.RespondAsync("This command can only be used in the designated ban channel.");
                    
                }
                
                
                
                
                
                
                
                return Task.CompletedTask;
            }
            
            
            
        }
            
        
        
        
        
        
        
    } // end of class Administrator_Commands


  
    
    
    
    
    
} // end of namespace
            

        
        
        
        
        
        
        
        
        
        