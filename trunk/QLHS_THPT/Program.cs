using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using DevExpress.LookAndFeel; 

namespace QLHS
{
    class Program : WindowsFormsApplicationBase
    {
        public Program()
        {
            Application.EnableVisualStyles();

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();

            MainForm = new frmMain();
            IsSingleInstance = true;
        }
        [STAThread]
        public static void Main(string[] args)
        {
            Instance = new Program();
            Instance.Run(args);
        }
        /// <summary>
        /// Nếu chương trình đang chạy, lần khởi động tiếp theo sẽ active lại chương trình
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            Instance.MainForm.Activate();
        }
        /// <summary>
        /// Sử dụng khi ứng dụng restart 
        /// </summary>
        public static void Restart()
        {
            // Bỏ chế chộ single instance
            Instance.IsSingleInstance = false;
            Application.Restart();
        }
        private static Program Instance;
    }
}