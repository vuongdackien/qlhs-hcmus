using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using QLHS.BUS;
using QLHS.DTO;


namespace QLHS
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
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHoc(),
                                                "MaNamHoc", "TenNamHoc",0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi, _KhoiBUS.LayDTKhoi(),
                                                "MaKhoi", "TenKhoi",0);
        }

        /// <summary>
        /// Load lại combobox lớp học theo năm và khối
        /// </summary>
        private void LoadComboboxLopHoc(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditLop, _LopBUS.LayDTLop_MaNam_MaKhoi(
                       Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc),
                         Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)
                    ), "MaLop", "TenLop", 0);
            comboBoxEditLop_SelectedIndexChanged(sender,e);
            this.HienThiHoSoHocSinh(gridViewDSHocSinh.GetRowCellValue(0, "MaHocSinh"));
            
        }
        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditKhoi) ||
                Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc(sender, e);
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc(sender, e);
        }

        private void comboBoxEditLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLop))
            {
                gridControlDSHocSinh.DataSource = null;
                return;
            }
            gridControlDSHocSinh.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(
                 Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop)
            );
        }
      

        /// <summary>
        /// Hiển thị chi tiết hồ sơ học sinh
        /// </summary>
        /// <param name="MaHS">String: MaHS</param>
        private void HienThiHoSoHocSinh(object MaHocSinh = null)
        {
            HocSinhDTO hocSinhDTO;
            if (MaHocSinh == null)
            {
                hocSinhDTO = new HocSinhDTO();
                panelControlChiTietHoSo.Enabled = false;
            }
            else
            {
                hocSinhDTO = _HocSinhBUS.LayHoSoHocSinh(MaHocSinh.ToString());
                panelControlChiTietHoSo.Enabled = true;
            }
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
            object MaHocSinh = this.gridViewDSHocSinh.GetRowCellValue(e.FocusedRowHandle, "MaHocSinh").ToString();
            HienThiHoSoHocSinh(MaHocSinh);
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonGhiDuLieu_Click(object sender, EventArgs e)
        {
            HocSinhDTO hocSinhDTO  = new HocSinhDTO();
            hocSinhDTO.STT = Convert.ToInt32(spinEditSTTSoDiem.Value);
            hocSinhDTO.NgaySinh = Convert.ToDateTime(dateEditNgaySinh.EditValue);
            hocSinhDTO.MaHocSinh = textEditmaHocSinh.Text;
            hocSinhDTO.TenHocSinh = textEditTenHocSinh.Text;
            hocSinhDTO.GioiTinh = radioGroupGioiTinh.SelectedIndex;
            hocSinhDTO.NoiSinh = textEditNoiSinh.Text;
            hocSinhDTO.DiaChi = textEditDiaChi.Text;
            hocSinhDTO.Email = textEditEmail.Text;
            
        }
  
    }
}