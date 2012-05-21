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
        /// <returns>Datatable</returns>
        public DataTable LayDT_DanhSach_MonHoc()
        {
            string sql = "SELECT MaMonHoc, TenMonHoc FROM MONHOC ORDER BY TenMonHoc  ASC";
            return GetTable(sql);
        }
        public MonHoc_HeSoDTO Lay_HeSoMonHoc()
        {
            string sql = "SELECT MaMonHoc, HeSo FROM MONHOC";
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

        public List<MonHocDTO> LayList_MonHoc()
        {
            string sql = string.Format("SELECT MaMonHoc, TenMonHoc FROM MONHOC ORDER BY TenMonHoc  ASC");
            OpenConnect();
            List<MonHocDTO> listMonHocDTO = new List<MonHocDTO>();
            MonHocDTO monhocDTO;
            var dr = ExecuteReader(sql);
            while (dr.Read())
            {
                monhocDTO = new MonHocDTO();
                monhocDTO.MaMonHoc = Convert.ToString(dr["MaMonHoc"]);
                monhocDTO.TenMonHoc = Convert.ToString(dr["TenMonHoc"]);
                listMonHocDTO.Add(monhocDTO);
            }
            CloseConnect();
            return listMonHocDTO;
        }    }
}
