using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class QuyDinhBUS
    {
        QuyDinhDAL _QuyDinhDAL;
        public QuyDinhBUS()
        {
            _QuyDinhDAL = new QuyDinhDAL();
        }
        /// <summary>
        /// Lấy tuổi cận dưới
        /// </summary>
        /// <returns>Int</returns>
        public int LayTuoiCanDuoi()
        {
            return (int)_QuyDinhDAL.LayGiaTri("TuoiCanDuoi");
        }
        public int LayNamCanDuoi()
        {
            return DateTime.Now.Year - this.LayTuoiCanDuoi();
        }
        /// <summary>
        /// Lấy tuổi cận trên
        /// </summary>
        /// <returns>Int</returns>
        public int LayTuoiCanTren()
        {
            return (int)_QuyDinhDAL.LayGiaTri("TuoiCanTren");
        }
        /// <summary>
        /// Lấy sỉ số cận dưới
        /// </summary>
        /// <returns>Int</returns>
        public int LaySiSoCanDuoi()
        {
            return (int)_QuyDinhDAL.LayGiaTri("SiSoCanDuoi");
        }
        /// <summary>
        /// Lấy sỉ số cận trên
        /// </summary>
        /// <returns>Int</returns>
        public int LaySiSoCanTren()
        {
            return (int)_QuyDinhDAL.LayGiaTri("SiSoCanTren");
        }
        /// <summary>
        /// Lấy điểm chuẩn
        /// </summary>
        /// <returns>Double</returns>
        public double LayDiemChuan()
        {
            return (double)_QuyDinhDAL.LayGiaTri("DiemChuan");
        }
    }
}
