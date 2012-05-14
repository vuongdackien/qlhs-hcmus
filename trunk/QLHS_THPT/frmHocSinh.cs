using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using QLHS.BUS;
using QLHS.DTO;


namespace QLHS_THPT
{
    public partial class frmHocSinh : DevExpress.XtraEditors.XtraForm
    {
        private NamHocBUS _NamHocBUS;
        private KhoiBUS _KhoiBUS;
        private LopBUS _LopBUS;
        private HocSinhBUS _HocSinhBUS;

        public frmHocSinh()
        {
            InitializeComponent();
            _NamHocBUS = new NamHocBUS();
            _KhoiBUS = new KhoiBUS();
            _LopBUS = new LopBUS();
            _HocSinhBUS = new HocSinhBUS();
          
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHoc(),
                                                "MaNamHoc", "TenNamHoc", "all", "Tất cả",0);
            ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi, _KhoiBUS.LayDTKhoi(),
                                                "MaKhoi", "TenKhoi",0);
        }

        /// <summary>
        /// Load lại combobox lớp học theo năm và khối
        /// </summary>
        private void LoadComboboxLopHoc()
        {
            ComboboxEditUtilities.SetDataSource(comboBoxEditLop, _LopBUS.LayDTLop_MaNam_MaKhoi(
                        ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc),
                         ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)
                    ), "MaLop", "TenLop", 0);
        }
        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboboxEditUtilities.CheckSelectedNull(comboBoxEditKhoi) ||
                ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc();
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc();
        }

        private void comboBoxEditLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLop))
                return;
            gridControl1.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(
                 ComboboxEditUtilities.GetValueItem(comboBoxEditLop)
            );
           // listBoxControlHocSinh.DisplayMember = "TenHocSinh";
          //  listBoxControlHocSinh.ValueMember = "MaHocSinh";
          //  listBoxControlHocSinh.DataSource = _
           
        }






  
    }
}