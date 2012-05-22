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
        public PhanLopBUS()
        {
            _PhanLopDAL = new PhanLopDAL();
            _HocSinhDAL = new HocSinhDAL();
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
    }
}
