using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;

namespace QLHS
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

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            
            Application.Run(new frmBC_TongKetHocKy());
        }
    }
}
