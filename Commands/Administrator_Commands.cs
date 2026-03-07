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
            [RequirePrefixes("!")]
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
            [RequirePrefixes("!")]
            [Hidden]
            
            public async Task _Kick_Command(CommandContext _Command_Kick, DiscordMember member, DiscordChannel _Channel, int Kickreason_index = -1)
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
                
               
                    string reasons = Kick_reasons[Kickreason_index]; // Reasons will access what is in the list of Kick reasons
                if (Kickreason_index <= Kick_reasons.Count)
                {
                    await member.SendMessageAsync($"{member.DisplayName} have been kicked for the following reason {Kick_reasons}");    
                }
                
                await member.RemoveAsync($"You have been kicked for the following reasons{reasons}");

                
            }
        }






        public class Ban_Command : BaseCommandModule
        {
            public RequirePrefixesAttribute RequirePrefixesAttribute {get;set;}
        
            
            private static readonly List<string> ban_reasons = new List<string>
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
            [RequirePrefixes("!")]
            [Hidden]
            public async Task _Ban_Command(CommandContext _Command_Context, DiscordMember member, DiscordChannel Channel, RequirePrefixesAttribute requirePrefixesAttribute)
            {
                
                
                if (member == null)
                {
                    member.SendMessageAsync("Please specify a member to ban.");
                    
                }
                
                //check if user has permission to ban
                if(!_Command_Context.Member.Permissions.HasPermission(Permissions.BanMembers))
                {
                  member.SendMessageAsync("You do not have permission to ban members.");
                    
                   
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
                    member.SendMessageAsync("This command can only be used in the designated ban channel.");
                    
                }
                
                
                int banreason_index = 0;
                if (banreason_index >= 0 && banreason_index < ban_reasons.Count) // Check if the index is within the valid range of the ban reasons list
                {                    string reason = ban_reasons[banreason_index]; // Get the reason from the list based on the index
                if(Channel.Id == _Command_Context.Channel.Id)
                {
                    await member.BanAsync(0, $"You have been banned for the following reasons: {ban_reasons}");
                    _Command_Context.RespondAsync($"User {member.Username} has been banned.");
                    
                }
                
            }
            
            
            
        }
        

        public class Unban_Command : BaseCommandModule
        {
            private ulong Channelid = 1401277269715980398; // unban channel id
            [Command("Unban")]
            [System.ComponentModel.Description("Unban users from Channel")]
            [RequirePermissions(Permissions.BanMembers)]
            [Hidden]
            public async Task _Unban_Command(CommandContext _Command_Context, DiscordMember member, DiscordChannel Channel, DiscordUser user)
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

        private readonly List<string> _timeoutTimespan = new List<string>
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
        public async Task _TimeoutCommand(CommandContext _Command_timeout, DiscordMember member, DiscordChannel _channelid)
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
                
                int _timeoutreason_index = 0;
                int _timeouttimespan_index = 0;
                if (_timeoutreason_index >= timeout_reasons.Count && _timeouttimespan_index >= _timeoutTimespan.Count)
                {
                    
                    member.SendMessageAsync("You have been timed out for the following reason: " + timeout_reasons[_timeoutreason_index] + " for the following timespan: " + _timeoutTimespan[_timeouttimespan_index]);
                    
                    
                }
                {
                    
                }
                
                
                
                
                
            }

            ;
        }
        }
        
    

    public class _GetLogs_Command : BaseCommandModule
    {
        private readonly ulong _logschannel = 1447104716877332501; // logs channel id
        [Command("GetLogs")]
        [System.ComponentModel.Description("Get Logs File in specified channel")]
        [RequirePermissions(Permissions.Administrator)]
        [RequirePrefixes("!")]
        [Hidden]
   
        public async Task _GetLogsinChannelCommand (CommandContext _Command_getlogs, DiscordChannel log_channel, DiscordAttachment attachment, 
            DiscordMessage message, DiscordMember member)
        {
         
            
            
            
            var file_path = "log.txt"; // path to the log file

            if(_logschannel == log_channel.Id)
            {
                
                
                message.RespondAsync("Here are the available log files: " + file_path);
                
                
            }
            
            if(member.IsBot)
            {
                message.RespondAsync("Bot can't request logs.");
            }
            
            if(member.Permissions != Permissions.Administrator)
            {
                message.RespondAsync("You are not allowed to use this command.");
                
            }
            
            
            
            
            
            
      
            
        }
       
        

    }
    
    } // end of class Administrator_Commands
    
} // end of namespace
            

        
        
        
        
        
        
        
        
        
        