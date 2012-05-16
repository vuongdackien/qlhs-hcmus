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
        public bool SuaHoSoHocSinh(HocSinhDTO hocsinhDTO,string MaLop)
        {
            string sql = string.Format("UPDATE HOCSINH SET TenHocSinh = '{1}', Email = '{2}', NgaySinh = '{3}', "
                         +"GioiTinh = {4}, NoiSinh = '{5}', DiaChi = '{6}' "
                         +"WHERE MaHocSinh = '{0}'",hocsinhDTO.MaHocSinh,hocsinhDTO.TenHocSinh,hocsinhDTO.Email,
                           hocsinhDTO.NgaySinh, hocsinhDTO.GioiTinh, hocsinhDTO.NoiSinh, hocsinhDTO.DiaChi);
          //  sql += string.Format("\nUPDATE PHANLOP SET STT = {2} WHERE MaHocSinh = '{0}' AND MaLop = '{1}'", hocsinhDTO.MaHocSinh,
                                //    MaLop,
                                 //   hocsinhDTO.STT);
            return ExecuteQuery(sql) > 0;
        }
        /// <summary>
        /// Thêm hồ sơ học sinh
        /// </summary>
        /// <param name="hocsinhDTO">HocSinhDTO</param>
        /// <returns>Bool: Thành công/Không</returns>
        public bool ThemHoSoHocSinh(HocSinhDTO hocsinhDTO,string MaLop)
        {
            string sql = string.Format("INSERT INTO HOCSINH (MaHocSinh, TenHocSinh , Email, NgaySinh, GioiTinh, NoiSinh, DiaChi) "
                         +"VALUES ('{0}',N'{1}','{2}','{3}',{4},N'{5}',N'{6}' ", hocsinhDTO.MaHocSinh, hocsinhDTO.TenHocSinh,
                           hocsinhDTO.Email, hocsinhDTO.NgaySinh, hocsinhDTO.GioiTinh, hocsinhDTO.NoiSinh, hocsinhDTO.DiaChi);
            sql += string.Format("\nINSERT INTO PHANLOP (STT,MaHocSinh,MaLop) VALUES ({0},'{1}','{2})", 
                        hocsinhDTO.STT,  hocsinhDTO.MaHocSinh, MaLop);
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


        #region Các hàm tìm kiếm học sinh
        /// <summary>
        /// Tìm kiếm học sinh 
        /// </summary>
        /// <param name="hs">Object: HocSinhTimKiem - Thông tin học sinh tìm kiếm</param>
        /// <param name="DS_MaLop">Default: NULL (Tìm tất cả các năm) || Tìm trong các lớp</param>
        /// <returns>DataTable HocSinh</returns>
        public DataTable TimKiem_HocSinh(HocSinhDTO hs, List<string> DS_MaLop = null)
        {
            List<HocSinhDTO> hsResult = new List<HocSinhDTO>();
            string oper = " LIKE ";
            string per = "%";
            string sql = "SELECT HS.MaHocSinh, TenHocSinh, GioiTinh, NgaySinh, NoiSinh, "
                          + " Email, DiaChi, TenLop, TenGiaoVien "
                          + " FROM HOCSINH AS HS, GIAOVIEN AS GV, LOP AS L, PHANLOP AS PL"
                          + " WHERE L.MaGiaoVien=GV.MaGiaoVien AND L.MaLop=PL.MaLop AND"
                          + " PL.MaHocSinh=HS.MaHocSinh ";
            string where = "";
                        
            // Mã học sinh
            if (!hs.MaHocSinh.Equals(""))
            {
                where += " AND MaHocSinh " + oper + "'" + per + hs.MaHocSinh + per + "' ";
            }
            //tên học sinh
            if (!hs.TenHocSinh.Equals(""))
            {
                where += " AND TenHocSinh " + oper + "'" + per + hs.TenHocSinh + per + "' "; 
            }
            //địa chỉ
            if (!hs.DiaChi.Equals(""))
            {
                where += " AND DiaChi " + oper + "'" + per + hs.DiaChi + per + "' ";            
            }
            sql += where;
            // Nếu tìm trong trong các lớp
           
            // thực hiện query
            return GetTable(sql);
        }
        #endregion
    }
}
