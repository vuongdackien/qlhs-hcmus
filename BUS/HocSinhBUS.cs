using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class HocSinhBUS
    {
        private HocSinhDAL _HocSinhDAL;
        public HocSinhBUS()
        {
            _HocSinhDAL = new HocSinhDAL();
        }
        /// <summary>
        /// Lấy DataTable học sinh từ Lớp học
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>DataTable</returns>
        public DataTable LayDTHocSinh_LopHoc(string MaLop)
        {
            return _HocSinhDAL.LayDTHocSinh_LopHoc(MaLop);
        }
         /// <summary>
        /// Lấy hồ sơ học sinh từ Mã học sinh
        /// </summary>
        /// <param name="MaHocSinh">string: Mã học sinh</param>
        /// <returns>HocSinhDTO</returns>
        public HocSinhDTO LayHoSoHocSinh(string MaHocSinh)
        {
            return _HocSinhDAL.LayHoSoHocSinh(MaHocSinh);
        }
    }
}
