using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management_System_of_Mariana_Trench
{
    public partial class FormLogin : Form
    {
        private DataAccess LoginData { get; set; } 
        public FormLogin()
        {
            InitializeComponent();
            this.LoginData = new DataAccess();
            //this.PopulateGridView();
        }


        //private void PopulateGridView(string sql = "SELECT * FROM LoginInfo where UserId = '" + this.txtUserid.Text + "' and Password = '" + this.txtPass.Text + "';");
        //{
        //    var ds = this.LoginData.ExecuteQuery(sql);
        //    this.dgvMovie.AutogenerateColumns = false;
        //    this.dgvMovie.DataSource = ds.Tables[0];
        //}

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            var query = "SELECT * FROM LoginInfo where UserId = '" + this.txtUserid.Text + "' and Password = '" + this.txtPass.Text + "';";
            
            var ds = this.LoginData.ExecuteQuery(query);

            string bringstringVar = this.txtUserid.Text;
            char[] separator = { '-' };
            string[] strlist = bringstringVar.Split(separator);
            string finalString = strlist[0];



            if (ds.Tables[0].Rows.Count == 1)
            {
                this.ClearContent();
                this.Hide();
                

                if (finalString is "admin")
                {
                    FormAdmin admin = new FormAdmin();
                    admin.Show();
                    MessageBox.Show("Successul Login");
                }
                else if (finalString is "employee")
                {
                    FormEmployee employee = new FormEmployee();
                    employee.Show();
                    MessageBox.Show("Successul Login");
                }
                
                
                

            }
            else
            {
                MessageBox.Show("Login Invalid");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void ClearContent()
        {
            this.txtUserid.Clear();
            this.txtPass.Clear();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormLogin
            // 
            this.ClientSize = new System.Drawing.Size(582, 483);
            this.Name = "FormLogin";
            this.ResumeLayout(false);

        }
    }
}
