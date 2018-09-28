using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase_QuanLyThanhToanGiangDay
{
    class GV_CD
    {
        string connStr = @"Data Source=(local);Initial Catalog=QUAN_LY_THANH_TOAN_GIANG_DAY;Integrated Security=True";
        static SqlConnection conn = new SqlConnection();
        SqlDataAdapter sda = new SqlDataAdapter();

        DataSet myDataSet = new DataSet();
        public DataTable myDisplayDataTable = new DataTable();

        public string MaGV, MaCD, NamHoc;
        public int HocKy;

        public GV_CD()
        {
            // Thiết lập kết nối đến cơ sở dữ liệu
            conn = new SqlConnection(connStr);

            // Nạp dữ liệu vào các DataSet, DataTable
            ReLoadData();
        }

        public void ReLoadData()
        {
            // Khởi tạo lệnh truy vấn
            SqlCommand mySqlCommand = conn.CreateCommand();
            mySqlCommand.CommandText = "SELECT * FROM ShowGV_CD()";
            sda.SelectCommand = mySqlCommand;

            // Điền dữ liệu vào DataSet
            conn.Open();
            myDataSet = new DataSet();
            sda.FillSchema(myDataSet, SchemaType.Mapped);
            sda.Fill(myDataSet);
            conn.Close();

            // Thiết đặt thuộc tính cho DataSet, DataTable
            myDataSet.Tables[0].TableName = "DISPLAY";
            myDisplayDataTable = new DataTable();
            myDisplayDataTable = myDataSet.Tables["DISPLAY"];
        }

        public int IsConnOpen()
        {
            if (conn.State == ConnectionState.Open) return 1;
            else return 0;
        }

        public void CloseConn()
        {
            conn.Close();
        }

        public void InsertGV_CD(string MaGV, string MaCD, int HocKy, string NamHoc)
        {
            SqlCommand insert = conn.CreateCommand();
            insert.CommandText = "InsertGV_CD";
            insert.CommandType = CommandType.StoredProcedure;
            insert.Parameters.Add(new SqlParameter("@MaGV", MaGV));
            insert.Parameters.Add(new SqlParameter("@MaCD", MaCD));
            insert.Parameters.Add(new SqlParameter("@hocKy", HocKy));
            insert.Parameters.Add(new SqlParameter("@namHoc", NamHoc));
            conn.Open();
            insert.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateGV_CD(string oldMaGV, string newMaGV, string oldMaCD, string newMaCD, int oldHocKy, int newHocKy, string oldNamHoc, string newNamHoc)
        {
            SqlCommand update = conn.CreateCommand();
            update.CommandText = "UpdateGV_CD";
            update.CommandType = CommandType.StoredProcedure;
            update.Parameters.Add(new SqlParameter("@oldMaGV", oldMaGV));
            update.Parameters.Add(new SqlParameter("@newMaGV", newMaGV));
            update.Parameters.Add(new SqlParameter("@oldMaCD", oldMaCD));
            update.Parameters.Add(new SqlParameter("@newMaCD", newMaCD));
            update.Parameters.Add(new SqlParameter("@oldHocKy", oldHocKy));
            update.Parameters.Add(new SqlParameter("@newHocKy", newHocKy));
            update.Parameters.Add(new SqlParameter("@oldNamHoc", oldNamHoc));
            update.Parameters.Add(new SqlParameter("@newNamHoc", newNamHoc));
            conn.Open();
            update.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteGV_CD(string MaGV, string MaCD, int HocKy, string NamHoc)
        {
            SqlCommand delete = conn.CreateCommand();
            delete.CommandText = "DeleteGV_CD";
            delete.CommandType = CommandType.StoredProcedure;
            delete.Parameters.Add(new SqlParameter("@MaGV", MaGV));
            delete.Parameters.Add(new SqlParameter("@MaCD", MaCD));
            delete.Parameters.Add(new SqlParameter("@hocKy", HocKy));
            delete.Parameters.Add(new SqlParameter("@namHoc", NamHoc));
            conn.Open();
            delete.ExecuteNonQuery();
            conn.Close();
        }

        public void SearchGV_CD(string type, string value)
        {
            SqlCommand search = conn.CreateCommand();
            search.CommandText = "SELECT * FROM SearchGV_CD(@type, @value)";
            search.Parameters.Add(new SqlParameter("@type", type));
            search.Parameters.Add(new SqlParameter("@value", value));
            sda.SelectCommand = search;

            // Điền dữ liệu vào DataSet
            conn.Open();
            myDataSet = new DataSet();
            sda.FillSchema(myDataSet, SchemaType.Mapped);
            sda.Fill(myDataSet);
            conn.Close();

            // Thiết đặt thuộc tính cho DataSet, DataTable
            myDataSet.Tables[0].TableName = "DISPLAY";
            myDisplayDataTable = new DataTable();
            myDisplayDataTable = myDataSet.Tables["DISPLAY"];
        }
    }
}
