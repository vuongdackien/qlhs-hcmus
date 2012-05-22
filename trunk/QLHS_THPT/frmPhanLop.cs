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
        private int dong_ht = -1;
        object MaHocSinh_Focus;
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
            gridControlDSHocSinh.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(
                 Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLop)
            );
           
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
            
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc, _NamHocBUS.LayDTNamHocCu(),
                                                "MaNamHoc", "TenNamHoc", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi, _KhoiBUS.LayDTKhoi(),
                                                "MaKhoi", "TenKhoi", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHocMoi, _NamHocBUS.LayDTNamHocMoi(),
                                                "MaNamHoc", "TenNamHoc", 0);
            
            
        }
       
        
        private void comboBoxEditLopMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditLopMoi))
            {
                gridControlDSHocSinhMoi.DataSource = null;
                return;
            }
            gridControlDSHocSinhMoi.DataSource = _HocSinhBUS.LayDTHocSinh_LopHoc(
                 Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi)
            );
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
          
            MaHocSinh_Focus = this.gridViewDSHocSinh.GetRowCellValue(e.FocusedRowHandle, "MaHocSinh").ToString();
            
            simpleButtonChuyenLop.Enabled = true;
            
        }

        private void simpleButtonChuyenLop_Click(object sender, EventArgs e)
        {

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
                Utilities.MessageboxUtilities.MessageError("Học sinh " + Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditLop)
                                                           + " đã được chuyển đi ");
                return;
            }
            else
            {
                if (_PhanLopBUS.ChuyenLop_HocSinh(MaHocSinh_Focus.ToString(), Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditLopMoi)))
                {
                    Utilities.MessageboxUtilities.MessageSuccess("Chuyển thành công");
                    comboBoxEditLopMoi_SelectedIndexChanged(sender, e);
                    simpleButtonChuyenLop.Enabled = false;
                }
            }
        }
       
    }
}