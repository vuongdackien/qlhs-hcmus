using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class MonHocDAL : ConnectData
    {
        MonHocDTO MHDTO;
        public int XoaMonHoc(string MaMH)
        {
           
            string sql="";
            sql = string.Format("delete  Giaovien  where MaMonHoc like '%{0}%'",MaMH);
            return ExecuteQuery(sql);
        }
        public int ThemMonHoc(MonHocDTO MHDTO)
        {
            string sql = "";
            sql = string.Format("insert into  MonHoc values ('{0}',N'{1}','{2}','{3}')",MHDTO.MaMonHoc,MHDTO.TenMonHoc,MHDTO.SoTiet,MHDTO.HeSo);
            return ExecuteQuery(sql);
        }
        public int CapNhatMonHoc(MonHocDTO MHDTO)
        {
            string sql = string.Format("update MonHoc set TenMonHoc=N'{0}', SoTiet='{1}', Heso='{2}'"
                                                     + "where madv={3} ", MHDTO.TenMonHoc, MHDTO.SoTiet,MHDTO.HeSo,MHDTO.MaMonHoc);
           return ExecuteQuery(sql);
        }
        public bool KiemtratontaiMonhoc(MonHocDTO MHDTO)
        {
            string sql = string.Format("SELECT count(*) as SoLuong FROM MonHoc WHERE MaMonHoc = '{0}'",MHDTO.MaMonHoc );
            return (int)ExecuteScalar(sql)==1 ;
        }

        /// <summary>
        /// Lấy Datatable danh sách môn học
        /// </summary>
        /// <param name="chiLayCacMonDangHoc">True: Chỉ lấy các môn đang học, False: Lấy tất cả 13 môn</param>
        /// <returns>Datatable</returns>
        public DataTable LayDT_DanhSach_MonHoc(bool chiLayCacMonDangHoc = true)
        {
            string sql = "";
            if (chiLayCacMonDangHoc)
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo FROM MONHOC WHERE TrangThai = 1 ORDER BY TenMonHoc ASC");
            else
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo FROM MONHOC ORDER BY TenMonHoc");

            return GetTable(sql);
        }
        /// <Tìm giáo viên theo điều kiện cho trước>
        /// Tìm với 1 điều kiện
        /// </summary>
        /// <param name="i">Các case thực hiện</param>
        /// 1: Tìm theo mã môn học
        /// 2: Tìm theo tên môn học
        /// 3: Tìm theo số tiết
        /// 4: Tìm theo hệ số
        /// <param name="DK">Điều kiện truyền vào</param>
        /// <returns></returns>
        public DataTable TableGiaoVien(int i, String DK)
        {
            string sql = "";
            switch (i)
            {
                case 1: sql = string.Format("select * from MonHoc where MaMonHoc like N'%{0}%' ", DK); break;
                case 2: sql = string.Format("select * from MonHoc where TenMonHoc like N'%{0}%' ", DK); break;
                case 3: sql = string.Format("select * from MonHoc where SoTiet like N'%{0}%' ", DK); break;
                case 4: sql = string.Format("select * from MonHoc where HeSo like N'%{0}%' ", DK); break;
                
            }

            DataTable dt = new DataTable();
            dt = GetTable(sql, true);
            return dt;
        }
        /// <Tìm kiếm với 2 điều kiện>
        /// 
        /// </summary>
        /// <param name="i">Các case</param>
        /// <param name="DK">Điều kiện truyền vào</param>
        /// <returns></returns>
      /*  public DataTable TableGiaoVien(int i, String DK)
        {
            string sql = "";
            switch (i)
            {
                case 1: sql = string.Format("select * from MonHoc where MaMonHoc like N'%{0}%' ", DK); break;
                case 2: sql = string.Format("select * from MonHoc where TenMonHoc like N'%{0}%' ", DK); break;
                case 3: sql = string.Format("select * from MonHoc where SoTiet like N'%{0}%' ", DK); break;
                case 4: sql = string.Format("select * from MonHoc where HeSo like N'%{0}%' ", DK); break;

            }

            DataTable dt = new DataTable();
            dt = GetTable(sql, true);
            return dt;
        }*/
        public MonHoc_HeSoDTO Lay_HeSoMonHoc()
        {
            string sql = "SELECT MaMonHoc, HeSo FROM MONHOC WHERE TrangThai = 1";
            OpenConnect();
            var dr = ExecuteReader(sql);
            MonHoc_HeSoDTO dsHeSo = new MonHoc_HeSoDTO();
            while (dr.Read())
            {
                double heso = Convert.ToDouble(dr["HeSo"]); 
                switch (dr["MaMonHoc"].ToString())
                {
                    case "toan": dsHeSo.toan = heso; break;
                    case "ly": dsHeSo.ly = heso; break;
                    case "hoa": dsHeSo.hoa = heso; break;
                    case "sinh": dsHeSo.sinh = heso; break;
                    case "nvan": dsHeSo.nvan = heso; break;
                    case "su": dsHeSo.su = heso; break;
                    case "dia": dsHeSo.dia = heso; break;
                    case "nngu": dsHeSo.nngu = heso; break;
                    case "tin": dsHeSo.tin = heso; break;
                    case "tduc": dsHeSo.tduc = heso; break;
                    case "gdcd": dsHeSo.gdcd = heso; break;
                    case "qphong": dsHeSo.qphong = heso; break;
                    case "cnghe": dsHeSo.cnghe = heso; break;
                }
            }
            CloseConnect();
            return dsHeSo;
        }
        /// <summary>
        /// Lấy danh sách môn học
        /// </summary>
        /// <param name="chiLayCacMonDangHoc">True: Chỉ lấy các môn đang học, False: Lấy tất cả 13 môn</param>
        /// <returns>List MonHocDTO</returns>
        public List<MonHocDTO> LayList_MonHoc(bool chiLayCacMonDangHoc = true)
        {
            string sql = "";
            if(chiLayCacMonDangHoc)
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo FROM MONHOC WHERE TrangThai = 1 ORDER BY TenMonHoc ASC");
            else
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo FROM MONHOC ORDER BY TenMonHoc");

            OpenConnect();
            List<MonHocDTO> listMonHocDTO = new List<MonHocDTO>();
            MonHocDTO monhocDTO;
            var dr = ExecuteReader(sql);
            while (dr.Read())
            {
                monhocDTO = new MonHocDTO();
                monhocDTO.MaMonHoc = Convert.ToString(dr["MaMonHoc"]);
                monhocDTO.TenMonHoc = Convert.ToString(dr["TenMonHoc"]);
                monhocDTO.SoTiet = Convert.ToInt16(dr["SoTiet"]);
                monhocDTO.HeSo = Convert.ToInt16(dr["HeSo"]);
                listMonHocDTO.Add(monhocDTO);
            }
            CloseConnect();
            return listMonHocDTO;
        }
        public bool KiemtratontaiMonhoc(MonHocDTO MH)
        {
            string sql = string.Format("SELECT count(*) as SoLuong FROM GiaoVien WHERE MaGiaoVien = '{0}'", MH.MaMonHoc);
            return (int)ExecuteScalar(sql) == 1;
        }
    }
}
