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
    public partial class Logon : Form
    {



        public Logon()
        {
            InitializeComponent();
            
        }



        private void button1_Click(object sender, EventArgs e4)
        {
            string ID = textBox1.Text.Trim();
            string Pass = textBox2.Text.Trim();
            if (radioButton1.Checked)
            {
                
                string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(SqlStr);
                
                try
                {
                    con.Open();
                    String sql =string.Format( "select * from student where id = '{0}' And password = '{1}' ",ID,Pass);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    
                            MessageBox.Show("欢迎你!");
                            new Student().Show();
                            Hide();
                     }
                     else
                        {
                            MessageBox.Show("用户名或密码错误请重输!");
                            textBox2.Clear();
                            textBox1.Clear();
                            textBox1.Focus();
                        }
                }
                catch (Exception e2)
                {
                    e2.GetHashCode();
                }
            }
            else if (radioButton2.Checked)
            {
                string SqlStr2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                SqlConnection con2 = new SqlConnection(SqlStr2);
                try
                {
                    con2.Open();
                    String sql2 = string.Format("select * from teacher where id = '{0}' And password = '{1}' ", ID, Pass);
                    SqlCommand cmd = new SqlCommand(sql2, con2);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd);
                    DataSet ds2 = new DataSet();
                    da2.Fill(ds2);
                    con2.Close();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {

                        MessageBox.Show("欢迎你!");
                        new Teacher().Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误请重输!");
                        textBox2.Clear();
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                }
                catch(Exception e3)
                {
                    e3.GetHashCode();
                }
            }
        }

        private void Logon_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e5)
        {
            if (MessageBox.Show("确认退出？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Activate().Show();
        }
    }
}
