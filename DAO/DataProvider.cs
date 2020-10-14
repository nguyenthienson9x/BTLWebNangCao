using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    class DataProvider
    {
        string chuoikn = @"Data Source=.\SQLEXPRESS;Initial Catalog=SKHLearning;Integrated Security=True";

        public SqlConnection kn = new SqlConnection();

        public void kn_csdl()
        {
            kn.ConnectionString = chuoikn;
            kn.Open();
        }

        public string ExecuteScalar(string procName, object[] para = null, List<string> listpara = null)
        {
            string kq = "";
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                try
                {
                    conn.Open();
                    DataTable table = new DataTable();
                    SqlCommand command = new SqlCommand(procName, conn);
                    command.CommandType = CommandType.StoredProcedure;
                    if (para != null)
                    {
                        for (int i = 0; i < para.Length; i++)
                        {
                            command.Parameters.AddWithValue(listpara[i], para[i]);
                        }
                    }
                    kq = command.ExecuteScalar().ToString();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                    kq = "";
                }

                return kq;
            }
        }

        public void dongketnoi()
        {
            if (kn.State == ConnectionState.Open)
            { kn.Close(); }
        }

        public DataTable laybang(string caulenh)
        {
            DataTable bangdulieu = new DataTable();
            try
            {
                kn_csdl();
                SqlDataAdapter Adapter = new SqlDataAdapter(caulenh, kn);
                DataSet ds = new DataSet();

                Adapter.Fill(bangdulieu);
            }
            catch (System.Exception)
            {
                bangdulieu = null;
            }
            finally
            {
                dongketnoi();
            }

            return bangdulieu;
        }

        public int xulydulieu(string caulenhsql)
        {
            int kq = 0;
            try
            {
                kn_csdl();
                SqlCommand lenh = new SqlCommand(caulenhsql, kn);
                kq = lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Thông báo lỗi ra!

                kq = 0;
            }
            finally
            {
                dongketnoi();
            }
            return kq;
        }
        public int ExecuteNonQuery(string procName, object[] para = null, List<string> listpara = null)
        {
            //connect tới database qua connString
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                int kq = 0;
                try
                {
                    conn.Open();
                    DataTable table = new DataTable();
                    SqlCommand command = new SqlCommand(procName, conn);
                    command.CommandType = CommandType.StoredProcedure;


                    if (para != null)
                    {
                        for (int i = 0; i < para.Length; i++)
                        {
                            command.Parameters.AddWithValue(listpara[i], para[i]);
                        }


                    }
                    kq = command.ExecuteNonQuery();
                }
                catch
                {
                    kq = 0;
                }

                return kq;
            }
        }

        public DataTable ExecuteQuery(string procName, object[] para = null, List<string> listpara = null)
        {
            //connect tới database qua connString
            using (SqlConnection conn = new SqlConnection(chuoikn))
            {
                DataTable table = new DataTable();
                try
                {
                    conn.Open();

                    SqlCommand command = new SqlCommand(procName, conn);
                    command.CommandType = CommandType.StoredProcedure;


                    if (para != null)
                    {
                        for (int i = 0; i < para.Length; i++)
                        {
                            command.Parameters.AddWithValue(listpara[i], para[i]);
                        }


                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
                catch
                {
                    table = null;
                }

                return table;
            }
        }
    }
}