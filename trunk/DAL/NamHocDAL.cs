using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using System.Data.OleDb;

namespace QLHS.DAL
{
    public class NamHocDAL : ConnectData
    {
        /// <summary>
        /// Lấy list năm học
        /// </summary>
        /// <returns>List: NamHocDTO</returns>
        public List<NamHocDTO> LayListNamHoc()
        {
            string sql = "SELECT MaNamHoc, TenNamHoc FROM NAMHOC";
            List<NamHocDTO> listNamHoc = new List<NamHocDTO>();
            NamHocDTO namHoc;

            OpenConnect();
            var dr = ExecuteReader(sql);
            while (dr.Read())
            {
                namHoc = new NamHocDTO(Convert.ToString(dr["MaNamHoc"]),
                                       Convert.ToString(dr["TenNamHoc"]));
                listNamHoc.Add(namHoc);
            }
            CloseConnect();

            return listNamHoc;
        }
        /// <summary>
        /// Lấy DataTable năm học
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDTNamHoc()
        {
            string sql = "SELECT MaNamHoc, TenNamHoc FROM NAMHOC";
            return GetTable(sql);
        }
        /// <summary>
        /// Lấy DataTable năm học có mã năm học là tham  số truyền vào
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDTNamHoc(string MaNamHoc)
        {
            string sql = string.Format("SELECT MaNamHoc, TenNamHoc FROM NAMHOC WHERE MaNamHoc='{0}'",MaNamHoc);
            return GetTable(sql);
        }
        /// <summary>
        /// Lấy DataTable năm học làm năm hiện tại=năm học mới
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDTNamHocMoi()
        {
            string sql = "SELECT MaNamHoc,TenNamHoc FROM NAMHOC WHERE substring(TenNamHoc,1,4)=year(getdate()) ";
            return GetTable(sql);
        }
        /// <summary>
        /// Lấy DataTable năm học cần chuyển lên lớp khi kết thúc năm học
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDTNamHocCu()
        {
            string sql = "SELECT MaNamHoc,TenNamHoc FROM NAMHOC WHERE substring(TenNamHoc,8,4)=year(getdate()) ";
            return GetTable(sql);
        }
    }
}
