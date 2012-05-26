using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using QLHS.BUS;
using QLHS.DTO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLHS
{
    public partial class frmQuyDinh : DevExpress.XtraEditors.XtraForm
    {
        DataTable Dt;
        QuyDinhBUS _QuyDinhBUS;
        QuyDinhDTO _QuyDinhDTO;
        int flag = 0;
        public frmQuyDinh()
        {
            InitializeComponent();
            _QuyDinhBUS = new QuyDinhBUS();
            simpleButtonSuaQuyDinh.Enabled = false;
            
        }

        private void simpleButtonThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButtonLoaddulieu_Click(object sender, EventArgs e)
        {
            Dt = new DataTable();
            Dt = _QuyDinhBUS.Table_QuyDinh();
            gridControlQuyDinh.DataSource = Dt;

        }

        private void simpleButtonSuaQuyDinh_Click(object sender, EventArgs e)
        {
            if (Utilities.MessageboxUtilities.MessageQuestionYesNo("Bạn có chắc chắn muốn sửa quy định hay không?") == System.Windows.Forms.DialogResult.Yes)
            {
                 gridViewQuyDinh.FocusedColumn = gridViewQuyDinh.Columns[0];
                 _QuyDinhDTO = new QuyDinhDTO();
                 
            string Khoa;
            string GiaTri;
            for (int i = 0; i < gridViewQuyDinh.RowCount; i++)
            {
                flag = 0;
                Khoa = gridViewQuyDinh.GetRowCellValue(i, "Khoa").ToString().Trim();
                GiaTri = gridViewQuyDinh.GetRowCellValue(i, "GiaTri").ToString().Trim();
                if (Khoa == "TenTruong" || Khoa == "DiaChiTruong")
                {
                    GiaTri = _QuyDinhBUS.Doichuoi(GiaTri, "'", "''", true);
                }
                else if (Khoa!="NgayApDung")               
                {
                    foreach (Char c in GiaTri)
                    {
                        if (!Char.IsDigit(c))
                        {
                            
                            Utilities.MessageboxUtilities.MessageError("Bạn không được nhập kí tự:" + c + " Tai Khóa:"+Khoa+" bạn chỉ có thể nhập số");
                            if (Utilities.MessageboxUtilities.MessageQuestionOkCancel("Bạn có muốn bỏ qua lỗi lưu tiếp các giá trị của khóa khác?") == System.Windows.Forms.DialogResult.Cancel)
                            {
                                flag = 3;
                               
                            }
                            flag = 2;
                            break;
                                                
                        }
                    }  
                }
                 if (flag==0)
                {
                    _QuyDinhDTO.Khoa = Khoa;
                    _QuyDinhDTO.GiaTri = GiaTri;
                    _QuyDinhBUS.capnhat(_QuyDinhDTO);
                }
                if (flag==3)
                {
                    break;
                }
                
            }
            if (flag==0)
            {
                Utilities.MessageboxUtilities.MessageSuccess("Đã hoàn tất quá trình cập nhật");
                
            }
            frmQuyDinh_Load(sender, e);
           }
        }

        private void frmQuyDinh_Load(object sender, EventArgs e)
        {
            
            Dt = new DataTable();
            Dt = _QuyDinhBUS.Table_QuyDinh();
            gridControlQuyDinh.DataSource = Dt;

        }

        public void Kiemtra( KeyPressEventArgs a)
        {
           
                string Khoa;
                string GiaTri;
                Khoa = gridViewQuyDinh.GetFocusedRowCellValue("Khoa").ToString();
                GiaTri = gridViewQuyDinh.GetFocusedRowCellValue("GiaTri").ToString();
                // break;
                if (Khoa != "TenTruong" && Khoa != "DiaChiTruong")
                {
                    if (!Char.IsDigit(a.KeyChar) && !Char.IsControl(a.KeyChar))
                    {
                        a.Handled = true;
                    }
                    a.Handled = false;
                }
                        
        }

        private void gridViewQuyDinh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            for (int i = 0; i <1; i++)
            {
                simpleButtonSuaQuyDinh.Enabled = true;
               
            }

        }

        
       
    }
}