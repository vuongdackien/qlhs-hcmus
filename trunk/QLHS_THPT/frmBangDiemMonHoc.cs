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

        private KhoiBUS _khoiBUS;
        private LopBUS _lopBUS;
        private NamHocBUS _namHocBUS;
        private HocSinhBUS _hocSinhBUS;
        private BangDiemBUS _bangDiemBUS;
        private HocKyBUS _hocKyBUS;
        private MonHocBUS _monHocBUS;
        private bool _has_edit_bangdiem; // Ghi nhận có chỉnh sửa bảng điểm
        private int _indexMonhoc, _indexHocky;



        public frmBangDiemMonHoc()
        {
            InitializeComponent();

            _khoiBUS = new KhoiBUS();
            _lopBUS = new LopBUS();
            _namHocBUS = new NamHocBUS();
            _hocSinhBUS = new HocSinhBUS();
            _bangDiemBUS = new BangDiemBUS();
            _hocKyBUS = new HocKyBUS();
            _monHocBUS = new MonHocBUS();
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
                gridControlTongKetNamHoc.DataSource = null;
                return;
            }
            _indexMonhoc = comboBoxEditMonHoc.SelectedIndex;
            _indexHocky = comboBoxEditHocKy.SelectedIndex;
            gridControlTongKetNamHoc.DataSource =
            _bangDiemBUS.LayBangDiem(treeListLopHoc.FocusedNode.GetValue("MaKhoi").ToString(),
                                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditHocKy),
                                                Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditMonHoc));
       
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
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditMonHoc,
                                                        _monHocBUS.LayDT_DanhSach_MonHoc(),
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
                    comboBoxEditHocKy.SelectedIndex = _indexMonhoc; // Phục hồi lại selectindex
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
                    comboBoxEditMonHoc.SelectedIndex = _indexMonhoc; // Phục hồi lại selectindex
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
            BangDiemDTO bangDiem = new BangDiemDTO();
            bangDiem.HocSinh.MaHocSinh = dr["MaHocSinh"].ToString();
            bangDiem.HocSinh.TenHocSinh = dr["TenHocSinh"].ToString();
            bangDiem.MonHoc.MaMonHoc = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditMonHoc);
            bangDiem.LopDTO.MaLop = treeListLopHoc.FocusedNode.GetValue("MaKhoi").ToString();
            bangDiem.D15_1 = dr["DM_1"] is DBNull ? -1 : Convert.ToDouble(dr["DM_1"]); 
            bangDiem.DM_2 = dr["DM_2"] is DBNull ? -1 : Convert.ToDouble(dr["DM_2"]); 
            bangDiem.D15_1 = dr["D15_1"] is DBNull ? -1 : Convert.ToDouble(dr["D15_1"]);
            bangDiem.D15_2 = dr["D15_2"] is DBNull ? -1 : Convert.ToDouble(dr["D15_2"]); 
            bangDiem.D15_3 = dr["D15_3"] is DBNull ? -1 : Convert.ToDouble(dr["D15_3"]); 
            bangDiem.D15_4 = dr["D15_4"] is DBNull ? -1 : Convert.ToDouble(dr["D15_4"]); 
            bangDiem.D1T_1 = dr["D1T_1"] is DBNull ? -1 : Convert.ToDouble(dr["D1T_1"]); 
            bangDiem.D1T_2 = dr["D1T_2"] is DBNull ? -1 : Convert.ToDouble(dr["D1T_2"]);
            bangDiem.DThi = dr["DThi"] is DBNull ? -1 : Convert.ToDouble(dr["DThi"]);

 
            try
            {
                // Kiểm tra điểm hợp lệ trên 1 dòng
                _bangDiemBUS.KiemTraHopLe_TrenDong_BangDiem(bangDiem);
                // Tính điểm trung bình
                double dTB_bangdiem = _bangDiemBUS.TinhDiem_TB_Mon_TrenDong(bangDiem);
                // Gán và hiển thị cột DTB
                advBandedGridView1.SetRowCellValue(e.RowHandle, "DTB",dTB_bangdiem);
                // Lưu vào CSDL
                
            }
            catch (Exception ex)
            {
                if (Utilities.MessageboxUtilities.MessageQuestionYesNo(ex.Message
                            + "\nBạn có muốn bỏ dòng này và nhập lại lần sau hay không?") == DialogResult.No)
                {
                    e.Valid = false;
                }
                else
                {
                    // Xóa tất cả các cột điểm
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "DM_1", null);
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "DM_2", null);
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "D15_1", null);
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "D15_2", null);
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "D15_3", null);
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "D15_4", null);
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "D1T_1", null);
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "D1T_2", null);
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "DThi", null);
                    advBandedGridView1.SetRowCellValue(e.RowHandle, "DTB", null);
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