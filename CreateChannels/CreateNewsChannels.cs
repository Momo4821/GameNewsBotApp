using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
namespace GameNewsBotApp.CreateChannels
{
    
    

public interface ICreateChannels
{
    
    Task CreateChannelAsync(DiscordGuild guild);
    
}

public class CreateChannels : ICreateChannels
{
    
    
    
    public async Task CreateChannelAsync(DiscordGuild guild)
    {
        
            
        List<string> ChannelNames = new List<string>
        {
          "Game-News-Marvel-Rivals",
          "Game-News-Risk-Of-Rain",
          "Game-News-TF2",
          "Game-News-PalWorld"
        };
        
        foreach (string channelName in ChannelNames)
        {
            if (!guild.Channels.Values.Any(c => c.Name == channelName))
            {
                
                await guild.CreateChannelAsync(channelName, 
                    ChannelType.Text,
                    null,
                        null);
            }
            
        }
        
        
    }
}
}