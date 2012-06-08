using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace QLHS
{
    class Program : WindowsFormsApplicationBase
    {
        private Program()
        {
            Application.EnableVisualStyles();

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();

            MainForm = new FrmMain();
            IsSingleInstance = true;
        }
        [STAThread]
        public static void Main(string[] args)
        {
            _instance = new Program();
            _instance.Run(args);
        }
        /// <summary>
        /// Nếu chương trình đang chạy, lần khởi động tiếp theo sẽ active lại chương trình
        /// </summary>
        /// <param name="eventArgs"></param>
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            _instance.MainForm.Activate();
        }
        /// <summary>
        /// Sử dụng khi ứng dụng restart 
        /// </summary>
        public static void Restart()
        {
            // Bỏ chế chộ single instance
            _instance.IsSingleInstance = false;
            Application.Restart();
        }
        private static Program _instance;
    }
}