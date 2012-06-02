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

        private int m_NamSinhTu;

        public int NamSinhTu
        {
            get { return m_NamSinhTu; }
            set { m_NamSinhTu = value; }
        }

        private int m_NamSinhDen;

        public int NamSinhDen
        {
            get { return m_NamSinhDen; }
            set { m_NamSinhDen = value; }
        }
    }
}
