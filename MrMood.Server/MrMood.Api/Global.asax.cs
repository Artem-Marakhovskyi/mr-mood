using MrMood.DataAccess.Context;
using MrMood.DataAccess.Initializer;
using System.Web.Http;

namespace MrMood.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(Config.Register);
           // DbInitializer.Initialize(new DataAccess.Context.MoodContext(new DbContextOptions("MoodDb")));
        }
    }
}
