using System;
using System.Data.OleDb;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;

namespace Util
{
    internal class CustomErrorSQL
    {
        public static string GetMessageError(OleDbException ex)
        {
            string error = "Mã lỗi: " + ex.ErrorCode + " : ";
            switch (ex.ErrorCode)
            {
                case 208:
                    error += "Lỗi dữ liệu database đã thay đổi hoặc không tồn tại trigger và storeprocedure";

                    break;
                case 515:
                    error += "Không thể bỏ trống dữ liệu! " + ex.Message;
                    break;
                case 2627:
                    error += "Mã thêm đã tồn tại (trùng khóa chính). Hãy kiểm tra lại mã trước khi lưu!";
                    break;
                case 3201:
                    error += "Đường dẫn không phù hợp. Hãy chọn ổ đĩa khác để lưu!";
                    break;

                default:
                    error += ex.Message + "\n";
                    break;
            }
            return error;
        }
    }

    public class MsgboxUtil
    {
        public static DialogResult Error(Exception ex)
        {
            return XtraMessageBox.Show(ex.Message,
                                       "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Error(string Message)
        {
            return XtraMessageBox.Show("Lỗi: " + Message, "LỖI",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Success(string Message)
        {
            return XtraMessageBox.Show(Message, "THÀNH CÔNG",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Info(string Message)
        {
            return XtraMessageBox.Show(Message, "THÔNG TIN",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult YesNo(string Message)
        {
            return XtraMessageBox.Show(Message, "HỎI",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult OkCancel(string Message)
        {
            return XtraMessageBox.Show(Message, "HỎI",
                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        public static void ShowTooltip(ToolTipController tooltip, string msg, string title = "<b>Hướng dẫn</b>")
        {
            var targ = new ToolTipControllerShowEventArgs();
            targ.Title = title;
            targ.ToolTip = msg;
            targ.ShowBeak = true;
            targ.Rounded = true;
            targ.RoundRadius = 7;
            targ.ToolTipType = ToolTipType.SuperTip;
            targ.IconType = ToolTipIconType.Information;
            targ.IconSize = ToolTipIconSize.Small;
            tooltip.ShowHint(targ);
        }
    }
}