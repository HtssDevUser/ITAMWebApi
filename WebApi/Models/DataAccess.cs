using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApi.Models
{
    public class DataAccess
    {
        String ConnString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        string SQL = "";

        public List<assets> GetAssets()
        {
            List<assets> lst = new List<assets>();
            assets _assets = new assets();

            try
            {
               
                using (SqlConnection con = new SqlConnection(ConnString))
                {
                    //SqlCommand cmd = new SqlCommand("GetAssets", con);
                    //cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ASSETS", con);
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (!(rdr.HasRows))
                    {
                        return null;
                    }

                    while (rdr.Read())
                    {
                        _assets = new assets();
                        _assets.id = Convert.ToInt16(rdr["ID"].ToString());
                        _assets.code = rdr["CODE"].ToString();
                        _assets.name = rdr["NAME"].ToString();
                        _assets.qty = Convert.ToInt16(rdr["QTY"].ToString());
                        _assets.status = Convert.ToInt16(rdr["STATUS"].ToString());

                        lst.Add(_assets);
                    }
                    con.Close();

                    return lst;
                }
            }
            catch (Exception ex)
            {
                _assets = new assets();
                _assets.id = 0;
                _assets.code = "Error";
                _assets.name = ex.Message ;
                _assets.qty = 0;
                _assets.status = 0; ;

                lst.Add(_assets);
                return lst;
            }
        }
    }
}