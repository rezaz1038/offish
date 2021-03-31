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

                tk.WriteLine("==============PGM.List===============");
                tk.WriteLine(MapRoutes.PGM.Single);
                tk.WriteLine(MapRoutes.PGM.Upsert);
                tk.WriteLine(MapRoutes.PGM.Delete);
                tk.WriteLine(MapRoutes.PGM.List);
                tk.WriteLine();

                tk.WriteLine("==============Role.List===============");
                tk.WriteLine(MapRoutes.Role.Single);
                tk.WriteLine(MapRoutes.Role.Upsert);
                tk.WriteLine(MapRoutes.Role.Delete);
                tk.WriteLine(MapRoutes.Role.List);
                tk.WriteLine(MapRoutes.Role.ListAll);
                tk.WriteLine();

                tk.WriteLine("==============Department.List===============");
                tk.WriteLine(MapRoutes.Department.Single);
                tk.WriteLine(MapRoutes.Department.Upsert);
                tk.WriteLine(MapRoutes.Department.Delete);
                tk.WriteLine(MapRoutes.Department.List);
                tk.WriteLine();

                tk.WriteLine("==============User.List===============");
                tk.WriteLine(MapRoutes.User.Single);
                tk.WriteLine(MapRoutes.User.Upsert);
                tk.WriteLine(MapRoutes.User.Delete);
                tk.WriteLine(MapRoutes.User.List);
                tk.WriteLine(MapRoutes.User.UploadAvatar);
                tk.WriteLine(MapRoutes.User.Login);
                tk.WriteLine(MapRoutes.User.ResetPassword);
                tk.WriteLine(MapRoutes.User.ChangePassword);
                tk.WriteLine();

                tk.WriteLine("==============Equipment.List===============");
                tk.WriteLine(MapRoutes.Equipment.Single);
                tk.WriteLine(MapRoutes.Equipment.Upsert);
                tk.WriteLine(MapRoutes.Equipment.Delete);
                tk.WriteLine(MapRoutes.Equipment.List);
                tk.WriteLine();

                tk.WriteLine("==============Type.List===============");
                tk.WriteLine(MapRoutes.Equipment.Type.Single);
                tk.WriteLine(MapRoutes.Equipment.Type.Upsert);
                tk.WriteLine(MapRoutes.Equipment.Type.Delete);
                tk.WriteLine(MapRoutes.Equipment.Type.List);
                tk.WriteLine();

                tk.WriteLine("==============Brand.List===============");
                tk.WriteLine(MapRoutes.Equipment.Brand.Single);
                tk.WriteLine(MapRoutes.Equipment.Brand.Upsert);
                tk.WriteLine(MapRoutes.Equipment.Brand.Delete);
                tk.WriteLine(MapRoutes.Equipment.Brand.List);
                tk.WriteLine();

                tk.WriteLine("==============Place.List===============");
                tk.WriteLine(MapRoutes.Equipment.Place.Single);
                tk.WriteLine(MapRoutes.Equipment.Place.Upsert);
                tk.WriteLine(MapRoutes.Equipment.Place.Delete);
                tk.WriteLine(MapRoutes.Equipment.Place.List);
                tk.WriteLine();

                tk.WriteLine("==============Offish.List===============");
                 
                tk.WriteLine(MapRoutes.Offish.Upsert.UpsertUrl);
                tk.WriteLine(MapRoutes.Offish.Upsert.register);
                tk.WriteLine(MapRoutes.Offish.Upsert.Delete);
                tk.WriteLine(MapRoutes.Offish.Upsert.Single);

                tk.WriteLine(MapRoutes.Offish.Category.Upsert);
                tk.WriteLine(MapRoutes.Offish.Category.List);
                tk.WriteLine(MapRoutes.Offish.Category.Delete);
                tk.WriteLine(MapRoutes.Offish.Category.Single);
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
