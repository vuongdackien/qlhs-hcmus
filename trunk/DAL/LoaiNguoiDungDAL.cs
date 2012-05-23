using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class LoaiNguoiDungDAL : ConnectData
    {
        /// <summary>
        /// Lấy datatable loại người dùng
        /// </summary>
        /// <returns></returns>
        public DataTable Lay_DT_LoaiNguoiDung()
        {
            return GetTable("SELECT MaLoaiND,TenLoaiND FROM LOAINGUOIDUNG");
        }
    }
}
