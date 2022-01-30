using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SovTechTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var isService = false;
            if(Debugger.IsAttached==false && args.Contains("--service"))
            {
                isService = true;
            }
            if (isService)
            {
                var pathToContentRoot = Directory.GetCurrentDirectory();
                var webhostArgs = args.Where(arg => arg != "--console").ToArray();

                string ConfigureFile = "appsettings.json";
                string PortNo = "5001";

                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);

                string AppJsonFilePath = Path.Combine(pathToContentRoot, ConfigureFile);

                if (File.Exists(AppJsonFilePath))
                {
                    using(StreamReader sr=new StreamReader(AppJsonFilePath))
                    {
                        string jsonData = sr.ReadToEnd();
                        JObject jObject = JObject.Parse(jsonData);
                        if (jObject["ServicePort"] != null)
                        {
                            PortNo = jObject["ServicePort"].ToString();
                        }

                    }
                    
                }

                var host = WebHost.CreateDefaultBuilder(args)
                                    .UseContentRoot(pathToContentRoot)
                                    .UseStartup<Startup>()
                                    .UseUrls("http://localhost:"+PortNo)
                                    .Build();
                host.RunAsService();
            }
            else
            {
                CreateHostBuilder(args).Build().Run();
            }

            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
