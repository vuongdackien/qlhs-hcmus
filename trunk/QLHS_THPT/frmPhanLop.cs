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
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditKhoi) ||
               Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc(sender, e);
            
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
            if (checkEditChuyenLop.Checked == true)
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
            comboBoxEditLopMoi_SelectedIndexChanged(sender,e);
        }

        private void comboBoxEditLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLop))
            {
                gridControlDSHocSinh.DataSource = null;
                return;
            }
            LoadGridcontrolDSHocSinh(); 
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
                return;
            this.LoadComboboxLopHoc(sender, e);
            if (checkEditChuyenLop.Checked == true)
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiMoi, _KhoiBUS.LayDTKhoi_Chuyen(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)),"MaKhoi","TenKhoi",0);
            }
            else
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiMoi, _KhoiBUS.LayDTKhoi_PL(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);
        }

        private void frmChuyenLop_Load(object sender, EventArgs e)
        {
            
            HienThi(checkEditPhanLopHocSinhMoi.Checked);
            checkEditChuyenBangDiem.Enabled = false;
            textEditLyDoChuyen.Enabled = false;
            if (checkEditPhanLopHocSinhMoi.Checked == true)
            {
                LoadGridcontrolDSHocSinh_HoSo();
                for (int i = 0; i < gridViewDSHocSinh.RowCount; i++)
                {
                    gridViewDSHocSinh.SetRowCellValue(i, "STT", i + 1);
                }
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiMoi, _KhoiBUS.LayDTKhoi_10(), "MaKhoi", "TenKhoi", 0);
            }
            else
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocCu(),
                                                    "MaNamHoc", "TenNamHoc", 0);
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi, _KhoiBUS.LayDTKhoi(),
                                                    "MaKhoi", "TenKhoi", 0);
                if (checkEditChuyenLop.Checked == true)
                {
                    Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocCu(),
                                                    "MaNamHoc", "TenNamHoc", 0);
                }
                else
                {
                    Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocMoi(),
                                                        "MaNamHoc", "TenNamHoc", 0);
                }
            }
            simpleButtonChuyenLop.Enabled = false;
            simpleButtonChuyenLai.Enabled = false;
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
            this.loadComboboxLopHoc_Moi(sender, e);
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
            
            MaHocSinh_Focus = this.gridViewDSHocSinh.GetRowCellValue(dongHT_GridHocSinh, "MaHocSinh").ToString();
            string MaLop = (Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
            int SiSoCanTren = _quyDinhBUS.LaySiSoCanTren();
            if ( _PhanLopBUS.Dem_SiSo_Lop(MaLop) >= SiSoCanTren)
            {
                Utilities.MessageboxUtilities.MessageError("Lớp " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLopMoi)
                                                            + " đã đủ học sinh theo quy định "
                                                            + " (" + SiSoCanTren + " học sinh / 1 lớp)!");
                return;
            }
            DataTable dtKiemTra;
            if (checkEditChuyenLop.Checked == true)
            {
                dtKiemTra = _PhanLopBUS.KT_HocSinh_ChuyenLop(MaHocSinh_Focus.ToString(), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
            }
            else
            {
                dtKiemTra = _PhanLopBUS.KT_HocSinh_TonTai_NamHoc(MaHocSinh_Focus.ToString(), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi));
            }
            if (dtKiemTra.Rows.Count>0)
            {
                Utilities.MessageboxUtilities.MessageError("Học sinh " +MaHocSinh_Focus.ToString()
                                                           + " đã được chuyển tới lớp" + dtKiemTra.Rows[0][1]+ " ");
                return;
            }
            else
            {
                if (gridViewDSHocSinhMoi.RowCount > 0)
                {
                    _PhanLopBUS.CapNhap_STT_HocSinh_Lop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
                }
                if (_PhanLopBUS.ChuyenLop_HocSinh(MaHocSinh_Focus.ToString(), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi)))
                {
                    string tb = "Chuyển học sinh thành công";
                    if (checkEditChuyenLop.Checked == true)
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
                            if (_ChuyenLopBUS.ChuyenBangDiem(_ChuyenLopDTO.MaHocSinh, _ChuyenLopDTO.TuLop, _ChuyenLopDTO.DenLop))
                                tb = tb + ",Chuyển bảng điểm thành công";

                        }
                        if (_ChuyenLopBUS.LuuChuyenLop(_ChuyenLopDTO))
                            tb = tb + ",Đã lưu thông tin chuyển lớp";
                        Utilities.MessageboxUtilities.MessageSuccess(tb);
                    }
                    comboBoxEditLopMoi_SelectedIndexChanged(sender, e);
                    LoadGridcontrolDSHocSinh();
                    LoadGridcontrolDSHocSinhMoi();
                    if (checkEditPhanLopHocSinhMoi.Checked == true)
                    {
                        LoadGridcontrolDSHocSinh_HoSo();
                    }
                }
            }
            hienThi_Button();
        }

        private void gridViewDSHocSinhMoi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            if (e.FocusedRowHandle < 0)
                return;

            dongHT_GridHocSinhMoi = e.FocusedRowHandle;
        }

        private void checkEditPhanLopHocSinhMoi_CheckedChanged(object sender, EventArgs e)
        {
            frmChuyenLop_Load(sender,e);
            if (gridViewDSHocSinh.RowCount > 0)
            {
                MaHocSinh_Focus = gridViewDSHocSinh.GetRowCellValue(0, "MaHocSinh");
            }
            else
                simpleButtonChuyenLop.Enabled = false;
            checkEditChuyenLop.Enabled = false;
            if (checkEditHocSinhChuaChuyen.Checked == false && checkEditPhanLopHocSinhMoi.Checked == false)
            {
                checkEditChuyenLop.Enabled = true;
            }
        }
        void HienThi(bool xl)
        {
            comboBoxEditKhoi.Enabled = comboBoxEditNamHoc.Enabled = comboBoxEditLop.Enabled = !xl;

        }

        private void simpleButtonChuyenLai_Click(object sender, EventArgs e)
        {
            MaHocSinhMoi_Focus = this.gridViewDSHocSinhMoi.GetRowCellValue(dongHT_GridHocSinhMoi, "MaHocSinh").ToString();
            if (_PhanLopBUS.XoaHocSinh_Lop(MaHocSinhMoi_Focus.ToString(), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi)))
            {
                Utilities.MessageboxUtilities.MessageSuccess("Chuyển Học Sinh "+MaHocSinhMoi_Focus+" Thành công");
                LoadGridcontrolDSHocSinhMoi();
                if (gridViewDSHocSinhMoi.RowCount > 0)
                {
                    _PhanLopBUS.CapNhap_STT_HocSinh_Lop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
                }
                LoadGridcontrolDSHocSinh();
                if (checkEditPhanLopHocSinhMoi.Checked == true)
                {
                    LoadGridcontrolDSHocSinh_HoSo();
                }
            }
            hienThi_Button();
        }
        private void LoadGridcontrolDSHocSinhMoi()
        {
            if (checkEditHocSinhChuaChuyen.Checked == true && checkEditPhanLopHocSinhMoi.Checked == true)
            {
                gridControlDSHocSinhMoi.DataSource = _PhanLopBUS.LayDT_HocSinh_DaChuyen_TuHoSo(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
            }
            else
            {
                if (checkEditHocSinhChuaChuyen.Checked == true && checkEditPhanLopHocSinhMoi.Checked == false)
                {
                    gridControlDSHocSinhMoi.DataSource = _PhanLopBUS.LayDT_HocSinh_DaChuyen(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
                }
                else
                    gridControlDSHocSinhMoi.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
            }
        }
        private void LoadGridcontrolDSHocSinh()
        {
            if (checkEditHocSinhChuaChuyen.Checked == true&&checkEditPhanLopHocSinhMoi.Checked==false)
            {
                gridControlDSHocSinh.DataSource = _PhanLopBUS.LayDT_HocSinh_ChuaChuyenLop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi));
            }
            else
                if (checkEditPhanLopHocSinhMoi.Checked == false)
                    gridControlDSHocSinh.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop));
        }
        private void LoadGridcontrolDSHocSinh_HoSo()
        {
            gridControlDSHocSinh.DataSource = _HocSinhBUS.LayDT_HS_HocSinh();
        }

        private void gridViewDSHocSinh_MouseEnter(object sender, EventArgs e)
        {
            simpleButtonChuyenLop.Enabled = true;
            simpleButtonChuyenLai.Enabled = false;
            hienThi_Button();
        }

        private void gridViewDSHocSinhMoi_MouseEnter(object sender, EventArgs e)
        {
            simpleButtonChuyenLop.Enabled = false;
            if (checkEditChuyenLop.Checked == true)
            {
                simpleButtonChuyenLai.Enabled = false;
            }
            else
                simpleButtonChuyenLai.Enabled = true;
            hienThi_Button();
        }
        private void hienThi_Button()
        {
            if (gridViewDSHocSinh.RowCount == 0)
            {
                simpleButtonChuyenLop.Enabled = false;
                if (gridViewDSHocSinhMoi.RowCount > 0)
                    simpleButtonChuyenLai.Enabled = true;
            }
            if (gridViewDSHocSinhMoi.RowCount == 0)
            {
                simpleButtonChuyenLai.Enabled = false;
                 if (gridViewDSHocSinh.RowCount>0)
                     simpleButtonChuyenLop.Enabled = true;
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
                Utilities.MessageboxUtilities.MessageError("Chưa có lớp trong năm học này, bạn cần phải tạo lớp trước khi muốn chuyển");
                return false;
            }
            if (comboBoxEditNamHoc.SelectedItem == null)
            {
                Utilities.MessageboxUtilities.MessageError("Chưa có dữ liệu của năm cũ");
                return false;
            }
            if (comboBoxEditLop.SelectedItem == null)
            {
                Utilities.MessageboxUtilities.MessageError("Chưa có lớp trong năm học này, bạn cần phải tạo lớp trước khi muốn chuyển");
                return false;
            }
            return true;
        }
        private void AnHien_from(bool ah)
        {
            comboBoxEditNamHocMoi.Enabled = ah;
            comboBoxEditKhoiMoi.Enabled = ah;
            comboBoxEditLopMoi.Enabled = ah;
            comboBoxEditNamHoc.Enabled = ah;
            comboBoxEditKhoi.Enabled = ah;
            comboBoxEditLop.Enabled = ah;
            gridControlDSHocSinh.Enabled = ah;
            gridControlDSHocSinhMoi.Enabled = ah;
            checkEditHocSinhChuaChuyen.Enabled = ah;
            checkEditPhanLopHocSinhMoi.Enabled = ah;
        }

        private void checkEditHocSinhChuaChuyen_CheckedChanged(object sender, EventArgs e)
        {
            LoadGridcontrolDSHocSinh();
            LoadGridcontrolDSHocSinhMoi();
            checkEditChuyenLop.Enabled = false;
            if (checkEditHocSinhChuaChuyen.Checked == false && checkEditPhanLopHocSinhMoi.Checked == false)
            {
                checkEditChuyenLop.Enabled = true;
            }
        }

        private void checkEditChuyenLop_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEditKhoi_SelectedIndexChanged(sender, e);
            if (checkEditChuyenLop.Checked == true)
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocCu(),
                                                "MaNamHoc", "TenNamHoc", 0);
            }
            else
            {
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocMoi(),
                                                    "MaNamHoc", "TenNamHoc", 0);
            }
            if (checkEditChuyenLop.Checked == true)
            {
                groupBoxPhanLop.Enabled = false;
                checkEditChuyenBangDiem.Enabled = true;
                textEditLyDoChuyen.Enabled = true;
            }
            else
            {
                checkEditChuyenBangDiem.Checked = false;
                textEditLyDoChuyen.Text = "";
                groupBoxPhanLop.Enabled = true;
            }
        }
    }
}