using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class ChuyenLopBUS
    {
        ChuyenLopDAL _ChuyenLopDAL = new ChuyenLopDAL();
        public bool ChuyenBangDiem(string MaHocSinh, string MaLop_old, string MaLop_new)
        {
            return _ChuyenLopDAL.ChuyenBangDiem(MaHocSinh, MaLop_old, MaLop_new);
        }
        public bool LuuChuyenLop(ChuyenLopDTO cl)
        {
            return _ChuyenLopDAL.LuuChuyenLop(cl);
        }
       
    }
}
