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
         /// <summary>
        /// Lấy bảng điểm môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaMonHoc">String: Mã môn học</param>
        /// <returns></returns>
        public DataTable LayBangDiem(string MaLop, string MaHocKy, string MaMonHoc)
        {
            return _BangDiemDAL.LayBangDiem(MaLop, MaHocKy, MaMonHoc);
        }
    }
}
