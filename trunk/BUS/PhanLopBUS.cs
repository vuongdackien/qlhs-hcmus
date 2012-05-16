using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class PhanLopBUS
    {
        PhanLopDAL _PhanLopDAL;
        public PhanLopBUS()
        {
            _PhanLopDAL = new PhanLopDAL();
        }
        /// <summary>
        /// Kiểm tra tồn tại  STT của 1 học sinh trong lớp
        /// </summary>
        /// <param name="STT">Int: Số thứ tự</param>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Bool:</returns>
        public bool KiemTra_STT_TonTai(int STT, string MaLop)
        {
            return _PhanLopDAL.KiemTra_STT_TonTai(STT, MaLop);
        }
        /// <summary>
        /// Lấy Số thứ tự tiếp theo trong bảng điểm
        /// </summary>
        /// <param name="MaLop">String: mã lớp</param>
        /// <returns>Int</returns>
        public int Lay_STT_TiepTheo(string MaLop)
        {
            return _PhanLopDAL.Lay_STT_TiepTheo(MaLop);
        }
        /// <summary>
        /// Lấy STT hiện tại của 1 học sinh
        /// </summary>
        /// <param name="MaHocSinh">String: Mã học sinh</param>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Int</returns>
        public int Lay_STT_HienTai(string MaHocSinh, string MaLop)
        {
            return _PhanLopDAL.Lay_STT_HienTai(MaHocSinh, MaLop);
        }
        /// <summary>
        /// Đếm sỉ số của 1 lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Int</returns>
        public int Dem_SiSo_Lop(string MaLop)
        {
            return _PhanLopDAL.Dem_SiSo_Lop(MaLop);
        }
    }
}
