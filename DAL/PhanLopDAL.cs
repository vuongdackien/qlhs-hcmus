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
        /// Kiểm tra mã học sinh trong năm cũ có tồn tại trong năm mới chưa
        /// </summary>
        /// <param name="MaHocSinh"></param>
        /// <param name="MaKhoi"></param>
        /// <param name="MaNamHoc"></param>
        /// <returns> bool</returns>
        public bool KT_HocSinh_TonTai_NamHoc(string MaHocSinh,string MaKhoi,string MaNamHoc)
        {
            string khoi="";
            if (MaKhoi == "10")
            {
                khoi = khoi + "('10',11)";
            }
            else
            {
                if (MaKhoi == "11")
                {
                    khoi = khoi + "('11','12')";
                }
                else
                    khoi = khoi + "(12)";
            }
            string sql = "select MaHocSinh,TenLop from PHANLOP as a, LOP as b where a.MaLop=b.MaLop and a.MaHocSinh='"+MaHocSinh+"' and b.MaNamHoc= '" + MaNamHoc + "' and b.MaKhoiLop in "+khoi+"  ";
            return GetTable(sql).Rows.Count > 0;
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
        public bool ChuyenLop_HocSinh(string MaHocSinh,string MaLop)
        {
            int Stt = Lay_STT_TiepTheo(MaLop);
            string sql = "INSERT INTO PHANLOP(Stt,MaHocSinh,MaLop) VALUES("+Stt+",'"+MaHocSinh+"','"+MaLop+"') ";
            return ExecuteQuery(sql) > 0;
        }
        public bool XoaHocSinh_Lop(string MaHocSinh, string MaLop)
        {
            string sql = "DELETE FROM PHANLOP WHERE MaHocSinh='"+MaHocSinh+"' AND MaLop='"+MaLop+"' ";
            return ExecuteQuery(sql) > 0;
        }
        public DataTable LayDT_HocSinh_ChuaChuyenLop(string MaLop,string MaNamHoc)
        {
            string sql = "select p.STT,p.MaHocSinh,h.TenHocSinh,(case when h.GioiTinh='0' then 'Nam' else N'Nữ' end) as GioiTinh from PHANLOP as p,HOCSINH as h WHERE p.MaHocSinh=h.MaHocSinh and p.MaHocSinh=h.MaHocSinh and p.MaLop='"+MaLop+"' and "+
"p.MaHocSinh not in (select p1.MaHocSinh from PHANLOP as p1, Lop as l where p1.MaLop=l.MaLop and l.MaNamHoc='"+MaNamHoc+"')";
            return GetTable(sql);
        }
       
    }
}

