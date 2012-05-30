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
        private HocSinhBUS _HocSinhBUS;
        private HocSinhDTO _hocSinhDTO;
        private PhanLopBUS _PhanLopBUS;
        private QuyDinhBUS _quyDinhBUS;
        private ChuyenLopDTO _ChuyenLopDTO;
        private ChuyenLopBUS _ChuyenLopBUS;
        object MaHocSinh_Focus, MaHocSinhMoi_Focus;
        private int dongHT_GridHocSinh, dongHT_GridHocSinhMoi = -1;
        public frmPhanLop()
        {
            InitializeComponent();
            _NamHocBUS = new NamHocBUS();
            _KhoiBUS = new KhoiBUS();
            _LopBUS = new LopBUS();
            _hocSinhDTO = new HocSinhDTO();
            _HocSinhBUS = new HocSinhBUS();
            _PhanLopBUS = new PhanLopBUS();
            _quyDinhBUS = new QuyDinhBUS();
            _ChuyenLopBUS = new ChuyenLopBUS();
            _ChuyenLopDTO = new ChuyenLopDTO();
        }
      

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
            {
                return;
            }
            if(radioButtonChuyenLop.Checked==true)
            {
                LoadCbKhoi_ChuyenLop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc));
            }
            else
            if (radioButtonPhanLopHocSinhCu.Checked == true)
            {
                LoadCbKhoi_PhanLopCu(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc));
            }
        }

        private void LoadComboboxLopHoc(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditLop, _LopBUS.LayDTLop_MaNam_MaKhoi(
                       Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc),
                         Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)
                    ), "MaLop", "TenLop", 0);
            
            comboBoxEditLop_SelectedIndexChanged(sender, e);
        }

        private void loadComboboxLopHoc_Moi(object sender, EventArgs e)
        {
            if (radioButtonChuyenLop.Checked == true)
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditLopMoi, _PhanLopBUS.LayDTLop_MaNam_MaKhoi_KhacMaLop(
                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi),
                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiMoi),
                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop)), "MaLop", "TenLop", 0);
            }
            else
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditLopMoi, _LopBUS.LayDTLop_MaNam_MaKhoi(
                        Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi),
                        Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiMoi)), "MaLop", "TenLop", 0);
            }
        }

        private void comboBoxEditLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLop))
            {
                gridControlDSHocSinh.DataSource = null;
                return;
            }
            LoadGridcontrolDSHocSinh();
            if (radioButtonChuyenLop.Checked == true)
            {
                this.loadComboboxLopHoc_Moi(sender, e);
            }
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc) || Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditKhoi))
                return;
            this.LoadComboboxLopHoc(sender, e);
            if (radioButtonChuyenLop.Checked == true)
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiMoi, 
                                            _PhanLopBUS.LayDTKhoi_Chuyen(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi),
                                            Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)), 
                                            "MaKhoi", "TenKhoi", 0);
                
            }
            else
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiMoi,
                                            _KhoiBUS.LayDTKhoi_PL(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)), 
                                            "MaKhoi", "TenKhoi", 0);
        }

        private void frmChuyenLop_Load(object sender, EventArgs e)
        {
            string tb = "";
            if (KiemTraTonTaiNamHocHT())
            {
                if (KiemTraKhoiLop_ChuyenLop(_NamHocBUS.LayDTNamHocHienTai().Rows[0][0].ToString()))
                {
                    LoadForm();
                    HienThiChuyenLop();
                }
                else
                    tb = tb + "Chưa có lớp trong năm học, bạn hãy tạo lớp trước khi sử dụng chức năng này";
            }
            else
            {
                tb = tb + "Trong dữ liệu chưa có năm học = năm học hiện tại trong quy định, "
                        + " bạn hãy tạo năm học trước khi sử dụng chức năng này";
            }
            if (tb != "")
            {
                Utilities.MessageboxUtilities.MessageError(tb);
                AnHien_from(false);
            }
        }
        private void comboBoxEditLopMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLopMoi))
            {
                gridControlDSHocSinhMoi.DataSource = null;
                return;
            }
            LoadGridcontrolDSHocSinhMoi();
        }

        private void comboBoxEditNamHocMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButtonPhanLopHocSinhCu.Checked == true)
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiMoi, 
                                                    _KhoiBUS.LayDTKhoi_PL(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)), 
                                                                        "MaKhoi", "TenKhoi", 0);
            if(radioButtonPhanLopHocSinhMoi.Checked==true)
            {
                LoadCbKhoiMoi_PhanLop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi));
            }
            if (radioButtonChuyenLop.Checked == true)
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiMoi, 
                                                    _PhanLopBUS.LayDTKhoi_Chuyen(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi), 
                                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);
            }
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
            dongHT_GridHocSinh = e.FocusedRowHandle;
        }

        private void simpleButtonChuyenLop_Click(object sender, EventArgs e)
        {
            if (KiemTra_DuLieu())
            {
                if (MessageBox.Show("Bạn có muốn chuyển học sinh " +
                    this.gridViewDSHocSinh.GetRowCellValue(dongHT_GridHocSinh, "TenHocSinh").ToString() 
                    + " trong lớp " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop) 
                    + " năm học " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc) 
                    + " sang lớp " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi) 
                    + " trong năm học " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHocMoi) + " không?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                    MessageBoxDefaultButton.Button1, 0, false) == DialogResult.Yes)
                {
                    MaHocSinh_Focus = this.gridViewDSHocSinh.GetRowCellValue(dongHT_GridHocSinh, "MaHocSinh").ToString();
                    string MaLop = (Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
                    int SiSoCanTren = _quyDinhBUS.LaySiSoCanTren();
                    if (_PhanLopBUS.Dem_SiSo_Lop(MaLop) >= SiSoCanTren)
                    {
                        Utilities.MessageboxUtilities.MessageError("Lớp "  
                                                                    + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi)
                                                                    + " đã đủ học sinh theo quy định "
                                                                    + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                        return;
                    }
                    DataTable dtKiemTra;
                    if (radioButtonChuyenLop.Checked == true)
                    {
                        dtKiemTra = _PhanLopBUS.KT_HocSinh_ChuyenLop(MaHocSinh_Focus.ToString(), 
                                                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
                    }
                    else
                    {
                        dtKiemTra = _PhanLopBUS.KT_HocSinh_TonTai_NamHoc(MaHocSinh_Focus.ToString(), 
                                                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi), 
                                                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi));
                    }
                    if (dtKiemTra.Rows.Count > 0)
                    {
                        Utilities.MessageboxUtilities.MessageError("Học sinh " + this.gridViewDSHocSinh.GetRowCellValue(dongHT_GridHocSinh, "MaHocSinh").ToString()
                                                                    + " - " + this.gridViewDSHocSinh.GetRowCellValue(dongHT_GridHocSinh, "TenHocSinh").ToString()
                                                                    + " đã được chuyển đến lớp" + dtKiemTra.Rows[0][1] + " ");
                        return;
                    }
                    else
                    {
                        if (gridViewDSHocSinhMoi.RowCount > 0)
                        {
                            _PhanLopBUS.CapNhap_STT_HocSinh_Lop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
                        }
                        if (_PhanLopBUS.ChuyenLop_HocSinh(MaHocSinh_Focus.ToString(), 
                                                            Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi)))
                        {
                            string tb = "Chuyển học sinh thành công";
                            if (radioButtonChuyenLop.Checked == true)
                            {
                                DateTime dDate = DateTime.Now;
                                _ChuyenLopDTO.TuLop = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop);
                                _ChuyenLopDTO.DenLop = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi);
                                _ChuyenLopDTO.NgayChuyen = dDate.ToString("dd-MM-yyy");
                                _ChuyenLopDTO.LyDoChuyen = textEditLyDoChuyen.Text.ToString();
                                _ChuyenLopDTO.ChuyenBangDiem = Convert.ToString(checkEditChuyenBangDiem.Checked);
                                _ChuyenLopDTO.MaHocSinh = MaHocSinh_Focus.ToString();
                                if (checkEditChuyenBangDiem.Checked == true)
                                {
                                    if (_ChuyenLopBUS.KT_HocSinhCo_BangDiem(MaHocSinh_Focus.ToString(), 
                                                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop)))
                                    {
                                        if (_ChuyenLopBUS.ChuyenBangDiem(_ChuyenLopDTO.MaHocSinh, 
                                                                            _ChuyenLopDTO.TuLop, _ChuyenLopDTO.DenLop))
                                            tb = tb + ",Chuyển bảng điểm thành công";
                                    }
                                    else
                                    {
                                        tb = tb + ", chuyển bảng điểm không thành công vì học sinh này chưa có điểm";
                                        _ChuyenLopDTO.ChuyenBangDiem = "false";
                                    }

                                }
                                if (_ChuyenLopBUS.LuuChuyenLop(_ChuyenLopDTO))
                                    tb = tb + ", Đã lưu thông tin chuyển lớp";

                            }
                            Utilities.MessageboxUtilities.MessageSuccess(tb);
                            comboBoxEditLopMoi_SelectedIndexChanged(sender, e);
                            LoadGridcontrolDSHocSinh();
                            LoadGridcontrolDSHocSinhMoi();
                            if (radioButtonPhanLopHocSinhMoi.Checked == true)
                            {
                                LoadGridcontrolDSHocSinh_HoSo();
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

            dongHT_GridHocSinhMoi = e.FocusedRowHandle;
        }
        void HienThi(bool xl)
        {
            comboBoxEditKhoi.Enabled = comboBoxEditNamHoc.Enabled = comboBoxEditLop.Enabled = !xl;

        }

        private void simpleButtonChuyenLai_Click(object sender, EventArgs e)
        {
            if (KiemTra_DuLieu())
            {
                if (MessageBox.Show("Bạn có muốn chuyển lại học sinh " 
                                    + this.gridViewDSHocSinhMoi.GetRowCellValue(dongHT_GridHocSinhMoi, "TenHocSinh").ToString()
                                    + " trong lớp" + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi) 
                                    + " năm học " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHocMoi) 
                                    + " sang lớp " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop) 
                                    + " trong năm học " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc) 
                                    + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button1, 0, false) == DialogResult.Yes)
                {
                    MaHocSinhMoi_Focus = this.gridViewDSHocSinhMoi.GetRowCellValue(dongHT_GridHocSinhMoi, "MaHocSinh").ToString();
                    int flag = 1;
                    string tb = "";
                    if (radioButtonChuyenLop.Checked == true)
                    {
                        if (_ChuyenLopBUS.KTHocSinhThuocLop_DuocChuyenTuLop(MaHocSinhMoi_Focus.ToString(), 
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi), 
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop)))
                        {
                            if (_ChuyenLopBUS.KT_HocSinhCo_BangDiem(MaHocSinhMoi_Focus.ToString(), 
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi)))
                            {
                                if (_ChuyenLopBUS.ChuyenBangDiem(MaHocSinhMoi_Focus.ToString(), 
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi), 
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop)))
                                {
                                    tb = tb + "Đã chuyển lại bảng điểm, ";
                                }
                            }
                            _ChuyenLopBUS.XoaChuyenLop(MaHocSinhMoi_Focus.ToString(), 
                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop), 
                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
                        }
                        else
                        {
                            Utilities.MessageboxUtilities.MessageError("Học sinh này không được chuyển từ lớp " 
                                + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop) 
                                + " hoặc không còn trong lớp " + 
                                Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi) + "");
                            flag = 0;
                        }
                    }
                    if (flag == 1)
                    {
                        if (_PhanLopBUS.XoaHocSinh_Lop(MaHocSinhMoi_Focus.ToString(), 
                            Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi)))
                        {
                            tb = tb + "Chuyển học sinh " 
                                    + this.gridViewDSHocSinhMoi.GetRowCellValue(dongHT_GridHocSinhMoi, "MaHocSinh").ToString()
                                    + " - " + this.gridViewDSHocSinhMoi.GetRowCellValue(dongHT_GridHocSinhMoi, "TenHocSinh").ToString()
                                    + " về lớp cũ thành công";
                            Utilities.MessageboxUtilities.MessageSuccess(tb);

                            LoadGridcontrolDSHocSinhMoi();
                            if (gridViewDSHocSinhMoi.RowCount > 0)
                            {
                                _PhanLopBUS.CapNhap_STT_HocSinh_Lop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
                            }
                            LoadGridcontrolDSHocSinh();
                            if (radioButtonPhanLopHocSinhMoi.Checked == true)
                            {
                                LoadGridcontrolDSHocSinh_HoSo();
                            }
                        }
                    }
                    hienThi_Button();
                }
            }
        }
        private void LoadGridcontrolDSHocSinhMoi()
        {
            if (checkEditHocSinhChuaChuyen.Checked == true && radioButtonPhanLopHocSinhMoi.Checked == true)
            {
                gridControlDSHocSinhMoi.DataSource = _PhanLopBUS.LayDT_HocSinh_DaChuyen_TuHoSo(
                                                        Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
            }
            else
            {
                if (checkEditHocSinhChuaChuyen.Checked == true && radioButtonPhanLopHocSinhCu.Checked == true)
                {
                    gridControlDSHocSinhMoi.DataSource = _PhanLopBUS.LayDT_HocSinh_DaChuyen(
                                                            Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi), 
                                                            Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
                }
                else
                {
                    gridControlDSHocSinhMoi.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(
                                                            Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
                }
            }
            
        }
        private void LoadGridcontrolDSHocSinh()
        {
            if (checkEditHocSinhChuaChuyen.Checked == true &&radioButtonPhanLopHocSinhCu.Checked == true)
            {
                gridControlDSHocSinh.DataSource = _PhanLopBUS.LayDT_HocSinh_ChuaChuyenLop(
                                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop), 
                                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi));
            }
            else
                if (radioButtonPhanLopHocSinhMoi.Checked == false)
                        gridControlDSHocSinh.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(
                                                              Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
        }
        private void LoadGridcontrolDSHocSinh_HoSo()
        {
            gridControlDSHocSinh.DataSource = _HocSinhBUS.LayDT_HS_HocSinh();
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
            if (radioButtonChuyenLop.Checked == true)
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
                    if (radioButtonChuyenLop.Checked == true)
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
            if (comboBoxEditNamHocMoi.SelectedItem==null)
            {
                Utilities.MessageboxUtilities.MessageError("Bạn cần phải tạo năm học mới");
                return false;
            }
            if (comboBoxEditLopMoi.SelectedItem == null)
            {
                Utilities.MessageboxUtilities.MessageError("Chưa có lớp trong năm học này, "
                                                         + "  bạn cần phải tạo lớp trước khi muốn chuyển");
                return false;
            }
            return true;
        }
        private void AnHien_from(bool ah)
        {
            groupControl1.Enabled = ah;
            groupControl2.Enabled = ah;
            gridControlDSHocSinh.Enabled = ah;
            gridControlDSHocSinhMoi.Enabled = ah;
            groupBoxChuyenLop.Enabled = ah;
            groupBoxPhanLop.Enabled = ah;
            simpleButtonDong.Enabled = true;
            simpleButtonChuyenLaiTatCa.Enabled = simpleButtonChuyenLai.Enabled 
                                                = simpleButtonChuyenHet.Enabled = simpleButtonChuyenLop.Enabled = ah;
            
        }

        private void checkEditHocSinhChuaChuyen_CheckedChanged(object sender, EventArgs e)
        {   
            LoadGridcontrolDSHocSinh();
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
            if (radioButtonChuyenLop.Checked == true)
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocHienTai(),
                                                "MaNamHoc", "TenNamHoc", 0);
            }
            else
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocCu(),
                                                    "MaNamHoc", "TenNamHoc", 0);
            }
            if (radioButtonChuyenLop.Checked == true)
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
            for (i = 0; i < gridViewDSHocSinh.RowCount; i++)
            {
                string MaLop = (Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
                int SiSoCanTren = _quyDinhBUS.LaySiSoCanTren();
                if (_PhanLopBUS.Dem_SiSo_Lop(MaLop) >= SiSoCanTren)
                {
                    Utilities.MessageboxUtilities.MessageError("Lớp " 
                                                                + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi)
                                                                + " đã đủ học sinh theo quy định "
                                                                + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                    break;
                }
                _PhanLopBUS.ChuyenLop_HocSinh(gridViewDSHocSinh.GetRowCellValue(i, "MaHocSinh").ToString(),
                                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
            }
            if (i < gridViewDSHocSinh.RowCount)
            {
                tb = tb + "Chuyển được " + i + 1 + " học sinh";
            }
            else
                tb = tb + "Chuyển hết học sinh";
                Utilities.MessageboxUtilities.MessageSuccess("" + tb + " từ lớp " 
                                                            + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop) 
                                                            + " trong năm học " 
                                                            + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc) 
                                                            + " sang lớp " 
                                                            + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi) 
                                                            + " trong năm học " 
                                                            + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHocMoi)
                                                            + " thành công");
        }
        private void ChuyenHetLai()
        {
            for (int i = 0; i < gridViewDSHocSinhMoi.RowCount; i++)
            {
                _PhanLopBUS.XoaHocSinh_Lop(gridViewDSHocSinhMoi.GetRowCellValue(i, "MaHocSinh").ToString(), 
                                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
            }
            Utilities.MessageboxUtilities.MessageSuccess("Đã chuyển lại hết học sinh từ lớp " 
                                                            + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi)
                                                            + " trong năm học " 
                                                            + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHocMoi) 
                                                            + " sang lớp "
                                                            + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop) 
                                                            + " trong năm học "
                                                            + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc) 
                                                            + " thành công");
        }

        private void simpleButtonChuyenHet_Click(object sender, EventArgs e)
        {
            if (KiemTra_DuLieu())
            {
                if (MessageBox.Show("Bạn có muốn chuyển hết học sinh từ lớp" 
                                    + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop) 
                                    + "trong năm học " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc) 
                                    + " sang lớp " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi) 
                                    + " trong năm học " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHocMoi)
                                    + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                                    MessageBoxDefaultButton.Button1, 0, false) == DialogResult.Yes)
                {
                    ChuyenHet();
                    simpleButtonChuyenLaiTatCa.Enabled = false;
                    simpleButtonChuyenLai.Enabled = false;
                    if (radioButtonPhanLopHocSinhMoi.Checked == true)
                    {
                        LoadGridcontrolDSHocSinh_HoSo();
                    }
                    else
                        LoadGridcontrolDSHocSinh();
                    LoadGridcontrolDSHocSinhMoi();

                }
            }
        }

        private void simpleButtonChuyenLaiTatCa_Click(object sender, EventArgs e)
        {
            if (KiemTra_DuLieu())
            {
                if (MessageBox.Show("Bạn có muốn chuyển lại hết học sinh từ lớp" 
                                    + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi) 
                                    + "trong năm học " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHocMoi) 
                                    + " sang lớp " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop) 
                                    + " trong năm học " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc)
                                    + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                                    MessageBoxDefaultButton.Button1, 0, false) == DialogResult.Yes)
                {
                    ChuyenHetLai();
                    simpleButtonChuyenHet.Enabled = false;
                    simpleButtonChuyenLop.Enabled = false;
                    if (radioButtonPhanLopHocSinhMoi.Checked == true)
                    {
                        LoadGridcontrolDSHocSinh_HoSo();
                    }
                    else
                        LoadGridcontrolDSHocSinh();
                    LoadGridcontrolDSHocSinhMoi();

                }
            }
        }
        private string GetValueCombobox(ComboBoxEdit cb)
        {
            return Utilities.ComboboxEditUtilities.GetValueItem(cb);
        }

        private void radioButtonChuyenLop_CheckedChanged(object sender, EventArgs e)
        {
            HienThiThucHien();
            if (radioButtonChuyenLop.Checked == true)
            {
                radioButtonPhanLopHocSinhCu.Checked = false;
                radioButtonPhanLopHocSinhMoi.Checked = false;
            }
            HienThiChuyenLop();
            HienThigGroupChyenLop_PhanLopNew(radioButtonPhanLopHocSinhMoi.Checked);
            LoadCbNamHocChung();
        }

        private void radioButtonPhanLopHocSinhMoi_CheckedChanged(object sender, EventArgs e)
        {
            HienThiThucHien();
            if (radioButtonPhanLopHocSinhMoi.Checked == true)
            {
                radioButtonChuyenLop.Checked = false;
            }
            HienThiChuyenLop();
            HienThigGroupChyenLop_PhanLopNew(radioButtonPhanLopHocSinhMoi.Checked);
            LoadCbNamHocMoi();
            LoadGridcontrolDSHocSinh_HoSo();
            for (int i = 0; i < gridViewDSHocSinh.RowCount; i++)
            {
                gridViewDSHocSinh.SetRowCellValue(i, "STT", i + 1);
            }
        }

        private void radioButtonPhanLopHocSinhCu_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPhanLopHocSinhCu.Checked == true)
            {
                radioButtonChuyenLop.Checked = false;
                HienThiChuyenLop();
                HienThigGroupChyenLop_PhanLopNew(radioButtonPhanLopHocSinhMoi.Checked);
                LoadCbNamHocCu();
                if (KiemTraCbThongTinLopCu())
                { 
                    LoadCbNamHocMoi();   
                }
                else
                {
                    radioButtonPhanLopHocSinhCu.Checked = false;
                    radioButtonPhanLopHocSinhCu.Enabled = false;
					HienThiFormGapLoi(false);
                }
                
            }
            
        }
        private void LoadCbNamHocChung()
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocHienTai(), 
                                                                "MaNamHoc", "TenNamHoc", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocHienTai(), 
                                                                 "MaNamHoc", "TenNamHoc", 0);
        }
        private void LoadCbNamHocMoi()
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocHienTai(), 
                                                                "MaNamHoc", "TenNamHoc", 0);
        }
        private void LoadCbKhoiMoi_PhanLop(string MaNamHoc)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiMoi,_PhanLopBUS.LayDTKhoi10(MaNamHoc),
                                                            "MaKhoi","TenKHoi",0);
        }
        private void LoadCbKhoi_ChuyenLop(string MaNamHoc)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi, _PhanLopBUS.LayDTKhoi(MaNamHoc), 
                                                                "MaKhoi", "TenKHoi", 0);
        }
        private void LoadCbNamHocCu()
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocCu(), 
                                                                "MaNamHoc", "TenNamHoc", 0);
        }
        private void LoadCbKhoi_PhanLopCu(string MaNamHoc)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi,_PhanLopBUS.LayDTKhoi_PhanLopCu(MaNamHoc),
                                                                "MaKhoi","TenKhoi",0);
        }
        private void HienThiChuyenLop()
        {
            if (radioButtonChuyenLop.Checked == true)
            {
                checkEditChuyenBangDiem.Enabled = true;
                textEditLyDoChuyen.Enabled = true;
                checkEditHocSinhChuaChuyen.Enabled= false;
                checkEditHocSinhChuaChuyen.Checked = false;
            }
            else
            {
                checkEditChuyenBangDiem.Enabled = false;
                textEditLyDoChuyen.Enabled = false;
                textEditLyDoChuyen.Text = "";
                if (radioButtonPhanLopHocSinhCu.Checked == false && radioButtonPhanLopHocSinhMoi.Checked == false)
                {
                    checkEditHocSinhChuaChuyen.Enabled = false;
                }
                else
                    checkEditHocSinhChuaChuyen.Enabled = true;
            }
        }
        private bool KiemTraTonTaiNamHocHT()
        {
            return _NamHocBUS.LayDTNamHocHienTai().Rows.Count > 0;
        }
        private void HienThigGroupChyenLop_PhanLopNew(bool ht)
        {
            groupControl1.Enabled = !ht;
        }
        private bool KiemTraCbThongTinLopCu()
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
            {
                Utilities.MessageboxUtilities.MessageError("Không có năm học sau năm học hiện tại, bạn hãy chọn chức năng khác");
                return false;

            }
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditKhoi))
            {
                Utilities.MessageboxUtilities.MessageError("Năm học này không tồn tại lớp học");
                return false;
            }
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLop))
            {
                Utilities.MessageboxUtilities.MessageError("Năm học này không có lớp");
                return false;
            }
            return true;
        }
        private bool KiemTraCbThongTinLopMoi()
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHocMoi))
            {
                Utilities.MessageboxUtilities.MessageError("Không có năm học sau năm học hiện tại, bạn hãy chọn chức năng khác");
                return false;

            }
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditKhoiMoi))
            {
                Utilities.MessageboxUtilities.MessageError("Năm học này không tồn tại lớp học");
                return false;
            }
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLopMoi))
            {
                Utilities.MessageboxUtilities.MessageError("Năm học này không có lớp");
                return false;
            }
            return true;
        }
        private bool KiemTraKhoiLop_ChuyenLop(string MaNamHoc)
        {
            return _PhanLopBUS.LayDTKhoi(MaNamHoc).Rows.Count>0;
        }
		private void HienThiFormGapLoi(bool ht)
        {
            groupControl1.Enabled=ht;
            groupControl2.Enabled=ht;
            gridControlDSHocSinh.Enabled=ht;
            gridControlDSHocSinhMoi.Enabled=ht;
        }
        private void HienThiThucHien()
        {
            if (groupControl1.Enabled == false)
            {
                groupControl1.Enabled = true;
            }
            if (groupControl2.Enabled == false)
            {
                groupControl2.Enabled = true;
            }
            if (gridControlDSHocSinh.Enabled == false)
            {
                gridControlDSHocSinh.Enabled = true;
            }
            if (gridControlDSHocSinhMoi.Enabled == false)
            {
                gridControlDSHocSinhMoi.Enabled = true;
            }
            
        }
        private void LoadForm()
        {
            simpleButtonChuyenLop.Enabled = false;
            simpleButtonChuyenLai.Enabled = false;
            simpleButtonChuyenHet.Enabled = false;
            simpleButtonChuyenLaiTatCa.Enabled = false;
        }   
    }
}