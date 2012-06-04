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

        #region Phân quyền, ẩn hiện các button
        /// <summary>
        /// Ẩn hiện tất cả menu cần thiết
        /// </summary>
        /// <param name="EnableAllMenu">True - Hiển thị / False - Ẩn</param>
        private void EnableAllMenu(bool EnableAllMenu)
        {
            // Quản lý hồ sơ - Hồ sơ năm học
            btnHomeKhaiBao.Enabled = EnableAllMenu;
            btnHomeNamHoc.Enabled = EnableAllMenu;
            btnHomeMonHoc.Enabled = EnableAllMenu;
            btnHomeLop.Enabled = EnableAllMenu;
            btnHomeGiaoVien.Enabled = EnableAllMenu;
            // Quản lý hồ sơ - Hồ sơ học sinh
            btnHomeHocSinh.Enabled = EnableAllMenu;
            btnHomeTimKiem.Enabled = EnableAllMenu;
            btnHomePhanLop.Enabled = EnableAllMenu;
            // Quản lý học tập - Quản lý điểm
            btnHomeNhapDiem.Enabled = EnableAllMenu;
            btnHomeXuatBD.Enabled = EnableAllMenu;
            // Quản lý học tập - Báo cáo tổng kết
            btnHomeTKDiemHK.Enabled = EnableAllMenu;
            btnHomeTKMonHoc.Enabled = EnableAllMenu;

        }
        /// <summary>
        /// Phân quyền người dùng, tùy thuộc từng quyền mà có những chức năng khác nhau
        /// </summary>
        public void PhanQuyenNguoiDung()
        {
            EnableAllMenu(true);
            switch (Util.ObjectUtil.user.LoaiNguoiDung.MaLoai)
            {
                // Administrator
                case "quantri":
                // Ban giám hiệu
                case "hieutruong":
                case "phohieutruong": NhomAdministrator(); break;
                // Giáo viên
                case "giaovien": NhomGiaoVien(); break;
                // Giáo vụ
                case "giaovu": NhomGiaoVu(); break;
                // mặc định ẩn hết menu
                default: EnableAllMenu(false); break;
            }
        }
        /// <summary>
        /// Diable menu không thuộc nhóm Administrator
        /// </summary>
        private void NhomAdministrator()
        {
            // nhóm administrator toàn quyền
        }
        /// <summary>
        /// Diable menu không thuộc nhóm giáo viên
        /// </summary>
        private void NhomGiaoVien()
        {
            // Quản lý hồ sơ - Hồ sơ năm học
            btnHomeKhaiBao.Enabled = false;
            btnHomeNamHoc.Enabled = false;
            btnHomeMonHoc.Enabled = false;
            btnHomeLop.Enabled = false;
            btnHomeGiaoVien.Enabled = false;
            // Quản lý hồ sơ - Hồ sơ học sinh
            btnHomeHocSinh.Enabled = false;
            btnHomePhanLop.Enabled = false;
            // Quản lý học tập - Quản lý điểm
            btnHomeNhapDiem.Enabled = false;
            btnHomeXuatBD.Enabled = false;
            // Quản lý học tập - Báo cáo tổng kết
            btnHomeTKDiemHK.Enabled = false;
            btnHomeTKMonHoc.Enabled = false;
        }
        /// <summary>
        /// Diable menu không thuộc nhóm giáo vụ
        /// </summary>
        private void NhomGiaoVu()
        {
            btnHomeKhaiBao.Enabled = false;
        }
        #endregion

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