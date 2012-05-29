using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class LopDAL : ConnectData
    {
        /// <summary>
        /// Lấy DataTable Lớp từ mã năm và khối
        /// </summary>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <param name="MaKhoi">String: mã khối</param>
        /// <returns></returns>
        public DataTable LayDTLop_MaNam_MaKhoi(string MaNamHoc, string MaKhoi)
        {
            string sql = string.Format("SELECT MaLop, TenLop, gv.MaGiaoVien, TenGiaoVien, SiSo, l. MaNamHoc, TenNamHoc, MaKhoiLop "
                                      + " FROM LOP l LEFT JOIN GIAOVIEN gv ON l.MaGiaoVien=gv.MaGiaoVien LEFT JOIN NAMHOC namhoc  ON " 
                                      + " l.MaNamHoc=namhoc.MaNamHoc WHERE "
                                      + " MaKhoiLop = '{0}' AND l.MaNamHoc = '{1}' ",MaKhoi,MaNamHoc);
            return GetTable(sql);
        }
        /// <summary>
        /// Lấy list Lớp từ mã năm và khối
        /// </summary>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <param name="MaKhoi">String: mã khối</param>
        /// <returns></returns>
        public List<LopDTO> LayListLop_MaNam_MaKhoi(string MaNamHoc, string MaKhoi)
        {
            string sql = string.Format("SELECT MaLop, TenLop, g.* FROM LOP l LEFT JOIN GIAOVIEN g "
                                      + " ON l.MaGiaoVien = g.MaGiaoVien WHERE MaKhoiLop = '{0}' "
                                      + " AND MaNamHoc = '{1}' ", MaKhoi, MaNamHoc);
            OpenConnect();
            List<LopDTO> listLopDTO = new List<LopDTO>();
            LopDTO lopDTO;
            var dr = ExecuteReader(sql);
            while (dr.Read())
            {
                lopDTO = new LopDTO();
                lopDTO.MaLop = Convert.ToString(dr["MaLop"]);
                lopDTO.TenLop = Convert.ToString(dr["TenLop"]);
                lopDTO.GiaoVien.MaGiaoVien = Convert.ToString(dr["MaGiaoVien"]);
                lopDTO.GiaoVien.TenGiaoVien = Convert.ToString(dr["TenGiaoVien"]);
                listLopDTO.Add(lopDTO);
            }
            CloseConnect();
            return listLopDTO;
        }
        /// <summary>
        /// Lấy tên giáo viên chủ nhiệm
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>String: Tên giáo viên</returns>
        public string Lay_TenGiaoVien_MaLop(string MaLop)
        {
            string sql = "SELECT gv.TenGiaoVien FROM GIAOVIEN gv, LOP l "
                        +"WHERE gv.MaGiaoVien = l.MaGiaoVien AND l.Malop ='"+MaLop+"'";
            return Convert.ToString(ExecuteScalar(sql));
        }
        /// <summary>
        /// Kiểm tra tồn tại mã lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Bool</returns>
        public bool KiemTra_TonTaiMaLop(string MaLop)
        {
            string sql = "SELECT count(*) FROM Lop WHERE MaLop = '"+MaLop+"'";
            return Convert.ToInt32(ExecuteScalar(sql)) > 0;
        }
        /// <summary>
        /// Thêm lớp mới
        /// </summary>
        /// <param name="lop">LopDTO</param>
        /// <returns></returns>
        public bool Them_Lop(LopDTO lop)
        {
            if (this.KiemTra_TonTaiMaLop(lop.MaLop))
            {
                Utilities.ExceptionUtilities.ThrowMsgBox("Lớp: " + lop.TenLop + " đã tồn tại!");
                return false;
            }
            string sql = string.Format("INSERT INTO LOP (MaLop, TenLop, MaGiaoVien, MaKhoiLop, MaNamHoc, SiSo) "
                                        +"VALUES ('{0}','{1}','{2}',{3},'{4}',{5})",
                                         lop.MaLop,lop.TenLop,lop.GiaoVien.MaGiaoVien,lop.MaKhoiLop,lop.MaNamHoc,0);
            return ExecuteQuery(sql) > 0;
        }
        /// <summary>
        /// Cập nhật giáo viên chủ nhiệm
        /// </summary>
        /// <param name="lop">LopDTO</param>
        /// <returns></returns>
        public bool CapNhat_GiaoVienCN_Lop(LopDTO lop)
        {
            string sql = string.Format("UPDATE LOP SET MaGiaoVien = '{1}' WHERE MaLop = '{0}'",
                                        lop.MaLop,  lop.GiaoVien.MaGiaoVien);
            return ExecuteQuery(sql) > 0; 
        }
        /// <summary>
        /// Xóa lớp từ mã lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns></returns>
        public bool Xoa_Lop(string MaLop)
        {
            string sql = "DELETE FROM PHANLOP WHERE MaLop = '"+MaLop+"'";
            sql += "\nDELETE FROM CHUYENLOP WHERE TuLop = '"+MaLop+"'";
            sql += "\nDELETE FROM CHUYENLOP WHERE DenLop = '" + MaLop + "'";
            sql += "\nDELETE FROM BANGDIEM WHERE MaLop = '" + MaLop + "'";
            sql += "\nDELETE FROM LOP WHERE MaLop = '" + MaLop + "'";
            return ExecuteQuery(sql) > 0;
        }
        public bool Xoa_Lop_Nam(string MaNamHoc)
        {
            string sql = "SELECT MaLop FROM LOP WHERE MaNamHoc = '" + MaNamHoc + "'";
            DataTable tbLop = GetTable(sql);
            foreach (DataRow dr in tbLop.Rows)
	        {
                 this.Xoa_Lop(dr["MaLop"].ToString());
	        }
            return true;
        }
    }
}
