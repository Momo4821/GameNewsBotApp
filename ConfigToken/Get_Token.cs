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
