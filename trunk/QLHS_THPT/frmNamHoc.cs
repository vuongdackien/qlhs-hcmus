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
    public partial class frmNamHoc : DevExpress.XtraEditors.XtraForm
    {
        private NamHocBUS _namHocBUS;
        public frmNamHoc()
        {
            InitializeComponent();
            _namHocBUS = new NamHocBUS();
        }

        private void frmNamHoc_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEdit1, _namHocBUS.LayNamHoc_ThemMoi(),
                                                                        "MaNamHoc", "TenNamHoc", 0);
            this._Load_Lai_GridView();
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;
            string maNamHoc = gridViewNamHoc.GetRowCellValue(e.FocusedRowHandle, "MaNamHoc").ToString();
            Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEdit1, maNamHoc);
        }
        private void _Load_Lai_GridView()
        {
            gridControlNamHoc.DataSource = _namHocBUS.LayDTNamHoc();
            if(gridViewNamHoc.RowCount > 0)
              gridView1_FocusedRowChanged(this, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
        }

        private void _Disable_Control(bool editing)
        {
            if (editing)
            {
                simpleButtonThem.Text = "Lưu (Enter)";
                simpleButtonXoa.Text = "Không thêm (Alt+&D)";
            }
            else
            {
                simpleButtonThem.Text = "Thêm (Enter)";
                simpleButtonXoa.Text = "Xóa (Alt+&D)";
            }
            comboBoxEdit1.Enabled = editing;
            gridControlNamHoc.Enabled = !editing;

        }

        private void simpleButtonThem_Click(object sender, EventArgs e)
        {
            if (simpleButtonThem.Text == "Thêm (Enter)")
            {
                _Disable_Control(editing:true);
            }
            else
            {
                NamHocDTO namHocDTO = new NamHocDTO() { MaNamHoc = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEdit1),
                                                        TenNamHoc = Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEdit1)};
                // check & save
                if (_namHocBUS.KiemTraTonTai_NamHoc(namHocDTO.MaNamHoc))
                {
                    Utilities.MessageboxUtilities.MessageError("Năm học " +namHocDTO.TenNamHoc
                                                                + " đã tồn tại. Hãy chọn 1 năm học khác!");
                    return;
                }
                else
                {
                    _namHocBUS.ThemNamHoc(namHocDTO);
                    Utilities.MessageboxUtilities.MessageSuccess("Đã tạo năm học mới thành công."
                                                               + "\nTiếp theo bạn hãy tạo danh sách lớp cho năm học này!");
                    this._Load_Lai_GridView();
                }
                _Disable_Control(editing: false);
            }
        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            string maNamHoc = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEdit1);
            string tenNamHoc = Utilities.ComboboxEditUtilities.GetDisplayItem(comboBoxEdit1);
            if (simpleButtonXoa.Text == "Xóa (Alt+&D)")
            {               
                if (_namHocBUS.KiemTraTonTai_NamHoc(maNamHoc))
                {
                    // xóa
                    if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có chắc chắn muốn xóa năm học"
                                                + tenNamHoc + " và tất cả hồ sơ: Lớp học, phân lớp, bảng điểm,... liên quan đến năm học này?")
                        == DialogResult.Yes)
                    {
                        _namHocBUS.XoaNamHoc(maNamHoc);
                        Utilities.MessageboxUtilities.MessageSuccess("Đã xóa năm học " + tenNamHoc + " thành công!");
                        this._Load_Lai_GridView();
                    }
                }
                else
                {
                    Utilities.MessageboxUtilities.MessageError("Không tồn tại năm học " + tenNamHoc);
                }
                
            }
            else // Không thêm
            {
                _Disable_Control(editing: false);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}