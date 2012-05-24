using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class HocSinhBUS
    {
        private HocSinhDAL _hocSinhDAL;
        private QuyDinhBUS _quyDinhBUS;
        private PhanLopBUS _phanLopBUS;
        public HocSinhBUS()
        {
            _hocSinhDAL = new HocSinhDAL();
            _quyDinhBUS = new QuyDinhBUS();
            _phanLopBUS = new PhanLopBUS();
        }
        /// <summary>
        /// Lấy DataTable học sinh từ Lớp học
        /// </summary>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <param name="chua_PhanLop">bool: Lấy danh sách chưa được phân lớp</param>
        /// <returns>DataTable</returns>
        public DataTable LayDTHocSinh_LopHoc(string MaLop, bool chua_PhanLop = false)
        {
            return _hocSinhDAL.LayDT_HocSinh_LopHoc(MaLop,chua_PhanLop);
        }
         /// <summary>
        /// Lấy hồ sơ học sinh từ Mã học sinh
        /// </summary>
        /// <param name="MaHocSinh">string: Mã học sinh</param>
        /// <returns>HocSinhDTO</returns>
        public HocSinhDTO LayHoSoHocSinh(string MaHocSinh)
        {
            return _hocSinhDAL.Lay_HoSo(MaHocSinh);
        }
        /// <summary>
        /// Kiểm tra tồn tại của 1 hồ sơ học sinh qua Mã học sinh
        /// </summary>
        /// <param name="MaHocSinh">String: Mã học sinh</param>
        /// <returns>Bpol: Tồn tại/Không</returns>
        public bool KiemTraTonTai_MaHocSinh(HocSinhDTO hocsinh)
        {
            return _hocSinhDAL.KiemTraTonTai_MaHocSinh(hocsinh.MaHocSinh);
        }
        /// <summary>
        /// Lưu hồ sơ học sinh 
        /// </summary>
        /// <param name="hocsinh">HocSinhDTO</param>
        /// <param name="MaLop">String: Mã lớp (nếu rỗng thì không phan lớp)</param>
        /// <returns>Bool</returns>
        public bool LuuHoSoHocSinh(HocSinhDTO hocsinh, string MaLop = null)
        {
            DateTime ngayAD_QD = _quyDinhBUS.LayNgayApDungQD() ;
            int namCanDuoi = _quyDinhBUS.LayNamCanDuoi(), namCanTren = _quyDinhBUS.LayNamCanTren();
            DateTime ngayNhapHoc;
            // Sửa hồ sơ học sinh
            if (_hocSinhDAL.KiemTraTonTai_MaHocSinh(hocsinh.MaHocSinh))
            {
                // Nếu hồ sơ có phân lớp và có sửa STT
                if (MaLop != null && hocsinh.STT != _phanLopBUS.Lay_STT_HienTai(hocsinh.MaHocSinh,MaLop)
                    && _phanLopBUS.KiemTra_STT_TonTai(hocsinh.STT, MaLop)) // STT mới này đã tồn tại
                {
                    Utilities.ExceptionUtilities.Throw("Sửa hồ sơ học sinh không hợp lệ!"
                                                        +"\nSố thứ tự " + hocsinh.STT + " đã tồn tại trong lớp "+MaLop+"."
                                            + "\nBạn có thể sử dụng chức năng \"Tự động sắp xếp số thứ tự\" theo alpha.");
                    return false;
                }
                ngayNhapHoc = _hocSinhDAL.Lay_HoSo(hocsinh.MaHocSinh).NgayNhapHoc;  
                // Nếu ngày nhập học sau ngày áp dụng quy định
                if (ngayNhapHoc >= ngayAD_QD)
                {
                    // Kiểm tra độ tuổi theo quy định
                    if (hocsinh.NgaySinh.Year < namCanDuoi || hocsinh.NgaySinh.Year > namCanTren)
                    {
                        Utilities.ExceptionUtilities.Throw("Sửa hồ sơ học sinh không hợp lệ!"
                                + "\nNăm sinh của học sinh phải theo quy định trong khoảng từ năm " + namCanDuoi + " đến năm " + namCanTren);
                        return false;
                    }
                }
                return _hocSinhDAL.Sua_HoSo(hocsinh, MaLop);
            }
            else // Thêm mới hồ sơ học sinh
            {
                ngayNhapHoc = DateTime.Now;
                // Nếu hồ sơ có phân lớp và kiểm tra STT đã tồn tại hay chưa?
                if (MaLop != null && _phanLopBUS.KiemTra_STT_TonTai(hocsinh.STT, MaLop))
                {
                    Utilities.ExceptionUtilities.Throw("Tiếp nhận học sinh không hợp lệ!"
                                                            +"\nSố thứ tự " + hocsinh.STT + " đã tồn tại trong lớp."
                                                                + "\nChương trình sẽ tự động tạo số thứ tự tiếp theo trong bảng điểm"
                                                                + "\nBạn có thể sử dụng chức năng \"Tự động sắp xếp số thứ tự\" theo alpha.");
                    return false;
                }
                hocsinh.MaHocSinh = Utilities.ObjectUtilities.NextID(_hocSinhDAL.Lay_MaCuoiCung(), "HS", 8);
                // Nếu ngày nhập học sau ngày áp dụng quy định
                if (ngayNhapHoc >= ngayAD_QD)
                {
                    // Kiểm tra độ tuổi theo quy định
                    if (hocsinh.NgaySinh.Year < namCanDuoi || hocsinh.NgaySinh.Year > namCanTren)
                    {
                        Utilities.ExceptionUtilities.Throw("Tiếp nhận học sinh không hợp lệ!"
                                + "\nNăm sinh của học sinh phải theo quy định trong khoảng từ năm " + namCanDuoi + " đến năm " + namCanTren);
                        return false;
                    }
                }
                return _hocSinhDAL.Them_HoSo(hocsinh, MaLop);
            }
           
        }
        /// <summary>
        /// Kiểm tra năm sinh có đúng theo quy định (Tuổi cận dưới, cận trên)
        /// </summary>
        /// <param name="namSinh">int: Năm</param>
        /// <returns>Bool</returns>
        public bool KiemTraNamSinhHopLe(int namSinh)
        {
            int tuoiCanDuoi = _quyDinhBUS.LayTuoiCanDuoi(),
                tuoiCanTren = _quyDinhBUS.LayTuoiCanTren();
            if(tuoiCanDuoi <= namSinh && namSinh <= tuoiCanTren)
                return true;
            return false;
        }

        /// <summary>
        /// Tìm kiếm học sinh 
        /// </summary>
        /// <param name="hs">Object: HocSinhTimKiem - Thông tin học sinh tìm kiếm</param>
        /// <param name="DS_MaLop">Default: NULL (Tìm tất cả các năm) || Tìm trong các lớp</param>
        /// <returns>DataTable HocSinh</returns>
        public DataTable TimKiem_HocSinh(HocSinhTimKiemDTO hs, List<string> DS_MaLop = null)
        {
            return _hocSinhDAL.Tim_HoSo(hs,DS_MaLop);
        }
        /// <summary>
        /// Xóa 1 hồ sơ học sinh
        /// </summary>
        /// <param name="MaHocSinh">String: Mã học sinh</param>
        /// <returns>Bool</returns>
        public bool Xoa_HoSo_HocSinh(string MaHocSinh)
        {
            return _hocSinhDAL.Xoa_HoSo(MaHocSinh);
        }

        public DataTable LayDTTenHocSinh()
        {
            return _hocSinhDAL.LayDT_TenHocSinh();
        }
        /// <summary>
        /// lấy DataTable học sinh chưa có lớp
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable LayDT_HS_HocSinh()
        {
            return _hocSinhDAL.LayDT_HS_HocSinh();
        }
    }
}
