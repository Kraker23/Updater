using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data;
using Updater.Configuration;

namespace Updater
{
    public partial class FrmMain : Form
    {
        Config configs;


        public FrmMain(IOptions<Config> settings)
        {
            this.configs = settings.Value;

            InitializeComponent();
        }
        
    }
}
