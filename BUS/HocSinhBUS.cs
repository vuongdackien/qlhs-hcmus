using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class HocSinhBUS
    {
        private HocSinhDAL _HocSinhDAL;
        private QuyDinhBUS _QuyDinhBUS;
        public HocSinhBUS()
        {
            _HocSinhDAL = new HocSinhDAL();
            _QuyDinhBUS = new QuyDinhBUS();
        }
        /// <summary>
        /// Lấy DataTable học sinh từ Lớp học
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>DataTable</returns>
        public DataTable LayDTHocSinh_LopHoc(string MaLop)
        {
            return _HocSinhDAL.LayDTHocSinh_LopHoc(MaLop);
        }
         /// <summary>
        /// Lấy hồ sơ học sinh từ Mã học sinh
        /// </summary>
        /// <param name="MaHocSinh">string: Mã học sinh</param>
        /// <returns>HocSinhDTO</returns>
        public HocSinhDTO LayHoSoHocSinh(string MaHocSinh)
        {
            return _HocSinhDAL.LayHoSoHocSinh(MaHocSinh);
        }
        /// <summary>
        /// Lưu hồ sơ học sinh (Add/Edit)
        /// </summary>
        /// <param name="hocsinh">HocSinhDTO</param>
        /// <returns>Bool</returns>
        public bool LuuHoSoHocSinh(HocSinhDTO hocsinh)
        {
           
            if (_HocSinhDAL.KiemTraTonTai_MaHocSinh(hocsinh.MaHocSinh))
                return _HocSinhDAL.SuaHoSoHocSinh(hocsinh);

            string lastMaHocSinh = _HocSinhDAL.LayMaCuoiCung();
            lastMaHocSinh = lastMaHocSinh.Equals("") ? "HS00000000" : lastMaHocSinh;
            hocsinh.MaHocSinh = Utilities.StringUtilities.NextID(lastMaHocSinh, "HS");
            return _HocSinhDAL.ThemHoSoHocSinh(hocsinh);
        }
        public bool KiemTraNamSinhHopLe(int namSinh)
        {
            int TuoiCanDuoi = _QuyDinhBUS.LayTuoiCanDuoi(),
                TuoiCanTren = _QuyDinhBUS.LayTuoiCanTren();
            //if(TuoiCanDuoi <= 
            return true;
        }
    }
}
