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
        private bool _is_add_button;
        private bool _is_delete_button;

        public frmGiaoVien()
        {
            InitializeComponent();
            _giaoVienBUS = new GiaoVienBUS();
            _is_add_button = true;
            _is_delete_button = true;
            
        }

        public void _Diable_Control(bool editing)
        {
            simpleButtonDong.Enabled = !editing;
            gridcontrolGiaoVien.Enabled = !editing;

            _is_add_button = !editing;
            _is_delete_button = !editing;

            simpleButtonThem.Text = editing ? "Không nhập (Alt+&N)" : "Thêm mới (Alt+&N)";
            simpleButtonXoa.Text = editing ? "Nhập lại (Alt+&D)" : "Xóa (Alt+&D)";
            if (!editing)
            {
                if (gridViewGiaoVien.RowCount > 0)
                    gridViewGiaoVien_FocusedRowChanged(this,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
                else
                {
                    _Reset_Control();
                }
            }
        }
        private void _Reset_Control()
        {
            textEditMaGiaoVien.Text = "";
            textEditTenGiaoVien.Text = "";
            simpleButtonLuu.Enabled = false;
        }
        private void simpleButtonThemGiaoVien_Click(object sender, EventArgs e)
        {
            if (_is_add_button)
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
            this._Diable_Control(editing: false);
            simpleButtonLuu.Enabled = false;
        }

      
        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonXoaGiaovien_Click(object sender, EventArgs e)
        {
            if (_is_delete_button)
            {
                if (_giaoVienBUS.KiemTonTai_GiaoVien(textEditMaGiaoVien.Text))
                {
                    if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có muốn xóa hồ sơ giáo viên: "
                                                        + textEditTenGiaoVien.Text + " hay không?")
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
            else // reset button
            {
                _Reset_Control();
                return;
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
            simpleButtonLuu.Enabled = false;
            _Load_GridView();
        }

        private void gridViewGiaoVien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Chac chan chon duoc 1 dong nao do
            if (gridViewGiaoVien.FocusedRowHandle < 0 || gridViewGiaoVien.FocusedRowHandle >= gridViewGiaoVien.RowCount) 
                return;
            textEditMaGiaoVien.Text = gridViewGiaoVien.GetRowCellValue(gridViewGiaoVien.FocusedRowHandle, "MaGiaoVien").ToString();
            textEditTenGiaoVien.Text = gridViewGiaoVien.GetRowCellValue(gridViewGiaoVien.FocusedRowHandle, "TenGiaoVien").ToString();
        }

        private void textEditTenGiaoVien_EditValueChanged(object sender, EventArgs e)
        {
            simpleButtonLuu.Enabled = true;
        }
    }
}