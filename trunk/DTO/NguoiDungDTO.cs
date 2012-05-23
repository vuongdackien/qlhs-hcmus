using System;
using System.Collections.Generic;
using System.Text;

namespace QLHS.DTO
{
    public class NguoiDungDTO
    {
        private string m_MaND;

        public string MaND
        {
            get { return m_MaND; }
            set { m_MaND = value; }
        }

        public int TrangThai { get; set; }

        private LoaiNguoiDungDTO m_LoaiNguoiDung = new LoaiNguoiDungDTO();

        public LoaiNguoiDungDTO LoaiNguoiDung
        {
            get { return m_LoaiNguoiDung; }
            set { m_LoaiNguoiDung = value; }
        }

        private string m_TenND;

        public string TenND
        {
            get { return m_TenND; }
            set { m_TenND = value; }
        }

        private string m_TenDNhap;

        public string TenDNhap
        {
            get { return m_TenDNhap; }
            set { m_TenDNhap = value; }
        }

        private string m_MatKhau;

        public string MatKhau
        {
            get { return m_MatKhau; }
            set { m_MatKhau = value; }
        }


    }

}
