using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;


namespace QLHS.DAL
{
    public class HocSinhDAL : ConnectData
    {
        /// <summary>
        /// Lấy DataTable học sinh từ Lớp học
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>DataTable</returns>
        public DataTable LayDTHocSinh_LopHoc(string MaLop)
        {
            string sql = string.Format("SELECT pl.STT, hs.MaHocSinh, hs.TenHocSinh "
                                       +"FROM PHANLOP pl LEFT JOIN HOCSINH hs ON pl.MaHocSinh = hs.MaHocSinh "
                                       +"WHERE pl.MaLop = '{0}'",MaLop);
            return GetTable(sql);
        }

        /// <summary>
        /// Lấy hồ sơ học sinh từ Mã học sinh
        /// </summary>
        /// <param name="MaHocSinh">string: Mã học sinh</param>
        /// <returns>HocSinhDTO</returns>
        public HocSinhDTO LayHoSoHocSinh(string MaHocSinh)
        {
            string sql = string.Format("SELECT pl.STT, pl.MaHocSinh, TenHocSinh , Email, NgaySinh, GioiTinh, NoiSinh, DiaChi "
                        + "FROM HOCSINH hs LEFT JOIN PHANLOP pl ON  pl.MaHocSinh = hs.MaHocSinh WHERE hs.MaHocSinh = '{0}'", MaHocSinh);
            HocSinhDTO hocSinhDTO = new HocSinhDTO();
            OpenConnect();
            var dr = ExecuteReader(sql);
            while (dr.Read())
            {
                hocSinhDTO.STT = Convert.ToInt32(dr["STT"]);
                hocSinhDTO.MaHocSinh = Convert.ToString(dr["MaHocSinh"]);
                hocSinhDTO.TenHocSinh = Convert.ToString(dr["TenHocSinh"]);
                hocSinhDTO.Email = Convert.ToString(dr["Email"]);
                hocSinhDTO.GioiTinh = Convert.ToInt16(dr["GioiTinh"]);
                hocSinhDTO.NgaySinh = Convert.ToDateTime(dr["NgaySinh"]);
                hocSinhDTO.NoiSinh = Convert.ToString(dr["NoiSinh"]);
                hocSinhDTO.DiaChi = Convert.ToString(dr["DiaChi"]);
            }
            CloseConnect();

            return hocSinhDTO;
        }
    }
}
