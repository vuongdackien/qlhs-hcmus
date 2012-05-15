using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLHS.Report;
using QLHS.BUS;
using QLHS.DTO;

namespace QLHS
{
    public partial class frmTongKetHocKy : DevExpress.XtraEditors.XtraForm
    {
        private BangDiemBUS _BangDiemBUS = new BangDiemBUS();
        public frmTongKetHocKy()
        {
            InitializeComponent();
        }

        private void simpleButtonXuatBD_Click(object sender, EventArgs e)
        {
            var ds = _BangDiemBUS.LayDTDiem_HocKy_Lop("10A01NH1112", "1");
            var rp = new rptTongKetHocKy();
            rp.SetDataSource(ds);

            frmReportView_TongKetHK _frmReportView_TongKetHK = new frmReportView_TongKetHK();
            _frmReportView_TongKetHK.crystalReportViewerTongKetMonHoc.ReportSource = rp;
            _frmReportView_TongKetHK.ShowDialog();
        }
    }
}