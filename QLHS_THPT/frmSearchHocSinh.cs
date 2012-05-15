using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList.Nodes;
using QLHS.DTO;
using QLHS.BUS;

namespace QLHS
{
    public partial class frmSearchHocSinh : DevExpress.XtraEditors.XtraForm
    {
        private KhoiBUS _KhoiBUS;
        private LopBUS _LopBUS;
        private NamHocBUS _NamHocBUS;
        public frmSearchHocSinh()
        {
            InitializeComponent();
            _KhoiBUS = new KhoiBUS();
            _LopBUS = new LopBUS();
            _NamHocBUS = new NamHocBUS();
        }


        private void CapNhatListLop()
        {
            List<LopDTO> list_LopNode;
            foreach (TreeListNode item in treeListSearch.Nodes)
            {
                item.Nodes.Clear();
                list_LopNode = _LopBUS.LayListLop_MaNam_MaKhoi(
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc),
                                    item.GetValue("MaKhoi").ToString()
                               );

                foreach (LopDTO lopNode in list_LopNode)
                {
                    this.treeListSearch.AppendNode(new object[] { lopNode.MaLop, lopNode.TenLop }, item);
                }

            }
        }

        private void frmSearchHocSinh_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,
                                                          _NamHocBUS.LayDTNamHoc(),
                                                          "MaNamHoc", "TenNamHoc",
                                                          "all", "Tất cả", 0);
            treeListSearch.ParentFieldName = "MaKhoi";
            treeListSearch.PreviewFieldName = "TenKhoi";
            treeListSearch.DataSource = _KhoiBUS.LayDTKhoi();
           
            CapNhatListLop();
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatListLop();
        }
    }
}