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
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditLopMoi,_LopBUS.LayDTLop_MaNam_MaKhoi(
                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi),
                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiMoi)),"MaLop","TenLop",0);
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
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiMoi, _KhoiBUS.LayDTKhoi_PL(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)), "MaKhoi", "TenKhoi", 0);
        }

        private void frmChuyenLop_Load(object sender, EventArgs e)
        {
            HienThi(checkEditPhanLopHocSinhMoi.Checked);
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
                Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocMoi(),
                                                    "MaNamHoc", "TenNamHoc", 0);
            }
            simpleButtonChuyenLop.Enabled = false;
            simpleButtonChuyenLai.Enabled = false;
            if (KiemTra_DuLieu()==false)
            {
                AnHien_from(KiemTra_DuLieu());
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
            if (_PhanLopBUS.KT_HocSinh_TonTai_NamHoc(MaHocSinh_Focus.ToString(), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi)))
            {
                Utilities.MessageboxUtilities.MessageError("Học sinh " +MaHocSinh_Focus.ToString()
                                                           + " đã được chuyển đi ");
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
                    Utilities.MessageboxUtilities.MessageSuccess("Chuyển thành công");
                    comboBoxEditLopMoi_SelectedIndexChanged(sender, e);
                    if (checkEditPhanLopHocSinhMoi.Checked == true)
                    {
                        LoadGridcontrolDSHocSinh_HoSo();
                    }
                    if (checkEditHocSinhChuaChuyen.Checked == true)
                    {
                        gridControlDSHocSinh.DataSource = _PhanLopBUS.LayDT_HocSinh_ChuaChuyenLop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi));
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
            checkEditHocSinhChuaChuyen.Checked = false;
            checkEditHocSinhChuaChuyen.Enabled = !checkEditPhanLopHocSinhMoi.Checked;
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
                if (checkEditPhanLopHocSinhMoi.Checked == true)
                {
                    LoadGridcontrolDSHocSinh_HoSo();
                }
                if (checkEditHocSinhChuaChuyen.Checked == true)
                {
                    gridControlDSHocSinh.DataSource = _PhanLopBUS.LayDT_HocSinh_ChuaChuyenLop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi));
                }
            }
            hienThi_Button();
        }
        private void LoadGridcontrolDSHocSinhMoi()
        {
            gridControlDSHocSinhMoi.DataSource=_HocSinhBUS.LayDTHocSinh_LopHoc(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi));
        }
        private void LoadGridcontrolDSHocSinh()
        {
            if (checkEditHocSinhChuaChuyen.Checked == true)
            {
                gridControlDSHocSinh.DataSource = _PhanLopBUS.LayDT_HocSinh_ChuaChuyenLop(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHocMoi));
            }
            else
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
        }
    }
}