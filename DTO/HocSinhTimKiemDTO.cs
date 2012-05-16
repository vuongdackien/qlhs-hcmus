using System;
using System.Collections.Generic;
using System.Text;

namespace QLHS.DTO
{
    public class HocSinhTimKiemDTO:HocSinhDTO
    {
        private bool m_TimChinhXac;

        public bool TimChinhXac
        {
            get { return m_TimChinhXac; }
            set { m_TimChinhXac = value; }
        }

        private string m_NamSinhTu;

        public string NamSinhTu
        {
            get { return m_NamSinhTu; }
            set { m_NamSinhTu = value; }
        }

        private string m_NamSinhDen;

        public string NamSinhDen
        {
            get { return m_NamSinhDen; }
            set { m_NamSinhDen = value; }
        }
    }
}
