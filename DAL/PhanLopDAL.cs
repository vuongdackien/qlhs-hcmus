using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class PhanLopDAL : ConnectData
    {
        public bool KiemTra_STT_TonTai(int STT, string MaLop)
        {
            string sql = "SELECT STT FROM PHANLOP WHERE MaLop = '"+MaLop+"' AND STT = "+STT;
            return GetTable(sql).Rows.Count > 0;
        }
    }
}
