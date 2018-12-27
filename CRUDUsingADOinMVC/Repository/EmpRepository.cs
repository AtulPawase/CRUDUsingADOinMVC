using CRUDUsingADOinMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDUsingADOinMVC.Repository
{
    public class EmpRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        public bool AddEmployee(EmpModel obj)
        {

            connection();
            SqlCommand com = new SqlCommand("spAddEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.EName);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        public List<EmpModel> GetAllEmployees()
        {
            connection();
            List<EmpModel> EmpList = new List<EmpModel>();
            SqlCommand com = new SqlCommand("spViewEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                EmpList.Add(new EmpModel
                {
                    EmpID = Convert.ToInt32(dr["ID"]),
                    EName=Convert.ToString(dr["Name"]),
                    City=Convert.ToString(dr["City"]),
                    Address=Convert.ToString(dr["Address"])
                    
                    
                });
            }
            return EmpList;
        }
        public bool UpdateEmployee(EmpModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("spUpdate", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", obj.EmpID);
            com.Parameters.AddWithValue("@Name", obj.EName);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteEmployee(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("spDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("ID", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}