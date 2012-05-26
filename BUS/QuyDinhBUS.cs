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
        QuyDinhDAL _QuyDinhDAL;
        public QuyDinhBUS()
        {
            _QuyDinhDAL = new QuyDinhDAL();
        }
        public string Doichuoi(string input, string oldValue, string newValue, bool matchCase)
        {

            RegexOptions regexOption = RegexOptions.None;
            if (!matchCase)
            {
                regexOption = RegexOptions.IgnoreCase;
            }

            Regex regex = new Regex(oldValue, regexOption);

            input = regex.Replace(input, newValue);

            return input;

        }
        ///<Lấy bảng quy định>
        ///Lấy bảng quy định
        ///</summary>
        public DataTable Table_QuyDinh()
        {
            return _QuyDinhDAL.Dt_QuyDinh();
        }
        public string Doichuoi(string input, string oldValue, string newValue, bool matchCase)
        {

            RegexOptions regexOption = RegexOptions.None;
            if (!matchCase)
            {
                regexOption = RegexOptions.IgnoreCase;
            }

            Regex regex = new Regex(oldValue, regexOption);

            input = regex.Replace(input, newValue);

            return input;

        }
        public void capnhat(QuyDinhDTO QDDTO)
        {
            _QuyDinhDAL.SuaQuyDinh(QDDTO);
        }
        /// <summary>
        /// Lấy tuổi cận dưới
        /// </summary>
        /// <returns>Int</returns>
        public int LayTuoiCanDuoi()
        {
            return Convert.ToInt32(_QuyDinhDAL.LayGiaTri("TuoiCanDuoi"));
        }
        /// <summary>
        /// Lấy tuổi cận trên
        /// </summary>
        /// <returns>Int</returns>
        public int LayTuoiCanTren()
        {
            return Convert.ToInt32(_QuyDinhDAL.LayGiaTri("TuoiCanTren"));
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
            return Convert.ToInt32(_QuyDinhDAL.LayGiaTri("SiSoCanTren"));
        }
        /// <summary>
        /// Lấy điểm chuẩn
        /// </summary>
        /// <returns>Double</returns>
        public double LayDiemChuan()
        {
            return Convert.ToDouble(_QuyDinhDAL.LayGiaTri("DiemChuan"));
        }
        public DateTime LayNgayApDungQD()
        {
            string ngayQD = _QuyDinhDAL.LayGiaTri("NgayApDung").ToString();
            return DateTime.ParseExact(ngayQD, "dd-MM-yyyy", null);
        }
      
    }
}
