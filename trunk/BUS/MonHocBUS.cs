using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class MonHocBUS
    {
        private MonHocDAL _MonHocDAL;
        public MonHocBUS()
        {
            _MonHocDAL = new MonHocDAL();
        }
        /// <summary>
        /// Lấy Datatable danh sách môn học
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable LayDT_DanhSach_MonHoc()
        {
            return _MonHocDAL.LayDT_DanhSach_MonHoc();
        }
    }
}
