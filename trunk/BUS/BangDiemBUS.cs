using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;
using System.Linq;

namespace QLHS.BUS
{
    public class BangDiemBUS
    {
        private BangDiemDAL _bangDiemDAL;
        private LopDAL _lopDAL;
        private PhanLopDAL _phanLopDAL;
        private QuyDinhBUS _quyDinhBUS;
        private HocSinhDAL _hocSinhDAL;
        private MonHocDAL _monHocDAL;

        public BangDiemBUS()
        {
            _bangDiemDAL = new BangDiemDAL();
            _lopDAL = new LopDAL();
            _phanLopDAL = new PhanLopDAL();
            _quyDinhBUS = new QuyDinhBUS();
            _hocSinhDAL = new HocSinhDAL();
            _monHocDAL = new MonHocDAL();
        }

        /// <summary>
        /// Lấy bảng điểm môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaMonHoc">String: Mã môn học</param>
        /// <returns></returns>
        public DataTable LayBangDiem_Lop_MonHoc_HocKy(string MaLop, string MaHocKy, string MaMonHoc)
        {
            return _bangDiemDAL.LayBangDiem_MonHoc_HocKy_Lop(MaLop, MaHocKy, MaMonHoc);
        }
        /// <summary>
        /// Kiểm tra hợp lệ các cột điểm trên 1 dòng của bảng điểm BangDiemDTO
        /// </summary>
        /// <param name="bd">BangDiemDTO</param>
        /// <returns>Bool</returns>
        public bool KiemTraHopLe_DataRow_Lop_MonHoc_HocKy(BangDiemDTO bd)
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
                Util.ExceptionUtil.Throw(msg);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Tính điểm trung bình môn trên 1 dòng bảng điểm
        /// </summary>
        /// <param name="bd">BangDiemDTO (Quy định: VỚi điểm == -1 xem như chưa nhập</param>
        /// <returns>double: Điểm trung bình</returns>
        public double TinhDiemTB_DataRow_Lop_MonHoc_HocKy(BangDiemDTO bd)
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
  
