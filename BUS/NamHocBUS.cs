using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class NamHocBUS
    {
        private NamHocDAL _NamHocDAL;

        public NamHocBUS()
        {
            _NamHocDAL = new NamHocDAL();
        }
        /// <summary>
        /// Lấy list năm học
        /// </summary>
        /// <returns>List</returns>
        public List<NamHocDTO> LayListNamHoc()
        {
            return _NamHocDAL.LayListNamHoc();
        }
        /// <summary>
        /// Lấy DataTable năm học
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDTNamHoc()
        {
            return _NamHocDAL.LayDTNamHoc();
        }
        /// <summary>
        /// Lấy DataTable năm học có mã năm học là tham  số truyền vào
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDTNamHoc(string MaNamHoc)
        {
            return _NamHocDAL.LayDTNamHoc(MaNamHoc);
        }
        /// <summary>
        /// Lấy DataTable năm học làm năm hiện tại=năm học mới
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDTNamHocMoi()
        {
            return _NamHocDAL.LayDTNamHocMoi();
        }
        /// <summary>
        /// Lấy DataTable năm học cần chuyển lên lớp khi kết thúc năm học
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDTNamHocCu()
        {
            return _NamHocDAL.LayDTNamHocCu();
        }
    }
}
