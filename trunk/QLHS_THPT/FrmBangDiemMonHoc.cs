using System;
using System.Windows.Forms;
using QLHS.BUS;
using QLHS.DTO;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors.Controls;

namespace QLHS
{
    public partial class FrmBangDiemMonHoc : DevExpress.XtraEditors.XtraForm
    {

        private readonly KhoiBUS _khoiBUS;
        private readonly LopBUS _lopBUS;
        private readonly NamHocBUS _namHocBUS;
        private readonly BangDiemBUS _bangDiemBUS;
        private readonly HocKyBUS _hocKyBUS;
        private readonly MonHocBUS _monHocBUS;

        public FrmBangDiemMonHoc()
        {
            InitializeComponent();

            _khoiBUS = new KhoiBUS();
            _lopBUS = new LopBUS();
            _namHocBUS = new NamHocBUS();
            _bangDiemBUS = new BangDiemBUS();
            _hocKyBUS = new HocKyBUS();
            _monHocBUS = new MonHocBUS();
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
            Util.CboUtil.SetDataSource(comboBoxEditMonHoc,
                                                        _monHocBUS.LayDT_DanhSach_MonHoc(),
                                                        "MaMonHoc", "TenMonHoc", 0);

            CapNhatListLop();
        }

        /// <summary>
        /// Cập nhật lại list lớp theo khối
        /// </summary>
        private void CapNhatListLop()
        {
            // Duyệt từng khối
            foreach (TreeListNode item in treeListLopHoc.Nodes)
            {

                item.Nodes.Clear();
                var listLopNode = _lopBUS.LayListLop_MaNam_MaKhoi(
                    Util.CboUtil.GetValueItem(comboBoxEditNamHoc),
                    item.GetValue("MaKhoi").ToString()
                    );
                // add các lớp vào khối item
                foreach (var lopNode in listLopNode)
                {
                    treeListLopHoc.AppendNode(new object[] { lopNode.MaLop, lopNode.TenLop }, item);
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
            if (treeListLopHoc.FocusedNode == null ||
                    Util.CboUtil.CheckSelectedNull(comboBoxEditMonHoc))
            {
                gridControlTongKetNamHoc.DataSource = null;
                return;
            }
            var maLop = treeListLopHoc.FocusedNode.GetValue("MaKhoi").ToString();
            gridControlTongKetNamHoc.DataSource =
            _bangDiemBUS.LayDT_BangDiem_Lop_MonHoc_HocKy(maLop, Util.CboUtil.GetValueItem(comboBoxEditHocKy),
                                            Util.CboUtil.GetValueItem(comboBoxEditMonHoc));
            labelControlNamHoc.Text = Util.CboUtil.GetDisplayItem(comboBoxEditNamHoc);
            labelControlLop.Text = treeListLopHoc.FocusedNode.GetValue("TenKhoi").ToString();
            labelControlHocKy.Text = Util.CboUtil.GetValueItem(comboBoxEditHocKy);
            labelControlGVCN.Text = _lopBUS.LayTenGiaoVien_MaLop(maLop);
            labelControlTenMon.Text = Util.CboUtil.GetDisplayItem(comboBoxEditMonHoc).ToUpper();
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatListLop();
            HienThi_Lai_BangDiem();
        }

        private void comboBoxEditHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThi_Lai_BangDiem();
        }
        
        private void comboBoxEditMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThi_Lai_BangDiem();
        }

        private void treeListLopHoc_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            HienThi_Lai_BangDiem();
        }

        private void advBandedGridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            var dr = advBandedGridView1.GetDataRow(e.RowHandle);
            var bangDiem = new BangDiemDTO
                               {
                                   HocSinh =
                                       {
                                           MaHocSinh = dr["MaHocSinh"].ToString(),
                                           TenHocSinh = dr["TenHocSinh"].ToString()
                                       },
                                   MaHocKy = Convert.ToInt32(Util.CboUtil.GetValueItem(comboBoxEditHocKy)),
                                   MonHoc = {MaMonHoc = Util.CboUtil.GetValueItem(comboBoxEditMonHoc)},
                                   LopDTO = {MaLop = treeListLopHoc.FocusedNode.GetValue("MaKhoi").ToString()},
                                   DM_1 = dr["DM_1"] is DBNull ? -1 : Convert.ToDouble(dr["DM_1"]),
                                   DM_2 = dr["DM_2"] is DBNull ? -1 : Convert.ToDouble(dr["DM_2"]),
                                   D15_1 = dr["D15_1"] is DBNull ? -1 : Convert.ToDouble(dr["D15_1"]),
                                   D15_2 = dr["D15_2"] is DBNull ? -1 : Convert.ToDouble(dr["D15_2"]),
                                   D15_3 = dr["D15_3"] is DBNull ? -1 : Convert.ToDouble(dr["D15_3"]),
                                   D15_4 = dr["D15_4"] is DBNull ? -1 : Convert.ToDouble(dr["D15_4"]),
                                   D1T_1 = dr["D1T_1"] is DBNull ? -1 : Convert.ToDouble(dr["D1T_1"]),
                                   D1T_2 = dr["D1T_2"] is DBNull ? -1 : Convert.ToDouble(dr["D1T_2"]),
                                   DThi = dr["DThi"] is DBNull ? -1 : Convert.ToDouble(dr["DThi"]),
                                   DTB = dr["DTB"] is DBNull ? -1 : Convert.ToDouble(dr["DTB"])
                               };


            try
            {
                // Kiểm tra điểm hợp lệ trên 1 dòng
                _bangDiemBUS.KiemTraHopLe_DataRow_Lop_MonHoc_HocKy(bangDiem);
                // Tính điểm trung bình
                var dTbBangdiem = _bangDiemBUS.TinhDTB_DataRow_Lop_MonHoc_HocKy(bangDiem);
                bangDiem.DTB = dTbBangdiem;
                // Gán và hiển thị cột DTB
                advBandedGridView1.SetRowCellValue(e.RowHandle, "DTB", dTbBangdiem);
                // Lưu vào CSDL
                _bangDiemBUS.LuuBangDiem_HocSinh_MonHoc_HocKy(bangDiem);

            }
            catch (Exception ex)
            {
                if (Util.MsgboxUtil.YesNo(ex.Message
                            + "\nBạn có muốn bỏ dòng này và nhập lại lần sau hay không?") == DialogResult.No)
                {
                    e.Valid = false;
                }
                else
                {
                    _bangDiemBUS.XoaBangDiem_HocSinh_MonHoc_HocKy(bangDiem);
                    HienThi_Lai_BangDiem();
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