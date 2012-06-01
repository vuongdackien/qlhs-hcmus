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
        IList<TongKetHocKyDTO> _ds_baocaoTongKetHocKy;
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
            _ds_baocaoTongKetHocKy = null;
        }      
       
        /// <summary>
        /// Hiển thị bảng tổng kết học kỳ
        /// </summary>
        private void HienThi_Bang_TongKetHocKy()
        {
            string MaKhoi = Util.CboUtil.GetValueItem(comboBoxEditKhoiLop);
            string MaHocKy =  Util.CboUtil.GetValueItem(comboBoxEditHocKy);
            string MaNamHoc = Util.CboUtil.GetValueItem(comboBoxEditNamHoc);

            _ds_baocaoTongKetHocKy = _bangDiemBUS.Lay_BangTongKet_Khoi_HocKy(MaKhoi,MaHocKy,MaNamHoc);

            gridControlTongKetHocKy.DataSource = _ds_baocaoTongKetHocKy;

            labelControlNamHoc.Text = Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc);
            labelControlHocKyTT.Text = MaHocKy;
            labelControlKhoiLop.Text = MaKhoi;
        }
        
        private void frmBC_TongKetHocKy_Load(object sender, EventArgs e)
        {
            Util.CboUtil.SetDataSource(comboBoxEditNamHoc,
                                                        _namHocBUS.LayDTNamHoc(),
                                                       "MaNamHoc", "TenNamHoc", 0);
            Util.CboUtil.SetDataSource(comboBoxEditHocKy,
                                                        _hocKyBUS.LayDTHocKy(),
                                                        "MaHocKy", "TenHocKy", 0);
            Util.CboUtil.SetDataSource(comboBoxEditKhoiLop,
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

        private rptTongKetHocKy _rptTongKetHocKy;
        private frmReportView _frmReportView_TongKetHocKy;
        private void simpleButtonXuatBD_Click(object sender, EventArgs e)
        {
            if (_ds_baocaoTongKetHocKy.Count == 0)
            {
                Util.MsgboxUtil.Error("Không tồn tại lớp để thực hiện báo cáo!");
                return;
            }
            if (_rptTongKetHocKy == null)
                _rptTongKetHocKy = new rptTongKetHocKy();
            _rptTongKetHocKy.SetDataSource(_ds_baocaoTongKetHocKy);
            // Set parameter
            _rptTongKetHocKy.SetParameterValue("paramTenNamHoc",
                Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc));
            _rptTongKetHocKy.SetParameterValue("paramMaHocKy",
                Util.CboUtil.GetValueItem(comboBoxEditHocKy));
            _rptTongKetHocKy.SetParameterValue("paramMaKhoi",
                Util.CboUtil.GetValueItem(comboBoxEditKhoiLop));

            if (_frmReportView_TongKetHocKy == null || _frmReportView_TongKetHocKy.IsDisposed)
                _frmReportView_TongKetHocKy = new frmReportView();
            _frmReportView_TongKetHocKy.crystalReportViewer.ReportSource = _rptTongKetHocKy;
            _frmReportView_TongKetHocKy.ShowDialog();
        }
    }
}