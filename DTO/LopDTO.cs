using System;
using System.Collections.Generic;
using System.Text;

namespace QLHS.DTO
{
    public class LopDTO
    {
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public int MaKhoiLop { get; set; }
        public string MaNamHoc { get; set; }
        public int SiSo { get; set; }

        private GiaoVienDTO _GiaoVienDTO = new GiaoVienDTO();

        public GiaoVienDTO GiaoVien
        {
            get { return _GiaoVienDTO; }
            set { _GiaoVienDTO = value; }
        }
        
    }
}
