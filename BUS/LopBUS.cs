using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class LopBUS
    {
        LopDAL _LopDAL;
        public LopBUS()
        {
            _LopDAL = new LopDAL();
        }

        public DataTable LayDTLop_MaNam_MaKhoi(string MaNamHoc, string MaKhoi)
        {
            return _LopDAL.LayDTLop_MaNam_MaKhoi(MaNamHoc, MaKhoi);
        }
    }
}
