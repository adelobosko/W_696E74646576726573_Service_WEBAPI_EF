using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace W_Service
{
    [RunInstaller(true)]
    public partial class SysInfoInstaller : Installer
    {
        ServiceInstaller serviceInstaller;
        ServiceProcessInstaller processInstaller;
        //C:\Windows\Microsoft.NET\Framework64\v4.0.30319
        //InstallUtil.exe
        //sc delete
        public SysInfoInstaller()
        {
            InitializeComponent();

            serviceInstaller = new ServiceInstaller();
            processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalService;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = "SysInfoService";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
