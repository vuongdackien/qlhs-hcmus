using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class MonHocDAL : ConnectData
    {
        MonHocDTO _monHocDTO;
        /// <summary>
        /// Thêm môn học
        /// </summary>
        /// <param name="monHoc">MonHocDTO</param>
        /// <returns></returns>
        public bool Them_MonHoc(MonHocDTO _monHocDTO)
        {
            string sql = string.Format("INSERT INTO MONHOC VALUES ('{0}',N'{1}',{2},{3},{4})",
                                        _monHocDTO.MaMonHoc, _monHocDTO.TenMonHoc, _monHocDTO.SoTiet,
                                        _monHocDTO.HeSo, _monHocDTO.TrangThai);
            return ExecuteQuery(sql) > 0;
        }
        /// <summary>
        /// Xóa môn học
        /// </summary>
        /// <param name="maMonHoc">string: Mã môn học</param>
        /// <returns></returns>
        public bool Xoa_MonHoc(string maMonHoc)
        {
            string bd = "SELECT count(*) as SoLuong FROM BANGDIEM WHERE MaMonHoc='"+maMonHoc+"'";
            int count = Convert.ToInt32(ExecuteScalar(bd));
            if(count>0)
            {
                return false;
            }
            string sql = "DELETE FROM MONHOC WHERE MaMonHoc ='" + maMonHoc + "'\n";
            return ExecuteQuery(sql) > 0;
        }
        /// <summary>
        /// Cập nhật môn học
        /// </summary>
        /// <param name="monHoc">MonHocDTO</param>
        /// <returns></returns>
        public bool CapNhat_MonHoc(MonHocDTO _monHocDTO)
        {
            string sql = string.Format("UPDATE MONHOC SET TenMonHoc = N'{0}', SoTiet={1}, HeSo={2}, TrangThai={3} "
                                     + "WHERE MaMonHoc='{4}' ", _monHocDTO.TenMonHoc,_monHocDTO.SoTiet,
                                     _monHocDTO.HeSo, _monHocDTO.TrangThai, _monHocDTO.MaMonHoc);
            return ExecuteQuery(sql) > 0;
        }

        /// <summary>
        /// Kiểm tra tồn tại môn học
        /// </summary>
        /// <param name="maMonHoc">string: Mã môn học</param>
        /// <returns></returns>
        public bool KiemTraTonTai_MonHoc(string maMonHoc)
        {
            string sql = string.Format("SELECT count(*) as SoLuong FROM MonHoc WHERE MaMonHoc = '{0}'", maMonHoc);
            return Convert.ToInt32(ExecuteScalar(sql)) == 1;
        }

        /// <summary>
        /// Kiểm tra tên môn học đã có hay chưa
        /// </summary>
        /// <param name="tenMonHoc"></param>
        /// <returns></returns>
        public bool KiemTraTonTai_TenMonHoc(MonHocDTO _monHocDTO)
        {
            string sql = string.Format("SELECT count(*) FROM MONHOC WHERE ");
            string tenmh = "";
            tenmh += " (TenMonHoc LIKE N'%" + _monHocDTO.TenMonHoc + "%' ";
            tenmh += " OR dbo.fnChuyenKhongDau(TenMonHoc) LIKE N'%" + _monHocDTO.TenMonHoc + "%')";
            sql += tenmh;
            return Convert.ToInt32(ExecuteScalar(sql)) == 1;
        }

        /// <summary>
        /// Kiểm tra tên môn học đã có hay chưa
        /// </summary>
        /// <param name="tenMonHoc"></param>
        /// <returns></returns>
        public bool KiemTra_ThongTin_MonHoc(MonHocDTO _monHocDTO)
        {
            string sql = string.Format("SELECT count(*) FROM MONHOC WHERE SoTiet={0} AND HeSo={1} AND TrangThai={2}", 
                                            _monHocDTO.SoTiet, _monHocDTO.HeSo, _monHocDTO.TrangThai);           
            return Convert.ToInt32(ExecuteScalar(sql)) == 1;
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
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo, TrangThai FROM MONHOC ORDER BY TenMonHoc");

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
                case 3: sql = string.Format("select * from MonHoc where SoTiet = '{0}' ", DK); break;
                case 4: sql = string.Format("select * from MonHoc where HeSo ='{0}' ", DK); break;
                case 5: sql = string.Format("select * from MonHoc where TrangThai = '{0}' ", DK); break;
            }

            DataTable dt = new DataTable();
            dt = GetTable(sql, true);
            return dt;
        }
             
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
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo,TrangThai FROM MONHOC WHERE TrangThai = 1 ORDER BY TenMonHoc ASC");
            else
                sql = string.Format("SELECT MaMonHoc, TenMonHoc, SoTiet, HeSo, TrangThai FROM MONHOC ORDER BY TenMonHoc");

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
                monhocDTO.TrangThai=Convert.ToInt16(dr["TrangThai"]);
                listMonHocDTO.Add(monhocDTO);
            }
            CloseConnect();
            return listMonHocDTO;
        }
    }
}
