using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Updater
{
    internal static class Program

    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static IConfiguration Configuration { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();


            ConfigurationBuilder confBuilder = new ConfigurationBuilder();
            Configuration = confBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
                     
            Configuration = confBuilder.Build();
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

           /* var form = ServiceProvider.GetRequiredService<Form1>();
            Application.Run(form);
            var form = ServiceProvider.GetRequiredService<frmUpdate>();
            Application.Run(form);*/
            var form = ServiceProvider.GetRequiredService<FrmMain>();
            Application.Run(form);

            //Application.Run(new frmUpdate());
            //Application.Run(new Form1());
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            // configs
            services.AddSingleton<IConfiguration>(Configuration);

            // config objects
            services
                .Configure<Configuration.Config>(Configuration.GetSection("Configuracion"));

           /* // clases
            services
                .AddScoped<IGenerators, Configuration.Config>()
                .AddTransient<ICodeGenerator, GeneratorFromXml>()
                .AddTransient<ITableDataInfoRecover, SqlDataInfoRecover>()
                .AddTransient<ICommandRuner, SQLCommandRunner>()
                .AddTransient<IDbConnection, SqlConnection>();
           */
            // forms
            services
                //.AddTransient<frmMain>()
                .AddTransient<FrmMain>()
                .AddTransient<Form1>();

        }
    }
}