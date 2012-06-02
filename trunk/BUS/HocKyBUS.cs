using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class HocKyBUS
    {
        /// <summary>
        /// Lấy DataTable Học kỳ
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDT_HocKy()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("MaHocKy");
            dataTable.Columns.Add("TenHocKy");
            for (int hk = 1; hk <= 2; hk++)
            {
                DataRow dr = dataTable.NewRow();
                dr["MaHocKy"] = hk;
                dr["TenHocKy"] = "Học kỳ " + hk;
                dataTable.Rows.Add(dr);
            }
            return dataTable;
        }
    }
}
