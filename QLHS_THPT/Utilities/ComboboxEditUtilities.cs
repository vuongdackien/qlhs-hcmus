using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DevExpress.XtraEditors;

namespace QLHS_THPT
{
    public class ComboboxEditUtilities
    {
        private string sValue;
        private string sDisplay;

        public ComboboxEditUtilities(string svalue, string sdisplay)
        {
            sValue = svalue;
            sDisplay = sdisplay;
        }
        
        public override string ToString() { return sDisplay; }
 
        public string Value
        {
            get { return sValue; }
        }

        /// <summary>
        /// Gắn DataSource cho ComboBoxEdit
        /// </summary>
        /// <param name="comb">ComboBoxEdit</param>
        /// <param name="dt">DataTable</param>
        /// <param name="value">String: Value member</param>
        /// <param name="display">String: Display member</param>
        /// <param name="selected_index">Int: Chọn dòng</param>
        public static void SetDataSource(ComboBoxEdit comb, DataTable dt, string value, string display,
            int selected_index = 0)
        {

            foreach (DataRow dr in dt.Rows)
            {
                comb.Properties.Items.Add(
                      new ComboboxEditUtilities(dr[value].ToString(), dr[display].ToString())
                );

            }
            comb.SelectedIndex = selected_index;
        }

        /// <summary>
        /// Gắn DataSource cho ComboBoxEdit có thêm dòng đầu tiên
        /// </summary>
        /// <param name="comb">ComboBoxEdit</param>
        /// <param name="dt">DataTable</param>
        /// <param name="value">String: Value member</param>
        /// <param name="display">String: Display member</param>
        /// <param name="value_all">String: Display member dòng đầu tiên</param>
        /// <param name="display_all">String: Value member dòng đầu tiên</param>
        /// <param name="selected_index">Int: Chọn dòng</param>
        public static void SetDataSource(ComboBoxEdit comb, DataTable dt, string value, string display, 
                string value_all = "all", string display_all = "Tất cả", int selected_index = 0)
        {

           comb.Properties.Items.Add(new ComboboxEditUtilities(value_all, display_all));
            foreach (DataRow dr in dt.Rows)
            {
                comb.Properties.Items.Add(
                      new ComboboxEditUtilities(dr[value].ToString(), dr[display].ToString())
                );
            }
            comb.SelectedIndex = selected_index;

        }

        /// <summary>
        /// Lấy giá trị selected của ComboboxEdit
        /// </summary>
        /// <param name="comb">ComboBoxEdit</param>
        /// <returns>string: giá trị valuemember</returns>
        public static string GetValueItem(ComboBoxEdit comb) 
        {
            return ((ComboboxEditUtilities)comb.SelectedItem).Value;
        }

        /// <summary>
        /// Chọn Item ComboBoxEdit
        /// </summary>
        /// <param name="comb">ComboBoxEdit</param>
        /// <param name="svalue">String: Giá trị chọn valuemember</param>
        public static void SelectedItem(ComboBoxEdit comb, string svalue) 
        {
            comb.EditValue = svalue;
        }
    }

}
