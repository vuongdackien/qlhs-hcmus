using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLHS.BUS;
using QLHS.DTO;

namespace QLHS
{
    public partial class frmQLNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        public frmQLNguoiDung()
        {
            InitializeComponent();
        }
        NguoiDungBUS _nguoiDungBUS = new NguoiDungBUS();
        GiaoVienBUS _giaoVienBUS = new GiaoVienBUS();
        LoaiNguoiDungBUS _loaiNguoiDungBUS = new LoaiNguoiDungBUS();
        int _currentRow = 0;

        private void frmQLNguoiDung_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNguoiDung, _giaoVienBUS.LayDT_DanhSachGiaoVien(),
                                                          "MaGiaoVien", "TenGiaoVien",0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditQuyenSuDung, _loaiNguoiDungBUS.Lay_DT_LoaiNguoiDung(),
                                                         "MaLoaiND", "TenLoaiND", 0);
            // load gridview
            gridControlNguoiDung.DataSource = _nguoiDungBUS.Lay_DT_NguoiDung();                                                
        }
        public void DisableControls(bool editing)
        {
            simpleButtonDong.Enabled = !editing;
            gridControlNguoiDung.Enabled = !editing;
            comboBoxEditNguoiDung.Enabled = editing;
            if (editing)
            {
                simpleButtonThemMoi.Text = "Không nhập (Alt+&N)";
                simpleButtonXoa.Text = "Nhập lại (Alt+&D)";
            }
            else
            {
                simpleButtonThemMoi.Text = "Thêm mới (Alt+&N)";
                simpleButtonXoa.Text = "Xóa (Alt+&D)";
            }
        }


        private void ResetControl()
        {
            comboBoxEditNguoiDung.SelectedIndex = 0;
            textEditMatKhau.Text = "";
            textEdittenTruyCap.Text = "";
            radioGroupTrangThai.SelectedIndex = 0;
        }

        private void simpleButtonThemMoi_Click(object sender, EventArgs e)
        {
            if (simpleButtonThemMoi.Text == "Thêm mới (Alt+&N)")
            {
                DisableControls(true);
                ResetControl();
            }
            else
            {
                // Hiển thị lại
                gridViewNguoiDung.FocusedRowHandle = 0;
                // Bỏ ẩn control
                DisableControls(false);
            } 
        }

        private void simpleButtonGhi_Click(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNguoiDung)
              || Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditQuyenSuDung))
                
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa chọn người dùng hoặc chưa có giáo viên nào trong danh sách!");
                return;
            }
            if (textEdittenTruyCap.Text == "")
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa nhập tên đăng nhập");
                return;
            }

            bool checkExistsUser = _nguoiDungBUS.KiemTraTonTai_NguoiDung(
                      Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNguoiDung));

            if (!checkExistsUser && textEditMatKhau.Text == "")
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa nhập mật khẩu!");
                return;
            }

            DisableControls(false);
            // Lay tt nguoi dung
            NguoiDungDTO user = new NguoiDungDTO();
            user.MaND = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNguoiDung);
            user.LoaiNguoiDung.MaLoai =  Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditQuyenSuDung);
            user.TenDNhap = textEdittenTruyCap.Text;
            user.MatKhau = (textEditMatKhau.Text == "") ? "" : textEditMatKhau.Text;
            user.TrangThai = radioGroupTrangThai.SelectedIndex;
            // Check nguoi dung ton tai hay chua
            if (!checkExistsUser)
            {
                // thêm
                if (_nguoiDungBUS.InsertUser(user))
                {
                    Utilities.MessageboxUtilities.MessageSuccess("Thêm thành công user: " +
                            Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNguoiDung) + " !");
                }
            }
            else
            {
                // Sửa
                if (_nguoiDungBUS.UpdateUser(user))
                {
                    Utilities.MessageboxUtilities.MessageSuccess("Sửa thành công user: " +  Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNguoiDung)  + " !");
                }
            }
            int cur = gridViewNguoiDung.FocusedRowHandle;
            gridControlNguoiDung.DataSource = _nguoiDungBUS.Lay_DT_NguoiDung(); 
            gridViewNguoiDung.FocusedRowHandle = cur;
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            if (!_nguoiDungBUS.KiemTraTonTai_NguoiDung(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNguoiDung)))
            {
                ResetControl();
                return;
            }
            else
            {
                string tenNguoiDung = Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNguoiDung);
                if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có muốn xóa người dùng "
                    + tenNguoiDung  + " hay không?") == DialogResult.Yes)
                {
                    if (_nguoiDungBUS.DeleteUser(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNguoiDung)))
                    {
                        Utilities.MessageboxUtilities.MessageSuccess("Xóa người dùng "
                                    + tenNguoiDung + " thành công!");
                        gridControlNguoiDung.DataSource = _nguoiDungBUS.Lay_DT_NguoiDung(); 
                        return;
                    }
                }
            }
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridViewNguoiDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _currentRow = gridViewNguoiDung.FocusedRowHandle;
            textEdittenTruyCap.Text = gridViewNguoiDung.GetRowCellValue(_currentRow, "TenDNhap").ToString();
            Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEditNguoiDung,
                    gridViewNguoiDung.GetRowCellValue(_currentRow, "MaND").ToString());
            Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEditQuyenSuDung,
                    gridViewNguoiDung.GetRowCellValue(_currentRow, "MaLoaiND").ToString());
            radioGroupTrangThai.SelectedIndex = (bool)gridViewNguoiDung.GetRowCellValue(_currentRow, "TrangThai") ? 1 : 0;
            textEditMatKhau.Text = "";
        }
    }
}