using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class LopBUS
    {
        LopDAL _LopDAL;
         
        public LopBUS()
        {
            _LopDAL = new LopDAL();
        }
         /// <summary>
        /// Lấy DataTable Lớp từ mã năm và khối
        /// </summary>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <param name="MaKhoi">String: mã khối</param>
        /// <returns>DataTable:</returns>
        public DataTable LayDTLop_MaNam_MaKhoi(string MaNamHoc, string MaKhoi)
        {
            return _LopDAL.LayDTLop_MaNam_MaKhoi(MaNamHoc, MaKhoi);
        }
        /// <summary>
        /// Lấy list Lớp từ mã năm và khối
        /// </summary>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <param name="MaKhoi">String: mã khối</param>
        /// <returns>List:</returns>
        public List<LopDTO> LayListLop_MaNam_MaKhoi(string MaNamHoc, string MaKhoi)
        {
            return _LopDAL.LayListLop_MaNam_MaKhoi(MaNamHoc, MaKhoi);
        }
         /// <summary>
        /// Lấy tên giáo viên chủ nhiệm
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>String: Tên giáo viên</returns>
        public string LayTenGiaoVien_MaLop(string MaLop)
        {
            return _LopDAL.LayTen_GiaoVien_MaLop(MaLop);
        }
        /// <summary>
        /// Kiểm tra tồn tại mã lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Bool</returns>
        public bool KiemTraTonTai_MaLop(string MaLop)
        {
            return _LopDAL.KiemTra_TonTaiMaLop(MaLop);
        }
        /// <summary>
        /// Thêm lớp mới
        /// </summary>
        /// <param name="lop">LopDTO</param>
        /// <returns></returns>
        public bool Them_Lop(LopDTO lop)
        {
            return _LopDAL.Them_HoSo_Lop(lop);
        }
        /// <summary>
        /// Cập nhật giáo viên chủ nhiệm
        /// </summary>
        /// <param name="lop">LopDTO</param>
        /// <returns></returns>
        public bool CapNhat_GiaoVienCN_Lop(LopDTO lop)
        {
            return _LopDAL.CapNhat_GiaoVienCN_Lop(lop);
        }
        /// <summary>
        /// Xóa lớp từ mã lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns></returns>
        public bool Xoa_Lop(string MaLop)
        {
            return _LopDAL.Xoa_HoSo_Lop(MaLop);
        }
    }
}
