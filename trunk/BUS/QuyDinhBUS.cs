using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class QuyDinhBUS
    {
        private QuyDinhDAL _quyDinhDAL;

        public QuyDinhBUS()
        {
            _quyDinhDAL = new QuyDinhDAL();
        }
      
        /// <summary>
        /// Lấy danh sách quy định
        /// </summary>
        /// <returns></returns>
        public QuyDinhDTO LayDS_QuyDinh()
        {
            return _quyDinhDAL.LayDS_QuyDinh();
        }

        /// <summary>
        /// Cập nhật quy định
        /// </summary>
        /// <param name="quyDinhDTO">QuyDinhDTO</param>
        /// <returns></returns>
        public bool CapNhatQuyDinh(QuyDinhDTO quyDinhDTO)
        {
            return _quyDinhDAL.SuaQuyDinh(quyDinhDTO);
        }

        /// <summary>
        /// Lấy tuổi cận dưới
        /// </summary>
        /// <returns>Int</returns>
        public int LayTuoiCanDuoi()
        {
            return Convert.ToInt32(_quyDinhDAL.LayGiaTri("TuoiCanDuoi"));
        }
        /// <summary>
        /// Lấy tuổi cận trên
        /// </summary>
        /// <returns>Int</returns>
        public int LayTuoiCanTren()
        {
            return Convert.ToInt32(_quyDinhDAL.LayGiaTri("TuoiCanTren"));
        }
        /// <summary>
        /// Lấy năm tuổi cận dưới
        /// </summary>
        /// <returns>Int: Năm</returns>
        public int LayNamCanDuoi()
        {
            return DateTime.Now.Year - this.LayTuoiCanTren();
        }
        /// <summary>
        /// Lấy năm tuổi cận trên
        /// </summary>
        /// <returns>Int: Năm</returns>
        public int LayNamCanTren()
        {
            return DateTime.Now.Year - this.LayTuoiCanDuoi();
        }
        /// <summary>
        /// Lấy mã năm học hiện tại
        /// </summary>
        /// <returns>String: mã năm</returns>
        public string LayMaNamHoc_HienTai()
        {
            return Convert.ToString(_quyDinhDAL.LayGiaTri("MaNamHocHT"));
        }
        /// <summary>
        /// Lấy sỉ số cận dưới
        /// </summary>
        /// <returns>Int</returns>
        public int LaySiSoCanDuoi()
        {
            return Convert.ToInt32(_quyDinhDAL.LayGiaTri("SiSoCanDuoi"));
        }
        /// <summary>
        /// Lấy sỉ số cận trên
        /// </summary>
        /// <returns>Int</returns>
        public int LaySiSoCanTren()
        {
            return Convert.ToInt32(_quyDinhDAL.LayGiaTri("SiSoCanTren"));
        }
        /// <summary>
        /// Lấy điểm chuẩn
        /// </summary>
        /// <returns>Double</returns>
        public double LayDiemChuan()
        {
            return Convert.ToDouble(_quyDinhDAL.LayGiaTri("DiemChuan"));
        }
        /// <summary>
        /// Lấy ngày áp dụng
        /// </summary>
        /// <returns></returns>
        public DateTime LayNgayApDungQD()
        {
            string ngayQD = _quyDinhDAL.LayGiaTri("NgayApDung").ToString();
            return DateTime.ParseExact(ngayQD, "dd-MM-yyyy", null);
        }
      
    }
}
