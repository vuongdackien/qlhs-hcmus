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
            string sql = "SELECT bd.*, pl.STT, hs.TenHocSinh "
                    + "FROM BANGDIEM bd, PHANLOP pl, HOCSINH hs WHERE hs.MaHocSinh = pl.MaHocSinh AND bd.MaHocSinh = pl.MaHocSinh "
                    + "AND bd.MaLop = '" + MaLop + "' AND bd.MaHocKy='" + MaHocKy + "' AND bd.MaMonHoc = '" + MaMonHoc + "' "
                    + "ORDER BY pl.STT ASC";
            return GetTable(sql);
        }
    }
}
