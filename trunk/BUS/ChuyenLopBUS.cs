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
        private ChuyenLopDAL _ChuyenLopDAL;
        private BangDiemBUS _BangDiemBUS;
        private PhanLopBUS _PhanLopBUS;
        public ChuyenLopBUS()
        {
            _ChuyenLopDAL = new ChuyenLopDAL();
            _PhanLopBUS = new PhanLopBUS();
            _BangDiemBUS = new BangDiemBUS();
        }

        public bool ChuyenLop_HocSinh_Lop( Dictionary<string,string> ds_HocSinhChon, ChuyenLopDTO thongTinCL)
        {
            IList<bool> list_success = new List<bool>();
            foreach (var item in ds_HocSinhChon)
            {
                if (thongTinCL.GiuLaiBangDiem)
                    _BangDiemBUS.CapNhat_BangDiem_HocSinh_LopMoi(item.Key, thongTinCL.TuLop, thongTinCL.DenLop);
                else
                    _BangDiemBUS.XoaBangDiem_HocSinh_Lop(item.Key, thongTinCL.TuLop);

                if (!_PhanLopBUS.KiemTraHSTonTaiTrongLop_ChuyenLop(item.Key, thongTinCL.DenLop))
                {
                    _PhanLopBUS.ThayDoi_LopMoi_HocSinh(item.Key, thongTinCL.TuLop, thongTinCL.DenLop);
                }
                list_success.Add(_ChuyenLopDAL.Luu_ThongTin_ChuyenLop(item.Key, thongTinCL));
            }
            foreach (var item in list_success)
            {
                if (!item)
                    return false;
            }
            return true;
        }
        public bool KTHocSinhThuocLop_DuocChuyenTuLop(string MaHocSinh, string MaLopMoi, string MaLopCu)
        {
            return _ChuyenLopDAL.KTHocSinhThuocLop_DuocChuyenTuLop(MaHocSinh, MaLopMoi, MaLopCu);
        }
        public bool XoaChuyenLop(string MaHocSinh, string TuLop, string DenLop)
        {
            return _ChuyenLopDAL.XoaChuyenLop(MaHocSinh, TuLop, DenLop);
        }
    }
}
