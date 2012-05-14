using System;
using System.Data;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using QLHS.BUS;
using QLHS.DTO;


namespace QLHS_THPT
{
    public partial class frmHocSinh : DevExpress.XtraEditors.XtraForm
    {
        private NamHocBUS _NamHocBUS;

        public frmHocSinh()
        {
            InitializeComponent();
            _NamHocBUS = new NamHocBUS();
          
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            List<NamHocDTO> listNamHoc = _NamHocBUS.LayListNamHoc();
            comboBoxEditKhoi.Properties.Items.Add(listNamHoc);
        }




  
    }
}