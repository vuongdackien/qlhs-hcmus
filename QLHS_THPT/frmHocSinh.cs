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
        private bool _is_add_button;
        private bool _is_delete_button;
        private int _current_row_edit;

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
            _is_add_button = true;
            _is_delete_button = true;
        }

        /// <summary>
        /// Hiển thị lại form học sinh khi có yêu cầu từ form tìm kiếm
        /// </summary>
        public void HienThiLai_FrmHocSinh_TuFormTimKiem()
        {
            if (MaLop != null)
            {
                string maNamHoc = Util.ObjectUtil.LayMaNamHocTuMaLop(MaLop);
                string maKhoi = Util.ObjectUtil.LayMaKhoiLopTuMaLop(MaLop);
                // Chọn lại năm học
                Util.CboUtil.SelectedItem(comboBoxEditNamHoc, maNamHoc);
                // Chọn lại khối
                Util.CboUtil.SelectedItem(comboBoxEditKhoi, maKhoi);
                // Chọn lại lớp
                Util.CboUtil.SelectedItem(comboBoxEditLop, MaLop);
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
                Util.MsgboxUtil.Error("Không tìm thấy hồ sơ học sinh có mã: "+MaHocSinh);
        }
      
        /// <summary>
        /// Load lại combobox lớp học theo năm và khối
        /// </summary>
        private void LoadComboboxLopHoc(object sender, EventArgs e)
        {
            Util.CboUtil.SetDataSource(comboBoxEditLop, _lopBUS.LayDTLop_MaNam_MaKhoi(
                       Util.CboUtil.GetValueItem(comboBoxEditNamHoc),
                         Util.CboUtil.GetValueItem(comboBoxEditKhoi)
                    ), "MaLop", "TenLop", 0);
            comboBoxEditLop_SelectedIndexChanged(sender,e);
            this.HienThiHoSoHocSinh(gridViewDSHocSinh.GetRowCellValue(0, "MaHocSinh"));
            
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
                panelControlHoSo.Enabled = false;
                _Reset_Control();
            }
            else
            {
                _hocSinhDTO = _hocSinhBUS.LayHoSo_HocSinh(MaHocSinh.ToString());
                panelControlHoSo.Enabled = true;
                spinEditSTTSoDiem.Value = _hocSinhDTO.STT;
                dateEditNgaySinh.EditValue = _hocSinhDTO.NgaySinh;
                textEditmaHocSinh.Text = _hocSinhDTO.MaHocSinh;
                textEditTenHocSinh.Text = _hocSinhDTO.TenHocSinh;
                radioGroupGioiTinh.SelectedIndex = _hocSinhDTO.GioiTinh;
                textEditNoiSinh.Text = _hocSinhDTO.NoiSinh;
                textEditDiaChi.Text = _hocSinhDTO.DiaChi;
                textEditEmail.Text = _hocSinhDTO.Email;
            }
           

        }
        /// <summary>
        /// Ẩn hiện các control cho thao tác thêm/không thêm
        /// </summary>
        /// <param name="is_adding">is_adding: Thêm/Không thêm</param>
        public void _Diable_Control(bool is_adding)
        {
            simpleButtonDong.Enabled = !is_adding;
            gridControlDSHocSinh.Enabled = !is_adding;

            if (!checkEditChuaPhanLop.Checked)
            {
                comboBoxEditNamHoc.Enabled = !is_adding;
                comboBoxEditKhoi.Enabled = !is_adding;
                comboBoxEditLop.Enabled = !is_adding;
                simpleButtonSXLaiSTT.Enabled = !is_adding;
            }
            else
            {
                comboBoxEditNamHoc.Enabled = false;
                comboBoxEditKhoi.Enabled = false;
                comboBoxEditLop.Enabled = false;
                simpleButtonSXLaiSTT.Enabled = false;
            }
            
            checkEditChuaPhanLop.Enabled = !is_adding;

            _is_add_button = !is_adding;
            _is_delete_button = !is_adding;

            simpleButtonThemMoi.Text = is_adding ? "Không nhập (Alt+&N)" : "Thêm mới (Alt+&N)";
            simpleButtonXoa.Text = is_adding ? "Nhập lại (Alt+&D)" : "Xóa (Alt+&D)";
            simpleButtonGhiDuLieu.Text = is_adding ? "Lưu hồ sơ (Enter)" : "Cập nhật (Enter)";

            // Mac dinh cac control nay deu duoc bat
            panelControlHoSo.Enabled = true;
            simpleButtonXoa.Enabled = true;
            simpleButtonGhiDuLieu.Enabled = true;

            if (gridViewDSHocSinh.RowCount > 0)
            {
                // Neu khong them moi chon hoc sinh
                if(!is_adding)
                {
                    gridViewDSHocSinh.FocusedRowHandle = _current_row_edit;
                    gridViewDSHocSinh_FocusedRowChanged(this,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, _current_row_edit));
                }
            }
            else  // TH Grid ko co hoc sinh nao
            {
                 simpleButtonGhiDuLieu.Enabled = is_adding; // An nut Cap Nhat, Hien nut Luu
                 simpleButtonXoa.Enabled = is_adding;
                 panelControlHoSo.Enabled = is_adding;
                _Reset_Control();
            }
        }
        /// <summary>
        /// Xóa dữ liệu control, chuẩn bị thêm mới hồ sơ
        /// </summary>
        private void _Reset_Control()
        {
            if (gridViewDSHocSinh.RowCount == 0)
                spinEditSTTSoDiem.Value = 1;
            textEditmaHocSinh.Text = "";
            textEditTenHocSinh.Text = "";
            textEditDiaChi.Text = "";
            textEditEmail.Text = "";
            textEditNoiSinh.Text = "";
            textEditTenHocSinh.Focus();
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            Util.CboUtil.SetDataSource(comboBoxEditNamHoc, _namHocBUS.LayDTNamHoc(), "MaNamHoc", "TenNamHoc", 0);
            Util.CboUtil.SetDataSource(comboBoxEditKhoi, _khoiBUS.LayDT_Khoi(),
                                                "MaKhoi", "TenKhoi", 0);
        }
        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditKhoi) ||
                Util.CboUtil.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc(sender, e);
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc(sender, e);
        }

        private void comboBoxEditLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLop))
            {
                gridControlDSHocSinh.DataSource = null;
                return;
            }
            this.LoadLai_GridControl_HocSinh();
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
                gridControlDSHocSinh.DataSource = _hocSinhBUS.LayDT_HocSinh("",true);
            else
                 gridControlDSHocSinh.DataSource = _hocSinhBUS.LayDT_HocSinh(
                     Util.CboUtil.GetValueItem(comboBoxEditLop), false
            );
            if (gridViewDSHocSinh.RowCount > 0)
            {
                object MaHocSinh = this.gridViewDSHocSinh.GetRowCellValue(0, "MaHocSinh").ToString();
                HienThiHoSoHocSinh(MaHocSinh);
            }
            _Diable_Control(is_adding: false);
        }
        private void simpleButtonGhiDuLieu_Click(object sender, EventArgs e)
        {
            if (_is_add_button)
                _current_row_edit = gridViewDSHocSinh.FocusedRowHandle;
            else
                _current_row_edit = 0;

            HocSinhDTO hocSinhDTO  = new HocSinhDTO();
            
            hocSinhDTO.NgaySinh = Convert.ToDateTime(dateEditNgaySinh.EditValue);
            hocSinhDTO.MaHocSinh = textEditmaHocSinh.Text;
            hocSinhDTO.TenHocSinh = textEditTenHocSinh.Text.Replace("'","''");
            hocSinhDTO.GioiTinh = radioGroupGioiTinh.SelectedIndex;
            hocSinhDTO.NoiSinh = textEditNoiSinh.Text.Replace("'", "''");
            hocSinhDTO.DiaChi = textEditDiaChi.Text.Replace("'", "''");
            hocSinhDTO.Email = textEditEmail.Text;
            string maLop = null;
            // neu co phan lop
            if(!checkEditChuaPhanLop.Checked)
            {
                hocSinhDTO.STT = Convert.ToInt32(spinEditSTTSoDiem.Value);
                maLop = Util.CboUtil.GetValueItem(comboBoxEditLop);
            }
            if (hocSinhDTO.TenHocSinh.Length < 3 || !hocSinhDTO.TenHocSinh.Contains(" "))
            {
                Util.MsgboxUtil.Error("Họ tên học sinh không hợp lệ (không chứa khoảng trắng) hoặc nhỏ hơn 3 ký tự!");
                textEditTenHocSinh.Focus();
                return;
            }
            if (hocSinhDTO.NoiSinh.Length < 3)
            {
                Util.MsgboxUtil.Error("Nơi sinh không hợp lệ (nhỏ hơn 3 ký tự)!");
                textEditNoiSinh.Focus();
                return;
            }
            if (hocSinhDTO.DiaChi.Length < 3)
            {
                Util.MsgboxUtil.Error("Địa chỉ không hợp lệ (nhỏ hơn 3 ký tự)!");
                textEditDiaChi.Focus();
                return;
            }
            try
            {
                _hocSinhBUS.LuuHoSo_HocSinh(hocSinhDTO, maLop);
                Util.MsgboxUtil.Success("Lưu hồ sơ học sinh " + hocSinhDTO.TenHocSinh + " thành công!");
            }
            catch (Exception ex)
            {
                Util.MsgboxUtil.Error(ex);
                return;
            }
            this.LoadLai_GridControl_HocSinh(checkEditChuaPhanLop.Checked);
            this._Diable_Control(is_adding: false);
        }
        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            if(!_is_delete_button)
            {
                _Reset_Control();
                return;
            }

            if(textEditmaHocSinh.Text == "")
            {
                Util.MsgboxUtil.Error("Bạn chưa chọn học sinh để thực hiện xóa!");
                return;
            }
            if (Util.MsgboxUtil.YesNo("Bạn có chắc chắn muốn xóa toàn bộ hồ sơ học sinh \""+textEditTenHocSinh.Text+"\" hay không?") == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            _hocSinhBUS.Xoa_HoSo_HocSinh(textEditmaHocSinh.Text);
            Util.MsgboxUtil.Success("Xóa hồ sơ học sinh thành công!");
            LoadLai_GridControl_HocSinh(checkEditChuaPhanLop.Checked);
            
        }
      
        private void simpleButtonThemMoi_Click(object sender, EventArgs e)
        {
            // Không thêm
            if (!_is_add_button)
            {
                this._Diable_Control(is_adding: false);
                return;
            }
            // Thêm
           
            // Neu co phan lop
            if (!checkEditChuaPhanLop.Checked)
            {
                string maNamHocHT = _quyDinhBUS.LayMaNamHoc_HienTai();
                string maNamHoc = Util.CboUtil.GetValueItem(comboBoxEditNamHoc);
                string tenNamHT = _namHocBUS.LayTenNamHoc_MaNamHoc(maNamHocHT);

                if (maNamHoc != maNamHocHT)
                {
                    if (Util.MsgboxUtil.YesNo("Chương trình chỉ được phép tiếp nhận học sinh trong năm " + tenNamHT
                                                                + "\nĐể thực hiện chức năng này, bạn có muốn di chuyển đến năm " + tenNamHT + " hay không?")
                                                        == System.Windows.Forms.DialogResult.Yes)
                    {
                        string maKhoiHT = Util.CboUtil.GetValueItem(comboBoxEditKhoi);
                        Util.CboUtil.SelectedItem(comboBoxEditNamHoc, maNamHocHT);
                        Util.CboUtil.SelectedItem(comboBoxEditKhoi, maKhoiHT);
                        Util.MsgboxUtil.Info("Đã chuyển đến năm " + tenNamHT
                                                        + ", bạn hãy chọn lớp để thực hiện tiếp nhận hồ sơ mới!");
                    }

                    return;
                }

                string MaLop = (Util.CboUtil.GetValueItem(comboBoxEditLop));
                int SiSoCanTren = _quyDinhBUS.LaySiSo_CanTren();
                if (_phanLopBUS.Dem_SiSo_Lop(MaLop) >= SiSoCanTren)
                {
                    Util.MsgboxUtil.Error("Lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop)
                                                                + " đã đủ học sinh theo quy định "
                                                                + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                    return;
                }
                spinEditSTTSoDiem.Value = _phanLopBUS.LaySTT_TiepTheo(MaLop);
            }
            this._Diable_Control(is_adding: true);
            this._Reset_Control();
            
        }

        private void dateEditNgaySinh_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Ngày sinh không hợp lệ";
        }

        private void textEditEmail_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = "Email không hợp lệ! (Ấn ESC để trở lại)";
        }

        private void simpleButtonSXLaiSTT_Click(object sender, EventArgs e)
        {
            if (checkEditChuaPhanLop.Checked)
            {
                Util.MsgboxUtil.Error("Danh sách hiện tại chưa được phân lớp nên không thể sắp xếp STT!");
                return;
            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLop))
            {
                Util.MsgboxUtil.Error("Bạn chưa chọn lớp để thực hiện");
                return;
            }
            _phanLopBUS.CapNhapSTT_HocSinh_Lop(Util.CboUtil.GetValueItem(comboBoxEditLop));
            Util.MsgboxUtil.Success("Cập nhật số thự tự cho lớp thành công!");
            // Load lại gridcontrol học sinh
            this.LoadLai_GridControl_HocSinh();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEditNamHoc.Enabled = !checkEditChuaPhanLop.Checked;
            comboBoxEditKhoi.Enabled = !checkEditChuaPhanLop.Checked;
            comboBoxEditLop.Enabled = !checkEditChuaPhanLop.Checked;
            spinEditSTTSoDiem.Enabled = !checkEditChuaPhanLop.Checked;
            this.LoadLai_GridControl_HocSinh(checkEditChuaPhanLop.Checked);
        }
    }
}