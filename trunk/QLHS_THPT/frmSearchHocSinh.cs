using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLHS.DTO;
using QLHS.BUS;

namespace QLHS
{
    public partial class frmSearchHocSinh : DevExpress.XtraEditors.XtraForm
    {
        private KhoiBUS _KhoiBUS;
        private LopBUS _LopBUS;
        public frmSearchHocSinh()
        {
            InitializeComponent();
            _KhoiBUS = new KhoiBUS();
            _LopBUS = new LopBUS();
        }

        private void frmSearchHocSinh_Load(object sender, EventArgs e)
        {
            DataTable khoilop = _KhoiBUS.LayDTKhoi();
            treeListSearch.DataSource = khoilop;

            foreach (DevExpress.XtraTreeList.Nodes.TreeListNode item in treeListSearch.Nodes)
            {
                treeListSearch.AppendNode(khoilop.Rows[0], item);
                treeListSearch.AppendNode(khoilop.Rows[0], item);
            }
        }
    }
}