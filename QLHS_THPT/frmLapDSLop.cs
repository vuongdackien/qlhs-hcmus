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
        public frmLapDSLop()
        {
            InitializeComponent();
            _giaoVienBUS = new GiaoVienBUS();
            _namHocBUS = new NamHocBUS();
            _quyDinhBUS = new QuyDinhBUS();
            _khoiBUS = new KhoiBUS();
            _lopBUS = new LopBUS();
        }

        private void HienThi_DSLop()
        {
            gridControlDSLop.DataSource = _lopBUS.LayDTLop_MaNam_MaKhoi(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc),
                                    Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi));
            
        }

        private void frmLapDSLop_Load(object sender, EventArgs e)
        {
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditNamHoc,
                                                         _namHocBUS.LayDTNamHoc(),
                                                        "MaNamHoc", "TenNamHoc", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditKhoi,
                                                        _khoiBUS.LayDTKhoi(),
                                                        "MaKhoi", "TenKhoi", 0);
            Utilities.ComboboxEditUtilities.SetDataSource(comboBoxEditGVCN,
                                                                   _giaoVienBUS.LayDT_DanhSachGiaoVien(),
                                                                   "MaGiaoVien", "TenGiaoVien", 0);
        }

        private void comboBoxEditNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HienThi_DSLop();
        }

        private void comboBoxEditKhoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            textEditTenLop.Properties.Mask.EditMask = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi)
                                                     +"[A-H][0-9]{1,2}";
            this.HienThi_DSLop();
        }

        private void DisableControls(bool editing)
        {
            simpleButtonDong.Enabled = !editing;
            gridControlDSLop.Enabled = !editing;
            comboBoxEditGVCN.Enabled = editing;
            comboBoxEditNamHoc.Enabled = !editing;
            comboBoxEditKhoi.Enabled = !editing;
            textEditTenLop.Enabled = editing;
            if (editing)
            {
                simpleButtonThemMoi.Text = "Không nhập (Alt+&N)";
                simpleButtonXoa.Text = "Nhập lại (Alt+&D)";
            }
            else
            {
                simpleButtonThemMoi.Text = "Thêm mới (Alt+&N)";
                simpleButtonXoa.Text = "Xóa (Alt+&D)";
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
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditNamHoc))
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa chọn năm học để thêm mới lớp!");
                return;
            }
            if (simpleButtonThemMoi.Text == "Thêm mới (Alt+&N)")
            {
                DisableControls(true);
                ResetControl();
            }
            else
            {
                // Hiển thị lại
                gridViewDSLop.FocusedRowHandle = 0;
                // Bỏ ẩn control
                DisableControls(false);
            } 
        }

        private void gridViewLop_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Chac chan chon duoc 1 dong nao do
           if (gridViewLop.FocusedRowHandle < 0) return;
           textEditMaLop.Text = gridViewLop.GetRowCellValue(gridViewLop.FocusedRowHandle, "MaLop").ToString();
           textEditTenLop.Text = gridViewLop.GetRowCellValue(gridViewLop.FocusedRowHandle, "TenLop").ToString();
           Utilities.ComboboxEditUtilities.SelectedItem(comboBoxEditGVCN,
               gridViewLop.GetRowCellValue(gridViewLop.FocusedRowHandle, "MaGiaoVien").ToString()
            );

        }

        private void textEditTenLop_InvalidValue(object sender, DevExpress.XtraEditors.Controls.InvalidValueExceptionEventArgs e)
        {
            string MaKhoi = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi);
            e.ErrorText = "Tên lớp không hợp lệ. Tên lớp có dạng " + MaKhoi + "[A-H][0-9][0-9]. VD: " + MaKhoi + "B02";
        }

        private void simpleButtonGhiDuLieu_Click(object sender, EventArgs e)
        {
            if (textEditTenLop.Text == "")
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa nhập tên lớp!");
                return;
            }
            if (Utilities.ComboboxEditUtilities.CheckSelectedNull(comboBoxEditGVCN))
            {
                Utilities.MessageboxUtilities.MessageError("Bạn chưa chọn GVCN!");
                return;
            }
            LopDTO lopDTO = new LopDTO();
            lopDTO.GiaoVien.MaGiaoVien = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditGVCN);

            string TenLop = textEditTenLop.Text;
            string tTenLop = TenLop.Substring(0, 3); // 10A
            int hTenLop = Convert.ToInt32(TenLop.Substring(3, TenLop.Length - 3)); // 1
            TenLop = tTenLop + ((hTenLop < 10) ? "0" + hTenLop.ToString() : hTenLop.ToString()); // 10A01

            lopDTO.MaNamHoc = Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditNamHoc);
            lopDTO.MaLop = TenLop + lopDTO.MaNamHoc;
            lopDTO.TenLop = textEditTenLop.Text;
            lopDTO.MaKhoiLop = Convert.ToInt16(Utilities.ComboboxEditUtilities.GetValueItem(comboBoxEditKhoi));
            

            if (_lopBUS.KiemTra_TonTaiMaLop(lopDTO.MaLop))
            {
                _lopBUS.CapNhat_GiaoVienCN_Lop(lopDTO);
                Utilities.MessageboxUtilities.MessageSuccess("Đã cập nhật lớp " + lopDTO.TenLop+" thành công!");
            }
            else
            {
                if(_lopBUS.Them_Lop(lopDTO))
                     Utilities.MessageboxUtilities.MessageSuccess("Đã tạo lớp " + lopDTO.TenLop + " thành công!");
            } 
            HienThi_DSLop();
            DisableControls(false);

        }

        private void simpleButtonXoa_Click(object sender, EventArgs e)
        {
            if (simpleButtonXoa.Text == "Nhập lại (Alt+&D)")
            {
                ResetControl();
                return;
            }
            else
            {
                if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có muốn xóa toàn bộ danh sách học sinh, "
                                +"bảng điểm học sinh và toàn bộ thông tin liên quan đến lớp "+textEditTenLop.Text+" hay không?")
                        == DialogResult.No)
                {
                    return;
                }

               _lopBUS.Xoa_Lop(textEditMaLop.Text);
                Utilities.MessageboxUtilities.MessageSuccess("Đã xóa lớp " + textEditTenLop.Text + " thành công!");
                HienThi_DSLop();
            }
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

 
    }
}