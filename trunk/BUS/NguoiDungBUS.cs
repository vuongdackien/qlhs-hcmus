using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class NguoiDungBUS
    {
        private NguoiDungDAL _nguoiDungDAL;
        public NguoiDungBUS()
        {
            _nguoiDungDAL = new NguoiDungDAL();
        }
        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <returns></returns>
        public DataTable LayDT_NguoiDung()
        {
            return _nguoiDungDAL.LayDT_NguoiDung();
        }
        /// <summary>
        /// Lấy danh sách người dùng đăng nhập
        /// </summary>
        /// <returns></returns>
        public DataTable LayDT_NguoiDung_DangNhap()
        {
            return _nguoiDungDAL.LayDT_NguoiDung_DangNhap();
        }
        /// <summary>
        /// Lấy thông tin người dùng qua username
        /// </summary>
        /// <param name="username">String: username</param>
        /// <returns></returns>
        public NguoiDungDTO LayThongTin_NguoiDung(string username)
        {
            return _nguoiDungDAL.LayDTO_ThongTin_NguoiDung(username);
        }
        /// <summary>
        /// Đổi mật khẩu người dùng
        /// </summary>
        /// <param name="TenDangNhap">Tên đăng nhập</param>
        /// <param name="NewPassword">Mật khẩu mới</param>
        public bool DoiMatKhau_NguoiDung(string TenDangNhap, string NewPassword)
        {
            return _nguoiDungDAL.DoiMatKhauNguoiDung(TenDangNhap, NewPassword);
        }
        /// <summary>
        /// Kiểm tra tồn tại người dùng
        /// </summary>
        /// <param name="MaUser">String: Mã người dùng</param>
        /// <returns></returns>
        public bool KiemTraTonTai_NguoiDung(string MaUser)
        {
            return _nguoiDungDAL.KiemTraTonTai_NguoiDung(MaUser);
        }
        /// <summary>
        /// Thêm thông tin người dùng
        /// </summary>
        /// <param name="user">NguoiDungDTO</param>
        /// <returns></returns>
        public bool Them_NguoiDung(NguoiDungDTO user)
        {
            return _nguoiDungDAL.Them_ThongTin_NguoiDung(user);
        }
        /// <summary>
        /// Sửa thông tin người dùng
        /// </summary>
        /// <param name="user">NguoiDungDTO</param>
        /// <returns></returns>
        public bool Sua_NguoiDung(NguoiDungDTO user)
        {
            return _nguoiDungDAL.Sua_ThongTin_NguoiDung(user);
        }
        /// <summary>
        /// Xóa thông tin người dùng
        /// </summary>
        /// <param name="MaUser">String: Mã user</param>
        /// <returns></returns>
        public bool Xoa_NguoiDung(string MaUser)
        {
            return _nguoiDungDAL.Xoa_ThongTin_NguoiDung(MaUser);
        }
    }
}
