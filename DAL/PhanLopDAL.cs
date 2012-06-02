using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class PhanLopDAL : ConnectData
    {
        /// <summary>
        /// Lấy hồ sơ phân lớp học sinh trong năm cũ có tồn tại trong năm mới chưa
        /// </summary>
        /// <param name="MaHocSinh"></param>
        /// <param name="MaKhoi"></param>
        /// <param name="MaNamHoc"></param>
        /// <returns>PhanLopDTO</returns>
        public PhanLopDTO Lay_PhanLop_HocSinh_Khoi_NamHoc(string MaHocSinh,string MaKhoi,string MaNamHoc)
        {
            string khoi_in="";
            if (MaKhoi == "10")
            {
                khoi_in = "(10,11)";
            }
            else
            {
                if (MaKhoi == "11")
                {
                    khoi_in = "(11,12)";
                }
                else
                    khoi_in = "(12)";
            }
            string sql = "select a.STT, a.MaHocSinh,b.TenLop, b.MaLop, b.TenLop, h.TenHocSinh from PHANLOP as a, LOP as b, HOCSINH h "
                        + "where a.MaLop=b.MaLop and h.MaHocSinh = a.MaHocSinh "
                        + "and a.MaHocSinh='"+MaHocSinh+"' and b.MaNamHoc= '"
                        + MaNamHoc + "' and b.MaKhoiLop in " + khoi_in + "  ";
            OpenConnect();
            var dr = ExecuteReader(sql);
            PhanLopDTO phanlop = null;
            while (dr.Read())
            {
                phanlop = new PhanLopDTO();
                phanlop.MaHocSinh = Convert.ToString(dr["MaHocSinh"]);
                phanlop.TenHocSinh = Convert.ToString(dr["TenHocSinh"]);
                phanlop.STT = Convert.ToInt32(dr["STT"]);
                phanlop.MaLop = Convert.ToString(dr["MaLop"]);
                phanlop.TenLop = Convert.ToString(dr["TenLop"]);
                break;
            }

            CloseConnect();
            return phanlop;
        }

        public bool KiemTra_STT_TonTai(int STT, string MaLop)
        {
            string sql = "SELECT STT FROM PHANLOP WHERE MaLop = '"+MaLop+"' AND STT = "+STT;
            return GetTable(sql).Rows.Count > 0;
        }
        public int Lay_STT_TiepTheo(string MaLop)
        {
            string sql = "SELECT STT FROM PHANLOP WHERE MaLop = '"+MaLop+"' ORDER BY STT DESC";
            return Convert.ToInt32(ExecuteScalar(sql)) + 1;
        }
        public int Lay_STT_HienTai(string MaHocSinh, string MaLop)
        {
            string sql = "SELECT STT FROM PHANLOP WHERE MaLop = '" + MaLop + "' AND MaHocSinh = '"+MaHocSinh+"'";
            return Convert.ToInt32(ExecuteScalar(sql));
        }
        /// <summary>
        /// Kiểm tra xem mã học sinh đã  phân lớp hay chưa
        /// </summary>
        /// <param name="MaHocSinh">String: mã học sinh</param>
        /// <returns>Bool</returns>
        public bool KiemTra_TonTai_HocSinh_PhanLop(string MaHocSinh)
        {
            string sql = "SELECT * FROM PHANLOP WHERE MaHocSinh = '"+MaHocSinh+"'";
            return GetTable(sql).Rows.Count > 0;
        }
        /// <summary>
        /// Đếm sỉ số của 1 lớp
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Int</returns>
        public int Dem_SiSo_Lop(string MaLop)
        {
            string sql = "SELECT count(*) FROM PHANLOP WHERE MaLop = '" + MaLop +"'";
            return Convert.ToInt32(ExecuteScalar(sql));
        }

        /// <summary>
        /// Cập nhật STT cho cả lớp
        /// </summary>
        /// <param name="MaLop">String: mã lớp</param>
        /// <param name="arrayList">ArrayList: ArrayList HocSinhChuanHoaTenDTO</param>
        /// <returns>Bool</returns>
        public bool CapNhat_STT_Lop(string MaLop, System.Collections.ArrayList arrayList)
        {
            string sql = "";
            foreach (HocSinhChuanHoaTenDTO hs in arrayList)
            {
                sql +=  "\nUPDATE PHANLOP SET STT = "+hs.STT+" WHERE MaHocSinh = '"+hs.MaHocSinh+"' AND MaLop = '"+MaLop+"'";
            }
            return ExecuteQuery(sql) > 0;
        }
        public bool ChuyenLop_HocSinh(Dictionary<string,string> ds_hocsinh,string MaLopMoi)
        {
            if (ds_hocsinh.Count == 0)
                return false;

            string sql = "INSERT INTO PHANLOP(STT,MaHocSinh,MaLop) ";
            string union = "";
            foreach (var item in ds_hocsinh)
            {
                sql += union + "\n SELECT " + 0 + ",'" + item.Key + "','" + MaLopMoi + "' ";
                union = " UNION ";
            }
            return ExecuteQuery(sql) > 0;
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
            return ExecuteQuery("UPDATE PHANLOP SET MaLop ='"+MaLopMoi+"' WHERE MaLop = '"+
                        MaLopCu+"' AND MaHocSinh = '"+MaHocSinh+"'") > 0;
        }
        public bool Xoa_DSHocSinh_Lop(Dictionary<string, string> ds_hocsinhchon, string MaLop)
        {
            string sql = "";
            foreach (var item in ds_hocsinhchon)
            {
                 sql += "\nDELETE FROM PHANLOP WHERE MaHocSinh='" + item.Key + "' AND MaLop='" + MaLop + "' ";
            }
            return ExecuteQuery(sql) > 0;
        }

        public DataTable LayDTLop_MaNam_MaKhoi_KhacMaLop(string MaNamHoc, string MaKhoi, string MaLop)
        {
            string sql = string.Format("SELECT MaLop, TenLop from Lop where "
                                      + " MaKhoiLop = '{0}' AND MaNamHoc = '{1}' and MaLop not in('{2}') ", MaKhoi, MaNamHoc, MaLop);
            return GetTable(sql);
        }
        public DataTable LayDTKhoi(string MaNamHoc)
        {
            string sql = "select distinct MaKhoiLop as MaKhoi ,N'Khối '+CONVERT(varchar,MaKhoiLop) as TenKhoi from LOP where MaNamHoc='" + MaNamHoc + "' ";
            return GetTable(sql);
        }
        public DataTable LayDTKhoi10(string MaNamHoc)
        {
            string sql = "select distinct MaKhoiLop as MaKhoi ,N'Khối '+CONVERT(varchar,MaKhoiLop) as TenKhoi from LOP where MaNamHoc='" + MaNamHoc + "' and MaKhoiLop=10 ";
            return GetTable(sql);
        }
        public DataTable LayDTKhoi_PhanLopCu(string MaNamHoc)
        {
            string sql = "select distinct MaKhoiLop as MaKhoi ,N'Khối '+CONVERT(varchar,MaKhoiLop) as TenKhoi from LOP where MaNamHoc='" + MaNamHoc + "' and MaKhoiLop in (10,11)";
            return GetTable(sql);
        }
        public DataTable LayDTKhoi_Chuyen(string MaNamHoc, string MaKhoi)
        {
            string sql = "select distinct MaKhoiLop as MaKhoi ,N'Khối '+CONVERT(varchar,MaKhoiLop) as TenKhoi from LOP where MaNamHoc='" + MaNamHoc + "' and MaKhoiLop ='" + MaKhoi + "'";
            return GetTable(sql);
        }
        public bool KiemTraHSTonTaiTrongLop_ChuyenLop(string MaHocSinh, string MaLop)
        {
            string sql = "select pl.MaHocSinh from PhanLop pl,HocSinh hs where pl.MaHocSinh='"+MaHocSinh+"' and pl.MaLop='"+MaLop+"' and pl.MaHocSinh=hs.MaHocSinh";
            return ExecuteScalar(sql) != null;
        }
    }
}

