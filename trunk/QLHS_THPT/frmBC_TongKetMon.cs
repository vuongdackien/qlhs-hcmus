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
        List<TongKetMonDTO> _ds_baocaoTongKetMonHoc;
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
            _ds_baocaoTongKetMonHoc = null;

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
            _ds_baocaoTongKetMonHoc = _bangDiemBUS.Lay_BangTongKet_MonHoc_Khoi_HocKy(maMonHoc, Util.CboUtil.GetValueItem(comboBoxEditKhoiLop),
                                    Util.CboUtil.GetValueItem(comboBoxEditHocKy),
                                    Util.CboUtil.GetValueItem(comboBoxEditNamHoc));
            gridControlTongKetMonHoc.DataSource = _ds_baocaoTongKetMonHoc;
           

            labelControlNamHoc.Text = Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc);
            labelControlHocKy.Text = Util.CboUtil.GetValueItem(comboBoxEditHocKy);
            labelControlKhoiLop.Text = Util.CboUtil.GetValueItem(comboBoxEditKhoiLop);
            labelControlMonHocTT.Text = treeMonHoc.FocusedNode.GetValue("TenMonHoc").ToString().ToUpper();      
        }

        private void frmBC_TongKetMon_Load(object sender, EventArgs e)
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

        private rptTongKetMon _rptTongKetMon;
        private frmReportView _frmReportView_TongKetMon;
        private void simpleButtonXuatBD_Click(object sender, EventArgs e)
        {
            if(_ds_baocaoTongKetMonHoc.Count == 0)
            {
                Util.MsgboxUtil.Error("Không tồn tại lớp để thực hiện báo cáo!");
                return;
            }
            if(_rptTongKetMon == null)
                 _rptTongKetMon = new rptTongKetMon();
            _rptTongKetMon.SetDataSource(_ds_baocaoTongKetMonHoc);
            // Set parameter
            _rptTongKetMon.SetParameterValue("paramTenMonHoc", 
                treeMonHoc.FocusedNode.GetValue("TenMonHoc").ToString().ToUpper());
            _rptTongKetMon.SetParameterValue("paramTenNamHoc", 
                Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc));
            _rptTongKetMon.SetParameterValue("paramMaHocKy",
                Util.CboUtil.GetValueItem(comboBoxEditHocKy));
            _rptTongKetMon.SetParameterValue("paramMaKhoi",
                Util.CboUtil.GetValueItem(comboBoxEditKhoiLop));
            
            if(_frmReportView_TongKetMon == null || _frmReportView_TongKetMon.IsDisposed)
                _frmReportView_TongKetMon = new frmReportView();
            _frmReportView_TongKetMon.crystalReportViewer.ReportSource = _rptTongKetMon;
            _frmReportView_TongKetMon.ShowDialog();
        }
    }
}