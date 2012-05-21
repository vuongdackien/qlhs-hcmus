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

namespace QLHS
{
    public partial class frmBC_BangDiemHocKy : DevExpress.XtraEditors.XtraForm
    {

        private KhoiBUS _khoiBUS;
        private LopBUS _lopBUS;
        private NamHocBUS _namHocBUS;
        private BangDiemBUS _bangDiemBUS;
        private HocKyBUS _hocKyBUS;


        public frmBC_BangDiemHocKy()
        {
            InitializeComponent();

            _khoiBUS = new KhoiBUS();
            _lopBUS = new LopBUS();
            _namHocBUS = new NamHocBUS();
            _bangDiemBUS = new BangDiemBUS();
            _hocKyBUS = new HocKyBUS();
        }

        private void frmBangDiemMonHoc_Load(object sender, EventArgs e)
        {
            treeListLopHoc.ParentFieldName = "MaKhoi";
            treeListLopHoc.PreviewFieldName = "TenKhoi";
            treeListLopHoc.DataSource = _khoiBUS.LayDTKhoi();

            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,
                                                         _namHocBUS.LayDTNamHoc(),
                                                        "MaNamHoc", "TenNamHoc", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditHocKy,
                                                        _hocKyBUS.LayDTHocKy(),
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
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc),
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
            labelControlNamHoc.Text = Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEditNamHoc);
            labelControlLop.Text = treeListLopHoc.FocusedNode.GetValue("TenKhoi").ToString();
            labelControlHocKy.Text = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy);
            labelControlGVCN.Text = _lopBUS.Lay_TenGiaoVien_MaLop(maLop);
        }
       
        private void simpleButtonXuatBD_Click(object sender, EventArgs e)
        {
         
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
  
    }
}