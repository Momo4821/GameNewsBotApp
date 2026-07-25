using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Discord.Interactions;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;


namespace GameNewsBotApp.Commands
{

public class Administrator_Commands
{

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
  
public void ValidateCommands (DiscordMember  member, CommandContext ctx)
{
 if(member.IsBot)
 ctx.RespondAsync("You are a bot, You can't Kick members of this sever");
 
 
 
 if(member.Id == ctx.Member.Id)
  ctx.RespondAsync("You have been kicked for spamming");
 
 
 
 if(member != null)
  ctx.RespondAsync("Please specifiy Meber to Kick");
 
}


public void CreateKickChannel (DiscordMember member, CommandContext ctx, ch)
{
 // create locked channel for admin users onl
 
 
 
}  


  [Command("kick")]
  [Description("Kick Command")]
  [RequirePrefixes("!")]
  [RequireBotPermissions(Permissions.Administrator)]
  public async Task kickCommand (CommandContext Kickcomman, DiscordMember member)
  {
   
   ValidateCommands(member, Kickcomman);


   
  
   
   int reasonindex = 0;
   string reason = kickreasons[reasonindex];
   if(reasonindex < kickreasons.Count)
   {
    await member.SendMessageAsync($"You have been kicked for the following reason: {reason} ");
    
  
   }
  
  
   
   
   
   
  }
  
  
 }
    
    
 
}


}