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
using connBuild;
using tmp_bd;
namespace BETRAGE
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        connbld cb = new connbld();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tmpMslDataSet.tmp_msl' table. You can move, or remove it, as needed.
            this.tmp_mslTableAdapter.Fill(this.tmpMslDataSet.tmp_msl);
            // TODO: This line of code loads data into the 'genMslDataSet.general_bd' table. You can move, or remove it, as needed.
            this.general_bdTableAdapter.Fill(this.genMslDataSet.general_bd);
            cn.ConnectionString = "Data Source=PLAYZZER;Initial Catalog=msl;Persist Security Info=True;User ID=sa;Password=go0d1uck";
            cmd.Connection = cn;
            loadtablename();

        }

        private void loadtablename()
        {
            comboBox1.Items.Clear();
            cmd.CommandText = "select tmp_list_team from tmp_msl "; 
            cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["tmp_list_team"].ToString());
                }
            }
            cn.Close();
        }
        private void loadcolumnname()
        {
            listBox1.Items.Clear();
            cmd.CommandText = "select * from tmp_msl where  tmp_list_team LIKE  '" + comboBox1.SelectedItem.ToString() + "'"; cn.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    for (int i = 0; i < 12; i++)
                        listBox1.Items.Add(dr[i].ToString());
                    button1.Text = dr[6].ToString();
                    button2.Text = dr[5].ToString();
                    lvs.Text = dr[7].ToString();
                    lmsl.Text = dr[8].ToString();
                    lbk.Text = dr[9].ToString();
                    lgr.Text = dr[10].ToString();
                    lbj.Text = dr[11].ToString();
                    label6.Text = dr[1].ToString();
                }
            }
            cn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                loadcolumnname();

            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gen_sql;
            gen_sql = button1.Text.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM general_bd where gen LIKE '" + gen_sql.ToString() + "%'", cn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            adapter.Update(dataset);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ha_sql;
            ha_sql = button2.Text.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM general_bd where ha LIKE '" + ha_sql.ToString() + "%'", cn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            adapter.Update(dataset);
        }

        private void btngen1_Click(object sender, EventArgs e)
        {
            string gen_sql;
            gen_sql = text_gen1.Text.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM general_bd where gen LIKE '" + gen_sql.ToString() + "%'", cn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            adapter.Update(dataset);
        }

        private void btngen2_Click(object sender, EventArgs e)
        {
            string gen_sql;
            gen_sql = text_gen2.Text.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM general_bd where gen LIKE '%" + gen_sql.ToString() + "'", cn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            adapter.Update(dataset);
        }

        private void btnha1_Click(object sender, EventArgs e)
        {
            string ha_sql;
            ha_sql = text_ha1.Text.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM general_bd where ha LIKE '" + ha_sql.ToString() + "%'", cn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            adapter.Update(dataset);
        }

        private void btnha2_Click(object sender, EventArgs e)
        {
            string ha_sql;
            ha_sql = text_ha2.Text.ToString();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM general_bd where ha LIKE '%" + ha_sql.ToString() + "'", cn);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dataGridView1.DataSource = dataset.Tables[0];
            adapter.Update(dataset);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }
      
    }
}
