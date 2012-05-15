using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QLHS.DTO;

namespace QLHS.DAL
{
    public class QuyDinhDAL : ConnectData
    {
        /// <summary>
        /// Lấy giá trị quy định
        /// </summary>
        /// <param name="khoa">string: khóa</param>
        /// <returns>object: giá trị</returns>
        public object LayGiaTri(string khoa)
        {
            string sql = "SELECT giatri FROM QUYDINH WHERE khoa = '"+khoa+"'";
            return ExecuteScalar(sql);
        }
    }
}
