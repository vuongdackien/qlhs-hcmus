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
        NguoiDungBUS _nguoiDungBUS;
        GiaoVienBUS _giaoVienBUS;
        LoaiNguoiDungBUS _loaiNguoiDungBUS;
        private bool _is_add_button;
        private bool _is_delete_button;
        private int _current_row_edit;

        public frmQLNguoiDung()
        {
            InitializeComponent();
            _nguoiDungBUS = new NguoiDungBUS();
            _giaoVienBUS = new GiaoVienBUS();
            _loaiNguoiDungBUS = new LoaiNguoiDungBUS();
            _is_add_button = _is_delete_button = true;
        }

        private void frmQLNguoiDung_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNguoiDung, _giaoVienBUS.LayDT_DanhSachGiaoVien(),
                                                          "MaGiaoVien", "TenGiaoVien",0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditQuyenSuDung, _loaiNguoiDungBUS.Lay_DT_LoaiNguoiDung(),
                                                         "MaLoaiND", "TenLoaiND", 0);
            // load gridview
            this._Load_Lai_Gridview();                             
        }
        private void _Load_Lai_Gridview(int row = 0)
        {
            gridControlNguoiDung.DataSource = _nguoiDungBUS.Lay_DT_NguoiDung();
            if (gridViewNguoiDung.RowCount > 0)
            {
                gridViewNguoiDung_FocusedRowChanged(this,
                    new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, row));
                gridViewNguoiDung.FocusedRowHandle = row;
            }
            else
            {
                _Reset_Control();
            }
        }
        private void _Reset_Control()
        {
            comboBoxEditNguoiDung.SelectedIndex = 0;
            textEditMatKhau.Text = "";
            textEdittenTruyCap.Text = "";
            radioGroupTrangThai.SelectedIndex = 0;
        }

        public void _Disable_Controls(bool editing)
        {
            simpleButtonDong.Enabled = !editing;
            gridControlNguoiDung.Enabled = !editing;
            comboBoxEditNguoiDung.Enabled = editing;

            _is_add_button = !editing;
            _is_delete_button = !editing;

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
            if (!editing)
            {
                if (gridViewNguoiDung.RowCount > 0)
                    gridViewNguoiDung_FocusedRowChanged(this,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
                else
                {
                    _Reset_Control();
                }
            }
        }

        private void simpleButtonThemMoi_Click(object sender, EventArgs e)
        {
            if (_is_add_button)
            {
                _Disable_Controls(true);
                _Reset_Control();
            }
            else
            {
                // Bỏ ẩn control
                _Disable_Controls(false);
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

            // Lay tt nguoi dung
            NguoiDungDTO user = new NguoiDungDTO();
            user.MaND = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNguoiDung);
            user.LoaiNguoiDung.MaLoai =  Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditQuyenSuDung);
            user.TenDNhap = textEdittenTruyCap.Text.Replace("'","''");
            user.MatKhau = (textEditMatKhau.Text == "") ? "" : textEditMatKhau.Text.Replace("'", "''");
            user.TrangThai = radioGroupTrangThai.SelectedIndex;
            // Check nguoi dung ton tai hay chua
            if (!checkExistsUser)
            {
                // thêm
                if (_nguoiDungBUS.ThemNguoiDung(user))
                {
                    Utilities.MessageboxUtilities.MessageSuccess("Thêm thành công user: " +
                            Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNguoiDung) + " !");
                }
                _Load_Lai_Gridview(0);
            }
            else
            {
                _current_row_edit = gridViewNguoiDung.FocusedRowHandle;
                // Sửa
                if (_nguoiDungBUS.SuaNguoiDung(user))
                {
                    Utilities.MessageboxUtilities.MessageSuccess("Sửa thành công user: " +  Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNguoiDung)  + " !");
                }
                _Load_Lai_Gridview(_current_row_edit);
            }
            
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            if (_is_delete_button)
            {
                if (!_nguoiDungBUS.KiemTraTonTai_NguoiDung(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNguoiDung)))
                {
                    _Reset_Control();
                    return;
                }
                else
                {
                    string tenNguoiDung = Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNguoiDung);
                    if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có muốn xóa người dùng "
                        + tenNguoiDung + " hay không?") == DialogResult.Yes)
                    {
                        if (_nguoiDungBUS.XoaNguoiDung(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNguoiDung)))
                        {
                            Utilities.MessageboxUtilities.MessageSuccess("Xóa người dùng "
                                        + tenNguoiDung + " thành công!");
                            gridControlNguoiDung.DataSource = _nguoiDungBUS.Lay_DT_NguoiDung();
                            return;
                        }
                    }
                }
            }
            else
            {
                _Reset_Control();
                return;
            }
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridViewNguoiDung_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Chac chan chon duoc 1 dong nao do
            if (gridViewNguoiDung.FocusedRowHandle < 0 || gridViewNguoiDung.FocusedRowHandle >= gridViewNguoiDung.RowCount)
                return;
            textEdittenTruyCap.Text = gridViewNguoiDung.GetRowCellValue(e.FocusedRowHandle, "TenDNhap").ToString();
            Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEditNguoiDung,
                    gridViewNguoiDung.GetRowCellValue(e.FocusedRowHandle, "MaND").ToString());
            Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEditQuyenSuDung,
                    gridViewNguoiDung.GetRowCellValue(e.FocusedRowHandle, "MaLoaiND").ToString());
            radioGroupTrangThai.SelectedIndex = (bool)gridViewNguoiDung.GetRowCellValue(e.FocusedRowHandle, "TrangThai") ? 1 : 0;
            textEditMatKhau.Text = "";
        }
    }
}