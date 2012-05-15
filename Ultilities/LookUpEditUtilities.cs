using System.Data;
using DevExpress.XtraEditors;

namespace Utilities
{

    public class LookUpEditUtilities
    {

        /// <summary>
        /// Gắn DataSource cho LookUpEdit
        /// </summary>
        /// <param name="lookUpEdit">LookUpEdit</param>
        /// <param name="tb">DataTable</param>
        /// <param name="nameValue">String: Value member</param>
        /// <param name="nameDisplay">String: Display member</param>
        /// <param name="select_index">Int: Chọn dòng</param>
        public static void SetDataSource
                (LookUpEdit lookUpEdit, DataTable tb, string nameValue, string nameDisplay, int select_index = 0)
        {
            // add datasource
            lookUpEdit.Properties.DataSource = tb;
            lookUpEdit.Properties.DisplayMember = nameDisplay;
            lookUpEdit.Properties.ValueMember = nameValue;
            // seleted index
            lookUpEdit.ItemIndex = select_index;
        }
        /// <summary>
        /// Gắn DataSource cho LookUpEdit
        /// </summary>
        /// <param name="lookUpEdit">LookUpEdit</param>
        /// <param name="tb">DataTable</param>
        /// <param name="nameValue">String: Value member</param>
        /// <param name="nameDisplay">String: Display member</param>
        /// <param name="nameValue_all">String: Display member dòng đầu tiên</param>
        /// <param name="nameDisplay_all">String: Value member dòng đầu tiên</param>
        /// <param name="select_index">Int: Chọn dòng</param>
        public static void SetDataSource
         (LookUpEdit lookUpEdit, DataTable tb, string nameValue, string nameDisplay,
                   string nameValue_all = "all", string nameDisplay_all = "Tất cả", int select_index = 0)
        {
            // Add new row
            DataRow dr = tb.NewRow();
            dr[nameValue] = nameValue_all;
            dr[nameDisplay] = nameDisplay_all;
            tb.Rows.InsertAt(dr, 0);
            // Add datasource
            lookUpEdit.Properties.DataSource = tb;
            lookUpEdit.Properties.DisplayMember = nameDisplay;
            lookUpEdit.Properties.ValueMember = nameValue;
            // seleted index
            lookUpEdit.ItemIndex = select_index;
        }

        /// <summary>
        /// Lấy giá trị selected của LookUpEdit
        /// </summary>
        /// <param name="lookUpEdit">LookUpEdit</param>
        /// <param name="ValueMember">String: tên field ValueMember muốn lấy</param>
        /// <returns>String: Giá trị valuemember</returns>
        public static string GetValueItem(LookUpEdit lookUpEdit, string ValueMember)
        {
            return lookUpEdit.GetColumnValue(ValueMember).ToString();
        }

        /// <summary>
        /// Chọn Item ComboBoxEdit
        /// </summary>
        /// <param name="comb">ComboBoxEdit</param>
        /// <param name="svalue">String: Giá trị chọn valuemember</param>
        public static void SelectedItem(LookUpEdit lookUpEdit, string svalue)
        {
            lookUpEdit.EditValue = svalue;
        }
       

      
    }
}
