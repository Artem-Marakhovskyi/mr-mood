using MrMood.Api.Controllers;
using MrMood.BussinessLogic;
using MrMood.DataAccess;
using MrMood.DataAccess.Context;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace MrMood.Api
{
    public class DependencyInjection
    {
        public static void Initialize(HttpConfiguration config)
        {
            var container = new UnityContainer();

            container.RegisterInstance(new DbContextOptions("MoodDb"));
            container.RegisterType<MoodContext, MoodContext>(new PerThreadLifetimeManager());
            container.RegisterType<SongController, SongController>();
            container.RegisterType<SongMarkController, SongMarkController>();
            container.RegisterType<SongsService, SongsService>();
            container.RegisterType<TagsService, TagsService>();
            container.RegisterType<ArtistsService, ArtistsService>();
            container.RegisterType<SongMarksService, SongMarksService>();
            container.RegisterType<SongMarkCalculator, SongMarkCalculator>();
            container.RegisterType<RepositoryHolder, RepositoryHolder>();
            container.RegisterType<UnitOfWork, UnitOfWork>();
            container.RegisterType<DbConnection, SqlConnection>();

            config.DependencyResolver = new UnityResolver(container);
        }
    }
}
