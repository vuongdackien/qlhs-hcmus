using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class BangDiemDAL : ConnectData
    {
        public DataTable LayDTDiem_HocKy_Lop(string MaLop, string MaHocKy)
        {
            string sql = string.Format("SELECT HS.TenHocSinh, PL.STT, BD.MaHocSinh, BD.MaMonHoc, "
                                        + " MH.TenMonHoc, "
                                        + " BD.MaHocKy, BD.DM_1, BD.DM_2, BD.D15_1, BD.D15_2, BD.D15_3, BD.D15_4, "
                                        + " BD.D1T_1, BD.D1T_1, BD.DThi "
                                        + " FROM BANGDIEM as BD, PHANLOP as PL, HOCSINH HS, MONHOC MH "
                                        + " WHERE BD.MaHocSinh=PL.MaHocSinh AND HS.MaHocSinh = PL.MaHocSinh "
                                        + " AND MH.MaMonHoc = BD.MaMonHoc "
                                        + " AND PL.MaLop = '{0}' AND "
                                        + " BD.MaHocKy = {1} ", MaLop, MaHocKy);
            return GetTable(sql);
        }
        /// <summary>
        /// Lấy bảng điểm môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaMonHoc">String: Mã môn học</param>
        /// <returns></returns>
        public DataTable LayBangDiem(string MaLop, string MaHocKy, string MaMonHoc)
        {
            if (MaLop == "" || MaHocKy == "" || MaMonHoc == "")
                return null;
            // Trước khi lấy, kiểm tra xem đã khởi tạo hay chưa? Nếu chưa thì khởi tạo
            string sql = string.Format("INSERT INTO BANGDIEM(MaHocSinh,MaHocKy,MaMonHoc,MaLop) "
                        + "SELECT distinct pl.MaHocSinh, '{0}' MaHocKy, '{2}' MaMonHoc, pl.MaLop "
                        +"FROM PHANLOP pl LEFT JOIN BANGDIEM bd ON pl.MaLop = bd.MaLop "
                        +"WHERE pl.MaLop = '{1}' "
                        +"AND pl.MaHocSinh NOT IN "
                        +"(select MaHocSinh FROM BANGDIEM "
	                    +"WHERE MaLop = '{1}' AND MaHocKy = '{0}' AND MaMonHoc = '{2}')",
                          MaHocKy, MaLop,MaMonHoc);
            ExecuteQuery(sql);
            // Lấy bảng điểm
            sql = "\nSELECT bd.*, pl.STT, hs.TenHocSinh "
                    + "FROM BANGDIEM bd, PHANLOP pl, HOCSINH hs WHERE hs.MaHocSinh = pl.MaHocSinh AND bd.MaHocSinh = pl.MaHocSinh "
                    + "AND bd.MaLop = '" + MaLop + "' AND bd.MaHocKy='" + MaHocKy + "' AND bd.MaMonHoc = '" + MaMonHoc + "' "
                    + "ORDER BY pl.STT ASC";
            return GetTable(sql);
        }
        /// <summary>
        /// Lưu bảng điểm 1 môn học / 1 học sinh / 1 học kỳ / 1 lớp / 1 năm học
        /// </summary>
        /// <param name="bd">BangDiemDTO</param>
        /// <returns>Bool</returns>
        public bool LuuBangDiem_MonHoc_HocSinh_HocKy(BangDiemDTO bd)
        {
            
            string sql = string.Format("UPDATE BANGDIEM SET DM_1 = {1}, DM_2 = {2}, D15_1 = {3}, D15_2 = {4}, "
                        +"D15_3 = {5}, D15_4 = {6}, D1T_1 = {7}, D1T_2 = {8}, DThi = {9}, DTB = {10} "
                        +"WHERE MaHocSinh = '{0}' AND MaHocKy = '{11}' AND MaLop = '{12}'",
                            bd.HocSinh.MaHocSinh, 
                            (bd.DM_1 == -1) ? "NULL" : bd.DM_1.ToString(),
                            (bd.DM_2 == -1) ? "NULL" : bd.DM_2.ToString(),
                            (bd.D15_1 == -1) ? "NULL" : bd.D15_1.ToString(),
                            (bd.D15_2 == -1) ? "NULL" : bd.D15_2.ToString(),
                            (bd.D15_3 == -1) ? "NULL" : bd.D15_3.ToString(),
                            (bd.D15_4 == -1) ? "NULL" : bd.D15_4.ToString(),
                            (bd.D1T_1 == -1) ? "NULL" : bd.D1T_1.ToString(),
                            (bd.D1T_2 == -1) ? "NULL" : bd.D1T_2.ToString(),
                            (bd.DThi == -1) ? "NULL" : bd.DThi.ToString(),
                            (bd.DTB == -1) ? "NULL" : bd.DTB.ToString(),
                         bd.MaHocKy,bd.LopDTO.MaLop);
            return ExecuteQuery(sql) > 0;
        }
        /// <summary>
        /// Xóa bảng điểm 1 môn học / 1 học sinh / 1 học kỳ / 1 lớp / 1 năm học
        /// </summary>
        /// <param name="bd">BangDiemDTO</param>
        /// <returns>bool</returns>
        public bool XoaBangDiem_MonHoc_HocSinh_HocKy(BangDiemDTO bd)
        {
            string sql = string.Format("UPDATE BANGDIEM SET DM_1 = NULL, DM_2 =  NULL, D15_1 = NULL, D15_2 =  NULL, "
                                     + "D15_3 = NULL, D15_4 = NULL, D1T_1 =  NULL, D1T_2 =  NULL, DThi =  NULL, DTB =  NULL "
                                      +"WHERE MaHocSinh = '{0}' "
                                      +"AND MaLop = '{1}' AND MaHocKy = {2} AND MaMonHoc = '{3}'",
                                      bd.HocSinh.MaHocSinh, bd.LopDTO.MaLop, bd.MaHocKy, bd.MonHoc.MaMonHoc);
            return ExecuteQuery(sql) > 0;
        }

        public DataTable LayBangDiem_NamHoc_Khoi(string MaKhoi, string MaMonHoc)
        {
            return null;
        }

        /// <summary>
        /// Lấy bảng điểm môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaMonHoc">String: Mã môn học</param>
        /// <returns></returns>
        public DataTable LayBangDiem_MonHoc(string MaKhoi, string MaHocKy, string MaMonHoc, string MaNamHoc)
        {
            if (MaKhoi == "" || MaHocKy == "" || MaMonHoc == "" || MaNamHoc=="")
                return null;

            string sql = string.Format("SELECT TenLop, TenGiaoVien, SiSo, count(*) as SoLuongDat, ((cast(count(lop.MaLop) as real) )/SiSo) as TyLe"                                        
                                        + " FROM BANGDIEM bdiem, HOCSINH hsinh, GIAOVIEN gvien, LOP lop, PHANLOP plop "
                                        + " WHERE hsinh.MaHocSinh=bdiem.MaHocSinh AND gvien.MaGiaoVien=lop.MaGiaoVien "
                                        + " AND DTB>=5 "
                                        + " AND lop.MaLop=plop.MaLop AND plop.MahocSinh=hsinh.MaHocSinh "
                                        + " AND MaMonHoc='"+MaMonHoc+"'  AND "
                                        + " MaHocKy='"+MaHocKy+"' AND LEFT(lop.MaLop,2)='"+MaKhoi+"' "
                                        + " AND RIGHT(lop.MaLop,6)='"+MaNamHoc+"'"
                                        + " GROUP BY TenLop, TenGiaoVien, SiSo ");
            return GetTable(sql);
        }
    }
}
