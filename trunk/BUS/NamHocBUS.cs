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
    }
}
