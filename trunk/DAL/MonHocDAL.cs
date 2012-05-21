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
        }
    }
}
