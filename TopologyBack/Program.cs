using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Topology
{
    class Program
    {
        public static String HomeDir { get; set; }

        static void Main(string[] args)
        {

            if (0 == args.Count())
            {
                Console.WriteLine("ERROR: неверное количество аргументов. Не указана домашняя папка.");
                Console.WriteLine("Парметры вызова: dotnet TopologyBack.dll Путь_к_домашней_папке");
                return;
            }

            HomeDir = args[0];
            if (!Directory.Exists(HomeDir))
            {
                Console.WriteLine("ERROR: неверное имя папки. Папка не существует.");
                Console.WriteLine("Парметры вызова: dotnet TopologyBack.dll Путь_к_домашней_папке");
                return;
            }


            var host = new WebHostBuilder()
                            .UseKestrel()
                            .UseContentRoot(Directory.GetCurrentDirectory())
                            .UseIISIntegration()
                            .UseStartup<Startup>()
                            .UseApplicationInsights()
                            .Build();

                        host.Run();  
        }
    }
}
