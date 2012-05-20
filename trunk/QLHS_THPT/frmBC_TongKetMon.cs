using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLHS.Report;
using QLHS.BUS;
using QLHS.DTO;

namespace QLHS
{
    public partial class frmBC_TongKetMon : DevExpress.XtraEditors.XtraForm
    {
        private KhoiBUS _khoiBUS;
        private LopBUS _lopBUS;
        private NamHocBUS _namHocBUS;
        private BangDiemBUS _bangDiemBUS;
        private HocKyBUS _hocKyBUS;
        private MonHocBUS _monHocBUS;
        private BangDiemBUS _BangDiemBUS;
        public frmBC_TongKetMon()
        {
            InitializeComponent();
            _khoiBUS = new KhoiBUS();
            _lopBUS = new LopBUS();
            _namHocBUS = new NamHocBUS();
            _bangDiemBUS = new BangDiemBUS();
            _hocKyBUS = new HocKyBUS();
            _monHocBUS = new MonHocBUS();
            _BangDiemBUS = new BangDiemBUS();

        }
        /// <summary>
        /// Hiển thị bảng tổng kết môn
        /// </summary>
        private void HienThi_Bang_TongKetMon()
        {
            if (treeMonHoc.FocusedNode == null)
            {
                gridControlTongKetMonHoc.DataSource = null;
                return;
            }

            //Chắc chắn chọn được node
            string maMonHoc = treeMonHoc.FocusedNode.GetValue("MaMonHoc").ToString();
            gridControlTongKetMonHoc.DataSource =
            _bangDiemBUS.LayBangDiem_MonHoc(maMonHoc, Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiLop),
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy),  
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc));

            labelControlNamHoc.Text = Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc);
            labelControlHocKy.Text = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy);
            labelControlKhoiLop.Text = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiLop);
            labelControlMonHocTT.Text = treeMonHoc.FocusedNode.GetValue("TenMonHoc").ToString().ToUpper();      
        }
        private void frmBC_TongKetMon_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,
                                                        _namHocBUS.LayDTNamHoc(),
                                                       "MaNamHoc", "TenNamHoc", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditHocKy,
                                                        _hocKyBUS.LayDTHocKy(),
                                                        "MaHocKy", "TenHocKy", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoiLop,
                                                        _khoiBUS.LayDTKhoi(),
                                                        "MaKhoi", "TenKhoi", 0);

            treeMonHoc.ParentFieldName = "MaMonHoc";
            treeMonHoc.PreviewFieldName = "TenMonHoc";
            treeMonHoc.DataSource = _monHocBUS.LayDT_DanhSach_MonHoc();
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {           
            this.HienThi_Bang_TongKetMon();
        }

        private void comboBoxEditHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_Bang_TongKetMon();
        }

        private void comboBoxEditKhoiLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_Bang_TongKetMon();
        }

        private void treeMonHoc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.HienThi_Bang_TongKetMon();
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonXuatBD_Click(object sender, EventArgs e)
        {
            string MaMonHoc = treeMonHoc.FocusedNode.GetValue("MaMonHoc").ToString();
            string MaKhoi = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiLop);
            string MaHocKy = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy);            
            string MaNamHoc = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc);
            var ds = _BangDiemBUS.LayBangDiem_MonHoc(MaMonHoc,MaKhoi,MaHocKy,MaNamHoc);          
            var rp = new rptTongKetMon();
            rp.SetDataSource(ds);

            frmReportView_TongKetMon _frmReportView_TongKetMH = new frmReportView_TongKetMon();
            _frmReportView_TongKetMH.crystalReportViewerTongKetMonHoc.ReportSource = rp;
            _frmReportView_TongKetMH.ShowDialog();
        }
    }
}