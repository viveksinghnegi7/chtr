using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using chtr.server.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
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
                //remove for production code..
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.WithOrigins("http://localhost:4200");
                policy.AllowCredentials();
                policy.AllowAnyOrigin();
            }));

            services.AddMvc().AddControllersAsServices();
            services.AddSignalR(cfg =>
            {
                cfg.EnableDetailedErrors = true;
            });
           

            var builder = new ContainerBuilder();
            builder.RegisterModule(new ApplicationModule());
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

            app.UseMvc();

        }
    }
}
