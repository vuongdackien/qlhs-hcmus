using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class BangDiemBUS
    {
        private BangDiemDAL _BangDiemDAL;
        public BangDiemBUS()
        {
            _BangDiemDAL = new BangDiemDAL();
        }

        /// <summary>
        /// Lấy DataTable học sinh từ Lớp học
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>DataTable</returns>
        public DataTable LayDTDiem_HocKy_Lop(string MaLop, string MaHocKy)
        {
            return _BangDiemDAL.LayDTDiem_HocKy_Lop(MaLop, MaHocKy);
        }
    }
}
