using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Collections;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using QLHS.DTO;
using DevExpress.XtraEditors;

namespace QLHS_THPT
{

    public static partial class Utilities
    {

        #region Hàm thêm 1 row vào combobox
        public static void AddDataSource_LookUpEdit
                (LookUpEdit lookUpEdit, DataTable tb, string nameValue, string nameDisplay)
        {
            lookUpEdit.Properties.DataSource = tb;
            lookUpEdit.Properties.DisplayMember = nameDisplay;
            lookUpEdit.Properties.ValueMember = nameValue;
      }
        #endregion

      
    }
}
