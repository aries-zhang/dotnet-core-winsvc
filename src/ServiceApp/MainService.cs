using EventHubListener;
using System.Configuration;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace ServiceApp
{
    public partial class MainService : ServiceBase
    {
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Task.Run(() =>
            {
                var param = new EventHubParameter()
                {
                    ConnectionString = ConfigurationManager.AppSettings[""],
                    ConsumerGroup = ConfigurationManager.AppSettings[""],
                    EntityPath = ConfigurationManager.AppSettings[""],
                    StorageConnectionString = ConfigurationManager.AppSettings[""],
                    StorageContainer = ConfigurationManager.AppSettings[""]
                };

                Listener.Run(param).Wait();
            });
        }

        protected override void OnStop()
        {
            Listener.Close().Wait();
        }
    }
}
