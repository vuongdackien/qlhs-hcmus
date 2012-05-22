using System;
using System.Collections.Generic;
using System.Text;

namespace QLHS.DTO
{
    public class LoaiNguoiDungDTO
    {
        private string m_MaLoai;

        public string MaLoai
        {
            get { return m_MaLoai; }
            set { m_MaLoai = value; }
        }

        private string m_TenLoaiND;

        public string TenLoaiND
        {
            get { return m_TenLoaiND; }
            set { m_TenLoaiND = value; }
        }
    }
}
