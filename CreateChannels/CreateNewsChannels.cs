using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
namespace GameNewsBotApp.CreateChannels
{
    
    
public static class ChannelCreationService
{
    public static Dictionary<string, ulong> CreatedChannelInformation {get;set;} = new Dictionary<string, ulong>(); 
    //public class Dictionary<TKey,TValue>
    public static List<string> ChannelNames {get;} = new List<string>
    {
        "game-news-marvel-rivals",
        "game-news-risk-of-rain",
        "game-news-tf2",
        "game-news-palworld"
    };

   

public interface ICreateChannels
{
    Task CreateChannelAsync(DiscordGuild guild);
    Task StoreChannelInfomrationAsync(DiscordGuild guild);
    
}


public class CreateChannels : ICreateChannels
{
    
    public async Task CreateChannelAsync(DiscordGuild guild)
    {
        string category = "game-news"; 
        
            if(!guild.Channels.Values.Any(c => c.Name == category && c.Type == ChannelType.Category))
            {
                await guild.CreateChannelCategoryAsync(
                    category,
                    null,
                    0,
                    "category for news"
        
                ); 
                }
        DiscordChannel channel = guild.Channels.Values.Single(c => c.Name == category);
        foreach (string channelName in ChannelNames)
        {
            if (!guild.Channels.Values.Any(c => c.Name == channelName))
            {
                
                await guild.CreateChannelAsync(
                    name: channelName, 
                    type: ChannelType.Text,
                    parent: channel,
                    topic: null,
                    nsfw: false);
                
               
            }
            
        }
        
    }
    
    public async Task StoreChannelInfomrationAsync (DiscordGuild guild)
    {
  
        
        foreach (var channels in guild.Channels.Values)
        {
          string channelname = channels.Name;
          ulong channelid = channels.Id;

            
            if (!CreatedChannelInformation.ContainsKey(channelname))
            {
                CreatedChannelInformation.Add(channelname, channelid);     
            }
           
            Console.WriteLine(channelname + channelid);
        }
        
        }
}
}
}

