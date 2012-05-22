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
                         + " WHERE a.MaND = b.MaGiaoVien and a.MaLoai = c.MaLoai";
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
                nguoiDung.TrangThai = Convert.ToBoolean(dr["TrangThai"]);
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
            string sql = "UPDATE NGUOIDUNG SET MatKhau = '" + Utilities.ObjectUtilities.MaHoaMD5(NewPassword) + "' WHERE TenDNhap = '" + TenDangNhap + "'";
            return ExecuteQuery(sql) > 0 ? true : false;
        }
    }
}
