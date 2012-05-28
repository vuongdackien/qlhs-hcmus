using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLHS.BUS;
using QLHS.DTO;
using Utilities;
using DevExpress.XtraEditors;

namespace QLHS
{
    public partial class frmGiaoVien : DevExpress.XtraEditors.XtraForm
    {
        private GiaoVienBUS _giaoVienBUS;

        public frmGiaoVien()
        {
            InitializeComponent();
            _giaoVienBUS = new GiaoVienBUS();
        }

        public void _Diable_Control(bool editing)
        {
            simpleButtonDong.Enabled = !editing;
            gridcontrolGiaoVien.Enabled = !editing;

            if (editing)
            {
                simpleButtonThem.Text = "Không nhập (Alt+&N)";
                simpleButtonXoa.Text = "Nhập lại (Alt+&D)";
            }
            else
            {
                simpleButtonThem.Text = "Thêm mới (Alt+&N)";
                simpleButtonXoa.Text = "Xóa (Alt+&D)";
            }
        }
        private void _Reset_Control()
        {
            textEditMaGiaoVien.Text = "";
            textEditTenGiaoVien.Text = "";
        }
        private void simpleButtonThemGiaoVien_Click(object sender, EventArgs e)
        {
            if (simpleButtonThem.Text == "Thêm mới (Alt+&N)")
            {
                _Diable_Control(editing:true);
                _Reset_Control();
            }
            else
            {
                // Bỏ ẩn control
                _Diable_Control(editing:false);
            } 
        }

        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            this._Load_GridView();
        }

        private void _Load_GridView()
        {
            gridcontrolGiaoVien.DataSource = _giaoVienBUS.LayDT_DanhSachGiaoVien();
            if (gridViewGiaoVien.RowCount > 0)
                gridViewGiaoVien_FocusedRowChanged(this, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
            else
            {
                _Reset_Control();
            }
        }

      
        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonXoaGiaovien_Click(object sender, EventArgs e)
        {
            if (simpleButtonXoa.Text == "Nhập lại (Alt+&D)")
            {
                _Reset_Control();
                return;
            }
            else
            {
                if (_giaoVienBUS.KiemTonTai_GiaoVien(textEditMaGiaoVien.Text))
                {
                    if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có muốn xóa hồ sơ giáo viên: "
                                                        +textEditTenGiaoVien.Text+" hay không?")
                            == DialogResult.No)
                    {
                        return;
                    }

                    _giaoVienBUS.Xoa_GiaoVien(textEditMaGiaoVien.Text);
                    Utilities.MessageboxUtilities.MessageSuccess("Đã xóa hồ sơ giáo viên: "
                                                + textEditTenGiaoVien.Text + " thành công!");
                    _Load_GridView();
                }
            }
        }

        private void simpleButtonLuuGiaoVien_Click(object sender, EventArgs e)
        {
            if (textEditTenGiaoVien.Text.Length <= 3 || !textEditTenGiaoVien.Text.Contains(" "))
            {
                Utilities.MessageboxUtilities.MessageError("Tên giáo viên không hợp lệ hoặc nhỏ hơn 3 ký tự!");
                return; 
            }

            GiaoVienDTO giaoVienDTO = new GiaoVienDTO()
                                          {
                                            MaGiaoVien = textEditMaGiaoVien.Text,
                                            TenGiaoVien = textEditTenGiaoVien.Text.Replace("'", "''")
                                          };

            // Sửa
            if (_giaoVienBUS.KiemTonTai_GiaoVien(giaoVienDTO.MaGiaoVien))
            {
                _giaoVienBUS.CapNhat_GiaoVien(giaoVienDTO);
                Utilities.MessageboxUtilities.MessageSuccess("Đã cập nhật hồ sơ giáo viên: " + giaoVienDTO.TenGiaoVien + " thành công!");
            }
            else // thêm
            {
                if (_giaoVienBUS.Them_GiaoVien(giaoVienDTO))
                    Utilities.MessageboxUtilities.MessageSuccess("Đã tạo hồ sơ giáo viên: " + giaoVienDTO.TenGiaoVien + " thành công!");
            }
            _Load_GridView();
            _Diable_Control(editing:false);
        }

        private void gridViewGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Chac chan chon duoc 1 dong nao do
            if (gridViewGiaoVien.FocusedRowHandle < 0 || gridViewGiaoVien.FocusedRowHandle >= gridViewGiaoVien.RowCount) 
                return;
            textEditMaGiaoVien.Text = gridViewGiaoVien.GetRowCellValue(gridViewGiaoVien.FocusedRowHandle, "MaGiaoVien").ToString();
            textEditTenGiaoVien.Text = gridViewGiaoVien.GetRowCellValue(gridViewGiaoVien.FocusedRowHandle, "TenGiaoVien").ToString();
        }
    }
}