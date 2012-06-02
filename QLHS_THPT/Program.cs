using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.Common;
using System.Threading;

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

            bool firstInstance;
            using (Mutex mutex = new Mutex(true, "Instance Program", out firstInstance))
            {
                if (firstInstance)
                    Application.Run(new frmMain());
                else
                     Util.MsgboxUtil.Error("Chương trình đang chạy!");
            }
        }
    }
}
