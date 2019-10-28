using System.ServiceProcess;
using System.Timers;

namespace W_Service
{
    public partial class SysInfoService : ServiceBase
    {
        private Timer _timer;
        public SysInfoService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WorkHelper.Log("Service started");
            WorkHelper.LogSysInfo();
            _timer = new Timer
            {
                AutoReset = true,
                Interval = 1000*60*30,
                Enabled = true
            };
            _timer.Elapsed += OnTimedEvent;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            WorkHelper.LogSysInfo();
        }


        protected override void OnStop()
        {
            WorkHelper.Log($"Service is stopped!");
        }
    }
}
