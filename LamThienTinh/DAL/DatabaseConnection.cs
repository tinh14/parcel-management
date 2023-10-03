using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace DAL
{
    public class DatabaseConnection
    {
        public SqlConnection con;

        public DatabaseConnection()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            AppDomain.CurrentDomain.SetData("DataDirectory", Directory.GetParent(path).Parent.Parent.Parent.FullName + "\\DAL");
            string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=""D:\All\C# Projects\Quản lý bưu kiện trong bưu điện TP Rạch Giá\LamThienTinh\DAL\MyDatabase.mdf"";Integrated Security=True;User Instance=True;MultipleActiveResultSets=True";
            con = new SqlConnection(connectionString);
        }
    }
}
