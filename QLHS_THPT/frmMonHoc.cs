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
        MonHocBUS _MonHocBus=new MonHocBUS();
        MonHocDTO _MonHocDTO;
        private int flag = 0;
        DataTable DT;
        public frmMonHoc()
        {
            InitializeComponent();
        }
     /*   public void load_Compobox()
       {
            
        }*/
        public void KhoiTaoTrangthai()
        {

            //simpleButtonThemMonHoc.Enabled = true;
            //simpleButtonXoaMonHoc.Enabled = true;
            simpleButtonSuaMonHoc.Enabled = true;
            simpleButtonhuy.Enabled = false;
            simpleButtonLuu.Enabled = false;
            //textEditMaMonHoc.Enabled = false;
            //textEditTenMonHoc.Enabled = false;
            //textEditSoTiet.Enabled = false;
            //comboBoxEditHeSo.Enabled = false;
            //comboBoxEditTrangThai.Enabled = false;
            simpleButtonhuy.Enabled = false;
            flag = 0;
           
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
       

       /* private void simpleButtonThemMonHoc_Click(object sender, EventArgs e)
        {
           // simpleButtonThemMonHoc.Enabled = false;
            simpleButtonXoaMonHoc.Enabled = true;
            simpleButtonSuaMonHoc.Enabled = false;
            simpleButtonhuy.Enabled = true;
            simpleButtonLuu.Enabled = true;
            textEditMaMonHoc.Enabled = true;
            textEditTenMonHoc.Enabled = true;
            textEditSoTiet.Enabled = true;
            comboBoxEditHeSo.Enabled = true;
            simpleButtonhuy.Enabled = false;
            flag = 1;
        }
        private void simpleButtonXoaMonHoc_Click(object sender, EventArgs e)
        {
            string MaMH = textEditMaMonHoc.Text.Trim();
            MaMH = doichuoi(MaMH);
            _MonHocBus.XoaMonHoc(MaMH);
            Utilities.MessageboxUtilities.MessageSuccess("Bạn đã xóa thành công môn học: "+MaMH);
        }*/

        private void simpleButtonSuaMonHoc_Click(object sender, EventArgs e)
        {
            //simpleButtonThemMonHoc.Enabled = false;
          //  simpleButtonXoaMonHoc.Enabled = true;
            simpleButtonSuaMonHoc.Enabled = false;
            simpleButtonhuy.Enabled = true;
            simpleButtonLuu.Enabled = true;
            //textEditMaMonHoc.Enabled = false;
            //textEditTenMonHoc.Enabled = true;
            //textEditSoTiet.Enabled = true;
            //comboBoxEditHeSo.Enabled = true;
            //comboBoxEditTrangThai.Enabled = true;
            
            flag = 2;
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

        private void simpleButtonLuu_Click(object sender, EventArgs e)
        {
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
                TenMH = gridViewMonHoc.GetRowCellValue(i, "MaMonHoc").ToString();
                SoTiet = int.Parse(gridViewMonHoc.GetRowCellValue(i, "MaMonHoc").ToString());
                HeSo = int.Parse(gridViewMonHoc.GetRowCellValue(i, "MaMonHoc").ToString());
                TrangThai = int.Parse(gridViewMonHoc.GetRowCellValue(i, "MaMonHoc").ToString());
                _MonHocDTO.MaMonHoc = MaMH;
                _MonHocDTO.TenMonHoc = TenMH;
                _MonHocDTO.SoTiet = SoTiet;
                _MonHocDTO.HeSo = HeSo;
                _MonHocDTO.TrangThai = TrangThai;
                _MonHocBus.CapNhatMonHOc(_MonHocDTO);
            }
            Utilities.MessageboxUtilities.MessageSuccess("Bạn đã cập nhật thành công");
                frmMonHoc_Load(sender, e);
            }

        private void simpleButtonloaddulieu_Click(object sender, EventArgs e)
        {
            DT = _MonHocBus.LayDT_DanhSach_MonHoc(false);
            load_dulieu(DT);
        }

      

        private void gridViewMonHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //for (int i = 0; i < gridViewMonHoc.RowCount; i++)
            //{
            //    textEditMaMonHoc.Text = gridViewMonHoc.GetFocusedRowCellValue("MaMonHoc").ToString();
            //    textEditTenMonHoc.Text = gridViewMonHoc.GetFocusedRowCellValue("TenMonHoc").ToString();
            //    textEditSoTiet.Text = gridViewMonHoc.GetFocusedRowCellValue("SoTiet").ToString();
            //    comboBoxEditHeSo.Text="";
            //    comboBoxEditTrangThai.Text="";
            //    comboBoxEditHeSo.SelectedText= gridViewMonHoc.GetFocusedRowCellValue("HeSo").ToString();
            //    comboBoxEditTrangThai.SelectedText = gridViewMonHoc.GetFocusedRowCellValue("TrangThai").ToString();
            //    break;
                
            //}
        }

       /* private void simpleButtonTimKiem_Click(object sender, EventArgs e)
        {
            if (textEditTK.Text.Trim()!="")
            {
                if (radioButtonMaGiaoVien.Checked)
	             {
		             DT=_MonHocBus.Table_MonHoc(3,textEditTK.Text.Trim());
                     load_dulieu(DT);
	            }
                if (radioButtonTenMonHoc.Checked)
	            {
		             DT=_MonHocBus.Table_MonHoc(2,textEditTK.Text.Trim());
                     load_dulieu(DT);
	            }
                else
	            {
                     DT=_MonHocBus.Table_MonHoc(1,textEditTK.Text.Trim());
                     load_dulieu(DT);
	            }
               
                
            }
        }*/

       /* private void textEditSoTiet_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            int n = 1;
            if (!int.TryParse(this.textEditSoTiet.Text, out n))
            {
                Utilities.MessageboxUtilities.MessageError("Số tiết phải là số nguyên");
                
            }
            else
            {
                e.Handled = true;
            }
            
        }*/

          

        
    }
}