using MrMood.DataAccess.Initializer;
using System.Web.Http;

namespace MrMood.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            DbInitializer.Initialize(new DataAccess.Context.MoodContext("MoodDb"));
        }
    }
}
