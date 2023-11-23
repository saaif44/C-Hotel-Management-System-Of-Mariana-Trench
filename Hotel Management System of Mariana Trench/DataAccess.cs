using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hotel_Management_System_of_Mariana_Trench
{
    public class DataAccess     //database connection ke shobjayga theke use korar jnno public DataAccess class nilam
    {
        private SqlConnection sqlcon;  //accessor //sqlConnection built korar jnno private accessor niye property banalam
        public SqlConnection Sqlcon //property
        {
            get { return this.sqlcon; }
            set { this.sqlcon = value; }
        }

        private SqlCommand sqlcom; // specify sqlCommand type of interaction we performed
        public SqlCommand Sqlcom
        {
            get { return this.sqlcom; }
            set { this.sqlcom = value; }
        }

        private SqlDataAdapter sda;  //conjunction with SqlConnection and SqlCommand to increase performance when connecting to a SQL Server database
        public SqlDataAdapter Sda
        {
            get { return this.sda; }
            set { this.sda = value; }
        }

        private DataSet ds; //represents the data in table structure which means the data into rows and columns
        public DataSet Ds 
        {
            get { return this.ds; }
            set { this.ds = value; }
        }

        //internal DataTable dt;

        public DataAccess() //method
        {
            this.Sqlcon = new SqlConnection(@"Data Source=SAAIF\SQL;Initial Catalog=HotelData;Persist Security Info=True;User ID=sa;Password=pass");
            Sqlcon.Open();
        }

        private void QueryText(string query)    //query likhe querytext method er parameter ee pass kortesi
        {
            this.Sqlcom = new SqlCommand(query, this.Sqlcon);
        }

        public DataSet ExecuteQuery(string sql) //query execute kortesi
        {
            this.QueryText(sql);
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds);
            return Ds;
        }

        public DataTable ExecuteQueryTable(string sql)  //table execute kortesi
        {
            this.QueryText(sql);
            this.Sda = new SqlDataAdapter(this.Sqlcom);
            this.Ds = new DataSet();
            this.Sda.Fill(this.Ds);
            return Ds.Tables[0];
        }

        public int ExecuteDMLQuery(string sql)
        {
            this.QueryText(sql);
            int u = this.Sqlcom.ExecuteNonQuery();
            return u;
        }
    }
}