            return Util.ObjectUtil.LamTron(TongDiem / 7);

        }
         /// <summary>
        /// Lưu bảng điểm 1 môn học / 1 học sinh / 1 học kỳ / 1 lớp / 1 năm học
        /// </summary>
        /// <param name="bd">BangDiemDTO</param>
        /// <returns>Bool</returns>
        public bool LuuBangDiem_HocSinh_MonHoc_HocKy(BangDiemDTO bd)
        {
            return _bangDiemDAL.LuuBangDiem_MonHoc_HocSinh_HocKy(bd);
        }
        /// <summary>
        /// Xóa bảng điểm 1 môn học / 1 học sinh / 1 học kỳ / 1 lớp / 1 năm học
        /// </summary>
        /// <param name="bd">BangDiemDTO</param>
        /// <returns>bool</returns>
        public bool XoaBangDiem_HocSinh_MonHoc_HocKy(BangDiemDTO bd)
        {
            return _bangDiemDAL.XoaBangDiem_MonHoc_HocSinh_HocKy(bd);
        }

   
        /// <summary>
        /// Lấy bảng điểm tổng kết học kỳ theo lớp
        /// </summary>
        /// <param name="MaLop">String: mã lớp</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <returns>List BangDiemHocKyDTO</returns>
        public List<BangDiemHocKyDTO> Lay_BangDiem_Lop_HocKy(string MaLop, string MaHocKy)
        {
            List<BangDiemHocKyDTO> bangDiemHocKy = new List<BangDiemHocKyDTO>();
            // Lấy ds học sinh của lớp
            var ds_hocsinh = _hocSinhDAL.LayList_HocSinh_LopHoc(MaLop);
            MonHoc_HeSoDTO dsHeSoMonHoc = _monHocDAL.Lay_HeSoMonHoc();
            foreach (HocSinhDTO hocsinh in ds_hocsinh)
            {
                BangDiemHocKyDTO bangDiemCaNhan = new BangDiemHocKyDTO();
                bangDiemCaNhan.STT = hocsinh.STT;
                bangDiemCaNhan.MaHocSinh = hocsinh.MaHocSinh;
                bangDiemCaNhan.TenHocSinh = hocsinh.TenHocSinh;
                // Tinh điểm tb
                DataTable tbBangDiem = _bangDiemDAL.LayBangDiem_HocKy_HocSinh(MaLop,hocsinh.MaHocSinh,MaHocKy);
                int soMonHoc = tbBangDiem.Rows.Count;
                int soMonDuDiem = 0;
                double tongDiem = 0;
                double tongHeSo = 0;
                double heso = 0;
                object dtb = 0;
                foreach (DataRow dr in tbBangDiem.Rows)
                {
                    if (dr["DTB"] is DBNull)
                        dtb = "_";
                    else 
                        dtb = dr["DTB"];  

                    switch(Convert.ToString(dr["MaMonHoc"]))
                    {
                        case "toan"  : bangDiemCaNhan.dtoan = dtb;  
                                       heso = dsHeSoMonHoc.toan ; break;
                        case "ly"  : bangDiemCaNhan.dly = dtb; 
                                        heso = dsHeSoMonHoc.ly ; break;
                        case "hoa": bangDiemCaNhan.dhoa = dtb;
                                        heso =dsHeSoMonHoc.hoa ; break;
                        case "sinh"  : bangDiemCaNhan.dsinh = dtb; 
                                       heso = dsHeSoMonHoc.sinh ; break;
                        case "ngvan"  : bangDiemCaNhan.dngvan = dtb;
                                       heso = dsHeSoMonHoc.nngu ; break;
                        case "su"  : bangDiemCaNhan.dsu = dtb;  
                                       heso = dsHeSoMonHoc.su ; break;
                        case "dia"  : bangDiemCaNhan.ddia = dtb; 
                                       heso = dsHeSoMonHoc.dia ; break;
                        case "nngu"  : bangDiemCaNhan.dnngu = dtb; 
                                        heso = dsHeSoMonHoc.nngu ; break;
                        case "tin"  : bangDiemCaNhan.dtin = dtb;
                                       heso = dsHeSoMonHoc.tin ; break;
                        case "tduc"  : bangDiemCaNhan.dtduc = dtb;
                                       heso = dsHeSoMonHoc.tduc ; break;
                        case "gdcd": bangDiemCaNhan.dgdcd = dtb; 
                                        heso = dsHeSoMonHoc.gdcd ; break;
                        case "qphong"  : bangDiemCaNhan.dqphong = dtb; 
                                       heso =dsHeSoMonHoc.qphong ; break;
                        case "cnghe"  : bangDiemCaNhan.dcnghe = dtb; 
                                       heso = dsHeSoMonHoc.cnghe ; break;
                    }
                    if (!Convert.ToString(dtb).Equals("_"))
                    {
                        tongDiem += heso * Convert.ToDouble(dtb);
                        tongHeSo += heso;
                        soMonDuDiem++;
                    }
                }
                if (soMonDuDiem == soMonHoc)
                {
                    bangDiemCaNhan.DTB = Util.ObjectUtil.LamTron(tongDiem / tongHeSo, 4);
                }
                else
                    bangDiemCaNhan.DTB = "_";

                bangDiemHocKy.Add(bangDiemCaNhan);
            }

            return bangDiemHocKy;
        }
        /// <summary>
        /// Lấy bảng tổng kết môn học theo học kỳ của lớp
        /// </summary>
        /// <param name="MaLop">String: Mã khối</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaMonHoc">String: Mã môn học</param>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <returns>List TongKetMonDTO</returns>
        public List<TongKetMonDTO> Lay_BangTongKet_MonHoc_Khoi_HocKy(string MaMonHoc, string MaKhoi, string MaHocKy, string MaNamHoc)
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
                double diemDat = _quyDinhBUS.LayDiemChuanDatMon();
                int soLuongDat = 0;

                // Chưa nhập đủ điểm
                if (bdiemLop.Rows.Count == siSo)
                {
                    foreach (DataRow dr in bdiemLop.Rows)
                    {
                        if (Convert.ToDouble(dr["DTB"]) >= diemDat)
                            soLuongDat++;
                    }
                }

