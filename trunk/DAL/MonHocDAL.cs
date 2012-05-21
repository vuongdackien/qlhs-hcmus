using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class MonHocDAL : ConnectData
    {
        /// <summary>
        /// Lấy Datatable danh sách môn học
        /// </summary>
        /// <param name="chiLayCacMonDangHoc">True: Chỉ lấy các môn đang học, False: Lấy tất cả 13 môn</param>
        /// <returns>Datatable</returns>
        public DataTable LayDT_DanhSach_MonHoc(bool chiLayCacMonDangHoc = true)
        {
            string sql = "";
            if (chiLayCacMonDangHoc)
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo FROM MONHOC ORDER BY TenMonHoc ASC WHERE TrangThai = 1");
            else
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo FROM MONHOC ORDER BY TenMonHoc");

            return GetTable(sql);
        }
        public MonHoc_HeSoDTO Lay_HeSoMonHoc()
        {
            string sql = "SELECT MaMonHoc, HeSo FROM MONHOC WHERE TrangThai = 1";
            OpenConnect();
            var dr = ExecuteReader(sql);
            MonHoc_HeSoDTO dsHeSo = new MonHoc_HeSoDTO();
            while (dr.Read())
            {
                double heso = Convert.ToDouble(dr["HeSo"]); 
                switch (dr["MaMonHoc"].ToString())
                {
                    case "toan": dsHeSo.toan = heso; break;
                    case "ly": dsHeSo.ly = heso; break;
                    case "hoa": dsHeSo.hoa = heso; break;
                    case "sinh": dsHeSo.sinh = heso; break;
                    case "nvan": dsHeSo.nvan = heso; break;
                    case "su": dsHeSo.su = heso; break;
                    case "dia": dsHeSo.dia = heso; break;
                    case "nngu": dsHeSo.nngu = heso; break;
                    case "tin": dsHeSo.tin = heso; break;
                    case "tduc": dsHeSo.tduc = heso; break;
                    case "gdcd": dsHeSo.gdcd = heso; break;
                    case "qphong": dsHeSo.qphong = heso; break;
                    case "cnghe": dsHeSo.cnghe = heso; break;
                }
            }
            CloseConnect();
            return dsHeSo;
        }
        /// <summary>
        /// Lấy danh sách môn học
        /// </summary>
        /// <param name="chiLayCacMonDangHoc">True: Chỉ lấy các môn đang học, False: Lấy tất cả 13 môn</param>
        /// <returns>List MonHocDTO</returns>
        public List<MonHocDTO> LayList_MonHoc(bool chiLayCacMonDangHoc = true)
        {
            string sql = "";
            if(chiLayCacMonDangHoc)
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo FROM MONHOC ORDER BY TenMonHoc ASC WHERE TrangThai = 1");
            else
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo FROM MONHOC ORDER BY TenMonHoc");

            OpenConnect();
            List<MonHocDTO> listMonHocDTO = new List<MonHocDTO>();
            MonHocDTO monhocDTO;
            var dr = ExecuteReader(sql);
            while (dr.Read())
            {
                monhocDTO = new MonHocDTO();
                monhocDTO.MaMonHoc = Convert.ToString(dr["MaMonHoc"]);
                monhocDTO.TenMonHoc = Convert.ToString(dr["TenMonHoc"]);
                monhocDTO.SoTiet = Convert.ToInt16(dr["SoTiet"]);
                monhocDTO.HeSo = Convert.ToInt16(dr["HeSo"]);
                listMonHocDTO.Add(monhocDTO);
            }
            CloseConnect();
            return listMonHocDTO;
        }    
    }
}
