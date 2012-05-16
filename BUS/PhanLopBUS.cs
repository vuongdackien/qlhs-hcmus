using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;
using QLHS.DAL;

namespace QLHS.BUS
{
    public class PhanLopBUS
    {
        PhanLopDAL _PhanLopDAL;
        public PhanLopBUS()
        {
            _PhanLopDAL = new PhanLopDAL();
        }
        /// <summary>
        /// Kiểm tra tồn tại  STT của 1 học sinh trong lớp
        /// </summary>
        /// <param name="STT">Int: Số thứ tự</param>
        /// <param name="MaLop">String: Mã lớp</param>
        /// <returns>Bool:</returns>
        public bool KiemTra_STT_TonTai(int STT, string MaLop)
        {
            return _PhanLopDAL.KiemTra_STT_TonTai(STT, MaLop);
        }
    }
}
