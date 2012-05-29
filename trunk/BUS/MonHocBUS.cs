using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class MonHocBUS
    {
        private MonHocDAL _monHocDAL;
        public MonHocBUS()
        {
            _monHocDAL = new MonHocDAL();
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
        
        
        /// <summary>
        /// Lấy Datatable danh sách môn học
        /// </summary>
        /// <returns>Datatable</returns>
        public DataTable LayDT_DanhSach_MonHoc()
        {
            return _monHocDAL.LayDT_DanhSach_MonHoc();
        }
        public DataTable LayDT_DanhSach_MonHoc(bool trangthai)
        {
            return _monHocDAL.LayDT_DanhSach_MonHoc(trangthai);
        }
        /// <summary>
        /// 1:Tìm theo mã
        /// 2:Tìm theo tên
        /// 3:Tìm theo số tiết
        /// 4:Tìm theo hệ số
        /// 5:Tìm theo trang thái
        /// </summary>
        /// <param name="k"></param>
        /// <param name="Dk"></param>
        /// <returns></returns>
        public DataTable Table_MonHoc(int k,string Dk)
        {
            return _monHocDAL.TableGiaoVien(k,Dk);
        }

        /// <summary>
        /// Xóa môn học
        /// </summary>
        /// <param name="maMonHoc">string: Mã môn học</param>
        /// <returns></returns>
        public bool Xoa_MonHoc(string maMonHoc)
        {
            return _monHocDAL.Xoa_MonHoc(maMonHoc);
        }
        /// <summary>
        /// Thêm môn học
        /// </summary>
        /// <param name="monHoc">MonHocDTO</param>
        /// <returns></returns>
        public bool Them_MonHoc(MonHocDTO monHoc)
        {            
            return _monHocDAL.Them_MonHoc(monHoc);
        }
        /// <summary>
        /// Cập nhật môn học
        /// </summary>
        /// <param name="monHoc">MonHocDTO</param>
        /// <returns></returns>
        public bool CapNhat_MonHoc(MonHocDTO monHoc)
        {
            return _monHocDAL.CapNhat_MonHoc(monHoc);
        }
        /// <summary>
        /// Kiểm tra tồn tại môn học
        /// </summary>
        /// <param name="maMonHoc">string: Mã môn học</param>
        /// <returns></returns>
        public bool KiemTraTonTai_MonHoc(string maMonHoc)
        {
            return _monHocDAL.KiemTraTonTai_MonHoc(maMonHoc);
        }

        /// <summary>
        /// Kiểm tra tên môn học đã có hay chưa
        /// </summary>
        /// <param name="tenMonHoc"></param>
        /// <returns></returns>
        public bool KiemTraTonTai_TenMonHoc(MonHocDTO _monHocDTO)
        {
            return _monHocDAL.KiemTraTonTai_TenMonHoc(_monHocDTO);
        }

        public bool KiemTra_ThongTin_MonHoc(MonHocDTO _monHocDTO)
        {
            return _monHocDAL.KiemTra_ThongTin_MonHoc(_monHocDTO);
        }        
    }
}
