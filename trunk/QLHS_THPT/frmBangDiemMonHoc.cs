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
    public partial class frmBangDiemMonHoc : DevExpress.XtraEditors.XtraForm
    {

        private KhoiBUS _KhoiBUS;
        private LopBUS _LopBUS;
        private NamHocBUS _NamHocBUS;
        private HocSinhBUS _HocSinhBUS;
        private BangDiemBUS _BangDiemBUS;
        private HocKyBUS _HocKyBUS;
        private MonHocBUS _MonHocBUS;
        private bool _has_edit_bangdiem; // Ghi nhận có chỉnh sửa bảng điểm
        private int _index_monhoc, _index_hocky;



        public frmBangDiemMonHoc()
        {
            InitializeComponent();

            _KhoiBUS = new KhoiBUS();
            _LopBUS = new LopBUS();
            _NamHocBUS = new NamHocBUS();
            _HocSinhBUS = new HocSinhBUS();
            _BangDiemBUS = new BangDiemBUS();
            _HocKyBUS = new HocKyBUS();
            _MonHocBUS = new MonHocBUS();
            _has_edit_bangdiem = false;
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
                list_LopNode = _LopBUS.LayListLop_MaNam_MaKhoi(
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
                gridControlTongKetNamHoc.DataSource = null;
                return;
            }
            _index_monhoc = comboBoxEditMonHoc.SelectedIndex;
            _index_hocky = comboBoxEditHocKy.SelectedIndex;
            gridControlTongKetNamHoc.DataSource =
               _BangDiemBUS.LayBangDiem(treeListLopHoc.FocusedNode.GetValue("MaKhoi").ToString(),
                                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy),
                                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditMonHoc));
       
        }
        private void frmBangDiemMonHoc_Load(object sender, EventArgs e)
        {
            treeListLopHoc.ParentFieldName = "MaKhoi";
            treeListLopHoc.PreviewFieldName = "TenKhoi";
            treeListLopHoc.DataSource = _KhoiBUS.LayDTKhoi();

            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,
                                                         _NamHocBUS.LayDTNamHoc(),
                                                        "MaNamHoc", "TenNamHoc", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditHocKy,
                                                        _HocKyBUS.LayDTHocKy(),
                                                        "MaHocKy", "TenHocKy", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditMonHoc,
                                                        _MonHocBUS.LayDT_DanhSach_MonHoc(),
                                                        "MaMonHoc", "TenMonHoc", 0);
            
           this.CapNhatListLop();
        }
        private void simpleButtonXuatBD_Click(object sender, EventArgs e)
        {
            _has_edit_bangdiem = false;
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CapNhatListLop();
            this.HienThi_Lai_BangDiem();
        }

        private void comboBoxEditHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_has_edit_bangdiem)
            {
                if (Utilities.MessageboxUtilities.MessageQuestionYesNo(
                                "Bạn đã chỉnh sửa trên lưới. "
                                + "Nếu chọn lớp khác, chương trình sẽ không lưu dữ liệu hiện tại."
                                + "\nBạn có muốn di chuyển?") == System.Windows.Forms.DialogResult.No)
                {
                    // Ngừng event change comboBoxEditHocKy
                    comboBoxEditHocKy.SelectedIndexChanged -= new EventHandler(comboBoxEditHocKy_SelectedIndexChanged);
                    comboBoxEditHocKy.SelectedIndex = _index_monhoc; // Phục hồi lại selectindex
                    // Tiếp tục event change comboBoxEditHocKy
                    comboBoxEditHocKy.SelectedIndexChanged += new EventHandler(comboBoxEditHocKy_SelectedIndexChanged);
                    return;
                }
                else
                {
                    _has_edit_bangdiem = false;
                }
            }
            this.HienThi_Lai_BangDiem();
        }

        
        private void comboBoxEditMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_has_edit_bangdiem)
            {
                if (Utilities.MessageboxUtilities.MessageQuestionYesNo(
                                "Bạn đã chỉnh sửa trên lưới. "
                                + "Nếu chọn lớp khác, chương trình sẽ không lưu dữ liệu hiện tại."
                                + "\nBạn có muốn di chuyển?") == System.Windows.Forms.DialogResult.No)
                {
                    // Ngừng event change comboBoxEditMonHoc
                    comboBoxEditMonHoc.SelectedIndexChanged -= new EventHandler(comboBoxEditMonHoc_SelectedIndexChanged);
                    comboBoxEditMonHoc.SelectedIndex = _index_monhoc; // Phục hồi lại selectindex
                    // Tiếp tục event change comboBoxEditMonHoc
                    comboBoxEditMonHoc.SelectedIndexChanged += new EventHandler(comboBoxEditMonHoc_SelectedIndexChanged);
                    return;
                }
                else
                {
                    _has_edit_bangdiem = false;
                }
            }
            this.HienThi_Lai_BangDiem();
        }

        private void treeListLopHoc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            this.HienThi_Lai_BangDiem();
        }

        private void advBandedGridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            _has_edit_bangdiem = true; // ghi nhận có chỉnh sửa bảng điểm
        }

        private void treeListLopHoc_BeforeFocusNode(object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            if (_has_edit_bangdiem)
            {
                if (Utilities.MessageboxUtilities.MessageQuestionYesNo(
                                "Bạn đã chỉnh sửa trên lưới. "
                                + "Nếu chọn lớp khác, chương trình sẽ không lưu dữ liệu hiện tại."
                                + "\nBạn có muốn di chuyển?") == System.Windows.Forms.DialogResult.No)
                {
                    e.CanFocus = false;
                }
                else
                {
                    _has_edit_bangdiem = false;
                }
            }
        }



        private void advBandedGridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow dr = advBandedGridView1.GetDataRow(e.RowHandle);
            string msg = "";
            if (dr["DM_1"] is DBNull && dr["DM_2"] is DBNull)
                msg =  "miệng";
            else if (dr["D15_1"] is DBNull && dr["D15_2"] is DBNull
                    && dr["D15_3"] is DBNull && dr["D15_4"] is DBNull)
                msg = "15 phút";
            else if (dr["D1T_1"] is DBNull && dr["D1T_2"] is DBNull)
                msg = "1 tiết";
            else if (dr["DThi"] is DBNull)
                msg = "cuối kỳ";
            if (!msg.Equals(""))
                msg = "Bạn chưa nhập cột điểm " + msg +" cho học sinh "
                       +dr["TenHocSinh"]+" ("+dr["MaHocSinh"]+")."
                       +"\nBạn có muốn bỏ dòng này và nhập lại lần sau hay không?";


            if (!msg.Equals(""))
            {
                if (Utilities.MessageboxUtilities.MessageQuestionYesNo(msg) == DialogResult.No)
                {
                    e.Valid = false;
                }
            }
           

        }

        private void advBandedGridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }


        private void advBandedGridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                if (e.Value == null)
                    return;
                if (e.Value.Equals("") || e.Value is DBNull)
                    return;
                if (Convert.ToDouble(e.Value) > 10 || Convert.ToDouble(e.Value) < 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Điểm nhập không hợp lệ!";
                }
            }
            catch
            {
                e.Valid = false;
                e.ErrorText = "Điểm nhập không hợp lệ!";
            }
        }





  
    }
}