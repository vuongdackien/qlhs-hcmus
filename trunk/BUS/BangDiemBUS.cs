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
        public BangDiemBUS()
        {
            _bangDiemDAL = new BangDiemDAL();
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

        public DataTable Lay_Bang_BaoCao_Diem_TongKetMon(string MaNamHoc, string MaKhoi, string MaMonHoc)
        {
            return null;
        }

        /// <summary>
        /// Lấy bảng điểm tất cả môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã khối</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <returns></returns>
        public DataTable LayBangDiem_HocKy(string MaKhoi, string MaHocKy, string MaNamHoc)
        {
            DataTable tbBDHocKy = _bangDiemDAL.LayBangDiem_HocKy(MaKhoi, MaHocKy, MaNamHoc);
            // Them cot stt
            DataColumn colSTT = new DataColumn("STT");
            // add col stt vao datatable
            tbBDHocKy.Columns.Add(colSTT);
            // khoi tao cot stt
            for (int i = 0; i < tbBDHocKy.Rows.Count; i++)
            {
                tbBDHocKy.Rows[i]["STT"] = i + 1;
            }
            return tbBDHocKy;
        }

        /// <summary>
        /// Lấy bảng điểm môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã khối</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaMonHoc">String: Mã môn học</param>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <returns></returns>
        public DataTable LayBangDiem_MonHoc(string MaMonHoc, string MaKhoi, string MaHocKy, string MaNamHoc)
        {
            DataTable tbBDMonHoc =  _bangDiemDAL.LayBangDiem_MonHoc(MaMonHoc, MaKhoi, MaHocKy, MaNamHoc);
            // Them cot stt
            DataColumn colSTT = new DataColumn("STT");
            // add col stt vao datatable
            tbBDMonHoc.Columns.Add(colSTT);
            // khoi tao cot stt
            for (int i = 0; i < tbBDMonHoc.Rows.Count; i++)
            {
                tbBDMonHoc.Rows[i]["STT"] = i + 1;
            }
            return tbBDMonHoc;
        }

       
    }
}
