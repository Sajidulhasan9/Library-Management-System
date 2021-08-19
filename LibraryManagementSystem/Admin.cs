using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LMS_GUI
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void lblChangePassAdmin_Click(object sender, EventArgs e)
        {
            ChangePass cngPassAd = new ChangePass();
            cngPassAd.Show();
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    ModifyBooksAdmin mdfy = new ModifyBooksAdmin();
        //    mdfy.Show();
        //    this.Hide();
        //}

        private void Admin_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-BRIEJ2AN;Initial Catalog=LibraryManagementSystem_DB;Integrated Security=True");
            conn.Open();

            string query1 = "select * from AdminInfoTable where UserID=" + Login.zID;
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            DataTable dt1 = ds1.Tables[0];
            lblWelcome.Text = "Welcome, " + (dt1.Rows[0]["UserName"].ToString());
            txtID.Text= dt1.Rows[0]["UserID"].ToString();
            txtName.Text = dt1.Rows[0]["Name"].ToString();
            txtMobile.Text = dt1.Rows[0]["Mobile"].ToString();
            txtEmail.Text = dt1.Rows[0]["Email"].ToString();
           // userid = Convert.ToString(Login.zID);
           // username = dt1.Rows[0]["UserName"].ToString();

            //string query2 = "select * from BookTable";
            //SqlCommand cmd2 = new SqlCommand(query2, conn);
            //cmd2.ExecuteNonQuery();
            //SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
            //DataSet ds2 = new DataSet();
            //adp2.Fill(ds2);
            //DataTable dt2 = ds2.Tables[0];
            //dataGridView2.DataSource = dt2;
            //dataGridView2.Refresh();

            //string query3 = "select * from TrackTable where UserID=" + Login.zID;
            //SqlCommand cmd3 = new SqlCommand(query3, conn);
            //cmd3.ExecuteNonQuery();
            //SqlDataAdapter adp3 = new SqlDataAdapter(cmd3);
            //DataSet ds3 = new DataSet();
            //adp3.Fill(ds3);
            //DataTable dt3 = ds3.Tables[0];
            //lblFine.Text = "Fine: " + (dt3.Rows[0]["Fine"].ToString());

            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name, mob, email;
            if (txtName.Text == "")
            {
                MessageBox.Show("Name can not be empty");
                return;
            }
            else
            {
                name = txtName.Text;
            }
            if (txtMobile.Text == "")
            {
                MessageBox.Show("Mobile can not be empty");
                return;
            }
            else
            {
                mob = txtMobile.Text;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Email can not be empty");
                return;
            }
            else
            {
                email = txtEmail.Text;
            }
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-BRIEJ2AN;Initial Catalog=LibraryManagementSystem_DB;Integrated Security=True");
            conn.Open();
            string query = "update AdminInfoTable set Name='" + name + "', Mobile='" + mob + "', Email='" + email + "' where UserID= " + Login.zID;
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            if (r > 0)
            {
                string query1 = "select * from AdminInfoTable where UserID=" + Login.zID;
                SqlCommand cmd1 = new SqlCommand(query1, conn);
                cmd1.ExecuteNonQuery();
                SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                adp1.Fill(ds1);
                DataTable dt1 = ds1.Tables[0];
                //lblWelcome.Text = "Welcome, " + (dt1.Rows[0]["UserName"].ToString());
                txtName.Text = dt1.Rows[0]["Name"].ToString();
                txtMobile.Text = dt1.Rows[0]["Mobile"].ToString();
                txtEmail.Text = dt1.Rows[0]["Email"].ToString();
                MessageBox.Show("Update successful");
            }
            conn.Close();
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnTrackingList_Click(object sender, EventArgs e)
        {
            TrackTableAdmin trck = new TrackTableAdmin();
            trck.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login.zID = 0;
            Login.adminPass = false;
            Login lgin = new Login();
            lgin.Show();
            this.Hide();
        }
    }
}
