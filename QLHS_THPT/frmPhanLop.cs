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
    public partial class frmPhanLop : DevExpress.XtraEditors.XtraForm
    {
        private NamHocBUS _NamHocBUS;
        private KhoiBUS _KhoiBUS;
        private LopBUS _LopBUS;
        private HocSinhBUS _hocSinhBUS;
        private PhanLopBUS _phanLopBUS;
        private QuyDinhBUS _quyDinhBUS;
        private ChuyenLopBUS _ChuyenLopBUS;
        object _maHocSinh_Focus, _maHocSinhMoi_Focus;
        private int _dongHT_GridHocSinh, _dongHT_GridHocSinhMoi = -1;
        private string _maNamHocHienTai;

        private enum YeuCau
        {
            PhanLop_HoSoChuaPhanLop,
            PhanLop_HoSoNamCu,
            ChuyenLop_CungKhoi
        };

        public frmPhanLop()
        {
            InitializeComponent();
            _NamHocBUS = new NamHocBUS();
            _KhoiBUS = new KhoiBUS();
            _LopBUS = new LopBUS();
            _hocSinhBUS = new HocSinhBUS();
            _phanLopBUS = new PhanLopBUS();
            _quyDinhBUS = new QuyDinhBUS();
            _ChuyenLopBUS = new ChuyenLopBUS();
            _maNamHocHienTai = _quyDinhBUS.LayMaNamHoc_HienTai();
        }
      

        private void _Show_Control(YeuCau yc)
        {
            // Disable all control
            dateEditTu.Enabled = false;
            dateEditDen.Enabled = false;
            simpleButtonLayHSo.Enabled = false;

            checkEditHocSinhChuaChuyen.Enabled = false;

            checkEditChuyenBangDiem.Enabled = false;
            textEditLyDoChuyen.Enabled = false;

            groupControlLopCu.Enabled = true;

            // Show control
            if (yc == YeuCau.PhanLop_HoSoChuaPhanLop)
            {
                dateEditTu.Enabled = true;
                dateEditDen.Enabled = true;
                simpleButtonLayHSo.Enabled = true;
                groupControlLopCu.Enabled = false;
            }
            else if (yc == YeuCau.PhanLop_HoSoNamCu)
            {
                checkEditHocSinhChuaChuyen.Enabled = true;
            }
            else if(yc == YeuCau.ChuyenLop_CungKhoi)
            {
                checkEditChuyenBangDiem.Enabled = true;
                textEditLyDoChuyen.Enabled = true;
            }
        }
        private void LoadGridcontrolDSHocSinhMoi()
        {
            gridControlDSHocSinhMoi.DataSource =  _hocSinhBUS.LayDTHocSinh_LopHoc(
                                                        Util.CboUtil.GetValueItem(comboBoxEditLopMoi)
                                                  );
        }
        private void _LoadGridcontrolDSHocSinh()
        {
            // Chưa phân lớp
            if(radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
            {
                gridControlDSHocSinh.DataSource =   _hocSinhBUS.LayDT_HocSinh_ChuaPhanLop(
                                                            Convert.ToDateTime(dateEditTu.EditValue),
                                                            Convert.ToDateTime(dateEditDen.EditValue)
                                                     );
            }
            // phân lớp từ năm cũ || chuyển lớp cùng khối
            else if(radioButtonPhanLopHocSinh_NamTruoc.Checked || 
                    radioButtonChuyenLopCungKhoi.Checked)
            {
                  gridControlDSHocSinh.DataSource = _hocSinhBUS.LayDTHocSinh_LopHoc(
                         Util.CboUtil.GetValueItem(comboBoxEditLop)
                  );
            }
        }

        private void LoadCbNamHocChung()
        {
            Util.CboUtil.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocHienTai(), "MaNamHoc", "TenNamHoc", 0);
            Util.CboUtil.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocHienTai(), "MaNamHoc", "TenNamHoc", 0);
        }
        private void LoadCbNamHocMoi()
        {
            Util.CboUtil.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocHienTai(), "MaNamHoc", "TenNamHoc", 0);
        }
        private void LoadCbKhoiMoi_PhanLop(string MaNamHoc)
        {
            Util.CboUtil.SetDataSource(comboBoxEditKhoiMoi, _phanLopBUS.LayDTKhoi10(MaNamHoc), "MaKhoi", "TenKHoi", 0);
        }
        private void LoadCbKhoi_ChuyenLop(string MaNamHoc)
        {
            Util.CboUtil.SetDataSource(comboBoxEditKhoi, _phanLopBUS.LayDTKhoi(MaNamHoc), "MaKhoi", "TenKHoi", 0);
        }
        private void LoadCbNamHocTruoc()
        {
            Util.CboUtil.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocTruoc(), "MaNamHoc", "TenNamHoc", 0);
        }
        private void LoadCbKhoi_PhanLopCu(string MaNamHoc)
        {
            Util.CboUtil.SetDataSource(comboBoxEditKhoi, _phanLopBUS.LayDTKhoi_PhanLopCu(MaNamHoc), "MaKhoi", "TenKhoi", 0);
        }
        private bool KiemTraTonTaiNamHocHT()
        {
            return _NamHocBUS.LayDTNamHocHienTai().Rows.Count > 0;
        }

        private bool KiemTraCbThongTinLopCu()
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHoc))
            {
                Util.MsgboxUtil.Error("Không có năm học sau năm học hiện tại, bạn hãy chọn chức năng khác");
                return false;

            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditKhoi))
            {
                Util.MsgboxUtil.Error("Năm học này không tồn tại lớp học");
                return false;
            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLop))
            {
                Util.MsgboxUtil.Error("Năm học này không có lớp");
                return false;
            }
            return true;
        }
        private bool KiemTraCbThongTinLopMoi()
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHocMoi))
            {
                Util.MsgboxUtil.Error("Không có năm học sau năm học hiện tại, bạn hãy chọn chức năng khác");
                return false;

            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditKhoiMoi))
            {
                Util.MsgboxUtil.Error("Năm học này không tồn tại lớp học");
                return false;
            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLopMoi))
            {
                Util.MsgboxUtil.Error("Năm học này không có lớp");
                return false;
            }
            return true;
        }
        private bool KiemTraKhoiLop_ChuyenLop(string MaNamHoc)
        {
            return _phanLopBUS.LayDTKhoi(MaNamHoc).Rows.Count > 0;
        }

        private void LoadForm()
        {
            simpleButtonChuyenLop.Enabled = false;
            simpleButtonChuyenLai.Enabled = false;
            simpleButtonChuyenHet.Enabled = false;
            simpleButtonChuyenLaiTatCa.Enabled = false;
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHoc))
            {
                return;
            }
            LoadCbKhoi_ChuyenLop(Util.CboUtil.GetValueItem(comboBoxEditNamHoc));
        }

        private void LoadComboboxLopHoc(object sender, EventArgs e)
        {
            Util.CboUtil.SetDataSource(comboBoxEditLop, _LopBUS.LayDTLop_MaNam_MaKhoi(
                       Util.CboUtil.GetValueItem(comboBoxEditNamHoc),
                         Util.CboUtil.GetValueItem(comboBoxEditKhoi)
                    ), "MaLop", "TenLop", 0);
            
            comboBoxEditLop_SelectedIndexChanged(sender, e);
        }

        private void loadComboboxLopHoc_Moi(object sender, EventArgs e)
        {
            if (radioButtonChuyenLopCungKhoi.Checked == true)
            {
                Util.CboUtil.SetDataSource(comboBoxEditLopMoi, _phanLopBUS.LayDTLop_MaNam_MaKhoi_KhacMaLop(
                    Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi),
                    Util.CboUtil.GetValueItem(comboBoxEditKhoiMoi),
                    Util.CboUtil.GetValueItem(comboBoxEditLop)), "MaLop", "TenLop", 0);
            }
            else
            {
                Util.CboUtil.SetDataSource(comboBoxEditLopMoi, _LopBUS.LayDTLop_MaNam_MaKhoi(
                        Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi),
                        Util.CboUtil.GetValueItem(comboBoxEditKhoiMoi)), "MaLop", "TenLop", 0);
            }
        }

        private void comboBoxEditLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLop))
            {
                gridControlDSHocSinh.DataSource = null;
                return;
            }
            _LoadGridcontrolDSHocSinh();
            if (radioButtonChuyenLopCungKhoi.Checked == true)
            {
                this.loadComboboxLopHoc_Moi(sender, e);
            }
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHoc) || Util.CboUtil.CheckSelectedNull(comboBoxEditKhoi))
                return;
            this.LoadComboboxLopHoc(sender, e);
            if (radioButtonChuyenLopCungKhoi.Checked == true)
            {
                Util.CboUtil.SetDataSource(comboBoxEditKhoiMoi, _phanLopBUS.LayDTKhoi_Chuyen(Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi), Util.CboUtil.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);

            }
            else
            {
                Util.CboUtil.SetDataSource(
                    comboBoxEditKhoiMoi, _KhoiBUS.LayDTKhoi_PL(Util.CboUtil.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);
            }
        }

        private void frmChuyenLop_Load(object sender, EventArgs e)
        {
            string tb = "";
            if (KiemTraTonTaiNamHocHT())
            {
                if (KiemTraKhoiLop_ChuyenLop(_maNamHocHienTai))
                {
                    LoadForm();
                }
                else
                    tb = tb + "Chưa có lớp trong năm học, bạn hãy tạo lớp trước khi sử dụng chức năng này";
            }
            else
            {
                tb = tb + "Trong dữ liệu chưa có năm học = năm học hiện tại trong quy định, bạn hãy tạo năm học trước khi sử dụng chức năng này";
            }
            if (tb != "")
            {
                Util.MsgboxUtil.Error(tb);
            }
            // khoi tao 2 input datetime từ và đến
            DateTime dateTu = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
            dateEditTu.Properties.MaxValue = DateTime.Now;
            dateEditDen.Properties.MaxValue = DateTime.Now;
            dateEditTu.EditValue = dateTu;
            dateEditDen.EditValue = DateTime.Now;
            radioButtonPhanLopHocSinhMoi_CheckedChanged(this, new EventArgs());

        }
        private void comboBoxEditLopMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditLopMoi))
            {
                gridControlDSHocSinhMoi.DataSource = null;
                return;
            }
            LoadGridcontrolDSHocSinhMoi();
        }

        private void comboBoxEditNamHocMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(radioButtonPhanLopHoSo_ChuaPhanLop.Checked==true)
            {
                LoadCbKhoiMoi_PhanLop(Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi));
            }
            if (radioButtonChuyenLopCungKhoi.Checked == true)
            {
                Util.CboUtil.SetDataSource(comboBoxEditKhoiMoi, _phanLopBUS.LayDTKhoi_Chuyen(Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi), Util.CboUtil.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);
            }
            if(radioButtonPhanLopHocSinh_NamTruoc.Checked==true)
                Util.CboUtil.SetDataSource(comboBoxEditKhoiMoi, _KhoiBUS.LayDTKhoi_PL(Util.CboUtil.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);
        }
        
        private void comboBoxEditKhoiMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadComboboxLopHoc_Moi(sender, e);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridViewDSHocSinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;
            _dongHT_GridHocSinh = e.FocusedRowHandle;
        }

        private void simpleButtonChuyenLop_Click(object sender, EventArgs e)
        {
            if (KiemTra_DuLieu())
            {
                string lopnam = "";
                if (!radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                {
                    lopnam = lopnam + " trong lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop)
                    + " năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc);
                }
                if (Util.MsgboxUtil.YesNo("Bạn có muốn chuyển học sinh " +
                    this.gridViewDSHocSinh.GetRowCellValue(_dongHT_GridHocSinh, "TenHocSinh").ToString() 
                    +lopnam
                    + " sang lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) 
                    + " năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi) + " không?")
                    == DialogResult.Yes)
                {
                    _maHocSinh_Focus = this.gridViewDSHocSinh.GetRowCellValue(_dongHT_GridHocSinh, "MaHocSinh").ToString();
                    string MaLop = (Util.CboUtil.GetValueItem(comboBoxEditLopMoi));
                    int SiSoCanTren = _quyDinhBUS.LaySiSoCanTren();
                    if (_phanLopBUS.DemSiSoLop_HocSinhDangHoc(MaLop) >= SiSoCanTren)
                    {
                        Util.MsgboxUtil.Error("Lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi)
                                                                    + " đã đủ học sinh theo quy định "
                                                                    + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                        return;
                    }
                    DataTable dtKiemTra;
                    if (radioButtonChuyenLopCungKhoi.Checked)
                    {
                        dtKiemTra = _phanLopBUS.KT_HocSinh_ChuyenLop(
                            _maHocSinh_Focus.ToString(),
                            Util.CboUtil.GetValueItem(comboBoxEditLop)
                        );
                        if (_phanLopBUS.KiemTraHSTonTaiTrongLop_ChuyenLop(_maHocSinh_Focus.ToString(),
                                    Util.CboUtil.GetValueItem(comboBoxEditLopMoi)).Rows.Count > 0)
                        {
                            Util.MsgboxUtil.Error("Học sinh " 
                                + this.gridViewDSHocSinh.GetRowCellValue(_dongHT_GridHocSinh, "TenHocSinh").ToString()
                                + " đã có trong lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) + " ");
                            return;
                        }
                    }
                    else
                    {
                        if (radioButtonPhanLopHocSinh_NamTruoc.Checked)
                        {
                            if (_phanLopBUS.KT_HocSinh_ChuyenLop(_maHocSinh_Focus.ToString(), Util.CboUtil.GetValueItem(comboBoxEditLop)).Rows.Count > 0)
                            {
                                Util.MsgboxUtil.Error("Học sinh "
                                    + this.gridViewDSHocSinh.GetRowCellValue(_dongHT_GridHocSinh, "TenHocSinh").ToString()
                                    + " không học trong lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop));
                                return;
                            }
                        }
                        dtKiemTra = _phanLopBUS.KT_HocSinh_TonTai_NamHoc(_maHocSinh_Focus.ToString(),
                            Util.CboUtil.GetValueItem(comboBoxEditKhoi),
                            Util.CboUtil.GetValueItem(comboBoxEditNamHocMoi));
                    }
                    if (dtKiemTra.Rows.Count > 0)
                    {
                        Util.MsgboxUtil.Error("Học sinh " + this.gridViewDSHocSinh.GetRowCellValue(_dongHT_GridHocSinh, "TenHocSinh").ToString()
                                                                   + " đã được chuyển tới lớp" + dtKiemTra.Rows[0][1] + " ");
                        return;
                    }
                    else
                    {
                        if (gridViewDSHocSinhMoi.RowCount > 0)
                        {
                            _phanLopBUS.CapNhap_STT_HocSinh_Lop(Util.CboUtil.GetValueItem(comboBoxEditLopMoi));
                        }
                        if (_phanLopBUS.ChuyenLop_HocSinh(_maHocSinh_Focus.ToString(), Util.CboUtil.GetValueItem(comboBoxEditLopMoi)))
                        {
                            string tb = " sang lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) 
                                       + " năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi)+"thành công " ;
                            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                            {
                                tb =  "Đã phân: "+this.gridViewDSHocSinh.GetRowCellValue(_dongHT_GridHocSinh, "TenHocSinh").ToString() +tb;
                            }
                            if (radioButtonPhanLopHocSinh_NamTruoc.Checked)
                            {
                                tb = "Đã phân: " + this.gridViewDSHocSinh.GetRowCellValue(_dongHT_GridHocSinh, "TenHocSinh").ToString() + "  từ lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop)
                                    + " năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc) +tb;
                            }
                            if (radioButtonChuyenLopCungKhoi.Checked)
                            {
                                tb = "Đã chuyển: " + this.gridViewDSHocSinh.GetRowCellValue(_dongHT_GridHocSinh, "TenHocSinh").ToString() + "  từ lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop)
                                    + " năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc) + tb;
                                DateTime dDate = DateTime.Now;
                                ChuyenLopDTO chuyenLopDTO = new ChuyenLopDTO();
                                chuyenLopDTO.TuLop = Util.CboUtil.GetValueItem(comboBoxEditLop);
                                chuyenLopDTO.DenLop = Util.CboUtil.GetValueItem(comboBoxEditLopMoi);
                                chuyenLopDTO.NgayChuyen = dDate.ToString("dd-MM-yyy");
                                chuyenLopDTO.LyDoChuyen = textEditLyDoChuyen.Text.ToString();
                                chuyenLopDTO.ChuyenBangDiem = Convert.ToString(checkEditChuyenBangDiem.Checked);
                                chuyenLopDTO.MaHocSinh = _maHocSinh_Focus.ToString();
                                if (checkEditChuyenBangDiem.Checked)
                                {
                                    if (_ChuyenLopBUS.KT_HocSinhCo_BangDiem(_maHocSinh_Focus.ToString(), Util.CboUtil.GetValueItem(comboBoxEditLop)))
                                    {
                                        if (_ChuyenLopBUS.ChuyenBangDiem(chuyenLopDTO.MaHocSinh, chuyenLopDTO.TuLop, chuyenLopDTO.DenLop))
                                            tb = tb + ". Chuyển bảng điểm thành công";
                                    }
                                    else
                                    {
                                        tb = tb + ". Chuyển bảng điểm không thành công vì học sinh này chưa có điểm";
                                        chuyenLopDTO.ChuyenBangDiem = "false";
                                    }

                                }
                                if (_ChuyenLopBUS.LuuChuyenLop(chuyenLopDTO))
                                    tb = tb + ". Đã lưu thông tin chuyển lớp";

                            }
                            Util.MsgboxUtil.Success(tb);
                            comboBoxEditLopMoi_SelectedIndexChanged(sender, e);
                            _LoadGridcontrolDSHocSinh();
                            LoadGridcontrolDSHocSinhMoi();
                            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                            {
                                this._LoadGridcontrolDSHocSinh();
                            }
                        }
                    }
                    hienThi_Button();
                }
            }
        }

        private void gridViewDSHocSinhMoi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            if (e.FocusedRowHandle < 0)
                return;

            _dongHT_GridHocSinhMoi = e.FocusedRowHandle;
        }

        private void simpleButtonChuyenLai_Click(object sender, EventArgs e)
        {
            if (KiemTra_DuLieu())
            {
                if (Util.MsgboxUtil.YesNo("Bạn có muốn chuyển lại học sinh " 
                        + this.gridViewDSHocSinhMoi.GetRowCellValue(_dongHT_GridHocSinhMoi, "TenHocSinh").ToString() 
                        + " trong lớp" + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) + " năm học " 
                        + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi) + " sang lớp "
                        + Util.CboUtil.GetDisplayItem(comboBoxEditLop) + " trong năm học " 
                        + Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc) + " không?")
                            == DialogResult.Yes)
                {
                    _maHocSinhMoi_Focus = this.gridViewDSHocSinhMoi.GetRowCellValue(_dongHT_GridHocSinhMoi, "MaHocSinh").ToString();
                    string MaLop = (Util.CboUtil.GetValueItem(comboBoxEditLop));
                    int SiSoCanTren = _quyDinhBUS.LaySiSoCanTren();
                    if (_phanLopBUS.DemSiSoLop_HocSinhDangHoc(MaLop) >= SiSoCanTren)
                    {
                        Util.MsgboxUtil.Error("Lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop)
                                                                    + " đã đủ học sinh theo quy định "
                                                                    + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                        return;
                    }
                    int flag = 1;
                    string tb = "";
                    if (radioButtonChuyenLopCungKhoi.Checked == true)
                    {
                        if (_ChuyenLopBUS.KTHocSinhThuocLop_DuocChuyenTuLop(_maHocSinhMoi_Focus.ToString(), Util.CboUtil.GetValueItem(comboBoxEditLopMoi), Util.CboUtil.GetValueItem(comboBoxEditLop)))
                        {
                            if (_ChuyenLopBUS.KT_HocSinhCo_BangDiem(_maHocSinhMoi_Focus.ToString(), Util.CboUtil.GetValueItem(comboBoxEditLopMoi)))
                            {
                                if (_ChuyenLopBUS.ChuyenBangDiem(_maHocSinhMoi_Focus.ToString(), Util.CboUtil.GetValueItem(comboBoxEditLopMoi), Util.CboUtil.GetValueItem(comboBoxEditLop)))
                                {
                                    tb = tb + "Đã chuyển lại bảng điểm, ";
                                }
                            }
                            _ChuyenLopBUS.XoaChuyenLop(_maHocSinhMoi_Focus.ToString(), Util.CboUtil.GetValueItem(comboBoxEditLop), Util.CboUtil.GetValueItem(comboBoxEditLopMoi));
                            _phanLopBUS.CapNhap_STT_HocSinh_Lop(Util.CboUtil.GetValueItem(comboBoxEditLopMoi));
                        }
                        else
                        {
                            Util.MsgboxUtil.Error("Học sinh này không được chuyển từ lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop) + " hoặc không còn trong lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) + "");
                            flag = 0;
                        }
                    }
                    if (flag == 1)
                    {
                        if (_phanLopBUS.XoaHocSinh_Lop(_maHocSinhMoi_Focus.ToString(),
                            Util.CboUtil.GetValueItem(comboBoxEditLopMoi)))
                        {
                            tb = tb + "Chuyển Học Sinh " 
                                + this.gridViewDSHocSinhMoi.GetRowCellValue(_dongHT_GridHocSinhMoi, "TenHocSinh").ToString()
                                + " về lớp cũ thành công";
                            Util.MsgboxUtil.Success(tb);

                            LoadGridcontrolDSHocSinhMoi();
                            if (gridViewDSHocSinhMoi.RowCount > 0)
                            {
                                _phanLopBUS.CapNhap_STT_HocSinh_Lop(Util.CboUtil.GetValueItem(comboBoxEditLopMoi));
                            }
                            this._LoadGridcontrolDSHocSinh();
                            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked == true)
                            {
                                this._LoadGridcontrolDSHocSinh();
                            }
                        }
                    }
                    hienThi_Button();
                }
            }
        }
       

        private void gridViewDSHocSinh_MouseEnter(object sender, EventArgs e)
        {
            simpleButtonChuyenLop.Enabled = true;
            simpleButtonChuyenLai.Enabled = false;
            if (checkEditHocSinhChuaChuyen.Checked == true)
            {
                simpleButtonChuyenHet.Enabled = true;
            }
            hienThi_Button();
        }

        private void gridViewDSHocSinhMoi_MouseEnter(object sender, EventArgs e)
        {
            simpleButtonChuyenLop.Enabled = false;
            if (checkEditHocSinhChuaChuyen.Checked == true)
            {
                simpleButtonChuyenLai.Enabled = true;
                simpleButtonChuyenLaiTatCa.Enabled = true;
            }
            if (radioButtonChuyenLopCungKhoi.Checked == true)
            {
                simpleButtonChuyenLai.Enabled = true;
            }
            hienThi_Button();
        }
        private void hienThi_Button()
        {
            if (gridViewDSHocSinh.RowCount == 0)
            {
                simpleButtonChuyenLop.Enabled = false;
                simpleButtonChuyenHet.Enabled = false;
                if (gridViewDSHocSinhMoi.RowCount > 0)
                {
                    if (radioButtonChuyenLopCungKhoi.Checked == true)
                    {
                        simpleButtonChuyenLai.Enabled = true;
                    }
                    if (checkEditHocSinhChuaChuyen.Checked == true)
                    {
                        simpleButtonChuyenLai.Enabled = true;
                        simpleButtonChuyenLaiTatCa.Enabled = true;
                    }
                }
            }
            if (gridViewDSHocSinhMoi.RowCount == 0)
            {
                simpleButtonChuyenLai.Enabled = false;
                simpleButtonChuyenLaiTatCa.Enabled = false;
                if (gridViewDSHocSinh.RowCount > 0)
                {
                    simpleButtonChuyenLop.Enabled = true;
                    if (checkEditHocSinhChuaChuyen.Checked == true)
                    {
                        simpleButtonChuyenHet.Enabled = true;
                    }
                }
            }
        }
        public bool KiemTra_DuLieu()
        {
            if (comboBoxEditLopMoi.SelectedItem == null)
            {
                Util.MsgboxUtil.Error("Chưa có lớp trong năm học này, hoặc khối chỉ tồn tại 1 lớp, bạn cần phải tạo lớp trước khi muốn chuyển");
                return false;
            }
            return true;
        }

        private void checkEditHocSinhChuaChuyen_CheckedChanged(object sender, EventArgs e)
        {   
            _LoadGridcontrolDSHocSinh();
            LoadGridcontrolDSHocSinhMoi();
            if (checkEditHocSinhChuaChuyen.Checked == false)
            {
                simpleButtonChuyenHet.Enabled = false;
                simpleButtonChuyenLaiTatCa.Enabled = false;
                simpleButtonChuyenLai.Enabled = false;
            }
        }

        private void checkEditChuyenLop_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEditKhoi_SelectedIndexChanged(sender, e);
            if (radioButtonChuyenLopCungKhoi.Checked == true)
            {
                Util.CboUtil.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocHienTai(),
                                                "MaNamHoc", "TenNamHoc", 0);
            }
            else
            {
                Util.CboUtil.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocTruoc(),
                                                    "MaNamHoc", "TenNamHoc", 0);
            }
            if (radioButtonChuyenLopCungKhoi.Checked == true)
            {
                simpleButtonChuyenLop.Text = "Chuyển Lớp";
                checkEditChuyenBangDiem.Enabled = true;
                textEditLyDoChuyen.Enabled = true;
            }
            else
            {
                simpleButtonChuyenLop.Text = "Phân Lớp";
                checkEditChuyenBangDiem.Checked = false;
                textEditLyDoChuyen.Text = "";
                groupBoxPhanLop.Enabled = true;
            }
        }
        private void ChuyenHet()
        {
            int i;
            string tb = "";
            int SiSoCanTren = _quyDinhBUS.LaySiSoCanTren();
            for (i = 0; i < gridViewDSHocSinh.RowCount; i++)
            {
                string MaLop = (Util.CboUtil.GetValueItem(comboBoxEditLopMoi));
                if (_phanLopBUS.DemSiSoLop_HocSinhDangHoc(MaLop) >= SiSoCanTren)
                {
                    break;
                }
                _phanLopBUS.ChuyenLop_HocSinh(gridViewDSHocSinh.GetRowCellValue(i, "MaHocSinh").ToString(),Util.CboUtil.GetValueItem(comboBoxEditLopMoi));
            }
            if (i < gridViewDSHocSinh.RowCount)
            {
                if (i == 0)
                {
                    Util.MsgboxUtil.Error("Lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi)
                                                                + " đã đủ học sinh theo quy định "
                                                                + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                }
                else
                { 
                        tb = tb + "không phân hết được học sinh,chỉ phân được " + (i + 1) + " học sinh"; 
                
                }
            }
            else
                tb = tb + "Phân hết học sinh";
            if (i > 0)
            {
                if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked == true)
                {
                    Util.MsgboxUtil.Success( tb + " từ hồ sơ tới lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) + " trong năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi) + " thành công");
                }
                else
                    Util.MsgboxUtil.Success("" + tb + " từ lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop) + " trong năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc) + " sang lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) + " trong năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi) + " thành công");
                if (i < gridViewDSHocSinh.RowCount)
                {
                    Util.MsgboxUtil.Error("Lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi)
                                                                + " đã đủ học sinh theo quy định "
                                                                + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                }
            }

        }
        private void ChuyenHetLai()
        {
            for (int i = 0; i < gridViewDSHocSinhMoi.RowCount; i++)
            {
                _phanLopBUS.XoaHocSinh_Lop(gridViewDSHocSinhMoi.GetRowCellValue(i, "MaHocSinh").ToString(), Util.CboUtil.GetValueItem(comboBoxEditLopMoi));

            }
            _phanLopBUS.CapNhap_STT_HocSinh_Lop(Util.CboUtil.GetValueItem(comboBoxEditLopMoi));
            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked == true)
            {
                Util.MsgboxUtil.Success("Đã chuyển lại hết học sinh từ lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) + " trong năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi) + " về hồ sơ ");
            }
            else
                Util.MsgboxUtil.Success("Đã chuyển lại hết học sinh từ lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) + " trong năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi) + " sang lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop) + " trong năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc) + " thành công");
        }

        private void simpleButtonChuyenHet_Click(object sender, EventArgs e)
        {
            if (KiemTra_DuLieu())
            {
                string chuyen = "";
                if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked == true)
                {
                    chuyen = chuyen + " từ hồ sơ ";
                }
                else
                    chuyen = chuyen + Util.CboUtil.GetDisplayItem(comboBoxEditLop) + "trong năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc);
                if (MessageBox.Show("Bạn có muốn phân hết học sinh từ " + chuyen+ " sang lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) + " trong năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi) + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, 0, false) == DialogResult.Yes)
                {
                    ChuyenHet();
                    simpleButtonChuyenLaiTatCa.Enabled = false;
                    simpleButtonChuyenLai.Enabled = false;
                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked == true)
                    {
                        this._LoadGridcontrolDSHocSinh();
                    }
                    else
                        _LoadGridcontrolDSHocSinh();
                    LoadGridcontrolDSHocSinhMoi();

                }
            }
        }

        private void simpleButtonChuyenLaiTatCa_Click(object sender, EventArgs e)
        {
            if (KiemTra_DuLieu())
            {
                string chuyen = "";
                if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked == true)
                {
                    chuyen = chuyen + "về hồ sơ học sinh";
                }
                else
                    chuyen = chuyen + " về lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop) 
                            + " trong năm học " + Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc);
                    if (Util.MsgboxUtil.YesNo("Bạn có muốn chuyển lại hết học sinh từ lớp " 
                        + Util.CboUtil.GetDisplayItem(comboBoxEditLopMoi) 
                        + " trong năm học " 
                        + Util.CboUtil.GetDisplayItem(comboBoxEditNamHocMoi)
                        + chuyen + " không?") == DialogResult.Yes)
                {
                    string MaLop = (Util.CboUtil.GetValueItem(comboBoxEditLop));
                    int SiSoCanTren = _quyDinhBUS.LaySiSoCanTren();
                    if (_phanLopBUS.DemSiSoLop_HocSinhDangHoc(MaLop) >= SiSoCanTren)
                    {
                        Util.MsgboxUtil.Error("Lớp " + Util.CboUtil.GetDisplayItem(comboBoxEditLop)
                                                                    + " đã đủ học sinh theo quy định "
                                                                    + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                        return;
                    }
                    ChuyenHetLai();
                    simpleButtonChuyenHet.Enabled = false;
                    simpleButtonChuyenLop.Enabled = false;
                    if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked)
                    {
                        this._LoadGridcontrolDSHocSinh();
                    }
                    else
                        _LoadGridcontrolDSHocSinh();
                    LoadGridcontrolDSHocSinhMoi();

                }
            }
        }

        private void radioButtonChuyenLop_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonChuyenLopCungKhoi.Checked == true)
            {
                _Show_Control(YeuCau.ChuyenLop_CungKhoi);
            }
            LoadCbNamHocChung();
        }

        private void radioButtonPhanLopHocSinhMoi_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonPhanLopHoSo_ChuaPhanLop.Checked == true)
            {
                _Show_Control(YeuCau.PhanLop_HoSoChuaPhanLop);
            }
            LoadCbNamHocMoi();

            this._LoadGridcontrolDSHocSinh();

        }

        private void radioButtonPhanLopHocSinhCu_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPhanLopHocSinh_NamTruoc.Checked == true)
            {
                this._Show_Control(YeuCau.PhanLop_HoSoNamCu);

                LoadCbNamHocTruoc();
                
                if (KiemTraCbThongTinLopCu())
                { 
                    LoadCbNamHocMoi();   
                }
                else
                {
                    //radioButtonPhanLopHocSinh_NamTruoc.Checked = false;
                   // radioButtonPhanLopHocSinh_NamTruoc.Enabled = false;
                  //  this._Show_Control(YeuCau.PhanLop_HoSoChuaPhanLop);
                }
                
            }
            
        }

        private void simpleButtonLayHSo_Click(object sender, EventArgs e)
        {
            this._LoadGridcontrolDSHocSinh();
        }
    }
}