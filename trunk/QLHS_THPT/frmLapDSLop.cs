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
            gridControlDSLop.DataSource = _dsLop_Khoi_NamHoc;
            
        }

        private void frmLapDSLop_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,
                                                         _namHocBUS.LayDTNamHoc(),
                                                        "MaNamHoc", "TenNamHoc", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi,
                                                        _khoiBUS.LayDTKhoi(),
                                                        "MaKhoi", "TenKhoi", 0);
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_DSLop();
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_DSLop();
        }

        private void simpleButtonThemMoi_Click(object sender, EventArgs e)
        {
            if (comboBoxEditNamHoc.SelectedItem == null || comboBoxEditKhoi.SelectedItem == null)
                return;
            
        }

    }
}