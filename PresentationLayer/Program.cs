using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;



namespace PresentationLayer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = host.Services.GetRequiredService<Form1>();
            Application.Run(new Form1());
        }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()  
                .ConfigureServices((context, services) =>
                {
                    // BURAYA ekleyeceksin
                    //services.AddScoped<IAdminDal, EFAdminDal>();
                    //services.AddScoped<>();
                    services.AddScoped<Form1>(); // Form'u da ekle

                    // Gerekirse diğer servis kayıtları
                });
        }
    }
}
