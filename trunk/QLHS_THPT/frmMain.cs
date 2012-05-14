using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QLHS_THPT
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region Function Show MDI Child Form

        private Dictionary<Type, Form> openForms = new Dictionary<Type, Form>();
        /// <summary>
        /// Sử dụng để hiển thị MDI Children form
        /// </summary>
        /// <typeparam name="T">Tên form</typeparam>
        public void ShowMDIChildForm<T>() where T : Form, new()
        {
            Form instance;
            openForms.TryGetValue(typeof(T), out instance);
            if (instance == null || instance.IsDisposed)
            {
                instance = new T();
                openForms[typeof(T)] = instance;
                instance.MdiParent = this;
                instance.Show();
            }
            else
            {
                instance.Activate();
            }
        }
        #endregion



        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmHocSinh>();
        }
        
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }
        
        private void barBtnHoSoHocSinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmHocSinh>();
        }

        private void barBtnTimKiemHocSinh_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
    }
}