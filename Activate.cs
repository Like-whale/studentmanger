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
    public partial class Activate : Form
    {
        public Activate()
        {
            InitializeComponent();
        }

        private void Activate_Load(object sender, EventArgs e)
        {
            label4.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)//取消
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)//确定
        {
            StudentInfo si = new StudentInfo();
            si.XH = textBox1.Text;
            si.OldPass = textBox2.Text;
            si.NewPass1 = textBox3.Text;
            si.NewPass2 = textBox4.Text;

            /*string xh = textBox1.Text;
            string oldPass = textBox2.Text;
            string newPass1 = textBox3.Text;
            string newPass2 = textBox4.Text;*/

                if (si.XH != "" && si.OldPass != "" && si.NewPass1 != "" && si.NewPass2 != "" && si.NewPass1 == si.NewPass2)
            {
                try
                {
                    string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                    SqlConnection con = new SqlConnection(SqlStr);
                    con.Open();
                    String sql = string.Format("select * from information where 学号= '{0}'", si.XH);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            string SqlStr1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                            SqlConnection con1 = new SqlConnection(SqlStr1);
                            con1.Open();
                            String sql1 = string.Format("select * from student where id= '{0}'", si.XH);
                            SqlCommand cmd1 = new SqlCommand(sql1, con1);

                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            DataSet ds1 = new DataSet();
                            da1.Fill(ds1);
                            con1.Close();
                            if (ds1.Tables[0].Rows.Count <= 0)
                            {
                                string SqlStr2 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                                SqlConnection con2 = new SqlConnection(SqlStr2);
                                con2.Open();//将信息插入表格
                                String sql2 = "insert into student (id,password) values ('" + si.XH + "','" + si.NewPass2 + "' )";
                                SqlCommand cmd2 = new SqlCommand(sql2, con2);
                                cmd2.ExecuteNonQuery();
                                con2.Close();
                                MessageBox.Show("激活成功!请登录,注意密码只能在激活的时候改一次!请记好你的密码!");
                                Hide();
                            }
                            else if(ds1.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("该账户已经激活过了!");
                                textBox1.Focus();
                            }
                            /*  MessageBox.Show("欢迎你!");
                          new Student().Show();
                          Hide();*/
                        }
                        catch(Exception e2)
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("没有该学生信息,请检查你输入的账号以及你的老师是否添加该学生信息!");
                        textBox1.Focus();
                    }
                }
                catch (Exception e1)
                {

                }
            }
            else
            {
                MessageBox.Show("请检查信息是否输入完整,以及密码是否一致!");
            }
        }
    }
}
