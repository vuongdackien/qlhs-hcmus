using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class GiaoVienBUS
    {
        GiaoVienDAL GVDAL=new GiaoVienDAL();
        public void ThemGiaoVien(GiaoVienDTO GV)
        {
            GVDAL.ThemGiaoVien(GV);
        }
        public void XoaGiaoVien(GiaoVienDTO GV)
        {
            GVDAL.XoaGiaoVien(GV);
        }
        public void CapNhatGiaoVien(GiaoVienDTO GV)
        {
            GVDAL.CapNhatGiaoVien(GV);
        }

    }
}
