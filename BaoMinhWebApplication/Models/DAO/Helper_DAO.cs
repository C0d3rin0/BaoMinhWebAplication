using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BaoMinhWebApplication.Models.DAO
{
    static public class Helper_DAO
    {
        public static SqlConnection createAndOpenConnection()
        {
            SqlConnection con = new SqlConnection(getConnectionString());
            con.Open();
            return con;
        }

        static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static DataTable getTable(SqlCommand cmd)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public static SqlCommand addRangeIn(this SqlCommand cmd,List<string> items, string key, string accesskey)
        {
            List<string> parameters = new List<string>();
            for (int i = 0; i <= items.Count() - 1; i++)
            {
                parameters.Add($"{key}{i})");
                cmd.Parameters.AddWithValue(parameters[i], items[i]);
            }

            string parajoin = string.Join(",", parameters);

            cmd.CommandText += $" AND {accesskey} in ({parajoin})";
            return cmd;
        }
    }
}