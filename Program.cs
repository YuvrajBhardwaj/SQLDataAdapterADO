using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace SQLDataAdapterADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter ID of any employee: ");
            int id = Convert.ToInt32(Console.ReadLine());

            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("Select * from employee", con);
            //SqlDataAdapter sda = new SqlDataAdapter("spGetEmployee", con); if stored procedure...
            //sda.SelectCommand.CommandType = CommandType.StoredProcedure; if stored procedure...
            sda.SelectCommand.Parameters.AddWithValue("@id", id);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            foreach(DataRow row in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0} {1} {2} {3}",row[0],row[1],row[2],row[3]);
                //only 0,1,2,3 because we have 4 values in the table namely, Id, FirstName, MidName, and LastName. representing row values of the same row.
            }
            Console.ReadKey();
        }
    }
}
