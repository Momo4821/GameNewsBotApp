using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.Interactions;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using GameNewsBotApp.CreateChannels;
using GameNewsBotApp.Logging;
using Serilog;
using Serilog.Events;


namespace GameNewsBotApp.Commands
{

public class AdministratorCommands
{

 public static void ValidateKickCommand (CommandContext ctx, DiscordMember member)
 {
  
  if(member.IsBot)
   ctx.RespondAsync("You are a bot, You can't Kick members of this sever");
  
  if(member.Id == ctx.Member.Id)
   ctx.RespondAsync("You have been kicked for spamming");
  
  if(!member.Permissions.HasPermission(Permissions.KickMembers))
   member.SendMessageAsync("You don't have permission to use this command");
 
 }
 
 public static void ValidateBanCommand (CommandContext ctx, DiscordMember member, DiscordChannel channel)
 {
  if(member.IsBot)
   ctx.RespondAsync("You can't kick a Bot");
  
 
  if(member.Id == ctx.Member.Id)
   ctx.RespondAsync("You Can't Ban yourself");
  
   
  if(!member.Permissions.HasPermission(Permissions.BanMembers))
   member.SendMessageAsync("You don't have permission to use this command");
 }
 
 public static void ValidateLogSwitchCommand(CommandContext ctx, DiscordMember member)
 {
  if(member.IsBot)
   ctx.RespondAsync("You can't swtich log level");
  
  
  if(!member.Permissions.HasPermission(Permissions.Administrator))
   member.SendMessageAsync("You don't have permission to use this command");
  
  
  
 }
 
 public class KickCommand: BaseCommandModule
 {
  List<string>kickreasons = new List<string>
  {
   "You have violated the rules of this channel", //index  0 
   "You have been kicked for spamming", //index 1
   "You have been kicked for being rude", //index 2
   "You have been kicked for being toxic", //index 3
   "You have been kicked for being disrespectful", //index 4
   "You have been kicked for being a troll" //index 5
  };
  
  [Command("kick")]
  [Description("Kick Command")]
  [RequirePrefixes("!")]
  [RequireBotPermissions(Permissions.Administrator)]
  public async Task kickCommand (CommandContext CtxKick, DiscordMember member)
  {
   
   ValidateKickCommand(CtxKick, member);
   int reasonindex = 0;
   string reason = kickreasons[reasonindex];
   if(reasonindex < kickreasons.Count)
   {
    await member.SendMessageAsync($"You have been kicked for the following reason: {reason} ");
    Log.Information("");
   }
   else
   {
    
   }
   
  }
 }
    
 
 public class BanCommand: BaseCommandModule
 {
  
  List<String>BanReasons = new List<string>
  {
   "You have violated the rules of this Server",
   "You have been Banned for Spamming",
   "You have been Banned for Inappropriate Language",
   "You have been kicked for being disrespectful"
  };
  
  
  public async Task bancommand(CommandContext CtxBan, DiscordMember memeber, DiscordChannel channel)
  {
   
   ValidateBanCommand(CtxBan, memeber,channel);
   
  }
  
}
 
 
 public class TimeoutCommand: BaseCommandModule
 {
  [Command("timeout")]
  [Description("Timeout Command")]
  [RequirePrefixes("!")]
  [RequireBotPermissions(Permissions.ModerateMembers)]
  public async Task timeoutcommand(CommandContext CtxTimeout)
  {

   
  }
  }
  
  public class SetLogLevelDebug : BaseCommandModule
  {
   [Command("Debug")]
   [Description("Set LogLevel Debug")]
   [RequirePrefixes("!")]
   public async Task Setlogleveldebug(CommandContext ctxsetlogleveldebug)
   {
   
   LoggingData.Setlogleveldebug();
     await ctxsetlogleveldebug.RespondAsync("Working!");
     
    
    
   }
   }
   public class SetLogLevelInformation : BaseCommandModule
   {
    public async Task setloglevelinformation(CommandContext ctxsetloglevelinformation)
    {
     DiscordMember member= ctxsetloglevelinformation.Member;
     ValidateLogSwitchCommand(ctxsetloglevelinformation,member);
     if(CreateChannelsService.CreateChannelsServiceInstance.Modlogchannelid == ctxsetloglevelinformation.Channel.Id)
     {
      ValidateLogSwitchCommand(ctxsetloglevelinformation,member);
      LoggingData.Setloglevelinformation();
      Log.Information("Log Level has been swtiched to Information");
      
      }
    }
   }
 
  }
 }
