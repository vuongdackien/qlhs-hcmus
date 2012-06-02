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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Controls;
using QLHS.Report;

namespace QLHS
{
    public partial class frmBC_BangDiemHocKy : DevExpress.XtraEditors.XtraForm
    {

        private KhoiBUS _khoiBUS;
        private LopBUS _lopBUS;
        private NamHocBUS _namHocBUS;
        private BangDiemBUS _bangDiemBUS;
        private HocKyBUS _hocKyBUS;
        List<BangDiemHocKyDTO> _bangDiemHocKyDTO;

        public frmBC_BangDiemHocKy()
        {
            InitializeComponent();

            _khoiBUS = new KhoiBUS();
            _lopBUS = new LopBUS();
            _namHocBUS = new NamHocBUS();
            _bangDiemBUS = new BangDiemBUS();
            _hocKyBUS = new HocKyBUS();
            _bangDiemHocKyDTO = null;
        }

        private void frmBangDiemMonHoc_Load(object sender, EventArgs e)
        {
            treeListLopHoc.ParentFieldName = "MaKhoi";
            treeListLopHoc.PreviewFieldName = "TenKhoi";
            treeListLopHoc.DataSource = _khoiBUS.LayDT_Khoi();
            
            Util.CboUtil.SetDataSource(comboBoxEditNamHoc,
                                                         _namHocBUS.LayDTNamHoc(),
                                                        "MaNamHoc", "TenNamHoc", 0);
            Util.CboUtil.SetDataSource(comboBoxEditHocKy,
                                                        _hocKyBUS.LayDT_HocKy(),
                                                        "MaHocKy", "TenHocKy", 0);

            this.CapNhatListLop();
        }

        /// <summary>
        /// Cập nhật lại list lớp theo khối
        /// </summary>
        private void CapNhatListLop()
        {
            List<LopDTO> list_LopNode;
            // Duyệt từng khối
            foreach (TreeListNode item in treeListLopHoc.Nodes)
            {

                item.Nodes.Clear();
                list_LopNode = _lopBUS.LayListLop_MaNam_MaKhoi(
                                    Util.CboUtil.GetValueItem(comboBoxEditNamHoc),
                                    item.GetValue("MaKhoi").ToString()
                               );
                // add các lớp vào khối item
                foreach (LopDTO lopNode in list_LopNode)
                {
                    this.treeListLopHoc.AppendNode(new object[] { lopNode.MaLop, lopNode.TenLop }, item);
                }
            }
            treeListLopHoc.ExpandAll(); // Expand all nodes
        }
        
        /// <summary>
        /// Hiển thị lại bảng điểm
        /// </summary>
        private void HienThi_Lai_BangDiem()
        {
            // Chắc chắn chọn được node
            if (treeListLopHoc.FocusedNode == null)
            {
               // gridControlTongKetNamHoc.DataSource = null;
                return;
            }
            
            string maLop = treeListLopHoc.FocusedNode.GetValue("MaKhoi").ToString();
            _bangDiemHocKyDTO = _bangDiemBUS.LayList_BangDiem_Lop_HocKy(maLop,
                                                        Util.CboUtil.GetValueItem(comboBoxEditHocKy));
            gridControlBangDiemHocKy.DataSource = _bangDiemHocKyDTO;
            labelControlNamHoc.Text = Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc);
            labelControlLop.Text = treeListLopHoc.FocusedNode.GetValue("TenKhoi").ToString();
            labelControlHocKy.Text = Util.CboUtil.GetValueItem(comboBoxEditHocKy);
            labelControlGVCN.Text = _lopBUS.LayTenGiaoVien_MaLop(maLop);
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CapNhatListLop();
            this.HienThi_Lai_BangDiem();
        }

        private void comboBoxEditHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_Lai_BangDiem();
        }
        
        private void comboBoxEditMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_Lai_BangDiem();
        }

        private void treeListLopHoc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.HienThi_Lai_BangDiem();
        }
        private rptBangDiemHocKy _rptTongKetHocKy;
        private QLHS.Report.frmReportView _frmReportView;
        private void simpleButtonXuatBD_Click(object sender, EventArgs e)
        {
            if (_rptTongKetHocKy == null)
                _rptTongKetHocKy = new rptBangDiemHocKy();
            if (_frmReportView == null || _frmReportView.IsDisposed)
                _frmReportView = new frmReportView();
            _rptTongKetHocKy.SetDataSource(_bangDiemHocKyDTO);
            // Set parameter
            _rptTongKetHocKy.SetParameterValue("paramTenNam",labelControlNamHoc.Text);
            _rptTongKetHocKy.SetParameterValue("paramHocKy",labelControlHocKy.Text);
            _rptTongKetHocKy.SetParameterValue("paramGVCN", labelControlGVCN.Text);
            _rptTongKetHocKy.SetParameterValue("paramTenLop", labelControlLop.Text);

            
            _frmReportView.crystalReportViewer.ReportSource = _rptTongKetHocKy;
            _frmReportView.ShowDialog();
        }
  
    }
}