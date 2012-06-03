using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLHS
{
    public partial class frmHome : DevExpress.XtraEditors.XtraForm
    {
        private frmMain frmMainInstance;
        public frmHome()
        {
            InitializeComponent();
        }
        
        private void frmGUIDE_Resize(object sender, EventArgs e)
        {
            panelControl1.Location = new System.Drawing.Point(this.Size.Width / 2
              - panelControl1.Size.Width / 2, panelControl1.Location.Y);
        }
        private void frmHome_Load(object sender, EventArgs e)
        {
            frmMainInstance = this.ParentForm as frmMain;
        }

        #region Home introduce button

        private void btnHomeNamHoc_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmNamHoc>();
        }

        private void btnHomeGiaoVien_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmGiaoVien>();
        }

        private void btnHomeKhaiBao_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmQuyDinhDauNam>();
        }

        private void btnHomeHocSinh_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmHocSinh>();
        }

        private void btnHomeLop_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmLapDSLop>();
        }

        private void btnHomePhanLop_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmPhanLop>();
        }

        private void btnHomeTimKiem_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmTimHocSinh>();
        }

        private void btnHomeNhapDiem_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmBangDiemMonHoc>();
        }

        private void btnHomeMonHoc_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmMonHoc>();
        }

        private void btnHomeTKDiemHK_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmBC_TongKetHocKy>();
        }

        private void btnHomeXuatBD_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmBC_BangDiemHocKy>();
        }

        private void btnHomeTKMonHoc_Click(object sender, EventArgs e)
        {
            frmMainInstance.ShowMDIChildForm<frmBC_TongKetMon>();
        }
        #endregion

     
    }
}