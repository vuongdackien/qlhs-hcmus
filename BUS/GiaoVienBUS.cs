using System;
using System.Collections.Generic;
using System.Text;
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
        //public void TaoDsCv(TextBoxX MaCV, TextBoxX TenCV, TextBoxX DiemCong, TextBoxX TrangThai, TextBoxX Cap, TextBoxX MoTa, DataGridView dgv, BindingNavigator bdNav)
        //{
        //    BindingSource bdsrc = new BindingSource { DataSource = dtcongviec };
        //    dgv.DataSource = bdsrc;
        //    bdNav.BindingSource = bdsrc;
        //    MaCV.DataBindings.Clear();
        //    MaCV.DataBindings.Add("Text", bdsrc, "MaGV");
        //    TenCV.DataBindings.Clear();
        //    TenCV.DataBindings.Add("Text", bdsrc, "TenGV");
        //    DiemCong.DataBindings.Clear();
        //  

        //}
        public void ThemGiaoVien(GiaoVienDTO GV)
        {
            GVDAL.ThemGiaoVien(GV);
        }
        public void XoaGiaoVien(GiaoVienDTO GV)
        {
            GVDAL.XoaGiaoVien(GV);
        }
        public void CapNhatGiaoVien(GiaoVienDTO GV)
        {
            GVDAL.CapNhatGiaoVien(GV);
        }
        #region Tạo bảng các giáo viên
        /// <summary>
        /// Tạo bảng các giáo viên có điều kiện
        /// </summary>
        /// <param name="DK"> truyền điều kiện để lọc các giáo  viên tương ứng</param>
        /// <returns></returns>
        public DataTable TableGiaoVien( string DK)
        {
            dt = new DataTable(DK);
            return dt;
        }
        public DataTable TableGiaoVien()
        {
            dt = new DataTable();
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
        public void NewRows(string MaKH)
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
