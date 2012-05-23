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

        public void KhoiTaoTrangthai()
        {

            //simpleButtonThemMonHoc.Enabled = true;
            simpleButtonXoaMonHoc.Enabled = true;
            simpleButtonSuaMonHoc.Enabled = true;
            simpleButtonhuy.Enabled = false;
            simpleButtonLuu.Enabled = false;
            textEditMaMonHoc.Enabled = false;
            textEditTenMonHoc.Enabled = false;
            textEditSoTiet.Enabled = false;
            comboBoxEditHeSo.Enabled = false;
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
        */
        private void simpleButtonXoaMonHoc_Click(object sender, EventArgs e)
        {
            string MaMH = textEditMaMonHoc.Text.Trim();
            MaMH = doichuoi(MaMH);
            _MonHocBus.XoaMonHoc(MaMH);
            Utilities.MessageboxUtilities.MessageSuccess("Bạn đã xóa thành công môn học: "+MaMH);
        }

        private void simpleButtonSuaMonHoc_Click(object sender, EventArgs e)
        {
            //simpleButtonThemMonHoc.Enabled = false;
            simpleButtonXoaMonHoc.Enabled = true;
            simpleButtonSuaMonHoc.Enabled = false;
            simpleButtonhuy.Enabled = true;
            simpleButtonLuu.Enabled = true;
            textEditMaMonHoc.Enabled = false;
            textEditTenMonHoc.Enabled = true;
            textEditSoTiet.Enabled = true;
            comboBoxEditHeSo.Enabled = true;
            simpleButtonhuy.Enabled = false;
            flag = 2;
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
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
            if (flag == 1 || flag == 3)
            {
                if (KiemtraNull(textEditMaMonHoc.Text.Trim()))
                {
                    string MaMH = textEditMaMonHoc.Text.Trim();
                    MaMH = doichuoi(MaMH);
                    _MonHocDTO = new MonHocDTO();
                    if (textEditTenMonHoc.Text.Trim() != "")
                    {
                         string TenMH = textEditTenMonHoc.Text.Trim();
                         TenMH = doichuoi(TenMH);
                        int SoTiet=int.Parse(textEditSoTiet.Text.Trim());
                        int HeSo=int.Parse(comboBoxEditHeSo.SelectedText);
                       _MonHocDTO.MaMonHoc = MaMH;
                       _MonHocDTO.TenMonHoc = TenMH;
                       _MonHocDTO.SoTiet = SoTiet;
                       _MonHocDTO.HeSo = HeSo;
                        if (flag == 1)
                        {

                            
                            bool kq = _MonHocBus.KTTonTaiMonHoc(_MonHocDTO);
                            if (kq )
                            {
                                Utilities.MessageboxUtilities.MessageError("Hành động thêm thất bại. Có thể giáo viên này đã tồn tại trong cơ sở dữ liệu");
                            }
                            else
                            {
                                _MonHocBus.ThemMonHoc(_MonHocDTO);
                                Utilities.MessageboxUtilities.MessageSuccess("Bạn đã thêm thành công" + kq + " Giáo viên vào cơ sở dữ liệu");
                                
                            }

                        }

                        else if (flag == 3)
                        {

                            _MonHocBus.CapNhatMonHOc(_MonHocDTO);
                            Utilities.MessageboxUtilities.MessageSuccess("Cập nhật thành công môn học"+_MonHocDTO.TenMonHoc.ToString());
                        }

                    }
                    else
                    {
                        Utilities.MessageboxUtilities.MessageError("Tên môn học không thể để trống");
                        this.Cursor = textEditTenMonHoc.Cursor;
                    }

                }
                else
                {
                    Utilities.MessageboxUtilities.MessageError("Mã Môn học không thể để trống");

                }
                frmMonHoc_Load(sender, e);
            }
        }

        private void simpleButtonloaddulieu_Click(object sender, EventArgs e)
        {
            DT = _MonHocBus.LayDT_DanhSach_MonHoc(false);
            load_dulieu(DT);
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gridViewMonHoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            for (int i = 0; i < gridViewMonHoc.RowCount; i++)
            {
                textEditMaMonHoc.Text = gridViewMonHoc.GetFocusedRowCellValue("MaMonHoc").ToString();
                textEditTenMonHoc.Text = gridViewMonHoc.GetFocusedRowCellValue("TenMonHoc").ToString();
                textEditSoTiet.Text = gridViewMonHoc.GetFocusedRowCellValue("SoTiet").ToString();
                comboBoxEditHeSo.SelectedText="";
                comboBoxEditTrangThai.SelectedText="";
                comboBoxEditHeSo.SelectedText= gridViewMonHoc.GetFocusedRowCellValue("HeSo").ToString();
                comboBoxEditTrangThai.SelectedText = gridViewMonHoc.GetFocusedRowCellValue("TrangThai").ToString();
                break;
                
            }
        }

        

        

        
    }
}