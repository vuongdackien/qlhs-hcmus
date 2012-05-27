using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using QLHS.BUS;

namespace QLHS
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    { 
        private frmDangNhap _fLogin = null;
        private NguoiDungBUS _nguoiDungBUS;
        private frmDoiMatKhau _frmDoiMK = null;

        public frmMain()
        {
            InitializeComponent();
            _nguoiDungBUS = new NguoiDungBUS();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Login();
        }

        #region Function Show MDI Child Form

        public Dictionary<Type, Form> openForms = new Dictionary<Type, Form>();
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
            barBtnKhaiBaoNamHoc.Enabled = EnableAllMenu;
            barBtnQuanLyNamHoc.Enabled = EnableAllMenu;
            barBtnHeSoMonHoc.Enabled = EnableAllMenu;

            barBtnTiepNhanHocSinh.Enabled = EnableAllMenu;
            barBtnTimKiemHocSinh.Enabled = EnableAllMenu;
            barBtnPhanLopHocSinh.Enabled = EnableAllMenu;

            barBtnHoSoGiaoVien.Enabled = EnableAllMenu;

            barButtonItemDSLop.Enabled = EnableAllMenu;
            barButtonItemQuanLyNguoiDung.Enabled = EnableAllMenu;
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
            switch (Utilities.ObjectUtilities.user.LoaiNguoiDung.MaLoai)
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
            barBtnKhaiBaoNamHoc.Enabled = false;
            barBtnQuanLyNamHoc.Enabled = false;
            barBtnHeSoMonHoc.Enabled = false;

            barBtnTiepNhanHocSinh.Enabled = false;
            barBtnPhanLopHocSinh.Enabled = false;

            barBtnHoSoGiaoVien.Enabled = false;

            barButtonItemDSLop.Enabled = false;
            barButtonItemQuanLyNguoiDung.Enabled = false;

        }
        /// <summary>
        /// Diable menu không thuộc nhóm giáo vụ
        /// </summary>
        private void NhomGiaoVu()
        {
            barBtnKhaiBaoNamHoc.Enabled = false;
        }

       
        private void Login()
        {
            this.Hide();
            EnableAllMenu(false);

            if(_fLogin == null || _fLogin.IsDisposed)
                 _fLogin = new frmDangNhap();
            // Set datasource listbox trên form login
            _fLogin.listBoxControlNguoiDung.DataSource = _nguoiDungBUS.Lay_DT_NguoiDung_DangNhap();
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
                Utilities.MessageboxUtilities.MessageError("Bạn chưa chọn tên người dùng đăng nhập!");
                return; // trả về đăng nhập tiếp
            }
            string PassWord = _fLogin.textEditMatKhau.Text;
            string UserName = (_fLogin.textEditTenNguoiDung.Text != "") ? 
                    _fLogin.textEditTenNguoiDung.Text : _fLogin.listBoxControlNguoiDung.SelectedValue.ToString();
            // Kiểm tra password bỏ trống
            if (PassWord.Equals(""))
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa nhập password!");
                _fLogin.textEditMatKhau.Focus();
                return;
            }
            // Tạo biến lấy thông tin user đăng nhập hiện tại
            Utilities.ObjectUtilities.user = _nguoiDungBUS.LayThongTinNguoiDung(UserName);
            if (Utilities.ObjectUtilities.user == null)
            {
                Utilities.MessageboxUtilities.MessageError("Tài khoản này không tồn tại!");
                return;
            }
            // Kiểm tra password nhập có chính xác hay không
            if (Utilities.ObjectUtilities.user.MatKhau != Utilities.ObjectUtilities.MaHoaMD5(PassWord))
            {
                Utilities.MessageboxUtilities.MessageError("Mật khẩu không chính xác!");
                _fLogin.textEditMatKhau.Focus();
                return;
            }
            // Trạng thái người dùng
            if (Utilities.ObjectUtilities.user.TrangThai == 0)
            {
                Utilities.MessageboxUtilities.MessageError("Bạn không được phép truy cập! Vui lòng liên hệ người quản trị!");
                return;
            }
            _fLogin.Dispose();
            // Gắn lại trạng thái login dưới bar from Main
            barStaticItemLoaiNguoiDung.Caption = Utilities.ObjectUtilities.user.LoaiNguoiDung.TenLoaiND;
            barStaticItemTenNguoiDung.Caption = Utilities.ObjectUtilities.user.TenND;
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
                Utilities.MessageboxUtilities.MessageError("Bạn chưa nhập mật khẩu cũ!");
                _frmDoiMK.textEditMatKhauCu.Focus();
                return;
            }
            if (_frmDoiMK.textEditMatKhauMoi.Text == "")
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa nhập mật khẩu mới!");
                _frmDoiMK.textEditMatKhauMoi.Focus();
                return;
            }
            if (_frmDoiMK.textEditReMatKhauMoi.Text == "")
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa nhập mật lại khẩu mới!");
                _frmDoiMK.textEditReMatKhauMoi.Focus();
                return;
            }
            if (_frmDoiMK.textEditMatKhauMoi.Text != _frmDoiMK.textEditReMatKhauMoi.Text)
            {
                _frmDoiMK.textEditMatKhauMoi.Focus();
                Utilities.MessageboxUtilities.MessageError("Mật khẩu nhập lại không hợp lệ!");
                return;
            }
            if (Utilities.ObjectUtilities.user.MatKhau != Utilities.ObjectUtilities.MaHoaMD5(_frmDoiMK.textEditMatKhauCu.Text))
            {
                Utilities.MessageboxUtilities.MessageError("Mật khẩu cũ không hợp lệ!");
                _frmDoiMK.textEditMatKhauCu.Focus();
                return;
            }
            // Change password
            if (_nguoiDungBUS.DoiMatKhauNguoiDung(Utilities.ObjectUtilities.user.TenDNhap, _frmDoiMK.textEditMatKhauMoi.Text))
            {
                // Set mật khẩu mới
                Utilities.ObjectUtilities.user.MatKhau = Utilities.ObjectUtilities.MaHoaMD5(_frmDoiMK.textEditMatKhauMoi.Text);
                if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Đổi mật khẩu thành công! Bạn có muốn đăng nhập lại?")
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


       

     
    }
}