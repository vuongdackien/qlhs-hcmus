using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class GiaoVienBUS
    {
        GiaoVienDAL GVDAL=new GiaoVienDAL();
        DataTable dt;
        GiaoVienDTO GV;
       public string Doichuoi(string input, string oldValue, string newValue, bool matchCase)
        {

            RegexOptions regexOption = RegexOptions.None;

            if (!matchCase)
            {

                regexOption = RegexOptions.IgnoreCase;

            }

            Regex regex = new Regex(oldValue, regexOption);

            input = regex.Replace(input, newValue);

            return input;

        }
        
        public int ThemGiaoVien(GiaoVienDTO GV)
        {
            if (KiemTonTaiGiaoVien(GV))
            {
                return 0;
            }
            else
            {
                int kq = GVDAL.ThemGiaoVien(GV);
                return kq;
            }
            
        }
        public void XoaGiaoVien(string MaGV)
        {
            GVDAL.XoaGiaoVien(MaGV);
        }
        public void CapNhatGiaoVien(GiaoVienDTO GV)
        {
            GVDAL.CapNhatGiaoVien(GV);
        }
        #region Tạo bảng các giáo viên
        /// <summary>
        /// Tạo bảng các giáo viên có điều kiện
        /// 1:Tìm theo tên
        /// 2:Tìm theo mã
        /// 3:Tìm theo cả hai
        /// </summary>
        /// <param name="DK"> truyền điều kiện để lọc các giáo  viên tương ứng</param>
        /// <returns></returns>
        public DataTable TableGiaoVien(int i, string DK)
        {
            //dt = new DataTable();
            dt = GVDAL.TableGiaoVien(i,DK);
            return dt;
        }
        public DataTable TableGiaoVien()
        {
            dt = GVDAL.TableGiaoVien();
            //dt = new DataTable();
            return dt;
        }
        #endregion
        #region Tạo danh sách các giáo viên dạng List 
        public List<GiaoVienDTO> ListGiaoVien()
        {
            List<GiaoVienDTO> ListGV=new List<GiaoVienDTO>() ;
            ListGV=GVDAL.ListGiaoVien();
            return ListGV;
        }
        /// <Tạo danh sách các giáo viên có điều kiện>
        /// 
        /// </summary>
        /// <param name="DK">truyền điều kiện KD để tạo list các giáo viên tương ứng</param>
        /// <returns></returns>
        public List<GiaoVienDTO> ListGiaoVien(string DK)
        {
            List<GiaoVienDTO> ListGV = new List<GiaoVienDTO>();
            ListGV = GVDAL.ListGiaoVien(DK);
            return ListGV;
        }
        #endregion 
        /// <Thêm một dòng mới>
        /// 
        /// </summary>
        /// <param name="MaKH"></param>
        public void NewRows(string MAGV)
        {
            GV = new GiaoVienDTO();
            DataRow dr = GVDAL.GetNewRow();
            dr["MaGiaoVien"] = "";
            dr["TenGiaoVien"] = "";
            GVDAL.AddNewRow(dr);

        }
        public bool KiemTonTaiGiaoVien(GiaoVienDTO GV)
        {
           return GVDAL.KiemtratontaiGiaoVien(GV);
        }

    }
}
