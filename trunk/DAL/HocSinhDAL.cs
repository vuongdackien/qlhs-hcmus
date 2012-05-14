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
        public DataTable LayDTHocSinh_LopHoc(string MaLop)
        {
            string sql = string.Format("SELECT hs.MaHocSinh, hs.TenHocSinh "
                                       +"FROM PHANLOP pl LEFT JOIN HOCSINH hs ON pl.MaHocSinh = hs.MaHocSinh "
                                       +"WHERE pl.MaLop = '{0}'",MaLop);
            return GetTable(sql);
        }
    }
}