                // tạo bảng báo cáo tổng kết môn
                bangDiemTongKetMon.Add(new TongKetMonDTO() { 
                    STT = stt++,
                    TenGiaoVien = lop.GiaoVien.TenGiaoVien,
                    TenLop = lop.TenLop,
                    SiSo = siSo,
                    SoLuongDat = (siSo > 0 && bdiemLop.Rows.Count == siSo) ? soLuongDat.ToString() : "__",
                    TyLe = (siSo > 0 && bdiemLop.Rows.Count == siSo) ? ((soLuongDat * 100) / siSo).ToString() : "__"
                });
            }
            return bangDiemTongKetMon;
        }
        /// <summary>
        /// Tính điểm trung bình cho học sinh / học kỳ
        /// </summary>
        /// <param name="MaHocSinh">string: mã học sinh</param>
        /// <param name="MaLop">string: mã lớp</param>
        /// <param name="MaHocKy">string: mã học kỳ</param>
        /// <returns></returns>
        public double Tinh_DTB_HocSinh_Lop_HocKy(string MaHocSinh, string MaLop, string MaHocKy)
        {
            // Lấy bảng điểm học sinh ở học kỳ hiện tại
            DataTable bd_HocSinh = _bangDiemDAL.LayBangDiem_HocKy_HocSinh(MaLop, MaHocSinh, MaHocKy);
            double tongHeSo = 0, tongDiem = 0, heSo;
            // Duyệt từng môn và tính điểm TB
            foreach (DataRow bdmon in bd_HocSinh.Rows)
            {
                if (bdmon["DTB"] is DBNull)
                {
                    return 0;
                }
                else
                {
                    heSo =  Convert.ToDouble(bdmon["HeSo"]);
                    tongHeSo += heSo;
                    tongDiem += Convert.ToDouble(bdmon["DTB"]) * heSo; 
                }
            }
            return Util.ObjectUtil.LamTron(tongDiem / tongHeSo, 2);
        }

        /// <summary>
        /// Lấy bảng tổng kết theo học kỳ của khối
        /// </summary>
        /// <param name="MaLop">String: Mã khối</param>
        /// <param name="MaHocKy">String: Mã học kỳ</param>
        /// <param name="MaNamHoc">String: Mã năm học</param>
        /// <returns></returns>
        public IList<TongKetHocKyDTO> Lay_BangTongKet_Khoi_HocKy(string MaKhoi, string MaHocKy, string MaNamHoc)
        {
            IList<TongKetHocKyDTO> bangDiemTongKetHocKy = new List<TongKetHocKyDTO>();

            // Lấy danh sách các lớp trong khối hiện tại
            IList<LopDTO> ds_lop = _lopDAL.LayListLop_MaNam_MaKhoi(MaNamHoc, MaKhoi);

            int stt = 1, siSo;
            int soLuongDat = 0;
            double diemDat = _quyDinhBUS.LayDiemChuanDatMon();
            bool duDieuKienXetTiLe;

            // Đánh giá tỉ lệ từng lớp
            foreach (LopDTO lop in ds_lop)
            {
                soLuongDat = 0;
                IList<HocSinhDTO> listHS_Lop = _hocSinhDAL.LayList_HocSinh_LopHoc(lop.MaLop);
                siSo = listHS_Lop.Count;

                if (siSo != 0)
                {
                    // Duyệt từng học sinh trong lớp hiện tại, kiểm tra DTB, tính tỉ lệ
                    duDieuKienXetTiLe = true;
                    foreach (HocSinhDTO hs in listHS_Lop)
                    {
                        double dTBinhHs = this.Tinh_DTB_HocSinh_Lop_HocKy(hs.MaHocSinh, lop.MaLop, MaHocKy);
                        if (dTBinhHs == 0)
                        {
                            duDieuKienXetTiLe = false;
                            break;
                        }
                        if (dTBinhHs >= diemDat)
                        {
                            soLuongDat++;
                        }
                    }
                }
                else
                    duDieuKienXetTiLe = false;

                bangDiemTongKetHocKy.Add(new TongKetHocKyDTO()
                {
                    STT = stt++,
                    TenLop = lop.TenLop,
                    TenGiaoVien = lop.GiaoVien.TenGiaoVien,
                    SiSo = siSo,
                    SoLuongDat =  duDieuKienXetTiLe ? soLuongDat.ToString() : "__",
                    TyLe = duDieuKienXetTiLe ? ((soLuongDat*100) / siSo).ToString() : "__"
                });
            }
            return bangDiemTongKetHocKy;
        }

    }
}
