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

 public class KickRulesCommand: BaseCommandModule
 {
  List<string>kickrules = new List<string>
  {
   "You have violated the rules of this channel", //index  0 
   "You have been kicked for spamming", //index 1
   "You have been kicked for being rude", //index 2
   "You have been kicked for being toxic", //index 3
   "You have been kicked for being disrespectful", //index 4
   "You have been kicked for being a troll" //index 5
   
  };
  
  
  [Command("kickrules")]
  []
  public async Task KickRules (CommandContext kickrulescommand)
  {
   
   
   
   
   
  }
  
  
 }
    
    
    
    
    
    
    
    
    
}


}