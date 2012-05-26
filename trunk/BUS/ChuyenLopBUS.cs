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
        public bool KTHocSinhThuocLop_DuocChuyenTuLop(string MaHocSinh, string MaLopMoi, string MaLopCu)
        {
            return _ChuyenLopDAL.KTHocSinhThuocLop_DuocChuyenTuLop(MaHocSinh, MaLopMoi, MaLopCu);
        }
        public bool KT_HocSinhCo_BangDiem(string MaHocSinh, string MaLop)
        {
            return _ChuyenLopDAL.KT_HocSinhCo_BangDiem(MaHocSinh, MaLop);
        }
        public bool XoaChuyenLop(string MaHocSinh, string TuLop, string DenLop)
        {
            return _ChuyenLopDAL.XoaChuyenLop(MaHocSinh, TuLop, DenLop);
        }
    }
}
