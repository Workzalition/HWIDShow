using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HWIDShow
{
    class Program
    {
        [DllImport(@"ConsoleHider.dll")]
        public static extern void ConsoleHide();
        static void Main(string[] args)
        {
            ConsoleHide();
            MessageBox.Show("Showing HWID...");
            var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            var g = key.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", true);
            var j = g.GetValue("MachineGuid");
            MessageBox.Show(j.ToString().Replace("-", String.Empty).ToString());
            Environment.Exit(665);
        }
    }
}
