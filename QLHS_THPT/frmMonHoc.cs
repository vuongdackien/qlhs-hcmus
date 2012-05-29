using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using QLHS.BUS;
using QLHS.DTO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLHS
{
    public partial class frmMonHoc : DevExpress.XtraEditors.XtraForm
    {
        private MonHocBUS _monHocBUS;
        private bool _is_add_button;
        private bool _is_delete_button;

        public frmMonHoc()
        {
            InitializeComponent();
            _monHocBUS = new MonHocBUS();
            _is_add_button = true;
            _is_delete_button = true;
        }

        public void _Diable_Control(bool editing)
        {
            simpleButtonDong.Enabled = !editing;
            textEditMaMonHoc.Enabled = editing;
            gridcontrolMonHoc.Enabled = !editing;

            _is_add_button = !editing;
            _is_delete_button = !editing;

            simpleButtonThem.Text = editing ? "Không nhập (Alt+&N)" : "Thêm mới (Alt+&N)";
            simpleButtonXoa.Text = editing ? "Nhập lại (Alt+&D)" : "Xóa (Alt+&D)";
            if (!editing)
            {
                if (gridViewMonHoc.RowCount > 0)
                    gridViewMonHoc_FocusedRowChanged(this,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
                else
                {
                    _Reset_Control();
                }
            }
        }
        private void _Reset_Control()
        {
            textEditMaMonHoc.Text = "";
            textEditTenMonHoc.Text = "";
            spinEditSoTiet.Value=30;
            spinEditHeSo.Value=1;            
        }

        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            this._Load_GridView();
           
        }

        private void gridViewMonHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Chac chan chon duoc 1 dong nao do
            if (gridViewMonHoc.FocusedRowHandle < 0 || gridViewMonHoc.FocusedRowHandle >= gridViewMonHoc.RowCount)
                return;
            textEditMaMonHoc.Text = gridViewMonHoc.GetRowCellValue(gridViewMonHoc.FocusedRowHandle, "MaMonHoc").ToString();
            textEditTenMonHoc.Text = gridViewMonHoc.GetRowCellValue(gridViewMonHoc.FocusedRowHandle, "TenMonHoc").ToString();
            spinEditSoTiet.Text = gridViewMonHoc.GetRowCellValue(gridViewMonHoc.FocusedRowHandle, "SoTiet").ToString();
            spinEditHeSo.Text = gridViewMonHoc.GetRowCellValue(gridViewMonHoc.FocusedRowHandle, "HeSo").ToString();
            radioGroupTrangThai.SelectedIndex = Convert.ToInt32(gridViewMonHoc.GetRowCellValue(gridViewMonHoc.FocusedRowHandle, "TrangThai").ToString());            
        }

        private void simpleButtonThem_Click(object sender, EventArgs e)
        {           
            if (_is_add_button)
            {
                _Diable_Control(editing: true);
                _Reset_Control();
            }
            else
            {
                // Bỏ ẩn control
                _Diable_Control(editing: false);
            } 
        }

        private void _Load_GridView()
        {
            gridcontrolMonHoc.DataSource = _monHocBUS.LayDT_DanhSach_MonHoc(false);
            this._Diable_Control(editing: false);
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            if (_is_delete_button)
            {
                if (_monHocBUS.KiemTraTonTai_MonHoc(textEditMaMonHoc.Text))
                {
                    if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có muốn xóa môn học: "
                                                        + textEditTenMonHoc.Text + " hay không?")
                            == DialogResult.No)
                    {
                        return;
                    }

                    if (_monHocBUS.Xoa_MonHoc(textEditMaMonHoc.Text))
                    {
                        Utilities.MessageboxUtilities.MessageSuccess("Đã xóa môn học: "
                                                    + textEditTenMonHoc.Text + " thành công!");
                        _Load_GridView();
                    }
                    else
                    {
                        Utilities.MessageboxUtilities.MessageSuccess("Không thể xóa môn học: "
                                                    + textEditTenMonHoc.Text + " \n Vì môn học này đã tồn tại trong bảng điểm!");
                    }                    
                }

            }
            else // reset button
            {
                _Reset_Control();
                return;
            }
        }

        private void simpleButtonLuu_Click(object sender, EventArgs e)
        {
            //if (textEditTenMonHoc.Text.Length <= 3 || !textEditTenMonHoc.Text.Contains(" "))
            //{
            //    Utilities.MessageboxUtilities.MessageError("Tên môn học không hợp lệ hoặc nhỏ hơn 3 ký tự!");
            //    return;
            //}

            MonHocDTO _monHocDTO = new MonHocDTO()
            {
                MaMonHoc = textEditMaMonHoc.Text,
                TenMonHoc = textEditTenMonHoc.Text.Replace("'", "''"),
                SoTiet = Convert.ToInt32(spinEditSoTiet.Value),
                HeSo = Convert.ToInt32(spinEditHeSo.Value),
                TrangThai = Convert.ToInt32(radioGroupTrangThai.SelectedIndex)
            };

            // Sửa
            if (_monHocBUS.KiemTraTonTai_MonHoc(_monHocDTO.MaMonHoc))
            {
                _monHocBUS.CapNhat_MonHoc(_monHocDTO);
                Utilities.MessageboxUtilities.MessageSuccess("Đã cập nhật môn học: " + _monHocDTO.TenMonHoc + " thành công!");
            }
            else // thêm
            {
                if (_monHocBUS.Them_MonHoc(_monHocDTO))
                    Utilities.MessageboxUtilities.MessageSuccess("Đã tạo môn học: " + _monHocDTO.TenMonHoc + " thành công!");
            }
            _Load_GridView();
        }
    }
}

