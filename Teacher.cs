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
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e1)
        {
            if (MessageBox.Show("确认退出当前界面？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Hide();
                new Logon().Show();
            }
        }

        private void Teacher_Load(object sender, EventArgs e2)
        {
            // TODO: 这行代码将数据加载到表“database1DataSet16.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter8.Fill(this.database1DataSet16.information);
            // TODO: 这行代码将数据加载到表“database1DataSet15.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter7.Fill(this.database1DataSet15.information);
            // TODO: 这行代码将数据加载到表“database1DataSet14.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter6.Fill(this.database1DataSet14.information);
            // TODO: 这行代码将数据加载到表“database1DataSet13.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter5.Fill(this.database1DataSet13.information);
            // TODO: 这行代码将数据加载到表“database1DataSet8.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter4.Fill(this.database1DataSet8.information);
            // TODO: 这行代码将数据加载到表“database1DataSet7.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter3.Fill(this.database1DataSet7.information);
            // TODO: 这行代码将数据加载到表“database1DataSet6.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter2.Fill(this.database1DataSet6.information);
            // TODO: 这行代码将数据加载到表“database1DataSet5.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter1.Fill(this.database1DataSet5.information);
            // TODO: 这行代码将数据加载到表“database1DataSet4.information”中。您可以根据需要移动或删除它。
            this.informationTableAdapter.Fill(this.database1DataSet4.information);

            /*string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(SqlStr);

            string str1 = "select * from information";
            SqlCommand com1 = new SqlCommand(str1, con);
            SqlDataAdapter da = new SqlDataAdapter(com1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            con.Dispose();*/
            dataGridView3.Sort(dataGridView3.Columns[5], ListSortDirection.Descending);
            dgvBind();
        }

        private void button1_Click(object sender, EventArgs e)//添加按钮
        {
            new AddStudent().Show();
          //  MessageBox.Show("别点我");
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)//实时刷新数据
        {
            if (tabControl.SelectedTab == tabPage1)
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
                dataGridView3.Sort(dataGridView3.Columns[5], ListSortDirection.Descending);
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
            }
            else if (tabControl.SelectedTab == tabPage2)
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
                dataGridView3.Sort(dataGridView3.Columns[5], ListSortDirection.Descending);
            }
            else if (tabControl.SelectedTab == tabPage3)
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
                dataGridView3.Sort(dataGridView3.Columns[5], ListSortDirection.Descending);
            }
            else if (tabControl.SelectedTab == tabPage4)
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
                dataGridView3.Sort(dataGridView3.Columns[5], ListSortDirection.Descending);
            }
            else if (tabControl.SelectedTab == tabPage5)
            {
                string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(SqlStr);
                DataTable dt = dataGridView5.DataSource as DataTable;
                con.Open();
                string Sql = "select * from information";
                DataSet ds = new DataSet();
                using (SqlDataAdapter ada = new SqlDataAdapter(Sql, con))
                {

                    ada.Fill(ds);
                    dt = ds.Tables[0];
                }
                dataGridView5.DataSource = dt;
                dataGridView3.Sort(dataGridView3.Columns[5], ListSortDirection.Descending);
            }
        }

        private void button8_Click(object sender, EventArgs e)//查询按钮
        {
            string T1 = textBox1.Text;

            string SqlStr1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
            SqlConnection con1 = new SqlConnection(SqlStr1);
            try
            {
                con1.Open();
                String sql1 = string.Format("select * from information where 学号 = '{0}'",T1);
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
                    string Sql = "select * from information where 学号 = '" + textBox1.Text + "' ";
                    SqlCommand cmd = new SqlCommand(Sql, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    con.Close();
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView2.DataSource = ds.Tables[0];
                    dataGridView3.DataSource = ds.Tables[0];
                    dataGridView4.DataSource = ds.Tables[0];
                    dataGridView5.DataSource = ds.Tables[0];
                }
                else if(T1=="")
                {
                    MessageBox.Show("请输入学号!");
                }
                else if(ds1.Tables[0].Rows.Count <= 0)
                {
                    MessageBox.Show("该学号不存在,请重新输入!");
                    textBox1.Focus();
                    //textBox1.Clear();
                }
            }
            catch (Exception e2)
            {
                e2.GetHashCode();
            }

           
        }

        private void button3_Click(object sender, EventArgs e)//删除按钮
        {
            int a = dataGridView1.CurrentRow.Index;
            string str = dataGridView1.Rows[a].Cells[0].Value.ToString();
            if (a < 0)
            {
                MessageBox.Show("请选中一行");
            }
            else
            {
                if (MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
                        drv.Delete();
                        string SqlStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
                        SqlConnection con = new SqlConnection(SqlStr);
                        con.Open();
                        string Sql = "delete from information where 学号 = " + str + "";
                        SqlCommand cmd = new SqlCommand(Sql, con);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    MessageBox.Show("删除成功");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//修改信息
        {
            MessageBox.Show("修改成功!");
        }

       /* */private SqlConnection GetConnection()
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Test01\Test01\Database1.mdf;Integrated Security=True";
            SqlConnection mycon = new SqlConnection(constr);
            return mycon;
        }

        private void dgvBind()
        {
            SqlConnection mycon = GetConnection();
            try
            {
                mycon.Open();
                string sql = "select * from information";
                SqlDataAdapter sda = new SqlDataAdapter(sql, mycon);
                DataTable table = new DataTable();
                sda.Fill(table);
                this.dataGridView1.AutoGenerateColumns = true;
                this.dataGridView1.DataSource = table;
                this.dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mycon.Close();
            }
        }


       /* private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection mycon = GetConnection();
            try
            {
                mycon.Open();
                string mystr1 = dataGridView1.Columns[e.ColumnIndex].HeaderText;// + "=" + "'" + dataGridView1.CurrentCell.Value.ToString() + "'";
                string value = dataGridView1.CurrentCell.Value.ToString();
                string mystr2 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Console.WriteLine("{0},{1},{2}", mystr1, value, mystr2);
                Console.WriteLine("1111");
                string undateSql = "update information set " + mystr1 + "='"+value+"' where 学号 = " + mystr2;
                SqlCommand mycom = new SqlCommand(undateSql, mycon);
                mycom.ExecuteNonQuery();
                dgvBind();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("你是不是傻!");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mycon.Close();
            }
        }*/

        private void dataGridView1_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection mycon = GetConnection();
            try
            {
                mycon.Open();
                //string mystr1 = dataGridView1.Columns[e.ColumnIndex].HeaderText;// + "=" + "'" + dataGridView1.CurrentCell.Value.ToString() + "'";
                string mystr1 = dataGridView1.Columns[e.ColumnIndex].HeaderText + "=" + "N'" + dataGridView1.CurrentCell.Value.ToString() + "'";
                string value = dataGridView1.CurrentCell.Value.ToString();
                string mystr2 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                // Console.WriteLine("{0},{1},{2}", mystr1, value, mystr2);
                //Console.WriteLine("1111");
                //string undateSql = "update information set "+ mystr1 + "='" + value + "' where 学号 = " +mystr2;
                string undateSql =string.Format("update information set "+ mystr1 + " where 学号 = " + mystr2);// N'" + xb + "'
                SqlCommand mycom = new SqlCommand(undateSql, mycon);
                mycom.ExecuteNonQuery();
                dgvBind();
            }
            catch (Exception ex)
            {
                // MessageBox.Show("你是不是傻!");
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                mycon.Close();
            }
        }
    }
}
