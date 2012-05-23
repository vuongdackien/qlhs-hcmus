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
        GiaoVienDAL _giaoVienDAL =new GiaoVienDAL();
        DataTable _dataTableSource;
        GiaoVienDTO _giaoVienDTO;

        /// <summary>
        /// Lấy datatable danh sách giáo viên
        /// </summary>
        /// <returns></returns>
        public DataTable LayDT_DanhSachGiaoVien()
        {
            return _giaoVienDAL.LayDT_DanhSach_GiaoVien();
        }
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
                int kq = _giaoVienDAL.ThemGiaoVien(GV);
                return kq;
            }
            
        }
        public void XoaGiaoVien(string MaGV)
        {
            _giaoVienDAL.XoaGiaoVien(MaGV);
        }
        public void CapNhatGiaoVien(GiaoVienDTO GV)
        {
            _giaoVienDAL.CapNhatGiaoVien(GV);
        }

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
            _dataTableSource = _giaoVienDAL.TableGiaoVien(i,DK);
            return _dataTableSource;
        }
        public DataTable TableGiaoVien()
        {
            _dataTableSource = _giaoVienDAL.TableGiaoVien();
            //dt = new DataTable();
            return _dataTableSource;
        }
        
        /// <summary>
        /// Tạo danh sách các giáo viên dạng List 
        /// </summary>
        /// <returns></returns>
        public List<GiaoVienDTO> ListGiaoVien()
        {
            List<GiaoVienDTO> ListGV=new List<GiaoVienDTO>() ;
            ListGV=_giaoVienDAL.ListGiaoVien();
            return ListGV;
        }

        /// <summary>
        /// Truyền điều kiện KD để tạo list các giáo viên tương ứng
        /// </summary>
        /// <param name="DK"></param>
        /// <returns></returns>
        public List<GiaoVienDTO> ListGiaoVien(string DK)
        {
            List<GiaoVienDTO> ListGV = new List<GiaoVienDTO>();
            ListGV = _giaoVienDAL.ListGiaoVien(DK);
            return ListGV;
        }

        public void NewRows(string MAGV)
        {
            _giaoVienDTO = new GiaoVienDTO();
            DataRow dr = _giaoVienDAL.GetNewRow();
            dr["MaGiaoVien"] = "";
            dr["TenGiaoVien"] = "";
            _giaoVienDAL.AddNewRow(dr);

        }
        public bool KiemTonTaiGiaoVien(GiaoVienDTO GV)
        {
           return _giaoVienDAL.KiemtratontaiGiaoVien(GV);
        }

    }
}
