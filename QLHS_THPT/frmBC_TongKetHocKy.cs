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
    public partial class frmBC_TongKetHocKy : DevExpress.XtraEditors.XtraForm
    {
       private KhoiBUS _khoiBUS;
        private LopBUS _lopBUS;
        private NamHocBUS _namHocBUS;
        private BangDiemBUS _bangDiemBUS;
        private HocKyBUS _hocKyBUS;
        private MonHocBUS _monHocBUS;
        private BangDiemBUS _BangDiemBUS;

        public frmBC_TongKetHocKy()
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
        private void HienThi_Bang_TongKetHocKy()
        {
            gridControlTongKetHocKy.DataSource =
            _bangDiemBUS.LayBangDiem_HocKy(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiLop),
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy), 
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc));

            labelControlNamHoc.Text = Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc);
            labelControlHocKyTT.Text = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy);
            labelControlKhoiLop.Text = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiLop);            
        }

        private void simpleButtonXuatBD_Click(object sender, EventArgs e)
        {
           string MaKhoi = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiLop);
            string MaHocKy = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy);
            string MaNamHoc = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc);
            var ds = _BangDiemBUS.LayBangDiem_HocKy(MaKhoi,MaHocKy,MaNamHoc);          
            var rp = new rptTongKetHocKy();
            rp.SetDataSource(ds);

            frmReportView_TongKetHocKy _frmReportView_TongKetHK = new frmReportView_TongKetHocKy();
            _frmReportView_TongKetHK.crystalReportViewerTongKetHocKy.ReportSource = rp;
            _frmReportView_TongKetHK.ShowDialog();
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBC_TongKetHocKy_Load(object sender, EventArgs e)
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
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_Bang_TongKetHocKy();
        }

        private void comboBoxEditHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_Bang_TongKetHocKy();
        }

        private void comboBoxEditKhoiLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_Bang_TongKetHocKy();
        }

        private void treeMonHoc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.HienThi_Bang_TongKetHocKy();
        }
    }
}