using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apexapp.Services
{
    public class ApexAppContext
    {
        public static IConfiguration Configuration { get; set; }
    }
}
