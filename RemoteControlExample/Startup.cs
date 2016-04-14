using Owin;
using System.Web.Http;

namespace RemoteControlExample
{
    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                "default",
                "api/{controller}/{id}",
                new
                {
                    id = RouteParameter.Optional
                });
            app.UseWebApi(config);
        }
    }
}