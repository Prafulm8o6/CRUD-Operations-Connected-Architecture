using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace CRUD_Operations_Connected_Architecture
{
    public partial class Form1 : Form
    {
        private String conStr = ConfigurationManager.ConnectionStrings["myConStr"].ToString();

        SqlCommand cmd;
        SqlConnection con;

        DateTime dob;

        Update updateObj;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dob = DateTime.Parse(dateTimePicker1.Text);
            con = new SqlConnection(conStr);
            con.Open();
            string sqlCmd = "INSERT INTO myRecordsMst(fname,mname,lname,dob) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dob + "')";
            cmd = new SqlCommand(sqlCmd, con);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Text = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (updateObj == null || updateObj.IsDisposed)
            {
                updateObj = new Update();
                updateObj.MdiParent = this;
                updateObj.Show();
            }
            else
            {
                updateObj.Activate();
            }
        }
    }
}
