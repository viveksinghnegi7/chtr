using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using chtr.server.api;
using chtr.server.api.Configuration;
using chtr.server.data;
using chtr.server.data.Entities;
using chtr.server.Hubs;
using GraphiQl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace chtr.server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(s => s.AddPolicy("Cors", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.WithOrigins("http://localhost:4200");
                policy.AllowCredentials();
                policy.AllowAnyOrigin();
            }));

            var connectionString = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<ChtrDbContext>(options => options.UseSqlServer(connectionString));
            services.AddMvc().AddControllersAsServices();
            services.AddSignalR(cfg =>
            {
                cfg.EnableDetailedErrors = true;
            });
           

            var builder = new ContainerBuilder();
            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule(new ApiModule());
            builder.RegisterModule(new DataModule());
            builder.Populate(services);

            var container = builder.Build();
           
            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("Cors");
            app.UseSignalR(cfg =>
            {
                cfg.MapHub<ChatHub>("/chat");
            });

            app.UseGraphiQl(Api.GraphQlPath);
            app.UseMvc();

            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ChtrDbContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
