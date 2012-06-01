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

        /// <summary>
        /// Cập nhật STT học sinh cho cả lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Bool</returns>
        public bool CapNhap_STT_HocSinh_Lop(string MaLop)
        {
            DataTable dsHocSinh = _HocSinhDAL.LayDT_HocSinh_LopHoc(MaLop);
            int i = 0;
            int soHS = dsHocSinh.Rows.Count;
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

        public bool PhanLop_DSHocSinh_Lop(Dictionary<string,string> ds_hocsinhchuyen, string MaLopMoi)
        {
            string maKhoi = Util.ObjectUtil.LayMaKhoiLopTuMaLop(MaLopMoi),
                   maNamHoc = Util.ObjectUtil.LayMaNamHocTuMaLop(MaLopMoi);

            PhanLopDTO phanLopDTO = null;
            Dictionary<string, string> ds_them = new Dictionary<string,string>();
            foreach (var item in ds_hocsinhchuyen)
	        {
                phanLopDTO = _PhanLopDAL.KT_HocSinh_TonTai_Khoi_NamHoc(item.Key, maKhoi, maNamHoc);
                if (phanLopDTO == null)
                {
                    ds_them.Add(item.Key,item.Value);
                }
	        }

            // chuyển lớp cho ds học sinh
            _PhanLopDAL.ChuyenLop_HocSinh(ds_them, MaLopMoi);
            // cập nhật stt cho lớp
            this.CapNhap_STT_HocSinh_Lop(MaLopMoi);
            return true;
        }
        public bool Xoa_DSHocSinh_Lop(Dictionary<string,string> ds_hocsinhchon, string MaLop)
        {
            return _PhanLopDAL.Xoa_DSHocSinh_Lop(ds_hocsinhchon, MaLop);
        }
        public DataTable LayDTLop_MaNam_MaKhoi_KhacMaLop(string MaNamHoc, string MaKhoi, string MaLop)
        {
            return _PhanLopDAL.LayDTLop_MaNam_MaKhoi_KhacMaLop(MaNamHoc, MaKhoi, MaLop);
        }
        public DataTable KT_HocSinh_ChuyenLop(string MaHocSinh, string MaLop)
        {
            return _PhanLopDAL.KT_HocSinh_ChuyenLop(MaHocSinh, MaLop);
        }
        public DataTable LayDTKhoi(string MaNamHoc)
        {
            return _PhanLopDAL.LayDTKhoi(MaNamHoc);
        }
        public DataTable LayDTKhoi10(string MaNamHoc)
        {
            return _PhanLopDAL.LayDTKhoi10(MaNamHoc);
        }
        public DataTable LayDTKhoi_PhanLopCu(string MaNamHoc)
        {
            return _PhanLopDAL.LayDTKhoi_PhanLopCu(MaNamHoc);
        }
        public DataTable LayDTKhoi_Chuyen(string MaNamHoc, string MaKhoi)
        {
            return _PhanLopDAL.LayDTKhoi_Chuyen(MaNamHoc, MaKhoi);
        }
        public DataTable KiemTraHSTonTaiTrongLop_ChuyenLop(string MaHocSinh, string MaLop)
        {
            return _PhanLopDAL.KiemTraHSTonTaiTrongLop_ChuyenLop(MaHocSinh,MaLop);
        }

    }
}
