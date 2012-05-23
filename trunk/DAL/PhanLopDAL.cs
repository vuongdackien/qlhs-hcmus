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

       
    }
}
