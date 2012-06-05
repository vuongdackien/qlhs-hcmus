using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using QLHS.BUS;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using DatabaseConnectionManagement.Properties;

namespace QLHS
{

    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    { 
        private frmDangNhap _fLogin = null;
        private NguoiDungBUS _nguoiDungBUS;
        private frmDoiMatKhau _frmDoiMK = null;
        public Dictionary<Type, Form> openForms = new Dictionary<Type, Form>();

        public frmMain()
        {
            InitializeComponent();
            SkinHelper.InitSkinGallery(ribbonGalleryBarItemGiaoDien, true);
            UserLookAndFeel.Default.SkinName = Properties.Settings.Default.ApplicationSkinName;

            _nguoiDungBUS = new NguoiDungBUS();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Login();
            ShowMDIChildForm<frmHome>();
            var frm = openForms[typeof(frmHome)] as frmHome;
            xtraTabbedMdiManager.Pages[frm].ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
          
        }
        #region Function Show MDI Child Form
       
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
        public void ShowMDIChildForm<T>(object obj) where T : Form, new()
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

        #region Tác vụ đăng nhập
        /// <summary>
        /// Ẩn hiện tất cả menu cần thiết
        /// </summary>
        /// <param name="EnableAllMenu">True - Hiển thị / False - Ẩn</param>
        private void EnableAllMenu(bool EnableAllMenu)
        {
            // Quản lý hồ sơ - Hồ sơ năm học
            barBtnKhaiBaoNamHoc.Enabled = EnableAllMenu;
            barBtnQuanLyNamHoc.Enabled = EnableAllMenu;
            barBtnHeSoMonHoc.Enabled = EnableAllMenu;
            barButtonItemDSLop.Enabled = EnableAllMenu;
            barBtnHoSoGiaoVien.Enabled = EnableAllMenu;
            // Quản lý hồ sơ - Hồ sơ học sinh
            barBtnTiepNhanHocSinh.Enabled = EnableAllMenu;
            barBtnTimKiemHocSinh.Enabled = EnableAllMenu;
            barBtnPhanLopHocSinh.Enabled = EnableAllMenu;
            // Quản lý học tập - Quản lý điểm
            barButtonItemNhapDiemMonHoc.Enabled = EnableAllMenu;
            barButtonItemBCBangDiem.Enabled = EnableAllMenu;
            // Quản lý học tập - Báo cáo tổng kết
            barButtonItemTongKetMonHoc.Enabled = EnableAllMenu;
            barButtonItemTongKetHocKy.Enabled = EnableAllMenu;
            // Hệ thống
            barButtonItemQuanLyNguoiDung.Enabled = EnableAllMenu;
            barButtonItemCauHinhKetNoi.Enabled = EnableAllMenu;

            // menu system
            barButtonItemDangNhap.Enabled = !EnableAllMenu;
            barButtonItemDoiMatKhau.Enabled = EnableAllMenu;
            barButtonItemDangXuat.Enabled = EnableAllMenu;
            
        }
        /// <summary>
        /// Phân quyền người dùng, tùy thuộc từng quyền mà có những chức năng khác nhau
        /// </summary>
        private void PhanQuyenNguoiDung()
        {
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
            // phân quyền form home
            var frmHome = openForms[typeof(frmHome)] as frmHome;
            frmHome.PhanQuyenNguoiDung();
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
            barBtnKhaiBaoNamHoc.Enabled = false;
            barBtnQuanLyNamHoc.Enabled = false;
            barBtnHeSoMonHoc.Enabled = false;
            barButtonItemDSLop.Enabled = false;
            barBtnHoSoGiaoVien.Enabled = false;
            // Quản lý hồ sơ - Hồ sơ học sinh
            barBtnTiepNhanHocSinh.Enabled = false;
            barBtnPhanLopHocSinh.Enabled = false;
            // Quản lý học tập - Quản lý điểm
            barButtonItemNhapDiemMonHoc.Enabled = false;
            barButtonItemBCBangDiem.Enabled = false;
            // Quản lý học tập - Báo cáo tổng kết
            barButtonItemTongKetMonHoc.Enabled = false;
            barButtonItemTongKetHocKy.Enabled = false;
            // Hệ thống
            barButtonItemQuanLyNguoiDung.Enabled = false;
            barButtonItemCauHinhKetNoi.Enabled = false;
        }
        /// <summary>
        /// Diable menu không thuộc nhóm giáo vụ
        /// </summary>
        private void NhomGiaoVu()
        {
            barBtnKhaiBaoNamHoc.Enabled = false;
            // Hệ thống
            barButtonItemCauHinhKetNoi.Enabled = false;
        }

       
        private void Login()
        {
            this.Hide();
            EnableAllMenu(false);

            if(_fLogin == null || _fLogin.IsDisposed)
                 _fLogin = new frmDangNhap();
            // Set datasource listbox trên form login
            _fLogin.listBoxControlNguoiDung.DataSource = _nguoiDungBUS.LayDT_NguoiDung_DangNhap();
            _fLogin.listBoxControlNguoiDung.DisplayMember = "TenGiaoVien";
            _fLogin.listBoxControlNguoiDung.ValueMember = "TenDNhap";
            _fLogin.Show();
            // Khi người dùng click Đăng nhập, ta new event handler Click
            _fLogin.simpleButtonDangNhap.Click += new EventHandler(btn_Login_DangNhap_Click);
            _fLogin.simpleButtonThoat.Click += new EventHandler(btn_Login_Thoat_Click);
        }
        void btn_Login_DangNhap_Click(object sender, EventArgs e)
        {
            barStaticItemTenNguoiDung.Caption = "";
            barStaticItemLoaiNguoiDung.Caption = "";
            // Kiểm tra người dùng đã chọn username hay chưa
            if (_fLogin.listBoxControlNguoiDung.SelectedValue == null)
            {
                Util.MsgboxUtil.Error("Bạn chưa chọn tên người dùng đăng nhập!");
                return; // trả về đăng nhập tiếp
            }
            string PassWord = _fLogin.textEditMatKhau.Text;
            string UserName = (_fLogin.textEditTenNguoiDung.Text != "") ? 
                    _fLogin.textEditTenNguoiDung.Text : _fLogin.listBoxControlNguoiDung.SelectedValue.ToString();
            // Kiểm tra password bỏ trống
            if (PassWord.Equals(""))
            {
                Util.MsgboxUtil.Error("Bạn chưa nhập password!");
                _fLogin.textEditMatKhau.Focus();
                return;
            }
            // Tạo biến lấy thông tin user đăng nhập hiện tại
            Util.ObjectUtil.user = _nguoiDungBUS.LayThongTin_NguoiDung(UserName);
            if (Util.ObjectUtil.user == null)
            {
                Util.MsgboxUtil.Error("Tài khoản này không tồn tại!");
                return;
            }
            // Kiểm tra password nhập có chính xác hay không
            if (Util.ObjectUtil.user.MatKhau != Util.ObjectUtil.MaHoaMD5(PassWord))
            {
                Util.MsgboxUtil.Error("Mật khẩu không chính xác!");
                _fLogin.textEditMatKhau.Focus();
                return;
            }
            // Trạng thái người dùng
            if (Util.ObjectUtil.user.TrangThai == 0)
            {
                Util.MsgboxUtil.Error("Bạn không được phép truy cập! Vui lòng liên hệ người quản trị!");
                return;
            }
            _fLogin.Dispose();
            // Gắn lại trạng thái login dưới bar from Main
            barStaticItemLoaiNguoiDung.Caption = Util.ObjectUtil.user.LoaiNguoiDung.TenLoaiND;
            barStaticItemTenNguoiDung.Caption = Util.ObjectUtil.user.TenND;
            // hiển thị lại form main
            this.Show();
            // Enable all menu
            EnableAllMenu(true);
            // Phân quyền người dùng
            PhanQuyenNguoiDung();

        }
        void btn_Login_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void barButtonItemDangNhap_ItemClick(object sender, ItemClickEventArgs e)
        {
            btn_Login_DangNhap_Click(sender, e);
        }

        private void barButtonItemDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            EnableAllMenu(false);
            Login();
        }
        #endregion

