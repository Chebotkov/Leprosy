using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Uninstall
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start("cmd", "/c shutdown -s -f -t 00");
        }
    }
}
