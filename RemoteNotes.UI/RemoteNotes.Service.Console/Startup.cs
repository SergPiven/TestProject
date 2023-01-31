using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace RemoteNotes.Service.Console
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);
            services.AddSignalR(hubOptions =>
            {
                hubOptions.EnableDetailedErrors = true;
                hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
            });
            IManagerFactory managerFactory = new ManagerFactory();
            services.AddSingleton<IManagerFactory>(managerFactory);
            services.AddSingleton<HubEnvironment>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<MainHub>("/notes", options =>
                {
                    // 30Kb message buffer
                    options.TransportMaxBufferSize = 0;
                    options.ApplicationMaxBufferSize = 120 * 1024;
                });
            });
        }
    }
}
