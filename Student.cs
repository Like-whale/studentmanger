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

namespace Test01
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“database1DataSet12.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter7.Fill(this.database1DataSet12.information);
            // TODO: 这行代码将数据加载到表“database1DataSet11.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter6.Fill(this.database1DataSet11.information);
            // TODO: 这行代码将数据加载到表“database1DataSet10.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter5.Fill(this.database1DataSet10.information);
            // TODO: 这行代码将数据加载到表“database1DataSet9.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter4.Fill(this.database1DataSet9.information);
            // TODO: 这行代码将数据加载到表“database1DataSet3.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter3.Fill(this.database1DataSet3.information);
            // TODO: 这行代码将数据加载到表“database1DataSet2.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter2.Fill(this.database1DataSet2.information);
            // TODO: 这行代码将数据加载到表“database1DataSet1.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter1.Fill(this.database1DataSet1.information);
            // TODO: 这行代码将数据加载到表“database1DataSet.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter.Fill(this.database1DataSet.information);
            dataGridView4.Sort(dataGridView4.Columns[5], ListSortDirection.Descending);
           // this.dataGridView3.Sort(this.dataGridView3.Columns[5], ListSortDirection.Ascending);
            string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(SqlStr);
            DataTable dt = dataGridView1.DataSource as DataTable;
            con.Open();
            string Sql = "select * from information";
            DataSet ds = new DataSet();
            using (SqlDataAdapter ada = new SqlDataAdapter(Sql, con))
            {

                ada.Fill(ds);
                dt = ds.Tables[0];
            }
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出当前界面？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Hide();
                new Logon().Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string T1 = textBox1.Text;

            string SqlStr1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
            SqlConnection con1 = new SqlConnection(SqlStr1);
            try
            {
                con1.Open();
                String sql1 = string.Format("select * from student where id = '{0}'", T1);
                SqlCommand cmd1 = new SqlCommand(sql1, con1);

                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                con1.Close();
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                    SqlConnection con = new SqlConnection(SqlStr);
                    con.Open();
                    string Sql = "select * from information where 学号 = '" + textBox1.Text + "' or 姓名 = '" + textBox1.Text + "' or 班级 = '" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView2.DataSource = ds.Tables[0];
                    dataGridView3.DataSource = ds.Tables[0];
                    dataGridView4.DataSource = ds.Tables[0];
                }
                else if (T1 == "")
                {
                    MessageBox.Show("请输入学号!");
                }
                else if (ds1.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("该学号不存在,请重新输入!");
                    textBox1.Focus();
                    textBox1.Clear();
                }
            }
            catch (Exception e2)
            {
                e2.GetHashCode();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(SqlStr);
                DataTable dt = dataGridView1.DataSource as DataTable;
                con.Open();
                string Sql = "select * from information";
                DataSet ds = new DataSet();
                using (SqlDataAdapter ada = new SqlDataAdapter(Sql, con))
                {

                    ada.Fill(ds);
                    dt = ds.Tables[0];
                }
                dataGridView1.DataSource = dt;
                /* DataTable dt = dataGridView1.DataSource as DataTable;
                 if (dt != null)
                 {
                     try
                     {
                         string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                         SqlConnection con = new SqlConnection(SqlStr);
                         con.Open();
                         string Sql = "select * from information";
                         SqlCommand cmd = new SqlCommand(Sql, con);
                         SqlDataAdapter da = new SqlDataAdapter(cmd);
                         SqlCommandBuilder scb = new SqlCommandBuilder(da);
                         DataSet ds = new DataSet();
                         da.Fill(ds);
                         da.Update(dt);
                     }
                     catch(Exception e1)
                     {

                     }
                 }*/
             dataGridView4.Sort(dataGridView4.Columns[5], ListSortDirection.Descending);
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(SqlStr);
                DataTable dt = dataGridView2.DataSource as DataTable;
                con.Open();
                string Sql = "select * from information";
                DataSet ds = new DataSet();
                using (SqlDataAdapter ada = new SqlDataAdapter(Sql, con))
                {

                    ada.Fill(ds);
                    dt = ds.Tables[0];
                }
                dataGridView2.DataSource = dt;
                dataGridView4.Sort(dataGridView4.Columns[5], ListSortDirection.Descending);
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(SqlStr);
                DataTable dt = dataGridView3.DataSource as DataTable;
                con.Open();
                string Sql = "select * from information";
                DataSet ds = new DataSet();
                using (SqlDataAdapter ada = new SqlDataAdapter(Sql, con))
                {

                    ada.Fill(ds);
                    dt = ds.Tables[0];
                }
                dataGridView3.DataSource = dt;
                dataGridView4.Sort(dataGridView4.Columns[5], ListSortDirection.Descending);
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(SqlStr);
                DataTable dt = dataGridView4.DataSource as DataTable;
                con.Open();
                string Sql = "select * from information";
                DataSet ds = new DataSet();
                using (SqlDataAdapter ada = new SqlDataAdapter(Sql, con))
                {

                    ada.Fill(ds);
                    dt = ds.Tables[0];
                }
                dataGridView4.DataSource = dt;
                dataGridView4.Sort(dataGridView4.Columns[5], ListSortDirection.Descending);
            }
        }
    }
}
