using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class ChuyenLopBUS
    {
        private ChuyenLopDAL _chuyenLopDAL;
        private BangDiemBUS _bangDiemBUS;
        private PhanLopBUS _phanLopBUS;
        public ChuyenLopBUS()
        {
            _chuyenLopDAL = new ChuyenLopDAL();
            _phanLopBUS = new PhanLopBUS();
            _bangDiemBUS = new BangDiemBUS();
        }

        public bool ChuyenLop_HocSinh_Lop( Dictionary<string,string> ds_HocSinhChon, ChuyenLopDTO thongTinCL)
        {
            IList<bool> list_success = new List<bool>();
            foreach (var item in ds_HocSinhChon)
            {
                if (thongTinCL.GiuLaiBangDiem)
                    _bangDiemBUS.CapNhat_BangDiem_HocSinh_LopMoi(item.Key, thongTinCL.TuLop, thongTinCL.DenLop);
                else
                    _bangDiemBUS.XoaBangDiem_HocSinh_Lop(item.Key, thongTinCL.TuLop);

                if (!_phanLopBUS.KiemTraTonTai_HocSinh_TrongLop(item.Key, thongTinCL.DenLop))
                {
                    _phanLopBUS.ThayDoi_LopMoi_HocSinh(item.Key, thongTinCL.TuLop, thongTinCL.DenLop);
                }
                list_success.Add(_chuyenLopDAL.Luu_ThongTin_ChuyenLop(item.Key, thongTinCL));
            }
            foreach (var item in list_success)
            {
                if (!item)
                    return false;
            }
            return true;
        }
        public bool KiemTraHocSinh_ThuocLop_DuocChuyenTuLop(string MaHocSinh, string MaLopMoi, string MaLopCu)
        {
            return _chuyenLopDAL.KiemTra_HocSinhThuocLop_DuocChuyenTuLop(MaHocSinh, MaLopMoi, MaLopCu);
        }
        public bool Xoa_ChuyenLop(string MaHocSinh, string TuLop, string DenLop)
        {
            return _chuyenLopDAL.Xoa_ChuyenLop(MaHocSinh, TuLop, DenLop);
        }
    }
}
