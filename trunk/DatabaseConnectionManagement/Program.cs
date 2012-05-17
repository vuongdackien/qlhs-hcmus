using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DatabaseConnectionManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            double version = GetNetFrameWorkVersion();
            // Dung net framework 2.0 chi chay tren may co NF = 2,3
            // Dung net framework 3.5 khi chay tren may co NF >= 3.5
            Application.Run(new FrmAddConnection());
        }
        
        static double GetNetFrameWorkVersion()
        {
            Microsoft.Win32.RegistryKey installed_versions = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
            string[] version_names = installed_versions.GetSubKeyNames();
            //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
            return Convert.ToDouble(version_names[version_names.Length - 1].Remove(0, 1), System.Globalization.CultureInfo.InvariantCulture);
         }
    }
}