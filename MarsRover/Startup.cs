using System.Web.Http;
using MarsRover;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace MarsRover
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);
        }
    }
}
