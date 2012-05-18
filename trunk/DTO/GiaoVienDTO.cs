using System;
using System.Collections.Generic;
using System.Text;

namespace QLHS.DTO
{
    public class GiaoVienDTO
    {
        public GiaoVienDTO()
        { }
        public GiaoVienDTO(string MaGiaovien, string TenGiaoVien)
        {
            this.MaGiaoVien = MaGiaoVien;
            this.TenGiaoVien =TenGiaoVien;
        }

        public string MaGiaoVien { get; set; }
        public string TenGiaoVien { get; set; }
        
	
        

    }
}
