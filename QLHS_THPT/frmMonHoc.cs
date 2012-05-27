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
        MonHocBUS _MonHocBus = new MonHocBUS();
        MonHocDTO _MonHocDTO;
        DataTable DT;
        public frmMonHoc()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        public void KhoiTaoTrangthai()
        {

            simpleButtonSuaMonHoc.Enabled = false;


        }

        public static bool KiemtraNull(string Chuoi)
        {
            if (Chuoi == "")
            {
                return false;
            }
            return true;
        }
        public string doichuoi(string chuoi)
        {
            return _MonHocBus.Doichuoi(chuoi, "'", "''", true);
        }
        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void simpleButtonSuaMonHoc_Click(object sender, EventArgs e)
        {
            if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có chắc chắn muốn sửa Các môn học hay không?") == System.Windows.Forms.DialogResult.Yes)
            {
                int kq = 0;
                gridViewMonHoc.FocusedColumn = gridViewMonHoc.Columns[0];
                _MonHocDTO = new MonHocDTO();

                string MaMH;
                string TenMH;
                int SoTiet;
                int HeSo;
                int TrangThai;
                for (int i = 0; i < gridViewMonHoc.RowCount; i++)
                {
                    MaMH = gridViewMonHoc.GetRowCellValue(i, "MaMonHoc").ToString();
                    // MaMH = _MonHocBus.Doichuoi(MaMH, "'", "''", true);
                    TenMH = gridViewMonHoc.GetRowCellValue(i, "TenMonHoc").ToString();
                    TenMH = _MonHocBus.Doichuoi(MaMH, "'", "''", true);
                    SoTiet = int.Parse(gridViewMonHoc.GetRowCellValue(i, "SoTiet").ToString());
                    HeSo = int.Parse(gridViewMonHoc.GetRowCellValue(i, "HeSo").ToString());
                    TrangThai = int.Parse(gridViewMonHoc.GetRowCellValue(i, "TrangThai").ToString());
                    _MonHocDTO.MaMonHoc = MaMH;
                    _MonHocDTO.TenMonHoc = TenMH;
                    _MonHocDTO.SoTiet = SoTiet;
                    _MonHocDTO.HeSo = HeSo;
                    _MonHocDTO.TrangThai = TrangThai;
                    kq = _MonHocBus.CapNhatMonHOc(_MonHocDTO);

                }
                Utilities.MessageboxUtilities.MessageSuccess("Đã hoàn tất quá trình cập nhật môn học");
                frmMonHoc_Load(sender, e);
            }
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {

            KhoiTaoTrangthai();
            DT = new DataTable();
            DT = _MonHocBus.LayDT_DanhSach_MonHoc(false);

            gridControlMonHoc.DataSource = DT;
        }
        void load_dulieu(DataTable DT)
        {
            gridControlMonHoc.DataSource = DT;


        }



        private void simpleButtonhuy_Click(object sender, EventArgs e)
        {
            KhoiTaoTrangthai();
        }


        private void simpleButtonloaddulieu_Click(object sender, EventArgs e)
        {
            DT = _MonHocBus.LayDT_DanhSach_MonHoc(false);
            load_dulieu(DT);
            KhoiTaoTrangthai();
        }

        

        private void gridViewMonHoc_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                simpleButtonSuaMonHoc.Enabled = true;

            }
        }

      

       



       /* protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.Shift):
                    simpleButtonSuaMonHoc_Click(null, null);
                    break;
                case (Keys.Control | Keys.Alt):
                    simpleButtonloaddulieu_Click(null, null);
                    break;
                case (Keys.Control | Keys.Escape):
                    simpleButtonThoat_Click(null, null);
                    break;

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }*/

      






    }
}

