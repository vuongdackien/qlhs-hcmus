using System.Data;
using System.Data.OleDb;

namespace DAL
{
    class ConnectData
    {
        protected OleDbConnection m_Connect = null;
        public OleDbDataAdapter m_DataApdater = null;
        public DataTable m_Table = null;
        protected OleDbCommand m_Command = null;
        private string _strConnect = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Databases\QLHS.mdb;Persist Security Info=True";


        public ConnectData()
        {
             Connect();
        }

        public ConnectData(bool testConnect)
        {
            if (testConnect)
                TestConnect();
        }
        #region Thao tác đóng, mở kết nối
        /// <summary>
        /// Hàm kết nối CSDL
        /// </summary>
        /// <returns>return 1: nếu kết nối thành công || return > 1: mã lỗi </returns>
        public int Connect()
        {
            try
            {
                m_Connect = new OleDbConnection(_strConnect);
                this.Open();
            }
            catch(OleDbException ex)
            {
                this.Close();
                return ex.ErrorCode;
            }
            this.Close();
            return 1;
        }
        /// <summary>
        /// Kiểm tra kết nối với Database
        /// </summary>
        /// <param name="strConnect">String: Chuỗi kết nối</param>
        /// <returns></returns>
        public bool TestConnect(string strConnect = "")
        {
            if (strConnect != "")
                this._strConnect = strConnect;
            if(this.Connect() == 1)
                return true;
            return false;
        }


