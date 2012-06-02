using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class LoaiNguoiDungBUS
    {
        private LoaiNguoiDungDAL _loaiNguoiDungDAL;

        public LoaiNguoiDungBUS()
        {
            _loaiNguoiDungDAL = new LoaiNguoiDungDAL();
        }
        /// <summary>
        /// Lấy datatable loại người dùng
        /// </summary>
        /// <returns></returns>
        public DataTable LayDT_LoaiNguoiDung()
        {
            return _loaiNguoiDungDAL.Lay_DT_LoaiNguoiDung();
        }
    }
}
