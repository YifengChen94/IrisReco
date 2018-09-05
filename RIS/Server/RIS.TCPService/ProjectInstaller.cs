using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;

namespace Suzsoft.DDP.WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}