        /// <summary>
        /// Mở kết nối
        /// </summary>
        public void Open()
        {
            try
            {
                if (m_Connect != null)
                    if (m_Connect.State == ConnectionState.Closed)
                        m_Connect.Open();
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// Đóng kết nối
        /// </summary>
        public void Close()
        {
            if (m_Connect != null)
                if (m_Connect.State == ConnectionState.Open)
                    m_Connect.Close();
        }
        #endregion

        #region Hàm thao tác tạo ra database, datarow với các câu lệnh select command
        /// <summary>
        /// Hàm lấy DataTable từ 1 chuỗi truy vấn
        /// </summary>
        /// <param name="sql">String: Chuỗi truy vấn</param>
        /// <param name="setPropertiesDataTable">Bool (default FALSE): Sử dụng properties DataTable hay không? 
        /// Nếu có dùng gridview chỉnh sửa nhiều dòng thì bắt buộc phải setPropertiesDataTable = TRUE </param>
        /// <returns>Datatable: Kết quả truy vấn</returns>
        protected DataTable GetTable(string sql, bool setPropertiesDataTable = false)
        {
            try
            {
                if (setPropertiesDataTable)
                {
                    // Tạo dataApdapter vai trò như 1 ống hút thực hiện query đổ vào Datatable
                    m_DataApdater = new OleDbDataAdapter(sql, m_Connect);
                    m_Table = new DataTable();
                    // Đổ vào database
                    m_DataApdater.Fill(m_Table);
                    return m_Table;
                }
                else
                {
                    OleDbDataAdapter ap = new OleDbDataAdapter(sql, m_Connect);
                    DataTable tb = new DataTable();
                    ap.Fill(tb);
                    return tb;
                }
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// Truy vấn lấy dòng đầu tiên
        /// </summary>
        /// <param name="sql">String: Chuỗi truy vấn</param>
        /// <returns>DataRow: Dòng đầu tiên của kết quả</returns>
        protected DataRow GetFirstDataRow(string sql)
        {
            return GetTable(sql).Rows[0];
        }

        /// <summary>
        /// Lấy 1 dòng mới ứng với DataTable (Bắt buột trên Datatable truy vấn lần trước phải set properties = TRUE)
        /// </summary>
        /// <returns>Datarow: Dòng mới với kiểu dữ liệu từ DataTable hiện tại</returns>
        protected DataRow GetNewRow()
        {
            return m_Table.NewRow();
        }

        /// <summary>
        /// Lưu 1 dòng mới vào DataTable (Bắt buột trên Datatable truy vấn lần trước phải set properties = TRUE)
        /// </summary>
        /// <param name="dr">Datarow: Dòng mới với kiểu dữ liệu từ DataTable hiện tại được tạo từ hàm GetNewRow()</param>
        protected void AddNewRow(DataRow dr)
        {
            m_Table.Rows.Add(dr);
        }
        #endregion

        #region Hàm cập nhật tất cả thay đổi trong dataTable của dataGridview
        /// <summary>
        /// Hàm cập nhật tất cả thay đổi trong dataTable được set properties = TRUE (Sử dụng trên DataTable của GridView)
        /// </summary>
        /// <returns>Int: Số dòng được thay đổi</returns>
        public int UpdateAllDataTable()
        {
            int numRecords = 0;
            // Transaction dùng để rollback data khi gặp lỗi trong quá trình Save
            OleDbTransaction sqlTran = null;
            try
            {
                // Mở kết nối
                this.Open();
                // Mở Transaction
                sqlTran = m_Connect.BeginTransaction();
                m_DataApdater.SelectCommand.Transaction = sqlTran;
                OleDbCommandBuilder cbo = new OleDbCommandBuilder(m_DataApdater);
                numRecords = m_DataApdater.Update(m_Table);
                // Thực thi
                sqlTran.Commit();
            }
            catch
            {
                // Roolback data
                if (sqlTran != null)
                    sqlTran.Rollback();
                // Đóng kết nối
                this.Close();
            }
            this.Close();
            // Trả về số record thực thi
            return numRecords;
        }
        #endregion


        #region Hàm thực thi các câu lệnh sql
        /// <summary>
        /// Hàm thực hiện câu query truyền vào
        /// </summary>
        /// <param name="sql">String: Chuỗi truy vấn</param>
        /// <returns>Int: Số dòng được thực thi</returns>
        protected int ExecuteQuery(string sql)
        {
            int numRecords = 0;
            OleDbTransaction sqlTran = null;
            try
            {
                // Mở kết nối
                this.Open();
                // Mở Transaction
                sqlTran = m_Connect.BeginTransaction();
                OleDbCommand sqlComm = new OleDbCommand(sql, m_Connect);
                sqlComm.Transaction = sqlTran;
                numRecords = sqlComm.ExecuteNonQuery();
                // Thực thi
                sqlTran.Commit();
            }
            catch
            {
                // Roolback data
                if (sqlTran != null)
                    sqlTran.Rollback();
                // Đóng kn
                this.Close();
            }
            this.Close();
            // Trả về số record thực thi
            return numRecords;
        }

        /// <summary>
        /// Thực hiện OleDbCommand truyền vào
        /// </summary>
        /// <param name="m_Command">OleDbCommand: Giá trị OleDbCommand</param>
        /// <returns>Bool: Thực hiện thành công true/false</returns>
        protected bool ExecuteOleDbCommand(OleDbCommand m_Command)
        {
            try
            {
                this.Open();
                m_Command.Connection = m_Connect;
                if (m_Command.ExecuteNonQuery() > 0)
                {
                    this.Close();
                    return true;
                }
                this.Close();
                return false;

            }
            catch
            {
                this.Close();
                return false;
            }

        }

        /// <summary>
        /// Lấy giá trị của dòng đầu tiên, cột đầu tiên
        /// </summary>
        /// <param name="sql">String: Chuỗi truy vấn</param>
        /// <returns>Object: có thể ép kiểu lại.</returns>
        protected object ExecuteScalar(string sql)
        {
            try
            {
                this.Open();
                m_Command = new OleDbCommand(sql, m_Connect);
                object result = m_Command.ExecuteScalar();
                this.Close();
                return result;
            }
            catch
            {
                this.Close();
            }
            return null;

        }

        /// <summary>
        /// Lấy mã cuối cùng của 1 mã số trong 1 bảng (Dùng để tính toán lấy mã số tiếp theo)
        /// </summary>
        /// <param name="nameTable">String: Tên datatabale</param>
        /// <param name="nameSelectColumn">String: Tên cột mã số</param>
        /// <returns>String: Mã cuối cùng</returns>
        protected string GetLastID(string nameTable, string nameSelectColumn)
        {
            string sql = "SELECT TOP 1 * FROM " + nameTable + " ORDER BY " + nameSelectColumn + " DESC";
            return (string)ExecuteScalar(sql);
        }

        #endregion


    }
}
