using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grupocinte.Services.WebAPIRest.Helpers
{
    public class AppSettings
    {
        public string OriginCors { get; set; }
        public string Secret { get; set; }
        public string IsSuer { get; set; }
        public string Audience { get; set; }
    }
}
