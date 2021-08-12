using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace NetFrwk_Lib
{

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
    }



    public class DataSource
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        DataTable Dt;

        public DataSource()
        {
            Conn = new SqlConnection("Data Source=.;Initial Catalog=Company;Integrated Security=SSPI");
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            Conn.Open();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from Department";
            SqlDataReader reader = Cmd.ExecuteReader();
            Dt = new DataTable();
            Dt.Load(reader);
            reader.Close();
            foreach (DataRow dr in Dt.Rows)
            {
                departments.Add(
                      new Department() 
                      {
                          DeptNo  =Convert.ToInt32(dr["DeptNo"]),
                          DeptName = dr["DeptName"].ToString(),
                          Location = dr["Location"].ToString()
                      }
                    );
            }
            Conn.Close();
            Cmd.Dispose();
            Conn.Dispose();
            return departments;
        }
    }
}
