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

            DataRow dr = GetFirstDataRow(sql);
            hocSinhDTO.STT = Convert.ToInt32(dr["STT"]);
            hocSinhDTO.MaHocSinh = Convert.ToString(dr["MaHocSinh"]);
            hocSinhDTO.TenHocSinh = Convert.ToString(dr["TenHocSinh"]);
            hocSinhDTO.Email = Convert.ToString(dr["Email"]);
            hocSinhDTO.GioiTinh = Convert.ToInt16(dr["GioiTinh"]);
            hocSinhDTO.NgaySinh = Convert.ToDateTime(dr["NgaySinh"]);
            hocSinhDTO.NoiSinh = Convert.ToString(dr["NoiSinh"]);
            hocSinhDTO.DiaChi = Convert.ToString(dr["DiaChi"]);            
            return hocSinhDTO;
        }

        /// <summary>
        /// Sửa hồ sơ học sinh
        /// </summary>
        /// <param name="hocsinhDTO">HocSinhDTO</param>
        /// <returns>Bool: Thành công/Không</returns>
        public bool SuaHoSoHocSinh(HocSinhDTO hocsinhDTO)
        {
            string sql = string.Format("UPDATE HOCSINH SET TenHocSinh = N'{1}', Email = '{1}', NgaySinh = '{3}',"
                         +"GioiTinh = {4}, NoiSinh = N'{5}', DiaChi = N'{6}' "
                         +"WHERE MaHocSinh = '{0}'",hocsinhDTO.MaHocSinh,hocsinhDTO.TenHocSinh,
                           hocsinhDTO.Email, hocsinhDTO.NgaySinh, hocsinhDTO.GioiTinh, hocsinhDTO.NoiSinh, hocsinhDTO.DiaChi);
            sql += string.Format("\nUPDATE PHANLOP SET STT = {1} WHERE MaHocSinh = '{0}'", hocsinhDTO.MaHocSinh,
                                    hocsinhDTO.STT);
            return ExecuteQuery(sql) > 0;
        }
        /// <summary>
        /// Thêm hồ sơ học sinh
        /// </summary>
        /// <param name="hocsinhDTO">HocSinhDTO</param>
        /// <returns>Bool: Thành công/Không</returns>
        public bool ThemHoSoHocSinh(HocSinhDTO hocsinhDTO)
        {
            string sql = string.Format("INSERT INTO HOCSINH (MaHocSinh, TenHocSinh , Email, NgaySinh, GioiTinh, NoiSinh, DiaChi) "
                         +"VALUES ('{0}',N'{1}','{2}','{3}',{4},N'{5}',N'{6}' ", hocsinhDTO.MaHocSinh, hocsinhDTO.TenHocSinh,
                           hocsinhDTO.Email, hocsinhDTO.NgaySinh, hocsinhDTO.GioiTinh, hocsinhDTO.NoiSinh, hocsinhDTO.DiaChi);
            sql += string.Format("\nUPDATE PHANLOP SET STT = {1} WHERE MaHocSinh = '{0}'", hocsinhDTO.MaHocSinh,
                                    hocsinhDTO.STT);
            return ExecuteQuery(sql) > 0;
        }
        /// <summary>
        /// Kiểm tra tồn tại của 1 hồ sơ học sinh qua Mã học sinh
        /// </summary>
        /// <param name="MaHocSinh">String: Mã học sinh</param>
        /// <returns>Bpol: Tồn tại/Không</returns>
        public bool KiemTraTonTai_MaHocSinh(string MaHocSinh)
        {
            string sql = string.Format("SELECT count(*) as SL FROM HOCSINH WHERE MaHocSinh = '{0}'",MaHocSinh);
            return (int)ExecuteScalar(sql) == 1;
        }
        /// <summary>
        /// Lấy mã cuối cùng (MaHocSinh) - Bảng HOCSINH
        /// </summary>
        /// <returns>String: Mã cuối cùng</returns>
        public string LayMaCuoiCung()
        {
            return GetLastID("HOCSINH", "MaHocSinh");
        }

    }
}
