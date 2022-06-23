using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Data;

namespace CRUD_Operations_Connected_Architecture
{
    public partial class Update : Form
    {
        private String conStr = ConfigurationManager.ConnectionStrings["myConStr"].ToString();

        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader dr;

        DateTime dob;
        int RollNo;

        public Update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(conStr);
            con.Open();
            string sqlCmd = "SELECT * FROM myRecordsMst";
            cmd = new SqlCommand(sqlCmd, con);
            cmd.Connection = con;
            dr = cmd.ExecuteReader();
            BindingSource bs = new BindingSource();
            bs.DataSource = dr;
            comboBox1.DataSource = bs;
            comboBox1.DisplayMember = "rno";
            comboBox1.ValueMember = "rno";
            comboBox1.SelectedValue = "rno";
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals(""))
            {
                con = new SqlConnection(conStr);
                //RollNo = int.Parse(comboBox1.SelectedText);
                con.Open();
                string sqlCmd = "SELECT * FROM myRecordsMst WHERE rno = " + RollNo;
                cmd = new SqlCommand(sqlCmd, con);
                cmd.Connection = con;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    textBox1.Text = dr.GetValue(1).ToString();
                    textBox2.Text = dr.GetValue(2).ToString();
                    textBox3.Text = dr.GetValue(3).ToString();
                    dob = DateTime.Parse(dr.GetValue(4).ToString());
                    dateTimePicker1.Text = Convert.ToDateTime(dob).ToString();
                }

                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RollNo = int.Parse(comboBox1.SelectedText);
            dob = DateTime.Parse(dateTimePicker1.Text);
            con = new SqlConnection(conStr);
            con.Open();
            string sqlCmd = "UPDATE myRecordsMst SET fname = '" + textBox1.Text + "', mname = '" + textBox2.Text + "', lname = '" + textBox3.Text + "', dob = '" + dob + "' WHERE rno = " + RollNo;
            cmd = new SqlCommand(sqlCmd, con);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dateTimePicker1.Text = null;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!comboBox1.Text.Equals(""))
            {
                con = new SqlConnection(conStr);
                RollNo = int.Parse(comboBox1.SelectedText);
                con.Open();
                string sqlCmd = "SELECT * FROM myRecordsMst WHERE rno = " + RollNo;
                cmd = new SqlCommand(sqlCmd, con);
                cmd.Connection = con;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    textBox1.Text = dr.GetValue(1).ToString();
                    textBox2.Text = dr.GetValue(2).ToString();
                    textBox3.Text = dr.GetValue(3).ToString();
                    dob = DateTime.Parse(dr.GetValue(4).ToString());
                    dateTimePicker1.Text = Convert.ToDateTime(dob).ToString();
                }

                con.Close();
            }
        }
    }
}
