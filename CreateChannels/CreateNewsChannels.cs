using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
namespace GameNewsBotApp.CreateChannels
{
 public interface ICreateChannels
 {
   
  Task CreateChannelAsync(DiscordGuild guild);
  Task StoreChannelInfomrationAsync(DiscordGuild guild);
  
 }
 public class CreateChannelsService : ICreateChannels
 {
  
  public static CreateChannelsService CreateChannelsServiceInstance {get;} = new CreateChannelsService();
 public Dictionary<string, ulong> CreatedChannelInformation {get;set;} = new Dictionary<string, ulong>();

 
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
        
    if(!guild.Channels.Values.Any(c => c.Name == createcategory && c.Type == ChannelType.Category))
    {
     await guild.CreateChannelCategoryAsync(
      createcategory,
      null,
      0,
      "category for news"
        
     ); 
    }
    DiscordChannel category = guild.Channels.Values.Single(c => c.Name == createcategory);
    foreach (var channelName in ChannelNames)
    {
     if (!guild.Channels.Values.Any(c => c.Name == channelName))
     {
                
      await guild.CreateChannelAsync(
       name: channelName, 
       type: ChannelType.Text,
       parent: category,
       topic: null,
       nsfw: false);
                
               
     }

   
    
     
    }
        
   }
  
   public async Task StoreChannelInfomrationAsync (DiscordGuild guild)
   {
    foreach (var channelName in guild.Channels.Values)
    {
 if(ChannelNames.Exists(c => c.Equals(channelName.Name, StringComparison.OrdinalIgnoreCase)))
 {

  CreatedChannelInformation[channelName.Name] = channelName.Id;
  
 }
    }
 }
   
}
 }

