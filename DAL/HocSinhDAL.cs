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
        public DataTable LayDT_HocSinh_LopHoc(string MaLop)
        {
            string sql = string.Format("SELECT pl.STT, hs.* "
                                       +"FROM PHANLOP pl LEFT JOIN HOCSINH hs ON pl.MaHocSinh = hs.MaHocSinh "
                                       +"WHERE pl.MaLop = '{0}' ORDER BY pl.STT ASC",MaLop);
            return GetTable(sql);
        }
        /// <summary>
        /// lấy DataTable học sinh chưa được có lớp
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDT_HS_HocSinh()
        {
            DataTable dt = new DataTable();
            DataColumn dcl=new DataColumn("STT",typeof(int));
            dt.Columns.Add(dcl);
            string sql = "SELECT MaHocSinh,TenHocSinh from HOCSINH WHERE MaHocSinh not in (select MaHocSinh from PHANLOP)";
            m_DataApdater = new System.Data.SqlClient.SqlDataAdapter(sql, m_Connect);
            m_DataApdater.Fill(dt);
            return dt;
        }
        /// <summary>
        /// Lấy List học sinh từ Lớp học
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>List HocSinhDTO </returns>
        public List<HocSinhDTO> LayList_HocSinh_LopHoc(string MaLop)
        {
            string sql = string.Format("SELECT pl.STT, hs.* "
                                       + "FROM PHANLOP pl LEFT JOIN HOCSINH hs ON pl.MaHocSinh = hs.MaHocSinh "
                                       + "WHERE pl.MaLop = '{0}' ORDER BY pl.STT ASC", MaLop);
            List<HocSinhDTO> listHS = new List<HocSinhDTO>();
            OpenConnect();
            var reader = ExecuteReader(sql);
            while (reader.Read())
            {
                HocSinhDTO hs = new HocSinhDTO();
                hs.STT = Convert.ToInt16(reader["STT"]);
                hs.MaHocSinh = Convert.ToString(reader["MaHocSinh"]);
                hs.TenHocSinh = Convert.ToString(reader["TenHocSinh"]);
                hs.NoiSinh = Convert.ToString(reader["NoiSinh"]);
                hs.NgaySinh = Convert.ToDateTime(reader["NgaySinh"]);
                hs.GioiTinh = Convert.ToInt16(reader["GioiTinh"]);
                hs.Email = Convert.ToString(reader["Email"]);
                hs.DiaChi = Convert.ToString(reader["DiaChi"]);
                listHS.Add(hs);
            }
            CloseConnect();
            return listHS;
        }
        /// <summary>
        /// Lấy hồ sơ học sinh từ Mã học sinh
        /// </summary>
        /// <param name="MaHocSinh">string: Mã học sinh</param>
        /// <returns>HocSinhDTO</returns>
        public HocSinhDTO Lay_HoSo(string MaHocSinh)
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
        public bool Sua_HoSo(HocSinhDTO hocsinhDTO,string MaLop)
        {
            string sql = "set dateformat dmy\n";
             sql += string.Format("UPDATE HOCSINH SET TenHocSinh = N'{1}', Email = '{2}', NgaySinh = '{3:dd-MM-yyyy}', "
                         +"GioiTinh = {4}, NoiSinh = N'{5}', DiaChi = N'{6}' "
                         +"WHERE MaHocSinh = '{0}'",hocsinhDTO.MaHocSinh,hocsinhDTO.TenHocSinh,hocsinhDTO.Email,
                           hocsinhDTO.NgaySinh, hocsinhDTO.GioiTinh, hocsinhDTO.NoiSinh, hocsinhDTO.DiaChi);
            sql += string.Format("\nUPDATE PHANLOP SET STT = {2} WHERE MaHocSinh = '{0}' AND MaLop = '{1}'", hocsinhDTO.MaHocSinh,
                                    MaLop,
                                    hocsinhDTO.STT);
            return ExecuteQuery(sql) > 0;
        }
        /// <summary>
        /// Thêm hồ sơ học sinh
        /// </summary>
        /// <param name="hocsinhDTO">HocSinhDTO</param>
        /// <returns>Bool: Thành công/Không</returns>
        public bool Them_HoSo(HocSinhDTO hocsinhDTO,string MaLop)
        {
            string sql = "set dateformat dmy\n";
                  sql += string.Format("INSERT INTO HOCSINH (MaHocSinh, TenHocSinh , Email, NgaySinh, GioiTinh, NoiSinh, DiaChi) "
                         +"VALUES ('{0}',N'{1}','{2}','{3:dd-MM-yyyy}',{4},N'{5}',N'{6}')", hocsinhDTO.MaHocSinh, hocsinhDTO.TenHocSinh,
                           hocsinhDTO.Email, hocsinhDTO.NgaySinh, hocsinhDTO.GioiTinh, hocsinhDTO.NoiSinh, hocsinhDTO.DiaChi);
            sql += string.Format("\nINSERT INTO PHANLOP (STT,MaHocSinh,MaLop) VALUES ({0},'{1}','{2}')", 
                        hocsinhDTO.STT,  hocsinhDTO.MaHocSinh, MaLop);
            return ExecuteQuery(sql) > 0;
        }
        /// <summary>
        /// Kiểm tra tồn tại của 1 hồ sơ học sinh qua Mã học sinh
        /// </summary>
        /// <param name="MaHocSinh">String: Mã học sinh</param>
        /// <returns>Bool: Tồn tại/Không</returns>
        public bool KiemTraTonTai_MaHocSinh(string MaHocSinh)
        {
            string sql = string.Format("SELECT count(*) as SL FROM HOCSINH WHERE MaHocSinh = '{0}'",MaHocSinh);
            return (int)ExecuteScalar(sql) == 1;
        }
        /// <summary>
        /// Lấy mã cuối cùng (MaHocSinh) - Bảng HOCSINH
        /// </summary>
        /// <returns>String: Mã cuối cùng</returns>
        public string Lay_MaCuoiCung()
        {
            return GetLastID("HOCSINH", "MaHocSinh");
        }
        /// <summary>
        /// Xóa 1 hồ sơ học sinh
        /// </summary>
        /// <param name="MaHocSinh">String: Mã học sinh</param>
        /// <returns>Bool</returns>
        public bool Xoa_HoSo(string MaHocSinh)
        {
            string sql = "DELETE FROM PHANLOP WHERE MaHocSinh = '"+MaHocSinh+"'";
            sql += "\nDELETE FROM BANGDIEM WHERE MaHocSinh = '"+MaHocSinh+"'";
            sql += "\nDELETE FROM CHUYENLOP WHERE MaHocSinh = '" + MaHocSinh + "'";
            sql += "\nDELETE FROM HOCSINH WHERE MaHocSinh = '" + MaHocSinh + "'";
            return ExecuteQuery(sql) > 0;
        }

        #region Các hàm tìm kiếm học sinh
        /// <summary>
        /// Tìm kiếm học sinh 
        /// </summary>
        /// <param name="hs">Object: HocSinhTimKiem - Thông tin học sinh tìm kiếm</param>
        /// <param name="DS_MaLop">Default: NULL (Tìm tất cả các năm) || Tìm trong các lớp</param>
        /// <returns>DataTable HocSinh</returns>
        public DataTable Tim_HoSo(HocSinhTimKiemDTO hs, List<string> DS_MaLop = null)
        {
            List<HocSinhDTO> hsResult = new List<HocSinhDTO>();
            string oper = " LIKE ";
            string per = "%";
            string sql = "SELECT distinct hsinh.MaHocSinh, TenHocSinh, "
                          + " GioiTinh = (CASE GioiTinh WHEN 0 THEN N'Nam' "
                          + " WHEN 1 THEN N'Nữ' END), "
                          + " NgaySinh, NoiSinh, "
                          + " Email, DiaChi, TenLop, lop.MaLop, TenGiaoVien "
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
                where += " AND (TenHocSinh " + oper + "N'" + per + hs.TenHocSinh + per + "' ";
                where += "OR dbo.fnChuyenKhongDau(TenHocSinh) " + oper + "N'" + per + hs.TenHocSinh + per + "' )";
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

            //email
            if (!hs.Email.Equals(""))
            {
                where += " AND Email " + oper + "'" + per + hs.Email + per + "' ";
            }
            
            //địa chỉ
            if (!hs.DiaChi.Equals(""))
            {
                where += " AND (DiaChi " + oper + "'" + per + hs.DiaChi + per + "' ";
                where += "OR dbo.fnChuyenKhongDau(DiaChi) " + oper + "N'" + per + hs.DiaChi + per + "') ";
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
                where += "AND hsinh.MaHocSinh in (SELECT DISTINCT plop2.MaHocSinh FROM PHANLOP plop2 WHERE plop2.MaLop in ('" + MaLop + "')) ";
                where += "AND plop.MaLop in('" + MaLop + "')";
            }
            sql += where;
            // thực hiện query
            return GetTable(sql);
        }
        #endregion

        public DataTable LayDT_TenHocSinh()
        {
            string sql = "SELECT TenHocSinh FROM HOCSINH";
            return GetTable(sql);
        }
        
    }
}
