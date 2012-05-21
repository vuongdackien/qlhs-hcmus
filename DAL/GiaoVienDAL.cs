using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QLHS.DTO;


namespace QLHS.DAL
{ 
    public class GiaoVienDAL : ConnectData
    {
        GiaoVienDTO GV;
 
        public void ThemGiaoVien(GiaoVienDTO GV)
        {

            string sql = string.Format("insert into  Giaovien values (n'{0}',n'{1}')", GV.MaGiaoVien, GV.TenGiaoVien);
            ExecuteQuery(sql);
        }
        public void XoaGiaoVien(string  MaGV)
        {
            string sql = string.Format("delete  Giaovien  where MaGiaoVien like n'%{0}%')", MaGV);
            ExecuteQuery(sql);
        }
        public void CapNhatGiaoVien(GiaoVienDTO GV)
        {
            string sql = string.Format("update GiaoVien set TenGiaoVien=N'{0}'"
                                                     + "where madv={1} ", GV.TenGiaoVien, GV.MaGiaoVien);
            ExecuteQuery(sql);
        }
        #region Tạo bảng các giáo viên
        /// <summary>
        /// Tào bảng các giáo viên
        /// </summary>
        /// <returns></returns>
        public DataTable TableGiaoVien()
        {
            string sql = " select * from GiaoVien"; 
            DataTable dt = new DataTable();
            dt = GetTable(sql, true);
            return dt;
            
        }
      /// <summary>
      /// Tao bang giao vien theo MaGV hoặc tên giáo viên
      /// </summary>
      /// <param name="DK"></param>
      /// <returns></returns>
        public DataTable TableGiaoVien(String DK)
        {
            string sql = null;
            sql = string.Format("select * from GiaoVien where MaGiaoVien like N'%{0}%' or TenGiaoVien like N'%{0}%'", DK); 
            DataTable dt = new DataTable();
            dt =GetTable(sql, true);
            return dt;
        }
        
       #endregion 
        #region Tạo danh sách các giáo viên dạng list
        /// <summary>
        /// Tạo danh sách giáo viên theo yêu cầu
        /// </summary>
        /// <param name="DK"></param>
        /// <returns></returns>
        public List<GiaoVienDTO> ListGiaoVien(string DK)
        {

            string sql = "";
            sql = string.Format("select * from GiaoVien where MaGiaoVien like N'%{0}%' or TenGiaoVien like N'%{0}%'", DK);   
            DataTable dt = new DataTable();
            dt = GetTable(sql, true);
            List<GiaoVienDTO> ListGiaoVien = new List<GiaoVienDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                GV = new GiaoVienDTO { MaGiaoVien = dr[0].ToString(), TenGiaoVien = dr[1].ToString() };
                ListGiaoVien.Add(GV);
            }

            return ListGiaoVien;
        }
        /// <summary>
        /// Tạo toàn bộ danh sách giáo viên
        /// </summary>
        /// <param name="DK"></param>
        /// <returns></returns>
        public List<GiaoVienDTO> ListGiaoVien()
        {

            string sql = "";
            
            sql = " select * from GiaoVien";

            DataTable dt = new DataTable();
            dt =GetTable(sql, true);
            List<GiaoVienDTO> ListGiaoVien = new List<GiaoVienDTO>();
            foreach (DataRow dr in dt.Rows)
            {
                GV = new GiaoVienDTO { MaGiaoVien = dr[0].ToString(), TenGiaoVien = dr[1].ToString() };
                ListGiaoVien.Add(GV);
            }

            return ListGiaoVien;
        }
        #endregion
        public void AddNewRow(DataRow dr)
        { AddNewRow(dr); }
        public DataRow GetNewRow()
        { return GetNewRow(); }
        public bool KiemtratontaiGiaoVien(GiaoVienDTO GV)
        {
            string sql = string.Format("SELECT count(*) as SoLuong FROM GiaoVien WHERE MaGiaoVien = '{0}'", GV.MaGiaoVien);
            return (int)ExecuteScalar(sql) == 1;
        }
    }
}
