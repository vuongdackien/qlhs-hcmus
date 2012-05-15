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
                                                "MaNamHoc", "TenNamHoc",0);
            ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi, _KhoiBUS.LayDTKhoi(),
                                                "MaKhoi", "TenKhoi",0);
        }

        /// <summary>
        /// Load lại combobox lớp học theo năm và khối
        /// </summary>
        private void LoadComboboxLopHoc(object sender, EventArgs e)
        {
            ComboboxEditUtilities.SetDataSource(comboBoxEditLop, _LopBUS.LayDTLop_MaNam_MaKhoi(
                        ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc),
                         ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)
                    ), "MaLop", "TenLop", 0);
            comboBoxEditLop_SelectedIndexChanged(sender,e);
        }
        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboboxEditUtilities.CheckSelectedNull(comboBoxEditKhoi) ||
                ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc(sender, e);
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc(sender, e);
        }

        private void comboBoxEditLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLop))
            {
                gridControlDSHocSinh.DataSource = null;
                return;
            }
            gridControlDSHocSinh.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(
                 ComboboxEditUtilities.GetValueItem(comboBoxEditLop)
            );
        }

        void EditingControl(bool is_editing = true)
        {
            spinEditSTTSoDiem.Enabled = is_editing;
            dateEditNgaySinh.Enabled = is_editing;
            textEditDiaChi.Enabled = is_editing;
            textEditEmail.Enabled = is_editing;
           // textEditmaHocSinh.Enabled = is
        }

        /// <summary>
        /// Hiển thị chi tiết hồ sơ học sinh
        /// </summary>
        /// <param name="MaHS">String: MaHS</param>
        private void HienThiHoSoHocSinh(string MaHocSinh)
        {
            HocSinhDTO hocSinhDTO = _HocSinhBUS.LayHoSoHocSinh(MaHocSinh);
            spinEditSTTSoDiem.Value = hocSinhDTO.STT;
            dateEditNgaySinh.EditValue = hocSinhDTO.NgaySinh;
            textEditmaHocSinh.Text = hocSinhDTO.MaHocSinh;
            textEditTenHocSinh.Text = hocSinhDTO.TenHocSinh;
            radioGroupGioiTinh.SelectedIndex = hocSinhDTO.GioiTinh;
            textEditNoiSinh.Text = hocSinhDTO.NoiSinh;
            textEditDiaChi.Text = hocSinhDTO.DiaChi;
            textEditEmail.Text = hocSinhDTO.Email;
            
        }

        private void gridViewDSHocSinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string MaHocSinh = this.gridViewDSHocSinh.GetRowCellValue(e.FocusedRowHandle, "MaHocSinh").ToString();
            if (!MaHocSinh.Equals(""))
            {
                HienThiHoSoHocSinh(MaHocSinh);
            }
        }
  
    }
}