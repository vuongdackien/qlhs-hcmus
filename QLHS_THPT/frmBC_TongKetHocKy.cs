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
        List<TongKetHocKyDTO> _ds_baocaoTongKetHocKy;
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
        /// Hiển thị bảng tổng kết môn
        /// </summary>
        private void HienThi_Bang_TongKetHocKy()
        {
            _ds_baocaoTongKetHocKy = _bangDiemBUS.LayBangDiem_BaoCao_HocKy(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiLop),
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy),
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc));

            gridControlTongKetHocKy.DataSource = _ds_baocaoTongKetHocKy;

            labelControlNamHoc.Text = Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc);
            labelControlHocKyTT.Text = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy);
            labelControlKhoiLop.Text = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiLop);
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

        private rptTongKetHocKy _rptTongKetHocKy;
        private frmReportView_TongKetHocKy _frmReportView_TongKetHocKy;
        private void simpleButtonXuatBD_Click(object sender, EventArgs e)
        {
            if (_ds_baocaoTongKetHocKy.Count == 0)
            {
                Utilities.MessageboxUtilities.MessageError("Không tồn tại lớp để thực hiện báo cáo!");
                return;
            }
            if (_rptTongKetHocKy == null)
                _rptTongKetHocKy = new rptTongKetHocKy();
            _rptTongKetHocKy.SetDataSource(_ds_baocaoTongKetHocKy);
            // Set parameter
            _rptTongKetHocKy.SetParameterValue("paramTenNamHoc",
                Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc));
            _rptTongKetHocKy.SetParameterValue("paramMaHocKy",
                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy));
            _rptTongKetHocKy.SetParameterValue("paramMaKhoi",
                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoiLop));

            if (_frmReportView_TongKetHocKy == null || _frmReportView_TongKetHocKy.IsDisposed)
                _frmReportView_TongKetHocKy = new frmReportView_TongKetHocKy();
            _frmReportView_TongKetHocKy.crystalReportViewerTongKetHocKy.ReportSource = _rptTongKetHocKy;
            _frmReportView_TongKetHocKy.ShowDialog();
        }
    }
}