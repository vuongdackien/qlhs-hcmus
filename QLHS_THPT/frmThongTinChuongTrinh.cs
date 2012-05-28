using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLHS
{
    public partial class frmThongTinChuongTrinh : DevExpress.XtraEditors.XtraForm
    {
        public frmThongTinChuongTrinh()
        {
            InitializeComponent();
        }

        private void simpleButtonDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}