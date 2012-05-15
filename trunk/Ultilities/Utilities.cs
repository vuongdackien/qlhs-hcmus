using System;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using QLHS.DTO;

namespace Utilities
{
    public class XepLoaiHS
    {
        public static string Gioi = "HS Giỏi";
        public static string Kha = "HS Khá";
        public static string TB = "HS TB";
        public static string Yeu = "HS Yếu";
        public static string Kem = "HS Kém";
    }
    public static partial class StringUtilities
    {
        public static NguoiDungDTO user = null;

        #region Hàm lấy mã kế tiếp
        public static string NextID(string lastID, string prefixID)
        {
            lastID = lastID.Trim();
            int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
            int lengthNumerID = lastID.Length - prefixID.Length;
            string zeroNumber = "";
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + nextID.ToString();
                }
            }
            return prefixID + nextID;

        }
        #endregion


        #region Các hàm lấy mã năm học, mã khối từ mã lớp, kiểm tra mã khối, mã lớp

        /// <summary>
        ///  Hàm lấy mã năm học từ mã lớp
        /// </summary>
        /// <param name="malop">Mã lớp</param>
        /// <returns>Mã năm học</returns>
        public static string LayMaNamHocTuMaLop(string malop)
        {
            // 10A01NH1011 => NH1011
            return malop.Substring(5, 6);
        }

        /// <summary>
        /// Hàm lấy mã khối lớp từ mã lớp
        /// </summary>
        /// <param name="malop">String: Mã lớp</param>
        /// <returns>String: Mã khối</returns>
        public static string LayMaKhoiLopTuMaLop(string malop)
        {
            // 10A01NH1011 => 10
            return malop.Substring(0, 2);
        }

        /// <summary>
        /// Hàm kiểm tra mã lớp có đúng định dạng hay không?
        /// </summary>
        /// <param name="maLop">String: Mã lớp</param>
        /// <returns>Bool</returns>
        public static bool KiemTraMaLop(string maLop)
        {
            // 10A01NH1011
            if (maLop.Equals(""))
                return false;

            Regex myRegex = new Regex(@"\d{2}\w{1}d{1,2}NH\d{4}");
            Match m = myRegex.Match(maLop);
            return m.Success;
        }

        /// <summary>
        /// Hàm kiểm tra có phải là mã khối
        /// </summary>
        /// <param name="maKhoi">String: Mã khối</param>
        /// <returns>Bool</returns>
        public static bool KiemTraMaKhoi(string maKhoi)
        {
            return (maKhoi.Equals("10") || maKhoi.Equals("11") || maKhoi.Equals("12"));
        }
        /// <summary>
        /// Hàm lấy mã năm học tiếp theo từ mã năm học cũ
        /// </summary>
        /// <param name="MaNamHocHienTai">String: Mã năm học cũ</param>
        /// <returns>String: Mã năm học tiếp theo</returns>
        public static string MaNamHocKeTiep(string MaNamHocHienTai)
        {
            // NH1011
            int lastYear = int.Parse(MaNamHocHienTai.Substring(2, 2)) + 1;
            int nextYear = int.Parse(MaNamHocHienTai.Substring(4, 2)) + 1;
            string lastY = lastYear.ToString();
            string nextY = nextYear.ToString();
            if (lastYear < 10)
                lastY = "0" + lastY;
            if (nextYear < 10)
                nextY = "0" + nextY;
            return "NH" + lastY + nextY;
        }
        #endregion

        /// <summary>
        /// Hàm chuyển đổi chuỗi có dấu thành không dấu
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ConvertToUnSign(string text, char ReplaceSpecialChar)
        {
            for (int i = 32; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), ReplaceSpecialChar.ToString());
            }
            text = text.Replace(".", ReplaceSpecialChar.ToString());
            text = text.Replace(" ", ReplaceSpecialChar.ToString());
            text = text.Replace(",", ReplaceSpecialChar.ToString());
            text = text.Replace(";", ReplaceSpecialChar.ToString());
            text = text.Replace(":", ReplaceSpecialChar.ToString());
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        /// <summary>
        /// Tách họ tên
        /// </summary>
        /// <param name="hoten">String: Họ tên</param>
        /// <returns>string[]: firstname, midname, lastname</returns>
        public static string[] LayHoTen(string hoten)
        {
            string firstname = "";
            string midname = "";
            string lastname = "";
            hoten = hoten.Trim();
            string[] arrHoTen = hoten.Split(' ');
            int i = 0;
            foreach (string s in arrHoTen)
            {
                if (i == 0)
                    firstname = s;
                lastname = s;
                i++;
            }
            if (i == 1)
                firstname = "";
            int j = 0;
            foreach (string s in arrHoTen)
            {
                if (j != 0)
                    if (j != (i - 1))
                        midname += s + " ";
                j++;
            }
            midname = midname.TrimEnd();
            return new string[] { firstname, midname, lastname };
        }
  
        /// <summary>
        /// Mã hóa 1 chuỗi text bằng MD5
        /// </summary>
        /// <param name="text">String: Chuỗi cần mã hóa</param>
        /// <returns>String: Chuỗi đã mã hóa</returns>
        public static string MaHoaMD5(string text)
        {
            MD5CryptoServiceProvider _md5Hasher = new MD5CryptoServiceProvider();
            byte[] bs = Encoding.UTF8.GetBytes(text);
            bs = _md5Hasher.ComputeHash(bs);
            StringBuilder s = new StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2"));
            }
            return s.ToString();
        }
     
    }
}
