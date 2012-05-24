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
        private NamHocBUS _namHocBUS;
        private KhoiBUS _khoiBUS;
        private LopBUS _lopBUS;
        private HocSinhBUS _hocSinhBUS;
        private QuyDinhBUS _quyDinhBUS;
        private PhanLopBUS _phanLopBUS;
        private HocSinhDTO _hocSinhDTO;

        // Access from frmSearchHocSinh
        public string MaLop { get; set; }
        public string MaHocSinh { get; set; }
       
        public frmHocSinh()
        {
            InitializeComponent();
            _namHocBUS = new NamHocBUS();
            _khoiBUS = new KhoiBUS();
            _lopBUS = new LopBUS();
            _hocSinhBUS = new HocSinhBUS();
            _quyDinhBUS = new QuyDinhBUS();
            _phanLopBUS = new PhanLopBUS();
        }
        /// <summary>
        /// Hiển thị lại form học sinh khi có yêu cầu từ form tìm kiếm
        /// </summary>
        public void HienThiLai_FrmHocSinh_TuFormTimKiem()
        {
            if (MaLop != null)
            {
                string maNamHoc = Utilities.ObjectUtilities.LayMaNamHocTuMaLop(MaLop);
                string maKhoi = Utilities.ObjectUtilities.LayMaKhoiLopTuMaLop(MaLop);
                // Chọn lại năm học
                Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEditNamHoc, maNamHoc);
                // Chọn lại khối
                Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEditKhoi, maKhoi);
                // Chọn lại lớp
                Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEditLop, MaLop);
                // Bỏ check Tiếp nhận hồ sơ mới
                checkEditChuaPhanLop.Checked = false;
            }
            else
            {
                checkEditChuaPhanLop.Checked = true;
            }
            // Tìm vị trí học sinh trên GridView có mã là MaHocSinh truyền từ formSearch
            int found_select_handler = -1;
            for (int i = 0; i < gridViewDSHocSinh.RowCount; i++)
            {
                if (gridViewDSHocSinh.GetRowCellValue(i, "MaHocSinh").ToString() == MaHocSinh)
                {
                    found_select_handler = i;
                    break;
                }
            }
            // Chọn học sinh
            if (found_select_handler != -1)
                gridViewDSHocSinh.FocusedRowHandle = found_select_handler;
            else
                Utilities.MessageboxUtilities.MessageError("Không tìm thấy hồ sơ học sinh có mã: "+MaHocSinh);
        }
        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,_namHocBUS.LayDTNamHoc(),"MaNamHoc", "TenNamHoc",0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi, _khoiBUS.LayDTKhoi(),
                                                "MaKhoi", "TenKhoi",0);
        }

        /// <summary>
        /// Load lại combobox lớp học theo năm và khối
        /// </summary>
        private void LoadComboboxLopHoc(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditLop, _lopBUS.LayDTLop_MaNam_MaKhoi(
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
                _hocSinhDTO = _hocSinhBUS.LayHoSoHocSinh(MaHocSinh.ToString());
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
        private void LoadLai_GridControl_HocSinh(bool chuaPhanLop = false)
        {
            if(chuaPhanLop)
                gridControlDSHocSinh.DataSource = _hocSinhBUS.LayDTHocSinh_LopHoc("",true);
            else
                 gridControlDSHocSinh.DataSource = _hocSinhBUS.LayDTHocSinh_LopHoc(
                     Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop), false
            );
            if (gridViewDSHocSinh.RowCount > 0)
            {
                object MaHocSinh = this.gridViewDSHocSinh.GetRowCellValue(0, "MaHocSinh").ToString();
                HienThiHoSoHocSinh(MaHocSinh);
            }
            else
            {
                spinEditSTTSoDiem.Value = 1;
                textEditmaHocSinh.Text = "";
                textEditTenHocSinh.Text = "";
                textEditDiaChi.Text = "";
                textEditEmail.Text = "";
                textEditNoiSinh.Text = "";
                textEditTenHocSinh.Focus();
            }
        }
        private void simpleButtonGhiDuLieu_Click(object sender, EventArgs e)
        {
            HocSinhDTO hocSinhDTO  = new HocSinhDTO();
            
            hocSinhDTO.NgaySinh = Convert.ToDateTime(dateEditNgaySinh.EditValue);
            hocSinhDTO.MaHocSinh = textEditmaHocSinh.Text;
            hocSinhDTO.TenHocSinh = textEditTenHocSinh.Text;
            hocSinhDTO.GioiTinh = radioGroupGioiTinh.SelectedIndex;
            hocSinhDTO.NoiSinh = textEditNoiSinh.Text;
            hocSinhDTO.DiaChi = textEditDiaChi.Text;
            hocSinhDTO.Email = textEditEmail.Text;
            string maLop = null;
            // neu co phan lop
            if(!checkEditChuaPhanLop.Checked)
            {
                hocSinhDTO.STT = Convert.ToInt32(spinEditSTTSoDiem.Value);
                maLop = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop);
            }
            if (hocSinhDTO.TenHocSinh.Length < 3 || !hocSinhDTO.TenHocSinh.Contains(" "))
            {
                Utilities.MessageboxUtilities.MessageError("Họ tên học sinh không hợp lệ (không chứa khoảng trắng) hoặc nhỏ hơn 3 ký tự!");
                return;
            }
            try
            {
                _hocSinhBUS.LuuHoSoHocSinh(hocSinhDTO, maLop);
                Utilities.MessageboxUtilities.MessageSuccess("Lưu hồ sơ học sinh " + hocSinhDTO.TenHocSinh + " thành công!");
            }
            catch (Exception ex)
            {
                Utilities.MessageboxUtilities.MessageError(ex);
                return;
            }
            this.LoadLai_GridControl_HocSinh(checkEditChuaPhanLop.Checked);
            gridViewDSHocSinh.SelectRow(0);
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
            _hocSinhBUS.Xoa_HoSo_HocSinh(textEditmaHocSinh.Text);
            Utilities.MessageboxUtilities.MessageSuccess("Xóa hồ sơ học sinh thành công!");
            LoadLai_GridControl_HocSinh(checkEditChuaPhanLop.Checked);
            
        }
        private void simpleButtonThemMoi_Click(object sender, EventArgs e)
        {
            // Neu co phan lop
            if (!checkEditChuaPhanLop.Checked)
            {
                string MaLop = (Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
                int SiSoCanTren = _quyDinhBUS.LaySiSoCanTren();
                if (_phanLopBUS.Dem_SiSo_Lop(MaLop) >= SiSoCanTren)
                {
                    Utilities.MessageboxUtilities.MessageError("Lớp " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop)
                                                                + " đã đủ học sinh theo quy định "
                                                                + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                    return;
                }
                spinEditSTTSoDiem.Value = _phanLopBUS.Lay_STT_TiepTheo(MaLop);
            }
            textEditmaHocSinh.Text = "";
            textEditTenHocSinh.Text = "";
            textEditDiaChi.Text = "";
            textEditEmail.Text = "";
            textEditNoiSinh.Text = "";
            textEditTenHocSinh.Focus();
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

        private void simpleButtonSXLaiSTT_Click(object sender, EventArgs e)
        {
            if (checkEditChuaPhanLop.Checked)
            {
                Utilities.MessageboxUtilities.MessageError("Danh sách hiện tại chưa được phân lớp nên không thể sắp xếp STT!");
                return;
            }
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLop))
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa chọn lớp để thực hiện");
                return;
            }
            _phanLopBUS.CapNhap_STT_HocSinh_Lop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
            Utilities.MessageboxUtilities.MessageSuccess("Cập nhật số thự tự cho lớp thành công!");
            // Load lại gridcontrol học sinh
            this.LoadLai_GridControl_HocSinh();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEditNamHoc.Enabled = !checkEditChuaPhanLop.Checked;
            comboBoxEditLop.Enabled = !checkEditChuaPhanLop.Checked;
            spinEditSTTSoDiem.Enabled = !checkEditChuaPhanLop.Checked;
            this.LoadLai_GridControl_HocSinh(checkEditChuaPhanLop.Checked);
           
        }
    }
}