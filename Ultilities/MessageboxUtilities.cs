using DevExpress.XtraEditors;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Utilities
{

    class CustomErrorSQL
    {
        public static string GetMessageError(OleDbException ex)
        {
            string error = "Mã lỗi: " + ex.ErrorCode + " : ";
            switch (ex.ErrorCode)
            {
                case 208: error += "Lỗi dữ liệu database đã thay đổi hoặc không tồn tại trigger và storeprocedure";

                    break;
                case 515: error += "Không thể bỏ trống dữ liệu! " + ex.Message; break;
                case 2627: error += "Mã thêm đã tồn tại (trùng khóa chính). Hãy kiểm tra lại mã trước khi lưu!"; break;
                case 3201: error += "Đường dẫn không phù hợp. Hãy chọn ổ đĩa khác để lưu!"; break;

                default: error += ex.Message + "\n"; break;
            }
            return error;
        }
    }

    public class MessageboxUtilities
    {

        public static DialogResult MessageError(OleDbException ex)
        {
            return XtraMessageBox.Show(CustomErrorSQL.GetMessageError(ex),
                "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult MessageError()
        {
            
            return XtraMessageBox.Show("Có lỗi trong quá trình thực hiện", "LỖI",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult MessageError(string Message)
        {
            return XtraMessageBox.Show("Lỗi: " + Message, "LỖI",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static DialogResult MessageSuccess()
        {
            return XtraMessageBox.Show("Thực hiện thành công", "THÀNH CÔNG",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult MessageSuccess(string Message)
        {
            return XtraMessageBox.Show(Message, "THÀNH CÔNG",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult MessageQuestionYesNo(string Message)
        {
            return XtraMessageBox.Show(Message, "HỎI",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static DialogResult MessageQuestionOkCancel(string Message)
        {
            return XtraMessageBox.Show(Message, "HỎI",
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }
    }
}
