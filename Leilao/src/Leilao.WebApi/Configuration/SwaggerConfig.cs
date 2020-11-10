using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Leilao.WebApi.Configuration {

    public static class SwaggerConfig {

        public static void AddSwaggerConfiguration(this IServiceCollection services) {

            if(services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s => {

                s.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "MZLeilao API",
                    Description = "API feita para o servico online de leilao",
                    Contact = new OpenApiContact {
                        Name = "Marccus Zavadzki",
                        Email = "marcuszavadzki72@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/marccus-zava/")
                    },
                    License = new OpenApiLicense {
                        Name = "MZ"
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);
            });

        }

        public static void UseSwaggerSetup(this IApplicationBuilder application) {

            if(application == null)
                throw new ArgumentNullException(nameof(application));

            application.UseSwagger();
            application.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MZLeilao API");
            });

        }

    }
}
