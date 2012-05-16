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

        /// <summary>
        /// Cập nhật lại list lớp theo khối
        /// </summary>
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
            treeListSearch.ExpandAll(); // Expand all nodes
        }

        private void frmSearchHocSinh_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,
                                                          _NamHocBUS.LayDTNamHoc(),
                                                          "MaNamHoc", "TenNamHoc",0);
            treeListSearch.ParentFieldName = "MaKhoi";
            treeListSearch.PreviewFieldName = "TenKhoi";
            treeListSearch.DataSource = _KhoiBUS.LayDTKhoi(); 

            CapNhatListLop();
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatListLop();
        }

        private void treeListSearch_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }
        /// <summary>
        /// Chọn tất cả các nodes con khi node cha được chọn
        /// </summary>
        /// <param name="node">Node cha</param>
        /// <param name="check">Trạng thái đang/không được check</param>
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }
        /// <summary>
        /// Chọn node cha của nó khi 1 trong các node con của nó được check
        /// </summary>
        /// <param name="node">Node con</param>
        /// <param name="check">Trạng thái đang/không được check</param>
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void checkEditTatCaNam_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxEditNamHoc.Enabled = !checkEditTatCaNam.Checked;
            treeListSearch.Enabled = !checkEditTatCaNam.Checked;
        }

  
    }
}