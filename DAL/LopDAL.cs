using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class LopDAL : ConnectData
    {
        public DataTable LayDTLop_MaNam_MaKhoi(string MaNamHoc, string MaKhoi)
        {
            string sql = string.Format("SELECT MaLop, TenLop FROM LOP WHERE MaKhoiLop = '{0}' "
                                      +"AND MaNamHoc = '{1}' ",MaKhoi,MaNamHoc);
            return GetTable(sql);
        }
    }
}