        #region Đổi mật khẩu người dùng
        private void barButtonItemDoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_frmDoiMK == null || _frmDoiMK.IsDisposed)
                _frmDoiMK = new frmDoiMatKhau();
            _frmDoiMK.simpleButtonDoiMatKau.Click += new EventHandler(btnDoiMatKhau_Click);
            _frmDoiMK.simpleButtonThoat.Click += new EventHandler(btnThoatChangePass_Click);
            _frmDoiMK.Show();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (_frmDoiMK.textEditMatKhauCu.Text == "")
            {
                Util.MsgboxUtil.Error("Bạn chưa nhập mật khẩu cũ!");
                _frmDoiMK.textEditMatKhauCu.Focus();
                return;
            }
            if (_frmDoiMK.textEditMatKhauMoi.Text == "")
            {
                Util.MsgboxUtil.Error("Bạn chưa nhập mật khẩu mới!");
                _frmDoiMK.textEditMatKhauMoi.Focus();
                return;
            }
            if (_frmDoiMK.textEditReMatKhauMoi.Text == "")
            {
                Util.MsgboxUtil.Error("Bạn chưa nhập mật lại khẩu mới!");
                _frmDoiMK.textEditReMatKhauMoi.Focus();
                return;
            }
            if (_frmDoiMK.textEditMatKhauMoi.Text != _frmDoiMK.textEditReMatKhauMoi.Text)
            {
                _frmDoiMK.textEditMatKhauMoi.Focus();
                Util.MsgboxUtil.Error("Mật khẩu nhập lại không hợp lệ!");
                return;
            }
            if (Util.ObjectUtil.user.MatKhau != Util.ObjectUtil.MaHoaMD5(_frmDoiMK.textEditMatKhauCu.Text))
            {
                Util.MsgboxUtil.Error("Mật khẩu cũ không hợp lệ!");
                _frmDoiMK.textEditMatKhauCu.Focus();
                return;
            }
            // Change password
            if (_nguoiDungBUS.DoiMatKhau_NguoiDung(Util.ObjectUtil.user.TenDNhap, _frmDoiMK.textEditMatKhauMoi.Text))
            {
                // Set mật khẩu mới
                Util.ObjectUtil.user.MatKhau = Util.ObjectUtil.MaHoaMD5(_frmDoiMK.textEditMatKhauMoi.Text);
                if (Util.MsgboxUtil.YesNo("Đổi mật khẩu thành công! Bạn có muốn đăng nhập lại?")
                     == DialogResult.Yes)
                {
                    _frmDoiMK.Dispose();
                    Login();
                }
                else
                    _frmDoiMK.Dispose();
            }

        }

        void btnThoatChangePass_Click(object sender, EventArgs e)
        {
            _frmDoiMK.Dispose();
        }
        #endregion
        
        private void barBtnHoSoHocSinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmHocSinh>();
        }

        private void barBtnTimKiemHocSinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmTimHocSinh>();
        }

        private void barBtnHoSoGiaoVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmGiaoVien>();
        }
   
        private void barBtnPhanLopHocSinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmPhanLop>();
        }

        private void barButtonItemDSLop_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmLapDSLop>();
        }
        private void barButtonItemBCBangDiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmBC_BangDiemHocKy>();
        }

        private void barButtonItemTongKetMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmBC_TongKetMon>();
        }
        private void barButtonItemNhapDiemMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmBangDiemMonHoc>();
        }
        private void barButtonItemTongKetHocKy_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmBC_TongKetHocKy>();
        }

        private void barBtnQuanLyNamHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmNamHoc>();
        }
        private frmQLNguoiDung _frmQLNguoiDung = null;
        private void barButtonItemQuanLyNguoiDung_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_frmQLNguoiDung == null || _frmQLNguoiDung.IsDisposed)
                _frmQLNguoiDung = new frmQLNguoiDung();
            _frmQLNguoiDung.ShowDialog();
        }

        private void barBtnKhaiBaoNamHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmQuyDinhDauNam>();
        }

        private void barButtonItemCauHinhKetNoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            DatabaseConnectionManagement.frmAddConnection frm = new DatabaseConnectionManagement.frmAddConnection();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Util.MsgboxUtil.Success("Đã lưu cấu hình của chương trình!"
                       +"\nChương trình sẽ khởi động lại để cập nhật dữ liệu!");
                Application.Restart();
            }
        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThongTinChuongTrinh frmThongTin = new frmThongTinChuongTrinh();
            frmThongTin.ShowDialog();
        }

        private void barButtonItemThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.ExitThread();
        }

        private void barBtnHeSoMonHoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowMDIChildForm<frmMonHoc>();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape
                && !(xtraTabbedMdiManager.SelectedPage.MdiChild is frmHome))
            {
                if(Util.MsgboxUtil.YesNo("Bạn có muốn đóng màn hình "+
                    xtraTabbedMdiManager.SelectedPage.MdiChild.Text+" hay không?")
                == DialogResult.Yes)
                {
                    xtraTabbedMdiManager.SelectedPage.MdiChild.Close();
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            Properties.Settings.Default.Save();
        }

        
    }
}