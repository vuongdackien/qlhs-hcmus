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
            string sql = string.Format("SELECT MaLop, TenLop FROM LOP WHERE MaKhoiLop = '{0}' "
                                      +"AND MaNamHoc = '{1}' ",MaKhoi,MaNamHoc);
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
            string sql = string.Format("SELECT MaLop, TenLop FROM LOP WHERE MaKhoiLop = '{0}' "
                                      + "AND MaNamHoc = '{1}' ", MaKhoi, MaNamHoc);
            OpenConnect();
            List<LopDTO> listLopDTO = new List<LopDTO>();
            LopDTO lopDTO;
            var dr = ExecuteReader(sql);
            while (dr.Read())
            {
                lopDTO = new LopDTO();
                lopDTO.MaLop = Convert.ToString(dr["MaLop"]);
                lopDTO.TenLop = Convert.ToString(dr["TenLop"]);
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
    }
}
