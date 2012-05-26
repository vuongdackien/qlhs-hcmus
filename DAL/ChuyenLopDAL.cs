using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class ChuyenLopDAL : ConnectData
    {
        
        public bool ChuyenBangDiem(string MaHocSinh,string MaLop_old,string MaLop_new)
        {
            string sql = "update BANGDIEM SET MaLop='"+MaLop_new+"' where MaHocSinh='"+MaHocSinh+"'"
                +"and MaLop='"+MaLop_old+"'";
            return ExecuteQuery(sql) > 0;
        }
        public bool LuuChuyenLop(ChuyenLopDTO cl)
        {
             string sql = "set dateformat dmy\n";
                  sql += string.Format("INSERT INTO CHUYENLOP (TuLop, DenLop , NgayChuyen, LyDoChuyen, ChuyenBangDiem, MaHocSinh) "
                         + "VALUES ('{0}','{1}','{2}',N'{3}','{4}','{5}')", cl.TuLop, cl.DenLop, cl.NgayChuyen, cl.LyDoChuyen,cl.ChuyenBangDiem,cl.MaHocSinh);
            return ExecuteQuery(sql)>0;
            
        
        }
    }
}
