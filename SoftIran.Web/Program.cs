using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SoftIran.Insfrastrcture;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SoftIran.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                TextWriter tk = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Version.txt"), true);
                tk.WriteLine(DateTime.Now.ToShamsi().ToString()+" => "+DateTime.Now.Hour+":"+ DateTime.Now.Minute);
                tk.WriteLine("==============Department.List===============");
                tk.WriteLine(MapRoutes.Department.Single);
                tk.WriteLine(MapRoutes.Department.Upsert);
                tk.WriteLine(MapRoutes.Department.Delete);
                tk.WriteLine(MapRoutes.Department.List);
                tk.WriteLine();
                tk.Close();

            }
            catch (Exception)
            {

                throw;
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
