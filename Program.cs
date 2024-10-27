
using Microsoft.AspNetCore.Http.Connections;
using Projeto_signalR.Hubs;

namespace Projeto_signalR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();

            //// Adicione a política CORS
            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigins",
            //        policy =>
            //        {
            //            policy.WithOrigins("http://localhost:4200") // Adicione aqui as origens permitidas
            //                  .AllowAnyHeader()
            //                  .AllowAnyMethod()
            //                  .AllowCredentials(); // Isso permite o uso de credenciais
            //        });
            //});

            var app = builder.Build();

            app.UseCors(builder => builder
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin()
            );

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                // Mapeia o Hub de SignalR para uma rota específica
                endpoints.MapHub<PromoHub>("/PromoHub");
            });


            app.MapControllers();

            app.Run();
        }
    }
}
