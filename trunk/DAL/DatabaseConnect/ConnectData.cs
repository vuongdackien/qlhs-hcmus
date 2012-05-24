using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace QLHS.DAL
{
    public class ConnectData
    {
        protected SqlConnection m_Connect = null;
        protected SqlDataAdapter m_DataApdater = null;
        protected DataTable m_Table = null;
        protected SqlCommand m_Command = null;
        private string _strConnect = "";


        public ConnectData()
        {
            _strConnect = DatabaseConnectionManagement.Properties.Settings.Default.ConnectString;
            // Nếu không kết nối được
            if (!DatabaseConnectionManagement.FrmAddConnection.TestConnect())
            {
                if (DatabaseConnectionManagement.FrmAddConnection.Show() == System.Windows.Forms.DialogResult.OK)
                    _strConnect = DatabaseConnectionManagement.Properties.Settings.Default.ConnectString;
                else
                    System.Windows.Forms.Application.Exit();
            }

            Connect();
        }

        protected ConnectData(bool testConnect)
        {
            if (testConnect)
                TestConnect();
        }
        #region Thao tác đóng, mở kết nối
        /// <summary>
        /// Hàm kết nối CSDL
        /// </summary>
        /// <returns>Bool</returns>
        protected bool Connect()
        {
            try
            {
                m_Connect = new SqlConnection(_strConnect);
                this.OpenConnect();
                return true;
            }
            catch (SqlException ex)
            {
                 Utilities.ExceptionUtilities.ThrowMsgBox(ex.ErrorCode + ": " + ex.Message);
                return false;
            }
            finally
            { 
                 this.CloseConnect();
            }
        }
        /// <summary>
        /// Kiểm tra kết nối với Database
        /// </summary>
        /// <param name="strConnect">String: Chuỗi kết nối</param>
        /// <returns></returns>
        protected bool TestConnect(string strConnect = "")
        {
            if (strConnect != "")
                this._strConnect = strConnect;
            return this.Connect();
        }


        /// <summary>
        /// Mở kết nối
        /// </summary>
        protected void OpenConnect()
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
        protected void CloseConnect()
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
                    m_DataApdater = new SqlDataAdapter(sql, m_Connect);
                    m_Table = new DataTable();
                    // Đổ vào database
                    m_DataApdater.Fill(m_Table);
                    return m_Table;
                }
                else
                {
                    SqlDataAdapter ap = new SqlDataAdapter(sql, m_Connect);
                    DataTable tb = new DataTable();
                    ap.Fill(tb);
                    return tb;
                }
            }
            catch (SqlException ex)
            {
                 Utilities.ExceptionUtilities.ThrowMsgBox(ex.ErrorCode + ": " + ex.Message);
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
        protected int UpdateAllDataTable()
        {
            int numRecords = 0;
            // Transaction dùng để rollback data khi gặp lỗi trong quá trình Save
            SqlTransaction sqlTran = null;
            try
            {
                // Mở kết nối
                this.OpenConnect();
                // Mở Transaction
                sqlTran = m_Connect.BeginTransaction();
                m_DataApdater.SelectCommand.Transaction = sqlTran;
                SqlCommandBuilder cbo = new SqlCommandBuilder(m_DataApdater);
                numRecords = m_DataApdater.Update(m_Table);
                // Thực thi
                sqlTran.Commit();
            }
            catch (SqlException ex)
            {
                // Roolback data
                if (sqlTran != null)
                    sqlTran.Rollback();
                 Utilities.ExceptionUtilities.ThrowMsgBox(ex.ErrorCode + ": " + ex.Message);
            }
            finally
            { 
                // Đóng kết nối
                this.CloseConnect();
            }
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
            SqlTransaction sqlTran = null;
            try
            {
                // Mở kết nối
                this.OpenConnect();
                // Mở Transaction
                sqlTran = m_Connect.BeginTransaction();
                SqlCommand sqlComm = new SqlCommand(sql, m_Connect);
                sqlComm.Transaction = sqlTran;
                numRecords = sqlComm.ExecuteNonQuery();
                // Thực thi
                sqlTran.Commit();
            }
            catch (SqlException ex)
            {
                // Roolback data
                if (sqlTran != null)
                    sqlTran.Rollback();
                 Utilities.ExceptionUtilities.ThrowMsgBox(ex.ErrorCode + ": " + ex.Message);
            }
            finally
            { 
                // Đóng kn
                this.CloseConnect();
            }
            // Trả về số record thực thi
            return numRecords;
        }

        /// <summary>
        /// Thực hiện SqlCommand truyền vào
        /// </summary>
        /// <param name="m_Command">SqlCommand: Giá trị SqlCommand</param>
        /// <returns>Bool: Thực hiện thành công true/false</returns>
        protected bool ExecuteCommand(SqlCommand m_Command)
        {
            try
            {
                this.OpenConnect();
                m_Command.Connection = m_Connect;
                m_Command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                 Utilities.ExceptionUtilities.ThrowMsgBox(ex.ErrorCode + ": " + ex.Message);
                return false;
            }
            finally
            {
                this.CloseConnect();
            }
        }

        protected SqlDataReader ExecuteReader(string sql)
        {
            try
            {
                SqlCommand command = new SqlCommand(sql, this.m_Connect);
                return command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                 Utilities.ExceptionUtilities.ThrowMsgBox(ex.ErrorCode + ": " + ex.Message);
                return null;
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
                this.OpenConnect();
                m_Command = new SqlCommand(sql, m_Connect);
                return m_Command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                 Utilities.ExceptionUtilities.ThrowMsgBox(ex.ErrorCode + ": " + ex.Message);
                return null;
            }
            finally
            { 
                 this.CloseConnect();
            }
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
