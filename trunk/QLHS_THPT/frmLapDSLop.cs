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

namespace QLHS
{
    public partial class frmLapDSLop : DevExpress.XtraEditors.XtraForm
    {
        private GiaoVienBUS _giaoVienBUS;
        private NamHocBUS _namHocBUS;
        private QuyDinhBUS _quyDinhBUS;
        private KhoiBUS _khoiBUS;
        private LopBUS _lopBUS;
        private bool _is_add_button;
        private bool _is_delete_button;

        public frmLapDSLop()
        {
            InitializeComponent();
            _giaoVienBUS = new GiaoVienBUS();
            _namHocBUS = new NamHocBUS();
            _quyDinhBUS = new QuyDinhBUS();
            _khoiBUS = new KhoiBUS();
            _lopBUS = new LopBUS();
            _is_add_button = true;
            _is_delete_button = true;
        }

        private void HienThi_DSLop()
        {
            gridControlDSLop.DataSource = _lopBUS.LayDTLop_MaNam_MaKhoi(Util.CboUtil.GetValueItem(comboBoxEditNamHoc),
                                    Util.CboUtil.GetValueItem(comboBoxEditKhoi));
            this.DisableControls(editing: false);
        }

        private void frmLapDSLop_Load(object sender, EventArgs e)
        {
            Util.CboUtil.SetDataSource(comboBoxEditNamHoc,
                                                         _namHocBUS.LayDTNamHoc(),
                                                        "MaNamHoc", "TenNamHoc", 0);
            Util.CboUtil.SetDataSource(comboBoxEditKhoi,
                                                        _khoiBUS.LayDT_Khoi(),
                                                        "MaKhoi", "TenKhoi", 0);
            Util.CboUtil.SetDataSource(comboBoxEditGVCN,
                                                                   _giaoVienBUS.LayDT_DanhSachGiaoVien(),
                                                                   "MaGiaoVien", "TenGiaoVien", 0);
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_DSLop();
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            textEditTenLop.Properties.Mask.EditMask = Util.CboUtil.GetValueItem(comboBoxEditKhoi)
                                                     +"[A-H][0-9]{1,2}";
            this.HienThi_DSLop();
        }

        private void DisableControls(bool editing)
        {
            simpleButtonDong.Enabled = !editing;
            gridControlDSLop.Enabled = !editing;
            //comboBoxEditGVCN.Enabled = is_adding;
            //textEditTenLop.Enabled = is_adding;
            comboBoxEditNamHoc.Enabled = !editing;
            comboBoxEditKhoi.Enabled = !editing;
            

            _is_add_button = !editing;
            _is_delete_button = !editing;

            simpleButtonThemMoi.Text = editing ? "Không nhập (Alt+&N)" : "Thêm mới (Alt+&N)";
            simpleButtonXoa.Text = editing ? "Nhập lại (Alt+&D)" : "Xóa (Alt+&D)";

            if (!editing)
            {
                if (gridViewLop.RowCount > 0)
                    gridViewLop_FocusedRowChanged(this, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(0, 0));
                else
                {
                    textEditMaLop.Text = "";
                    textEditTenLop.Text = "";
                }
            }
        }


        private void ResetControl()
        {
            comboBoxEditGVCN.SelectedIndex = 0;
            textEditTenLop.Text = "";
            textEditMaLop.Text = "";
        }
        private void simpleButtonThemMoi_Click(object sender, EventArgs e)
        {
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditNamHoc))
            {
                Util.MsgboxUtil.Error("Bạn chưa chọn năm học để thêm mới lớp!");
                return;
            }
            if (_is_add_button) // button them moi
            {
                DisableControls(true);
                ResetControl();
            }
            else // button khong nhap
            {
                // Bỏ ẩn control
                DisableControls(false);
            } 
        }

        private void gridViewLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Chac chan chon duoc 1 dong nao do
           if (gridViewLop.FocusedRowHandle < 0 || gridViewLop.FocusedRowHandle >= gridViewLop.RowCount) return;
           textEditMaLop.Text = gridViewLop.GetRowCellValue(gridViewLop.FocusedRowHandle, "MaLop").ToString();
           textEditTenLop.Text = gridViewLop.GetRowCellValue(gridViewLop.FocusedRowHandle, "TenLop").ToString();
           Util.CboUtil.SelectedItem(comboBoxEditGVCN,
               gridViewLop.GetRowCellValue(gridViewLop.FocusedRowHandle, "MaGiaoVien").ToString()
            );

        }

        private void textEditTenLop_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            string MaKhoi = Util.CboUtil.GetValueItem(comboBoxEditKhoi);
            e.ErrorText = "Tên lớp không hợp lệ. Tên lớp có dạng " + MaKhoi + "[A-H][0-9][0-9]. VD: " + MaKhoi + "B02";
        }

        private void simpleButtonGhiDuLieu_Click(object sender, EventArgs e)
        {
            if (textEditTenLop.Text == "")
            {
                Util.MsgboxUtil.Error("Bạn chưa nhập tên lớp!");
                return;
            }
            if (Util.CboUtil.CheckSelectedNull(comboBoxEditGVCN))
            {
                Util.MsgboxUtil.Error("Bạn chưa chọn GVCN!");
                return;
            }
            LopDTO lopDTO = new LopDTO();
            lopDTO.GiaoVien.MaGiaoVien = Util.CboUtil.GetValueItem(comboBoxEditGVCN);

            string TenLop = textEditTenLop.Text;
            string tTenLop = TenLop.Substring(0, 3); // 10A
            int hTenLop = Convert.ToInt32(TenLop.Substring(3, TenLop.Length - 3)); // 1
            TenLop = tTenLop + ((hTenLop < 10) ? "0" + hTenLop.ToString() : hTenLop.ToString()); // 10A01

            lopDTO.MaNamHoc = Util.CboUtil.GetValueItem(comboBoxEditNamHoc);
            lopDTO.MaLop = TenLop + lopDTO.MaNamHoc;
            lopDTO.TenLop = textEditTenLop.Text;
            lopDTO.MaKhoiLop = Convert.ToInt16(Util.CboUtil.GetValueItem(comboBoxEditKhoi));
            

            if (_lopBUS.KiemTraTonTai_MaLop(lopDTO.MaLop))
            {
                _lopBUS.CapNhat_GiaoVienCN_Lop(lopDTO);
                Util.MsgboxUtil.Success("Đã cập nhật lớp " + lopDTO.TenLop+" thành công!");
            }
            else
            {
                if(_lopBUS.Them_Lop(lopDTO))
                     Util.MsgboxUtil.Success("Đã tạo lớp " + lopDTO.TenLop + " thành công!");
            } 
            HienThi_DSLop();

        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            if (!_is_delete_button) // button nhap lai 
            {
                ResetControl();
                return;
            }
            else // button xoa
            {
                if (_lopBUS.KiemTraTonTai_MaLop(textEditMaLop.Text))
                {
                    if (Util.MsgboxUtil.YesNo("Bạn có muốn xóa toàn bộ danh sách học sinh, "
                                    + "bảng điểm học sinh và toàn bộ thông tin liên quan đến lớp " + textEditTenLop.Text + " hay không?")
                            == DialogResult.No)
                    {
                        return;
                    }

                    _lopBUS.Xoa_Lop(textEditMaLop.Text);
                    Util.MsgboxUtil.Success("Đã xóa lớp " + textEditTenLop.Text + " thành công!");
                    HienThi_DSLop();
                }
            }
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Hiển thị frmNamHoc
            (this.ParentForm as frmMain).ShowMDIChildForm<frmNamHoc>();
        }

 
    }
}