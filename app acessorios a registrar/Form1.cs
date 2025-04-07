using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace app_acessorios_a_registrar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(0))
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    var t = dataGridView1.CurrentCell.Value.ToString();

                    string sqlCommand = "SELECT GPR_ArtigoComponentes.Componente, (select Artigo.Descricao From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As Descrição, GPR_ArtigoComponentes.consumo  As Quantidade, (select Artigo.CodBarras From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As CodBarras FROM Artigo, GPR_ArtigoComponentes where GPR_ArtigoComponentes.Artigo=Artigo.Artigo AND (Artigo.Artigo like '" + t + "' or Artigo.CodBarras like '" + t + "')";
                    string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
                   

                    SqlConnection ds = new SqlConnection(connectionString);



                    ds.Open();


                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand, ds);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ds.Close();

                    dataGridView1.DataSource = dt;

                    textBox1.Text = t;
                }
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(3))
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    dataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8);
                }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var s = textBox1.Text;
            string sqlCommand = "select top 20 Artigo From Artigo where Artigo like '" + s + "%'";
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            SqlConnection ds = new SqlConnection(connectionString);



            ds.Open();


            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, ds);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ds.Close();


            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = textBox1.Text;
            
            string sqlCommand = "SELECT GPR_ArtigoComponentes.Componente, (select Artigo.Descricao From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As Descrição, GPR_ArtigoComponentes.consumo  As Quantidade, (select Artigo.CodBarras From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As CodBarras FROM Artigo, GPR_ArtigoComponentes where GPR_ArtigoComponentes.Artigo=Artigo.Artigo AND (Artigo.Artigo like '" + s + "' or Artigo.CodBarras like '" + s + "') AND (GPR_ArtigoComponentes.Componente like '3%' or GPR_ArtigoComponentes.Componente like '4%')";
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            SqlConnection ds = new SqlConnection(connectionString);
            
                    
                
                    ds.Open();


            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, ds);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ds.Close();
            
            dataGridView1.DataSource = dt;

            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[3].Width = 400;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Code 128",60);
            
            



            
            


            


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex.Equals(0))
                if (dataGridView2.CurrentCell != null && dataGridView2.CurrentCell.Value != null)
                {
                    var t = dataGridView2.CurrentCell.Value.ToString();

                    textBox1.Text = t;
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var s = textBox1.Text;

            string sqlCommand = "SELECT GPR_ArtigoComponentes.Componente, (select Artigo.Descricao From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As Descrição, GPR_ArtigoComponentes.consumo  As Quantidade, (select Artigo.CodBarras From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As CodBarras FROM Artigo, GPR_ArtigoComponentes where GPR_ArtigoComponentes.Artigo=Artigo.Artigo AND (Artigo.Artigo like '" + s + "' or Artigo.CodBarras like '" + s + "')";
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            SqlConnection ds = new SqlConnection(connectionString);



            ds.Open();


            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, ds);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ds.Close();

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[3].Width = 400;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Code 128", 60);








        }
    }
}
