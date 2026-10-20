using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using Serilog;

namespace GameNewsBotApp.CreateChannels
{
 public interface ICreateChannels
 {
   
  Task CreateChannelAsync(DiscordGuild guild);
  Task StoreChannelInfomrationAsync(DiscordGuild guild);
  
  Task CreateLogChnanel(DiscordGuild guild);
  
  
 }
 public class CreateChannelsService : ICreateChannels
 {
  
  public static CreateChannelsService CreateChannelsServiceInstance {get;} = new CreateChannelsService();
 public Dictionary<string, ulong> CreatedChannelInformation {get;set;} = new Dictionary<string, ulong>();
 public ulong Modlogchannelid {get;set;}
 
 public List<string> ChannelNames {get;} = new List<string>
 {
  "game-news-marvel-rivals",
  "game-news-risk-of-rain",
  "game-news-tf2",
  "game-news-palworld"
 };
   public async Task CreateChannelAsync(DiscordGuild guild)
   {
    string createcategory = "game-news"; 
    if(guild.Channels.Values.Any(c => c.Name == createcategory && c.Type == ChannelType.Category))
    return;
    
    //create category if category doesn't exist
     await guild.CreateChannelCategoryAsync(
      createcategory,
      null,
      0,
      "category for news"
     ); 
    
    
    DiscordChannel category = guild.Channels.Values.Single(c => c.Name == createcategory);
    foreach (var channelName in ChannelNames)
    {
     if (guild.Channels.Values.Any(c => c.Name == channelName))
     return;
            
     //create mews channels if they don't exist
       await guild.CreateChannelAsync(
       name: channelName, 
       type: ChannelType.Text,
       parent: category,
       topic: null,
       nsfw: false);
    }
    Log.Debug("");
        
   }
   
   
   public async Task CreateLogChnanel(DiscordGuild guild)
   {
    string modcategory = "mod-logs";

    if (guild.Channels.Values.Any(c => c.Name == modcategory && c.Type == ChannelType.Category))
    return;
    
    //create channel category if missing
     await guild.CreateChannelCategoryAsync(
      name: modcategory,
      overwrites: null,
      position: 0,
      reason: "category for mod logs");
     Log.Information("Mod log category created in guild: {guildName}", guild.Name);
    

  
   DiscordChannel channel = guild.Channels.Values.Single(c => c.Name == modcategory);
   if (guild.Channels.Values.Any(c => c.Name == "logs"))
    return;
   //create channel if missing
     await guild.CreateChannelAsync(
     name: "logs",
     type: ChannelType.Text,
     parent: channel,
     topic: null,
     nsfw: false
    );
    Log.Information("mod-log channel created: {guild}", guild.Name);
   

DiscordChannel modchannel = guild.Channels.Values.Single(c => c.Name == "mod-logs");
Modlogchannelid = modchannel.Id;
    }
 
  
   public async Task StoreChannelInfomrationAsync (DiscordGuild guild)
   {
    foreach (var channelName in guild.Channels.Values)
    {
     if(ChannelNames.Exists(c => c.Equals(channelName.Name, StringComparison.OrdinalIgnoreCase)))
     {

      CreatedChannelInformation[channelName.Name] = channelName.Id;
      Log.Debug("Channel Names: {ChannelNames} added to the Dictionary", channelName);
      
     }
   
     
    }
   
   }
   }
 }
 