using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;
using System.Collections;

namespace QLHS.BUS
{
    public class PhanLopBUS
    {
        PhanLopDAL _PhanLopDAL;
        HocSinhDAL _HocSinhDAL;
        NamHocBUS _NamHocBUS;

        public PhanLopBUS()
        {
            _PhanLopDAL = new PhanLopDAL();
            _HocSinhDAL = new HocSinhDAL();
            _NamHocBUS = new NamHocBUS();
        }
        /// <summary>
        /// Kiểm tra tồn tại  STT của 1 học sinh trong lớp
        /// </summary>
        /// <param name="STT">Int: Số thứ tự</param>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Bool:</returns>
        public bool KiemTra_STT_TonTai(int STT, string MaLop)
        {
            return _PhanLopDAL.KiemTraTonTai_STT(STT, MaLop);
        }
        /// <summary>
        /// Lấy Số thứ tự tiếp theo trong bảng điểm
        /// </summary>
        /// <param name="MaLop">String: mã lớp</param>
        /// <returns>Int</returns>
        public int LaySTT_TiepTheo(string MaLop)
        {
            return _PhanLopDAL.Lay_STT_TiepTheo(MaLop);
        }
        /// <summary>
        /// Lấy STT hiện tại của 1 học sinh
        /// </summary>
        /// <param name="MaHocSinh">String: Mã học sinh</param>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Int</returns>
        public int LaySTT_HienTai(string MaHocSinh, string MaLop)
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
        /// <summary>
        /// Thay đổi lớp mới cho học sinh 
        /// </summary>
        /// <param name="MaHocSinh">String: mã học sinh</param>
        /// <param name="MaLopCu">String: Mã lớp cũ</param>
        /// <param name="MaLopMoi">String: Mã lớp mới</param>
        /// <returns></returns>
        public bool ThayDoi_LopMoi_HocSinh(string MaHocSinh, string MaLopCu, string MaLopMoi)
        {
            return _PhanLopDAL.ThayDoi_LopMoi_HocSinh(MaHocSinh, MaLopCu, MaLopMoi);
        }
        /// <summary>
        /// Cập nhật STT học sinh cho cả lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Bool</returns>
        public bool CapNhapSTT_HocSinh_Lop(string MaLop)
        {
            DataTable dsHocSinh = _HocSinhDAL.LayDT_HocSinh_LopHoc(MaLop);
            int i = 0;
            int soHS = dsHocSinh.Rows.Count;
            // Lop khong co hoc sinh nao
            if (soHS == 0)
                return false;
            HocSinhChuanHoaTenDTO[] listHocSinh = new HocSinhChuanHoaTenDTO[soHS];
           
            ArrayList arrList = new ArrayList();
            foreach (DataRow dr in dsHocSinh.Rows)
            {
                listHocSinh[i] = new HocSinhChuanHoaTenDTO();
                listHocSinh[i].MaHocSinh = dr["MaHocSinh"].ToString();
                listHocSinh[i].TenHocSinh = dr["TenHocSinh"].ToString();

                arrList.Add(listHocSinh[i]);
                i++;
            }
            HocSinhChuanHoaTenDTO.newHocSinhChuanHoaTenDTO _compare = new HocSinhChuanHoaTenDTO.newHocSinhChuanHoaTenDTO();
            arrList.Sort(_compare);

            i = 1;
            foreach (HocSinhChuanHoaTenDTO hs in arrList)
            {
                hs.STT = i++;
            }

           return _PhanLopDAL.CapNhat_STT_Lop(MaLop, arrList);
            
        }

        public bool PhanLop_DSHocSinh_Lop(Dictionary<string,string> ds_hocsinhchuyen, string MaLopMoi
                    , out List<PhanLopDTO> ds_TonTai)
        {
            ds_TonTai = new List<PhanLopDTO>();
            string maKhoi = Util.ObjectUtil.LayMaKhoiLopTuMaLop(MaLopMoi),
                   maNamHoc = Util.ObjectUtil.LayMaNamHocTuMaLop(MaLopMoi);

            PhanLopDTO phanLopDTO = null;
            Dictionary<string, string> ds_them = new Dictionary<string,string>();
            foreach (var item in ds_hocsinhchuyen)
	        {
                phanLopDTO = _PhanLopDAL.Lay_PhanLop_HocSinh_Khoi_NamHoc(item.Key, maKhoi, maNamHoc);
                if (phanLopDTO == null)
                {
                    ds_them.Add(item.Key, item.Value);
                }
                else
                    ds_TonTai.Add(phanLopDTO);
	        }
            if (ds_them.Count == 0)
                return false;
            // chuyển lớp cho ds học sinh
            _PhanLopDAL.ChuyenLop_HocSinh(ds_them, MaLopMoi);
            // cập nhật stt cho lớp
            this.CapNhapSTT_HocSinh_Lop(MaLopMoi);
            return true;
        }
        public bool Xoa_DSHocSinh_Lop(Dictionary<string,string> ds_hocsinhchon, string MaLop)
        {
            bool success =  _PhanLopDAL.Xoa_DSHocSinh_Lop(ds_hocsinhchon, MaLop);
            // cập nhật stt cho lớp
            this.CapNhapSTT_HocSinh_Lop(MaLop);
            return success;
        }
        public DataTable LayDTLop_MaNam_MaKhoi_KhacMaLop(string MaNamHoc, string MaKhoi, string MaLop)
        {
            return _PhanLopDAL.LayDT_Lop_MaKhoi_KhacMaLop_MaNam(MaNamHoc, MaKhoi, MaLop);
        }
        public bool KiemTraTonTai_HocSinh_TrongLop(string MaHocSinh, string MaLop)
        {
            return _PhanLopDAL.KiemTraTonTao_HSinh_TrongLop_ChuyenLop(MaHocSinh,MaLop);
        }

    }
}
