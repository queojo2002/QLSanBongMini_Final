﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DB
    {
        private static DAL_DB instance;

        public static string conn_str = @"Data Source=DESKTOP-0KAI17V;Initial Catalog=QLSanBongFinal;Integrated Security=True";

        public static DAL_DB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL_DB();
                }
                return instance;
            }
            private set
            {
                DAL_DB.instance = value;
            }
        }

        private DAL_DB() { }

        public DataTable ThuThi_Query(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(conn_str))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataAdapter apater = new SqlDataAdapter(cmd);

                apater.Fill(data);

                conn.Close();
            }
            return data;
        }

        public int ThuThi_NonQuery(string query)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(conn_str))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                data = cmd.ExecuteNonQuery();


                conn.Close();
            }


            return data;
        }
        public object ThuThi_QueryScalar(string query)
        {
            object data = 0;

            using (SqlConnection conn = new SqlConnection(conn_str))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                data = cmd.ExecuteScalar();

                conn.Close();
            }
            return data;
        }
    }
}
