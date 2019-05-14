using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TeacherManagement.Utils
{
    public class ConnectionString
    {
        private static SqlConnection connection;

        public static SqlConnection Connection()
        {
            string connectionString = ConfigurationManager
                                    .ConnectionStrings["TeacherManagementConnectString"].ToString();
            // nếu chưa tồn tại connection thì mới khởi tạo đối tượng
            if (connection == null)
            {
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }
    }
}