using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class KhoiBUS
    {
        /// <summary>
        /// Lấy DataTable Khối
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDTKhoi()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaKhoi");
            dataTable.Columns.Add("TenKhoi");
            for (int khoi = 10; khoi <= 12; khoi++)
            {
                DataRow dr = dataTable.NewRow();
                dr["MaKhoi"] = khoi;
                dr["TenKhoi"] = "Khối " + khoi;
                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }
    }
}
