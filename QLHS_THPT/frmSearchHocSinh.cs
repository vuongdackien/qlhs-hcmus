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
        private HocSinhBUS _HocSinhBUS;

        public frmSearchHocSinh()
        {
            InitializeComponent();
            _KhoiBUS = new KhoiBUS();
            _LopBUS = new LopBUS();
            _NamHocBUS = new NamHocBUS();
            _HocSinhBUS = new HocSinhBUS();
        }

        /// <summary>
        /// Cập nhật lại list lớp theo khối
        /// </summary>
        private void CapNhatListLop()
        {
            List<LopDTO> list_LopNode;
            // Duyệt từng khối
            foreach (TreeListNode item in treeListSearch.Nodes)
            {

                item.Nodes.Clear();
                list_LopNode = _LopBUS.LayListLop_MaNam_MaKhoi(
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc),
                                    item.GetValue("MaKhoi").ToString()
                               );
                // add các lớp vào khối item
                foreach (LopDTO lopNode in list_LopNode)
                {
                    this.treeListSearch.AppendNode(new object[] { lopNode.MaLop, lopNode.TenLop}, item);
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
            // Disable controls search
            DisableControls(false);                        
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
        
        /// <summary>
        /// Tìm kiếm học sinh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButtonSearch_Click(object sender, EventArgs e)
        {
            DataTable kq_TimKiemDS = null;
            HocSinhTimKiemDTO hsTimKiemDTO = new HocSinhTimKiemDTO();
            hsTimKiemDTO.MaHocSinh = textEditMaHocSinh.Text;
            hsTimKiemDTO.TenHocSinh = textEditHoTen.Text;
            //lấy giá trị của radioGioiTinh
            if (checkEditGioiTinh.Checked)
            {
                object selectedValue = radioGroupGioiTinh.Properties.Items[radioGroupGioiTinh.SelectedIndex].Value;
                hsTimKiemDTO.GioiTinh=(int)selectedValue;
            }
            hsTimKiemDTO.NamSinhTu = textEditNamSinhTu.Text;
            hsTimKiemDTO.NamSinhDen = textEditNamSinhDen.Text;
            hsTimKiemDTO.Email = textEditEmail.Text;
            hsTimKiemDTO.DiaChi = textEditDiaChi.Text;

            try
            {
                // Nếu ko chọn tìm kiếm tất cả các năm => Tìm kiếm trong tất cả các lớp được checked
                if (!checkEditTatCaNam.Checked)
                {
                    List<string> lopCheck = new List<string>();
                    foreach (TreeListNode khoi in treeListSearch.Nodes)
                    {
                        foreach (TreeListNode lop in khoi.Nodes)
                        {
                            if (lop.Checked)
                            {
                                lopCheck.Add(lop.GetValue("MaKhoi").ToString());
                            }
                        }
                    }
                    kq_TimKiemDS = _HocSinhBUS.TimKiem_HocSinh(hsTimKiemDTO, lopCheck);
                }
                else // Tìm trong tất cả các năm, các lớp
                {
                    kq_TimKiemDS = _HocSinhBUS.TimKiem_HocSinh(hsTimKiemDTO);
                }
            }
            catch (Exception ex)
            {
                Utilities.MessageboxUtilities.MessageError(ex);
                return;
            }

            gridControlSearchHocSinh.DataSource = kq_TimKiemDS;               
        }

        #region Ẩn hiện các control khi load form
        bool Check;
        private void DisableControls(bool show = true)
        {
            foreach (Control c in panelControlNDungDKien.Controls)
            {
                if (c is CheckEdit)
                {
                    ((CheckEdit)c).Checked = false;
                }
                else
                    c.Enabled = show;
            }
        }
        private void EnableControl(CheckEdit checkEdit, TextEdit textEdit)
        {
            if (checkEdit.Checked)
                Check = true;
            else
            {
                Check = false;
                textEdit.ResetText();
            }
            textEdit.Properties.ReadOnly = !Check;
            textEdit.Enabled = Check;
        }
        private void EnableControl(CheckEdit checkEdit, RadioGroup radioGroup)
        {
            if (checkEdit.Checked)
                Check = true;
            else
            {
                Check = false;
            }
            radioGroup.Properties.ReadOnly = !Check;
            radioGroup.Enabled = Check;            
        }
        #endregion

        #region Ẩn/hiện textEdit khi checked (không checked) checkEdit
        private void checkEditMaHocSinh_CheckedChanged(object sender, EventArgs e)
        {
            EnableControl(checkEditMaHocSinh, textEditMaHocSinh);
        }

        private void checkEditHoTen_CheckedChanged(object sender, EventArgs e)
        {
            EnableControl(checkEditHoTen, textEditHoTen);
        }

        private void checkEditGioiTinh_CheckedChanged(object sender, EventArgs e)
        {
            EnableControl(checkEditGioiTinh, radioGroupGioiTinh);
        }

        private void checkEditNamSinh_CheckedChanged(object sender, EventArgs e)
        {
            EnableControl(checkEditNamSinh, textEditNamSinhTu);
            EnableControl(checkEditNamSinh, textEditNamSinhDen);
        }

        private void checkEditEmail_CheckedChanged(object sender, EventArgs e)
        {
            EnableControl(checkEditEmail, textEditEmail);
        }

        private void checkEditDiaChi_CheckedChanged(object sender, EventArgs e)
        {
            EnableControl(checkEditDiaChi, textEditDiaChi);
        }
        #endregion
    }
}