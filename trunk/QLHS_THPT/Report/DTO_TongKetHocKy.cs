using System;
using System.Collections.Generic;
using System.Text;
using QLHS.DTO;

namespace QLHS
{
    public class DTO_TongKetHocKy
    {

        
        private HocSinhDTO _HocSinhDTO = new HocSinhDTO();

        public HocSinhDTO HocSinh
        {
            get { return _HocSinhDTO; }
            set { _HocSinhDTO = value; }
        }

        private MonHocDTO _MonHocDTO = new MonHocDTO();

        public MonHocDTO MonHoc
        {
            get { return _MonHocDTO; }
            set { _MonHocDTO = value; }
        }

        public int STT { get; set; }

        public double DM_1 { get; set; }
        public double DM_2 { get; set; }
        public double D15_1 { get; set; }
        public double D15_2 { get; set; }
        public double D15_3 { get; set; }
        public double D15_4 { get; set; }
        public double D1T_1 { get; set; }
        public double D1T_2 { get; set; }
        public double DThi { get; set; }
    }
}
