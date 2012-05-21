using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class BangDiemBUS
    {
        private BangDiemDAL _bangDiemDAL;
        private LopDAL _lopDAL;
        private MonHocDAL _monhocDAL;
        private PhanLopDAL _phanLopDAL;
        private QuyDinhBUS _quyDinhBUS;

        public BangDiemBUS()
        {
            _bangDiemDAL = new BangDiemDAL();
            _lopDAL = new LopDAL();
            _monhocDAL = new MonHocDAL();
            _phanLopDAL = new PhanLopDAL();
            _quyDinhBUS = new QuyDinhBUS();
        }

        /// <summary>
        /// Lấy DataTable học sinh từ Lớp học
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>DataTable</returns>
        public DataTable LayDTDiem_HocKy_Lop(string MaLop, string MaHocKy)
        {
            return _bangDiemDAL.LayDTDiem_HocKy_Lop(MaLop, MaHocKy);
        }
        /// <summary>
        /// Lấy bảng điểm môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaMonHoc">String: Mã môn học</param>
        /// <returns></returns>
        public DataTable LayBangDiem(string MaLop, string MaHocKy, string MaMonHoc)
        {
            return _bangDiemDAL.LayBangDiem(MaLop, MaHocKy, MaMonHoc);
        }
        /// <summary>
        /// Kiểm tra hợp lệ các cột điểm trên 1 dòng của bảng điểm BangDiemDTO
        /// </summary>
        /// <param name="bd">BangDiemDTO</param>
        /// <returns>Bool</returns>
        public bool KiemTraHopLe_TrenDong_BangDiem(BangDiemDTO bd)
        {
            string msg = "";
            if (bd.DM_1 == -1 && bd.DM_2 == -1)
                msg = "miệng";
            else if (bd.D15_1 == -1 && bd.D15_2 == -1 && bd.D15_3 == -1 && bd.D15_4 == -1)
                msg = "15 phút";
            else if (bd.D1T_1 == -1 && bd.D1T_2 == -1)
                msg = "1 tiết";
            else if (bd.DThi == -1)
                msg = "cuối kỳ";
            if (!msg.Equals(""))
                msg = "Bạn chưa nhập cột điểm " + msg + " cho học sinh "
                       + bd.HocSinh.TenHocSinh + " (" + bd.HocSinh.MaHocSinh+ ").";
            if (msg != "")
            {
                Utilities.ExceptionUtilities.Throw(msg);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Tính điểm trung bình môn trên 1 dòng bảng điểm
        /// </summary>
        /// <param name="bd">BangDiemDTO (Quy định: VỚi điểm == -1 xem như chưa nhập</param>
        /// <returns>double: Điểm trung bình</returns>
        public double TinhDiem_TB_Mon_TrenDong(BangDiemDTO bd)
        {
            int soCotM = 0, soCot15 = 0, soCot1T = 0;
            double tongM = 0, tong15 = 0, tong1T = 0;
            // Đếm cột miệng nhập
            if (bd.DM_1 >= 0)
            {
                tongM += bd.DM_1;
                soCotM++;
            }
            if (bd.DM_2 >= 0)
            {
                 tongM += bd.DM_2;
                 soCotM++;
            }
            // Đếm cột 15' nhập
            if (bd.D15_1 >= 0)
            {
                tong15 += bd.D15_1;
                soCot15++;
            }
            if (bd.D15_2 >= 0)
            {
               tong15 += bd.D15_2;
                soCot15++;
            }
            if (bd.D15_3 >= 0)
            {
               tong15 += bd.D15_3;
                soCot15++;
            }
            if (bd.D15_4 >= 0)
            {
               tong15 += bd.D15_4;
                soCot15++;
            }
            // Đếm số cột 1T
            if (bd.D1T_1 >= 0)
            {
                 tong1T += bd.D1T_1;
                 soCot1T++;
            }
            if (bd.D1T_2 >= 0)
            {
                tong1T += bd.D1T_2;
                 soCot1T++;
            }
            double TongDiem =    (tong15 / soCot15) * 1   // 15' hệ số 1
                               + (tongM / soCotM)   * 1   // M   hệ số 1
                               + (tong1T / soCot1T) * 2 // 1T  hệ số 2
                               +  bd.DThi           * 3;
  
            return Utilities.ObjectUtilities.LamTron(TongDiem / 7);

        }
         /// <summary>
        /// Lưu bảng điểm 1 môn học / 1 học sinh / 1 học kỳ / 1 lớp / 1 năm học
        /// </summary>
        /// <param name="bd">BangDiemDTO</param>
        /// <returns>Bool</returns>
        public bool LuuBangDiem_Mon_Hoc_HocSinh(BangDiemDTO bd)
        {
            return _bangDiemDAL.LuuBangDiem_MonHoc_HocSinh_HocKy(bd);
        }
        /// <summary>
        /// Xóa bảng điểm 1 môn học / 1 học sinh / 1 học kỳ / 1 lớp / 1 năm học
        /// </summary>
        /// <param name="bd">BangDiemDTO</param>
        /// <returns>bool</returns>
        public bool XoaBangDiem_MonHoc_HocSinh_HocKy(BangDiemDTO bd)
        {
            return _bangDiemDAL.XoaBangDiem_MonHoc_HocSinh_HocKy(bd);
        }

        /// <summary>
        /// Lấy bảng điểm môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã khối</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaMonHoc">String: Mã môn học</param>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <returns>List<TongKetMonDTO></returns>
        public List<TongKetMonDTO> LayBangDiem_BaoCao_MonHoc(string MaMonHoc, string MaKhoi, string MaHocKy, string MaNamHoc)
        {
            // Lấy tất cả các lớp trong khối
            List<LopDTO> ds_lop = _lopDAL.LayListLop_MaNam_MaKhoi(MaNamHoc, MaKhoi);
            List<TongKetMonDTO> bangDiemTongKetMon = new List<TongKetMonDTO>();
            int stt = 1;
            foreach (LopDTO lop in ds_lop)
            { 
                // Kiểm tra đã nhập điểm đủ cho lớp này hay chưa
                int siSo = _phanLopDAL.Dem_SiSo_Lop(lop.MaLop);
                DataTable bdiemLop = _bangDiemDAL.LayBangDiem_MonHoc_Lop(lop.MaLop, MaMonHoc, MaHocKy);
                // Tính toán số lượng đạt và tỉ lệ
                double diemDat = _quyDinhBUS.LayDiemChuan();
                int soLuongDat = 0;
                double tiLe = 0;
                // Chưa nhập đủ điểm
                if (bdiemLop.Rows.Count < siSo)
                {
                    soLuongDat = 0;
                }
                else
                {
                    foreach (DataRow dr in bdiemLop.Rows)
                    {
                        if (Convert.ToDouble(dr["DTB"]) >= diemDat)
                            soLuongDat++;
                    }
                }
                tiLe = (soLuongDat * 100) / siSo;

                // tạo bảng báo cáo tổng kết môn
                TongKetMonDTO mtongket = new TongKetMonDTO();
                mtongket.STT = stt++;
                mtongket.TenGiaoVien = lop.GiaoVien.TenGiaoVien;
                mtongket.TenLop = lop.TenLop;
                mtongket.SiSo = siSo;
                mtongket.SoLuongDat = soLuongDat;
                mtongket.TyLe = tiLe;
                // add vào ds bảng báo cáo
                bangDiemTongKetMon.Add(mtongket);
            }
            return bangDiemTongKetMon;
        }

        /// <summary>
        /// Lấy bảng điểm tất cả môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã khối</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <returns></returns>
        public List<TongKetHocKyDTO> LayBangDiem_BaoCao_HocKy(string MaKhoi, string MaHocKy, string MaNamHoc)
        {
            List<TongKetHocKyDTO> bangDiemTongKetHocKy = new List<TongKetHocKyDTO>();

            // Lấy tất cả các môn học trong bảng môn học
            List<MonHocDTO> ds_monhoc = _monhocDAL.LayList_MonHoc();

            List<LopDTO> ds_lop = _lopDAL.LayListLop_MaNam_MaKhoi(MaNamHoc, MaKhoi);

            int stt = 1;
            foreach (MonHocDTO monhoc in ds_monhoc)
            {
                foreach (LopDTO lop in ds_lop)
                {
                    // Kiểm tra đã nhập điểm đủ cho lớp này hay chưa
                    int siSo = _phanLopDAL.Dem_SiSo_Lop(lop.MaLop);
                    DataTable bdiemLop = _bangDiemDAL.LayBangDiem_MonHoc_Lop(lop.MaLop, monhoc.MaMonHoc, MaHocKy);
                    // Tính toán số lượng đạt và tỉ lệ
                    double diemDat = _quyDinhBUS.LayDiemChuan();
                    int soLuongDat = 0;
                    double tiLe = 0;
                    // Chưa nhập đủ điểm
                    if (bdiemLop.Rows.Count < siSo)
                    {
                        soLuongDat = 0;
                    }
                    else
                    {
                        foreach (DataRow dr in bdiemLop.Rows)
                        {
                            if (Convert.ToDouble(dr["DTB"]) >= diemDat)
                                soLuongDat++;
                        }
                    }
                    tiLe = (soLuongDat * 100) / siSo;

                    // tạo bảng báo cáo tổng kết môn
                    TongKetHocKyDTO mtongket = new TongKetHocKyDTO();
                    mtongket.STT = stt++;
                    mtongket.TenMonHoc = monhoc.TenMonHoc;
                    mtongket.TenGiaoVien = lop.GiaoVien.TenGiaoVien;
                    mtongket.TenLop = lop.TenLop;
                    mtongket.SiSo = siSo;
                    mtongket.SoLuongDat = soLuongDat;
                    mtongket.TyLe = tiLe;
                    // add vào ds bảng báo cáo
                    bangDiemTongKetHocKy.Add(mtongket);
                }
            }
            return bangDiemTongKetHocKy;
        }

    }
}
