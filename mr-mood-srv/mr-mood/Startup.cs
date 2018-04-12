using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MrMood.BussinessLogic;
using MrMood.BussinessLogic.Calculations;
using MrMood.DataAccess;
using MrMood.DataAccess.Context;

namespace MrMood
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<MoodContext>(
                builder =>
                {
                    builder.UseSqlServer(
                        Configuration.GetConnectionString("MoodDatabase"));
                },
                ServiceLifetime.Scoped);

            services.AddTransient<DbContext, MoodContext>();
            services.AddTransient<RepositoryHolder, RepositoryHolder>();
            services.AddTransient<UnitOfWork, UnitOfWork>();
            services.AddTransient<MoodContext, MoodContext>();
            services.AddTransient<SongsService, SongsService>();
            services.AddTransient<ArtistsService, ArtistsService>();
            services.AddTransient<TagsService, TagsService>();
            services.AddTransient<SongTagsService, SongTagsService>();
            services.AddTransient<SongMarkCalculator, SongMarkCalculator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
