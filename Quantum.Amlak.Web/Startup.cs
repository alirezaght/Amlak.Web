using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Quantum.Amlak.Web.Controllers;

[assembly: OwinStartup(typeof(Quantum.Amlak.Web.Startup))]

namespace Quantum.Amlak.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);


        }
    }
}
