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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)//取消按钮
        {
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)//确定按钮事件，添加
        {
            try { 
            string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(SqlStr);
            string xh = textBox1.Text;//获取一系列信息
            string xm = textBox2.Text;
            string xb = comboBox2.Text;
            DateTime cs = dateTimePicker1.Value;
            string jg = textBox3.Text;
            DateTime rx = dateTimePicker2.Value;
            string xy = comboBox1.Text;
            string zy = textBox4.Text;
            string bj = textBox5.Text;
            float gs = float.Parse(textBox6.Text);
            float yy = float.Parse(textBox7.Text);
            float xd = float.Parse(textBox8.Text);
            float c = float.Parse(textBox9.Text);
            float ty = float.Parse(textBox10.Text);
            float zc = float.Parse(textBox11.Text);
            string jc = textBox12.Text;
            float cx = float.Parse(textBox13.Text);
            /* Console.WriteLine("{0},{1},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}",xh,xm,xb,cs,jg,rx,xy,zy,bj,gs,
                 yy,xd,c,ty,zc,jc,cx);*/
            if (xh != "" && xm != ""  && jg != "" && xy != "" && zy != "" && bj != "" && 
                    gs >= 0 && yy >= 0 && xd >= 0 && c >= 0 && ty >= 0 && zc >= 0 && jc != "")//检查信息是否全部填写，格式是否正确
            {
                try
                {
                    con.Open();
                    String sql = string.Format("select * from information where 学号= '{0}' ", xh);
                    SqlCommand cmd = new SqlCommand(sql, con);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("该学号已经存在!请核对您的添加信息");
                        // textBox1.Clear();
                        textBox1.Focus();

                    }
                    else
                    {
                            string SqlStr1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                            SqlConnection con1 = new SqlConnection(SqlStr1);
                            con1.Open();//将信息插入表格
                            //字段前边加N将中文变成unicode字符串，保证插入到数据库的文字不会乱码。
                            String sql1 = "insert into information (学号,姓名,性别,出生日期,籍贯,入学日期,学院,专业,班级,高数,英语,线代,C,体育,综测分,活动奖惩,创新分) values ('"+xh+ "',N'" + xm + "',N'" + xb + "','" + cs + "',N'" + jg + "','" + rx + "',N'" + xy + "',N'" + zy + "',N'" + bj + "','" + gs + "','" + yy + "','" + xd + "','" + c + "','" + ty + "','" + zc + "',N'" + jc + "','" + cx + "' )";
                            SqlCommand cmd1 = new SqlCommand(sql1,con1);
                            cmd1.ExecuteNonQuery();
                            con1.Close();
                            MessageBox.Show("添加成功");
                        Hide();
                    }
                }
                catch (Exception e1)
                {
                        Console.WriteLine(e1.Message);
                }
            }
            else
            {
                MessageBox.Show("请将信息填写完整,并检查信息是否有误，成绩不能为负!注意活动奖惩不能留空，可以写无");
            }
        }
            catch(Exception e3)
            {
                MessageBox.Show("请将信息填写完整,并检查信息是否有误，成绩不能为负!注意活动奖惩不能留空，可以写无");
            }
        }
    }
}
