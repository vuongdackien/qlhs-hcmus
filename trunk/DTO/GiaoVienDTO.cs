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
            this.MaGV = MaGiaoVien;
            this.TenGV=TenGiaoVien;
        }
       
        private string  MaGiaoVien;

        public string MaGV
        {
            get { return MaGiaoVien; }
            set { MaGiaoVien = value; }
        }
        private string TenGiaoVien;

	    public string TenGV        
	    {
		    get { return TenGiaoVien;}
		    set { TenGiaoVien = value;}
	    }
	
        

    }
}
