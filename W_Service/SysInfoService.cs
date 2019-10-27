using System;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using static W_Service.InfoHelper;

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
            Log();
            _timer = new Timer
            {
                AutoReset = true,
                Interval = 5000,
                Enabled = true
            };
            _timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Log();
        }

        private static void Log()
        {
            var str = $"{GetPCName()}\r\n{GetManufacturer()}";
            str += $"\r\n{GetUsers().Aggregate((i, j) => $"{i}, {j}")}";
            str += $"\r\n{GetCPULoad().Select(cpu => $"{cpu.Item1}: {cpu.Item2}%").Aggregate((i, j) => $"{i}, {j}")}";
            str += $"\r\n{GetRAMLoad()}";
            str += $"\r\n{DateTime.Now.ToString()}";
            File.WriteAllText("E:\\res.txt", str);
        }

        protected override void OnStop()
        {
        }
    }
}
