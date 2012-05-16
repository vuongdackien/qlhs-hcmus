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
        public DataTable TimKiem_HocSinh(HocSinhTimKiemDTO hs, List<string> DS_MaLop = null)
        {
            List<HocSinhDTO> hsResult = new List<HocSinhDTO>();
            string oper = " LIKE ";
            string per = "%";
            string sql = "SELECT hsinh.MaHocSinh, TenHocSinh, GioiTinh, NgaySinh, NoiSinh, "
                          + " Email, DiaChi, TenLop, TenGiaoVien "
                          + " FROM HOCSINH hsinh, GIAOVIEN gvien, LOP lop, PHANLOP plop"
                          + " WHERE lop.MaGiaoVien=gvien.MaGiaoVien AND lop.MaLop=plop.MaLop AND"
                          + " plop.MaHocSinh=hsinh.MaHocSinh ";
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

            //giới tính
            if (!hs.GioiTinh.Equals(-1))
            {
                where += "AND GioiTinh = " + hs.GioiTinh + " ";
            }

            //năm sinh từ
            if (!hs.NamSinhTu.Equals(""))
            {
                where += "AND YEAR(NgaySinh)  >='" + hs.NamSinhTu + "' ";
            }

            //năm sinh đến
            if (!hs.NamSinhDen.Equals(""))
            {
                where += "AND YEAR(NgaySinh)  <='" + hs.NamSinhDen + "' ";
            }
            
            //địa chỉ
            if (!hs.DiaChi.Equals(""))
            {
                where += " AND DiaChi " + oper + "'" + per + hs.DiaChi + per + "' ";            
            }
           
            // Nếu tìm trong trong các lớp
            if (DS_MaLop!=null)
            {
                string MaLop = "";
                for (int i = 0; i < DS_MaLop.Count; i++)
                {
                    string comma = "";
                    if (i != (DS_MaLop.Count - 1))
                        comma = "','";
                    MaLop += DS_MaLop[i] + comma;
                }
                where += "AND MaHocSinh in (SELECT DISTINCT MaHocSinh FROM PHANLOP WHERE MaLop in ('" + MaLop + "')) ";
                where += "AND MaLop in('" + MaLop + "')";
            }
            sql += where;
            // thực hiện query
            return GetTable(sql);
        }
        #endregion
    }
}
