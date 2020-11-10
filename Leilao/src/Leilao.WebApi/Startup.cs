using Leilao.CrossCutting.IoC;
using Leilao.WebApi.Configuration;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Leilao.WebApi {

    public class Startup {

        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment env) {

            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", true, true).AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services) {

            // Se não adicionar, o Swagger nao funciona.
            services.AddControllers();

            services.AddSwaggerConfiguration();

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    b => b
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetPreflightMaxAge(TimeSpan.FromDays(30))
                );
            });

            services.AddMediatR(typeof(Startup));

            RegisterServices(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseRouting();

            // Se não adicionar, o Swagger nao funciona.
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            app.UseSwaggerSetup();
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration configuration) {
            NativeInjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}
