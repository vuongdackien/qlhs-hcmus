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
    public partial class frmQuyDinhDauNam : DevExpress.XtraEditors.XtraForm
    {
        public frmQuyDinhDauNam()
        {
            InitializeComponent();
        }

        private void frmQuyDinh_Resize(object sender, EventArgs e)
        {
            // canh giữa form
          //  panelControl2.Location =
               // new Point(this.MdiParent.Size.Width / 2 - panelControl2.Size.Width / 2,
                    //       panelControl2.Location.Y);
        }
    }
}