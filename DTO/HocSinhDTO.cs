using System;
using System.Collections.Generic;
using System.Text;

namespace QLHS.DTO
{
    public class HocSinhDTO
    {        
        public int STT { get; set; }
        public string MaHocSinh { get; set; }
        public string TenHocSinh { get; set; }
        public string Email { get; set; }
        public int GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string DiaChi { get; set; }

        private int a; // Phu them
    }
}
