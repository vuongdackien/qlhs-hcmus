using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class NguoiDungDAL : ConnectData
    {
        public NguoiDungDAL()
        {

        }
        /// <summary>
        /// Lấy danh sách người dùng
        /// </summary>
        /// <returns></returns>
        public DataTable Lay_DT_NguoiDung()
        {
            string sql = "SELECT MaND, a.MaLoaiND, TenLoaiND, TenGiaoVien ,TenDNhap, a.TrangThai "
                         + " FROM NGUOIDUNG a,GIAOVIEN b, LOAINGUOIDUNG c "
                         + " WHERE a.MaND = b.MaGiaoVien and a.MaLoaiND = c.MaLoaiND";
            return GetTable(sql);
        }
        /// <summary>
        /// Lấy danh sách người dùng đăng nhập
        /// </summary>
        /// <returns></returns>
        public DataTable Lay_DT_NguoiDung_DangNhap()
        {
            string sql = "SELECT MaND, a.MaLoaiND, TenLoaiND, TenGiaoVien ,TenDNhap "
                         + " FROM NGUOIDUNG a,GIAOVIEN b, LOAINGUOIDUNG c "
                         + " WHERE a.MaND = b.MaGiaoVien and a.MaLoaiND = c.MaLoaiND AND a.TrangThai = 1";
            return GetTable(sql);
        }
        public NguoiDungDTO LayThongTinNguoiDung(string username)
        {
            string sql = "SELECT MaND, a.MaLoaiND, MatKhau, TenLoaiND, TenGiaoVien ,TenDNhap, a.TrangThai "
                        + " FROM NGUOIDUNG a, GIAOVIEN b, LOAINGUOIDUNG c "
                        + " WHERE a.MaND = b.MaGiaoVien and a.MaLoaiND = c.MaLoaiND "
                        + " AND TenDNhap = '" + username + "'";
            NguoiDungDTO nguoiDung = null;
            OpenConnect();
            var dr = ExecuteReader(sql);
            while (dr.Read())
            {
                nguoiDung = new NguoiDungDTO();
                nguoiDung.MaND = Convert.ToString(dr["MaND"]);
                nguoiDung.LoaiNguoiDung.MaLoai = Convert.ToString(dr["MaLoaiND"]);
                nguoiDung.LoaiNguoiDung.TenLoaiND = Convert.ToString(dr["TenLoaiND"]);
                nguoiDung.TenND = Convert.ToString(dr["TenGiaoVien"]);
                nguoiDung.TenDNhap = Convert.ToString(dr["TenDNhap"]);
                nguoiDung.MatKhau = Convert.ToString(dr["MatKhau"]);
                nguoiDung.TrangThai = Convert.ToInt16(dr["TrangThai"]);
            }
            CloseConnect();
            return nguoiDung;
        }
        /// <summary>
        /// Đổi mật khẩu người dùng
        /// </summary>
        /// <param name="TenDangNhap">Tên đăng nhập</param>
        /// <param name="NewPassword">Mật khẩu mới</param>
        public bool DoiMatKhauNguoiDung(string TenDangNhap, string NewPassword)
        {
            string sql = "UPDATE NGUOIDUNG SET MatKhau = '" + Util.ObjectUtil.MaHoaMD5(NewPassword) + "' WHERE TenDNhap = '" + TenDangNhap + "'";
            return ExecuteQuery(sql) > 0 ? true : false;
        }
        /// <summary>
        /// Kiểm tra tồn tại người dùng
        /// </summary>
        /// <param name="MaUser">String: Mã người dùng</param>
        /// <returns></returns>
        public bool KiemTraTonTai_NguoiDung(string MaUser)
        {
            string sql = "SELECT MaND FROM NGUOIDUNG WHERE MaND = '" + MaUser + "'";
            return (ExecuteScalar(sql) == null) ? false : true;
        }
        /// <summary>
        /// Thêm thông tin người dùng
        /// </summary>
        /// <param name="user">NguoiDungDTO</param>
        /// <returns></returns>
        public bool ThemNguoiDung(NguoiDungDTO user)
        {
            string sql = string.Format("INSERT INTO NGUOIDUNG (MaND, MaLoaiND, TenDNhap, MatKhau, TrangThai ) "
                        + "VALUES ('{0}','{1}','{2}','{3}','{4}')",
                        user.MaND, user.LoaiNguoiDung.MaLoai, user.TenDNhap, Util.ObjectUtil.MaHoaMD5(user.MatKhau), user.TrangThai);
            if (ExecuteQuery(sql) > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Sửa thông tin người dùng
        /// </summary>
        /// <param name="user">NguoiDungDTO</param>
        /// <returns></returns>
        public bool SuaNguoiDung(NguoiDungDTO user)
        {
            string updatePassword = (user.MatKhau == "") ? "" : "MatKhau = '" + Util.ObjectUtil.MaHoaMD5(user.MatKhau) + "',";
            string sql = string.Format("UPDATE NGUOIDUNG SET MaLoaiND = '{0}', TenDNhap = '{1}', " + updatePassword + " TrangThai = '{2}' "
                        + "WHERE MaND = '{3}'",
                        user.LoaiNguoiDung.MaLoai, user.TenDNhap, user.TrangThai, user.MaND);
            if (ExecuteQuery(sql) > 0)
                return true;
            return false;
        }
        /// <summary>
        /// Xóa thông tin người dùng
        /// </summary>
        /// <param name="MaUser">String: Mã user</param>
        /// <returns></returns>
        public bool XoaNguoiDung(string MaUser)
        {
            string sql = "DELETE FROM NGUOIDUNG WHERE MaND = '" + MaUser + "'";
            return ExecuteQuery(sql) > 0 ? true : false;
        }

    }
}
