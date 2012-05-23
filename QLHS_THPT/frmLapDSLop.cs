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
    public partial class frmLapDSLop : DevExpress.XtraEditors.XtraForm
    {
        private GiaoVienBUS _giaoVienBUS;
        private NamHocBUS _namHocBUS;
        private QuyDinhBUS _quyDinhBUS;
        private KhoiBUS _khoiBUS;
        private LopBUS _lopBUS;
        DataTable _dsLop_Khoi_NamHoc;        
        public frmLapDSLop()
        {
            InitializeComponent();
            _giaoVienBUS = new GiaoVienBUS();
            _namHocBUS = new NamHocBUS();
            _quyDinhBUS = new QuyDinhBUS();
            _khoiBUS = new KhoiBUS();
            _lopBUS = new LopBUS();
            _dsLop_Khoi_NamHoc = null;
        }

        private void HienThi_DSLop()
        {
            _dsLop_Khoi_NamHoc = _lopBUS.LayDTLop_MaNam_MaKhoi(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc),
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi));
            gridControl.DataSource = _dsLop_Khoi_NamHoc;
            
        }

        private void frmLapDSLop_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,
                                                         _namHocBUS.LayDTNamHoc(),
                                                        "MaNamHoc", "TenNamHoc", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi,
                                                        _khoiBUS.LayDTKhoi(),
                                                        "MaKhoi", "TenKhoi", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditGVCN,
                                                                   _giaoVienBUS.LayDT_DanhSachGiaoVien(),
                                                                   "MaGiaoVien", "TenGiaoVien", 0);
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_DSLop();
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            textEditTenLop.Properties.Mask.EditMask = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)
                                                     +"[A-H][0-9][0-9]";
            this.HienThi_DSLop();
        }

        private void simpleButtonThemMoi_Click(object sender, EventArgs e)
        {
            if (comboBoxEditNamHoc.SelectedItem == null || comboBoxEditKhoi.SelectedItem == null)
                return;
        }

        private void gridViewLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
           textEditmaLop.Text = gridViewLop.GetRowCellValue(gridViewLop.FocusedRowHandle, "MaLop").ToString();
           textEditTenLop.Text = gridViewLop.GetRowCellValue(gridViewLop.FocusedRowHandle, "TenLop").ToString();
           Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEditGVCN,
               gridViewLop.GetRowCellValue(gridViewLop.FocusedRowHandle, "MaGiaoVien").ToString()
            );

        }

        private void textEditTenLop_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            string MaKhoi = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi);
            e.ErrorText = "Tên lớp không hợp lệ. Tên lớp có dạng " + MaKhoi + "[A-H][0-9][0-9]. VD: " + MaKhoi + "B02";
        }

    }
}