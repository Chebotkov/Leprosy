using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace ShutDownService
{
    public partial class Service : ServiceBase
    {
        public Service()
        {
            InitializeComponent();
            this.CanStop = false;
            this.CanPauseAndContinue = false;
        }

        protected override void OnStart(string[] args)
        {
            MessageBox.Show("Shut down");
        }

        protected override void OnStop()
        {
        }
    }
}
