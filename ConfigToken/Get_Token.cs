using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNewsBotApp.ConfigToken
{
    internal class Get_Token
    {
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    namespace GameNewsBotApp.config
    {


        public class Get_Token
        {

            public string token = System.Environment.GetEnvironmentVariable("BOT_TOKEN", EnvironmentVariableTarget.User);
            public bool delete = false;

        }



    }
    /*




     // public string Token { get; set; }


     public string Prefix { get; set; }



     public async Task ReadJson()
     {
         using (StreamReader sr = new StreamReader("config.json")) //use streamreader to read config json file
         {
             string json = await sr.ReadToEndAsync();
             Jsonstructure data = JsonConvert.DeserializeObject<Jsonstructure>(json);
             this.Prefix = data.prefix;


         }


     }
    }




    internal sealed class Jsonstructure //access is only internal can't be inherited
    {

     //public string Token { get; set; }
     public string prefix { get; set; }

    }



    //create a class to get an evinromtnal vriable






    *//* public Get_Token
     {
         string Token = Environment.GetEnvironmentVariable("BOT_TOKEN");



     }*/







}
}
