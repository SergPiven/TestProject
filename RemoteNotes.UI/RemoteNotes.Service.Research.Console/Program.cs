using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.IO;

namespace RemoteNotes.Service.Research.Console
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);
            return WebHost.CreateDefaultBuilder(args)
            .UseContentRoot(pathToContentRoot)
            .UseStartup<Startup>()
            .UseUrls("http://localhost:61234/");
        }
    }
}
