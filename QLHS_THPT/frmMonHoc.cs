using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using QLHS.BUS;
using QLHS.DTO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace QLHS
{
    public partial class frmMonHoc : DevExpress.XtraEditors.XtraForm
    {
        private MonHocBUS _monHocBUS;
        private int _current_row_edit;

        public frmMonHoc()
        {
            InitializeComponent();
            _monHocBUS = new MonHocBUS();
        }

        public void _Diable_Control(bool editing)
        {
            simpleButtonDong.Enabled = !editing;
            textEditMaMonHoc.Enabled = editing;
            gridcontrolMonHoc.Enabled = !editing;
           
            if (!editing)
            {
                if (gridViewMonHoc.RowCount > 0)
                {
                    gridViewMonHoc.FocusedRowHandle = _current_row_edit;
                    gridViewMonHoc_FocusedRowChanged(this,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, _current_row_edit));
                }
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
       
        private void _Load_GridView()
        {
            gridcontrolMonHoc.DataSource = _monHocBUS.LayDT_DanhSach_MonHoc(false);
            RepositoryItemCheckEdit fCheckEdit = new RepositoryItemCheckEdit();
            fCheckEdit.ValueChecked = 1;
            fCheckEdit.ValueUnchecked = 0;
            gridColumnTrangThai.ColumnEdit = fCheckEdit;
            gridColumnTrangThai.FieldName = "TrangThai";

            this._Diable_Control(editing: false);
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonLuu_Click(object sender, EventArgs e)
        {
            _current_row_edit = gridViewMonHoc.FocusedRowHandle;

            // Kiem tra mon hoc da ton tai
            for (int i = 0; i < gridViewMonHoc.RowCount; i++)
            {
                if (i != gridViewMonHoc.FocusedRowHandle)
                {
                    if (gridViewMonHoc.GetRowCellValue(i,"TenMonHoc").ToString() == textEditTenMonHoc.Text)
                    {
                        Utilities.MessageboxUtilities.MessageError("Môn học "+textEditTenMonHoc.Text+
                                                                 " đã tồn tại");
                        return;
                    }
                }
            }

          

            // Sửa
            if (spinEditHeSo.Value < 1 || spinEditHeSo.Value > 2)
            {
                Utilities.MessageboxUtilities.MessageError("Hệ số của môn học "
                                                    + textEditTenMonHoc + " chỉ là 1 hoặc 2!");
                return;
            }
            if (spinEditSoTiet.Value < 0 || spinEditSoTiet.Value >= 120)
            {
                Utilities.MessageboxUtilities.MessageError("Số tiết của môn học không hợp lệ " +
                                               "(không thể nhỏ hơn 15 và quá 120)!");
                return;
            }

            MonHocDTO _monHocDTO = new MonHocDTO()
            {
                MaMonHoc = textEditMaMonHoc.Text,
                TenMonHoc = textEditTenMonHoc.Text.Replace("'", "''"),
                SoTiet = Convert.ToInt32(spinEditSoTiet.Value),
                HeSo = Convert.ToInt32(spinEditHeSo.Value),
                TrangThai = Convert.ToInt32(radioGroupTrangThai.SelectedIndex)
            };

            _monHocBUS.CapNhat_MonHoc(_monHocDTO);
            Utilities.MessageboxUtilities.MessageSuccess("Đã cập nhật môn học: " + _monHocDTO.TenMonHoc + " thành công!");
            _Load_GridView();
        }
    }
}

