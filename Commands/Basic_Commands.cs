using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using Discord.Interactions;
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
            public Task _Role_Command(CommandContext _Command_Role, DiscordRole _DiscordRole, DiscordChannel _channel)
            {


                if (!_channel.IsPrivate)
                {
                    // don't display roles
                    
                    
                }

                
                
                


                return Task.CompletedTask;
            }

        }




        public class Kick_Command : BaseCommandModule
        {
            public static readonly List<string> Kick_reasons = new List<string>
            {
                "You have violated the rules of this channel", //index  0 
                "You have been kicked for spamming", //index 1
                "You have been kicked for being rude", //index 2
                "You have been kicked for being toxic", //index 3
                "You have been kicked for being disrespectful", //index 4
                "You have been kicked for being a troll", //index 5

            };


            [Command("Kick")]
            [Description("Kick users from Channel")]
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
                else
                {
                    //nothign happens only kicks can happen in private dm 
                }



                //specificy member to kick



            }




        }





        public class Kick_Rules : BaseCommandModule
        {
            [Command("!kickRules")]
            [Description("Display the rules for kicking users")]

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



        public class _Invite_Join : BaseCommandModule
        {
            [Command("Join")]
            [Description("Invite to join the channel.")]
            
            public Task _Invite_Join_command(CommandContext _Invite_Join, DiscordChannel _channel,
                DiscordAuditLogBanEntry _Logentry, DiscordMember _member, DiscordGuild _guild)
            {

             // check permissions for user to create invite linke

             if (!_Invite_Join.Member.Permissions.HasPermission(Permissions.CreateInstantInvite))
             {
                // do nothing
                _member.SendMessageAsync("You do not have permission to join the channel.");
                 
                 
             }
                
                
                //craete invite link

                var invite = _channel.CreateInviteAsync(max_age:7 * 24 * 60 * 60, // 7 days);
                    max_uses: 100, // 100 uses
                    reason: "Invite created by the bot for joining the channel.");

                if (_channel.IsPrivate)
                {
                    _Invite_Join.RespondAsync("This command can only be used in public channels.");
                    return Task.CompletedTask;
                }
                
                
                
                if (_channel.Id != 1394896421211209799)
                {
                    _Invite_Join.RespondAsync("This command can only be used in the invite channel.");
                    return Task.CompletedTask;
                }
                
                
                
    
                
                
    




                return Task.CompletedTask;
            }



        }




        public class Ban_Command : BaseCommandModule


        {
            private ulong ban_Channel = 1394896421211209799;

            [Command("Ban")]
            [Description("Ban users from Channel")]
            public async Task _Ban_Command(CommandContext _Command_Ban, DiscordMember Member,
                DiscordAuditLogBotAddEntry _Discord_auditLog, DiscordChannel _Channel)
            
            {

                //check if user has the permission to ban users

                if (_Channel.Id != 1394896421211209799)
                {
                    
                    //do noting can't ban outside of ban channel
                    
                }

                else
                {
                    
                    if(!Member.Permissions.HasPermission(Permissions.BanMembers))
                    {
                    
                 
                    
                    }

                    if (Member.Id == _Command_Ban.Member.Id)
                    {
                        _Channel.SendMessageAsync("You cannot ban yourself.");
                    
                    

                    }

                    if (Member.IsBot)
                    {
                    
                        _Channel.SendMessageAsync("You cannot ban bots.");
                        
                    }

                    if (Member.IsOwner)

                    {
                        _Channel.SendMessageAsync("You cannot ban yourself.");
                        
                    }
                
                }
                
            
                
                
                
                
                

            }

        }




    }
}