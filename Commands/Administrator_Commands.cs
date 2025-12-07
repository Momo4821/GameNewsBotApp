using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
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
            [RequirePermissions(Permissions.KickMembers)]
            [Hidden]
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
            [RequirePermissions(Permissions.KickMembers)]
            [Hidden]
            
            public async Task _Kick_Command(CommandContext _Command_Kick, DiscordMember member, DiscordChannel _Channel,
                int reason_indxed = -1)
            {
            
                //check if user has permission to kick
                
                if (member == null)
                {
                    await _Command_Kick.RespondAsync("Please specify a member to kick.");
                  

                }


                if (member.IsBot)
                {
                    await member.SendMessageAsync("This Memeber is a bot. You can't kick a bot");

                }

                if (member.Id == _Command_Kick.Member.Id)
                {
                    await member.SendMessageAsync("You cannot kick yourself.");
                  
                }

                if (reason_indxed < 0 || reason_indxed >= Kick_reasons.Count)
                {
                    var reasonsList = string.Join("\n", Kick_reasons.Select((r, i) => $"{i}: {r}")); // i is the index of the reason    
                                                                                                    //r is the reason
                    await member.SendMessageAsync(
                        $"Invalid reason index. Please choose a valid reason from the list:");
                   
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
            [RequirePermissions(Permissions.BanMembers)]
            [Hidden]
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
        

        public class Unban_Command : BaseCommandModule
        {
            private ulong Channelid = 1401277269715980398; // unban channel id
            [Command("Unban")]
            [System.ComponentModel.Description("Unban users from Channel")]
            [RequirePermissions(Permissions.BanMembers)]
            [Hidden]
            public Task _Unban_Command(CommandContext _Command_Context, DiscordMember member, DiscordChannel Channel, DiscordUser user)
            {
                if (member == null)
                {
                    _Command_Context.RespondAsync("Please specify a member to unban.");
                    
                }
                
                //check if user has permission to unban
                
                if (member.IsBot)
                {
                    _Command_Context.RespondAsync("You cannot unban a bot.");
                    
                }
                
                if (member.Id == _Command_Context.Member.Id)
                {
                    _Command_Context.RespondAsync("You cannot unban yourself.");
                    
                }
                
                //check if the channel is the correct channel for unbanning
                if (Channel.Id != 1394896421211209799)
                {
                    _Command_Context.RespondAsync("This command can only be used in the designated unban channel.");
                    
                }


                if (Channel.Id == _Command_Context.Channel.Id)
                {
                    _Command_Context.Guild.UnbanMemberAsync(user.Id,user.Mention);
                    _Command_Context.RespondAsync($"User {user.Username} has been unbanned.");
                      // Log the unban action
                    
                }
              
                
                return Task.CompletedTask;
            }
        }
        
 


  
    public class _timeout_Command : BaseCommandModule
    {
        private readonly List<string> timeout_reasons = new List<string>
        {
            "Timeout for spamming", //index 0
            "Timeout for being rude", //index 1
            "Timeout for being toxic", //index 2
            "Timeout for being disrespectful", //index 3
            "Timeout for being a troll", //index 4  
            
            

        };

        private readonly List<string> timeout_timespan = new List<string>
        {
            "10 mintes",
            "30 minutes",
            "1 hour",
            "6 hours",
            "12 hours",
            "1 day",


        };
        

        private ulong _timeoutchannl = 1444853871821328584; // timeout channel in discord channel
        [Command("Timeout")]
        [System.ComponentModel.Description("Timeout users from Channel")]
        [RequirePermissions(Permissions.ModerateMembers)]
        [Hidden]
        public Task _TimeoutCommand(CommandContext _Command_timeout, DiscordMember member, DiscordChannel _channelid)
        {
            if (member == null)
            {
                _Command_timeout.RespondAsync("Please specify a member to timeout.");
                
            }


            if (member.IsBot)
            {
                
                _Command_timeout.RespondAsync("You cannot ban a bot.");
            }
            
            if (member.Id == _Command_timeout.Member.Id)
            {
                _Command_timeout.RespondAsync("You cannot timeout yourself.");
                
            }
            
            if (_channelid.Id != _timeoutchannl)
            {
             
                member.SendMessageAsync("This command can only be used in the designated timeout channel.");
                
            }


            if (_channelid.Id == _Command_timeout.Channel.Id)
            {
                
                
                
                
                
                
            }
            
                
            
            
            return Task.CompletedTask;
        }
        }
        
    public class _GetLogs_Command : BaseCommandModule
    {
        private readonly ulong _logschannel = 1447104716877332501; // logs channel id
        [Command("GetLogs")]
        [System.ComponentModel.Description("Get Logs File in specified channel")]
        [RequirePermissions(Permissions.Administrator)]
        [Hidden]
   
        public Task _GetLogsinChannelCommand (CommandContext _Command_getlogs, DiscordChannel log_channel, DiscordAttachment attachment, DiscordMessage message)
        {
         
            
            var file_path = "log.txt"; // path to the log file

            if(_logschannel == log_channel.Id)
            {
                message.RespondAsync("Here are the available log files: " + file_path);
                
                
            }
            
      
            return Task.CompletedTask;
        }


       
        

    }
    
    } // end of class Administrator_Commands
    
} // end of namespace
            

        
        
        
        
        
        
        
        
        
        