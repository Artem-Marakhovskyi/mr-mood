using System.Web.Http;

namespace MrMood.Api
{
    public static class Config
    {
        public static void Register(HttpConfiguration config)
        {
            RoutesConfig.Register(config);
            DependencyInjection.Initialize(config);
        }
    }
}
