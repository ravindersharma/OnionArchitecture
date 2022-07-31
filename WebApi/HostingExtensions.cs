using Application;
using Microsoft.OpenApi.Models;
using Persistence;

namespace WebApi
{
    public static class HostingExtensions
    {

        /// <summary>
        /// Method to configure services 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => {
                c.IncludeXmlComments($"{System.AppDomain.CurrentDomain.BaseDirectory}\\OnionArchitecture.xml");
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "OnionArchitecture"
                });
            });

            // Add applicaition layer here
            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);


            return builder.Build();
        }

        /// <summary>
        /// Method to configure middleware (pipeline) for api
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            //confiure middlerware for app

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }



           

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;

        }


    }
}
