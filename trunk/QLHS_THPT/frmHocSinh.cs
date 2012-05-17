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
        private QuyDinhBUS _QuyDinhBUS;
        private PhanLopBUS _PhanLopBUS;
        private HocSinhDTO _hocSinhDTO;
        public frmHocSinh()
        {
            InitializeComponent();
            _NamHocBUS = new NamHocBUS();
            _KhoiBUS = new KhoiBUS();
            _LopBUS = new LopBUS();
            _HocSinhBUS = new HocSinhBUS();
            _QuyDinhBUS = new QuyDinhBUS();
            _PhanLopBUS = new PhanLopBUS();
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,_NamHocBUS.LayDTNamHoc(),
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
            this.LoadLai_GridControl_HocSinh();
        }
      

        /// <summary>
        /// Hiển thị chi tiết hồ sơ học sinh
        /// </summary>
        /// <param name="MaHS">String: MaHS</param>
        private void HienThiHoSoHocSinh(object MaHocSinh = null)
        {
            if (MaHocSinh == null)
            {
                _hocSinhDTO = new HocSinhDTO();
                panelControlChiTietHoSo.Enabled = false;
            }
            else
            {
                _hocSinhDTO = _HocSinhBUS.LayHoSoHocSinh(MaHocSinh.ToString());
                panelControlChiTietHoSo.Enabled = true;
            }
            spinEditSTTSoDiem.Value = _hocSinhDTO.STT;
            dateEditNgaySinh.EditValue = _hocSinhDTO.NgaySinh;
            textEditmaHocSinh.Text = _hocSinhDTO.MaHocSinh;
            textEditTenHocSinh.Text = _hocSinhDTO.TenHocSinh;
            radioGroupGioiTinh.SelectedIndex = _hocSinhDTO.GioiTinh;
            textEditNoiSinh.Text = _hocSinhDTO.NoiSinh;
            textEditDiaChi.Text = _hocSinhDTO.DiaChi;
            textEditEmail.Text = _hocSinhDTO.Email;
            
        }

        private void gridViewDSHocSinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;
           object MaHocSinh = this.gridViewDSHocSinh.GetRowCellValue(e.FocusedRowHandle, "MaHocSinh").ToString();
           HienThiHoSoHocSinh(MaHocSinh);
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Load lại GridControl học sinh
        /// </summary>
        private void LoadLai_GridControl_HocSinh()
        {
            gridControlDSHocSinh.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(
                               Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop)
                   );
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
            string MaLop = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop);
            if (hocSinhDTO.TenHocSinh.Length < 3 || !hocSinhDTO.TenHocSinh.Contains(" "))
            {
                Utilities.MessageboxUtilities.MessageError("Họ tên học sinh không hợp lệ (không chứa khoảng trắng) hoặc nhỏ hơn 3 ký tự!");
                return;
            }
            try
            {
                _HocSinhBUS.LuuHoSoHocSinh(hocSinhDTO, MaLop);
                Utilities.MessageboxUtilities.MessageSuccess("Lưu hồ sơ học sinh " + hocSinhDTO.TenHocSinh + " thành công!");
                this.LoadLai_GridControl_HocSinh();
                gridViewDSHocSinh.SelectRow(0);
            }
            catch (Exception ex)
            {
                Utilities.MessageboxUtilities.MessageError(ex);
                return;
            }
        }
        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            if(textEditmaHocSinh.Text == "")
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa chọn học sinh để thực hiện xóa!");
                return;
            }
            if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có chắc chắn muốn xóa toàn bộ hồ sơ học sinh \""+textEditTenHocSinh.Text+"\" hay không?") == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            try
            {
                _HocSinhBUS.Xoa_HoSo_HocSinh(textEditmaHocSinh.Text);
                Utilities.MessageboxUtilities.MessageSuccess("Xóa hồ sơ học sinh thành công!");
                LoadLai_GridControl_HocSinh();
            }
            catch(Exception ex)
            {
                Utilities.MessageboxUtilities.MessageError(ex);
            }
            
        }
        private void simpleButtonThemMoi_Click(object sender, EventArgs e)
        {
            string MaLop = (Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
            int SiSoCanTren =  _QuyDinhBUS.LaySiSoCanTren();
            if(_PhanLopBUS.Dem_SiSo_Lop(MaLop) >= SiSoCanTren)
            { 
                Utilities.MessageboxUtilities.MessageError("Lớp "+Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop)
                                                            +" đã đủ học sinh theo quy định "
                                                            +" ("+SiSoCanTren+" học sinh / 1 lớp)!");
                return;                                                                        
            }
            spinEditSTTSoDiem.Value = _PhanLopBUS.Lay_STT_TiepTheo(MaLop);
            textEditmaHocSinh.Text = "";
            textEditTenHocSinh.Text = "";
            textEditDiaChi.Text = "";
            textEditEmail.Text = "";
            textEditNoiSinh.Text = "";
            dateEditNgaySinh.Properties.MinValue = new DateTime(_QuyDinhBUS.LayNamCanDuoi(),1,1);
            dateEditNgaySinh.Properties.MaxValue = new DateTime(_QuyDinhBUS.LayNamCanTren(), 1, 1);
           
        }

        private void dateEditNgaySinh_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Ngày sinh không hợp lệ";
        }

        private void textEditEmail_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Email không hợp lệ! (Ấn ESC để trở lại)";
        }

        private void simpleButtonChuyenLop_Click(object sender, EventArgs e)
        {

        }

        private void simpleButtonInHoSo_Click(object sender, EventArgs e)
        {

        }

        

        private void simpleButtonSXLaiSTT_Click(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLop))
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa chọn lớp để thực hiện");
                return;
            }
            try
            {
                _PhanLopBUS.CapNhap_STT_HocSinh_Lop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
                Utilities.MessageboxUtilities.MessageSuccess("Cập nhật số thự tự cho lớp thành công!");
                // Load lại gridcontrol học sinh
                this.LoadLai_GridControl_HocSinh();
            }
            catch(Exception ex)
            {
                Utilities.MessageboxUtilities.MessageError(ex);
            }
        }

  
    }
}