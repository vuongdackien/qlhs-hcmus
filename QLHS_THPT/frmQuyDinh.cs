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
        public frmQuyDinh()
        {
            InitializeComponent();
            _QuyDinhBUS = new QuyDinhBUS();
            
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
                Khoa = gridViewQuyDinh.GetRowCellValue(i, "Khoa").ToString();
                GiaTri = gridViewQuyDinh.GetRowCellValue(i, "GiaTri").ToString();
                _QuyDinhDTO.Khoa = Khoa;
                _QuyDinhDTO.GiaTri = GiaTri;
                _QuyDinhBUS.capnhat(_QuyDinhDTO);
                
            }
            Utilities.MessageboxUtilities.MessageSuccess("Bạn đã cập nhật thành công");
            frmQuyDinh_Load(sender, e);
            
            }
        }

        private void frmQuyDinh_Load(object sender, EventArgs e)
        {
            
            Dt = new DataTable();
            Dt = _QuyDinhBUS.Table_QuyDinh();
            gridControlQuyDinh.DataSource = Dt;

        }

        private void gridViewQuyDinh_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            for (int i = 0; i < gridViewQuyDinh.RowCount; i++)
            {
                
            }
        }

       
    }
}