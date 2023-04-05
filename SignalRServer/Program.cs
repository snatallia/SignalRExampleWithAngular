using SignalRServer.Features;
using SignalRServer.HubConfig;

namespace SignalRServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("SingalRCorsPolicy", builder => builder
                                                           .WithOrigins("http://localhost:4200")
                                                           .AllowAnyMethod()                                                           
                                                           .AllowAnyHeader()
                                                           .AllowCredentials());
            });
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<ChartTimer>();           
            builder.Services.AddControllers();
            
            var app = builder.Build();
            app.UseHttpsRedirection();
            app.UseCors("SingalRCorsPolicy");            
            app.UseAuthorization();            
            app.MapControllers();
            app.MapHub<ChartHub>("/chart");            
            app.Run();
        }
    }
}