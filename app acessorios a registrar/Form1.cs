using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using mshtml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace app_acessorios_a_registrar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);

        }

        private string l;
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
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



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (dataGridView1.CurrentCell.ColumnIndex.Equals(3))
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
                {
                    dataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8);
                }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var s = textBox1.Text;
            string sqlCommand = "select top 20 Artigo, Descricao From Artigo where Artigo like '" + s + "%'";
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
            l = textBox1.Text;
            string sqlCommand = "SELECT GPR_ArtigoComponentes.Componente, (select Artigo.Descricao From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As Descrição, GPR_ArtigoComponentes.consumo  As Quantidade, (select Artigo.CodBarras From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As CodBarras FROM Artigo, GPR_ArtigoComponentes where GPR_ArtigoComponentes.Artigo=Artigo.Artigo AND (Artigo.Artigo like '" + s + "' or Artigo.CodBarras like '" + s + "') AND (GPR_ArtigoComponentes.Componente like '3%' or GPR_ArtigoComponentes.Componente like '4%')";
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            SqlConnection ds = new SqlConnection(connectionString);



            ds.Open();


            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, ds);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ds.Close();

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[3].Width = 400;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Code 128", 60);












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
            l = textBox1.Text;
            string sqlCommand = "SELECT GPR_ArtigoComponentes.Componente, (select Artigo.Descricao From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As Descrição, GPR_ArtigoComponentes.consumo  As Quantidade, (select Artigo.CodBarras From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As CodBarras FROM Artigo, GPR_ArtigoComponentes where GPR_ArtigoComponentes.Artigo=Artigo.Artigo AND (Artigo.Artigo like '" + s + "' or Artigo.CodBarras like '" + s + "')";
            string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            SqlConnection ds = new SqlConnection(connectionString);



            ds.Open();


            SqlDataAdapter da = new SqlDataAdapter(sqlCommand, ds);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ds.Close();

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[3].Width = 400;
            dataGridView1.RowTemplate.Height = 80;
            dataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Code 128", 60);








        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (l != null)
            {
                textBox1.Text = l;
                string sqlCommand = "SELECT GPR_ArtigoComponentes.Componente, (select Artigo.Descricao From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As Descrição, GPR_ArtigoComponentes.consumo  As Quantidade, (select Artigo.CodBarras From Artigo where GPR_ArtigoComponentes.Componente= Artigo.Artigo) As CodBarras FROM Artigo, GPR_ArtigoComponentes where GPR_ArtigoComponentes.Artigo=Artigo.Artigo AND (Artigo.Artigo like '" + l + "' or Artigo.CodBarras like '" + l + "')";
                string connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

                SqlConnection ds = new SqlConnection(connectionString);



                ds.Open();


                SqlDataAdapter da = new SqlDataAdapter(sqlCommand, ds);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ds.Close();

                dataGridView1.DataSource = dt;

                dataGridView1.Columns[1].Width = 350;
                dataGridView1.Columns[3].Width = 400;
                dataGridView1.RowTemplate.Height = 80;
                dataGridView1.Columns[3].DefaultCellStyle.Font = new Font("Code 128", 60);



            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = "";
            try
            {
                a = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if(String.Compare(a, "2") < 0)
                {
                    try
                    {
                        var driver = new ChromeDriver();
                        driver.Navigate().GoToUrl("http://10.0.0.243/gpr/pedidos_mp_Fabrico/pedidos_mp_fabrico.php");
                        try
                        {
                            var input = driver.FindElement(By.Name("pesquisa"));
                            //input.Equals("NewVaue");
                            input.SendKeys(a);
                            var input1 = driver.FindElement(By.Id("fillup"));
                            //input.Equals("NewVaue");
                            input1.SendKeys("1");
                            var input2 = driver.FindElement(By.Id("cbUni"));
                            //input.Equals("NewVaue");
                            input2.SendKeys("Caixa");
                            var input3 = driver.FindElement(By.Id("cbLoc"));
                            //input.Equals("NewVaue");
                            input3.SendKeys("Linha1");
                            var input4 = driver.FindElement(By.Id("cbPri"));
                            //input.Equals("NewVaue");
                            input4.SendKeys("Urgencia Media"); ;


                            //System.Threading.Thread.Sleep(50000);
                            //driver.Quit();
                        }
                        finally { }


                    }
                    catch { MessageBox.Show("não foi possivel abrir Web Browser"); }
                    finally { }
                }
                else if (String.Compare(a, "A") < 0)
                {
                    try
                    {
                        var driver = new ChromeDriver();
                        driver.Navigate().GoToUrl("http://10.0.0.243/gpr/pedidos_MP_pintura/pedidos_MP_pintura.php");
                        try
                        {
                            var input = driver.FindElement(By.Name("pesquisa"));
                            //input.Equals("NewVaue");
                            input.SendKeys(a);
                            var input1 = driver.FindElement(By.Id("fillup"));
                            //input.Equals("NewVaue");
                            input1.SendKeys("1");
                            var input2 = driver.FindElement(By.Id("cbUni"));
                            //input.Equals("NewVaue");
                            input2.SendKeys("Caixa");
                            var input3 = driver.FindElement(By.Id("cbLoc"));
                            //input.Equals("NewVaue");
                            input3.SendKeys("Linha1");
                            var input4 = driver.FindElement(By.Id("cbPri"));
                            //input.Equals("NewVaue");
                            input4.SendKeys("Urgencia Media"); ;


                            //System.Threading.Thread.Sleep(50000);
                            //driver.Quit();
                        }
                        finally { }


                    }
                    catch { MessageBox.Show("não foi possivel abrir Web Browser"); }
                    finally { }
                }
                else
                {
                    try
                    {
                        var driver = new ChromeDriver();
                        driver.Navigate().GoToUrl("http://10.0.0.243/gpr/pedidos_mp/pedidos_MP.php");
                        try
                        {
                            var input = driver.FindElement(By.Name("pesquisa"));
                            //input.Equals("NewVaue");
                            input.SendKeys(a);
                            var input1 = driver.FindElement(By.Id("fillup"));
                            //input.Equals("NewVaue");
                            input1.SendKeys("1");
                            var input2 = driver.FindElement(By.Id("cbUni"));
                            //input.Equals("NewVaue");
                            input2.SendKeys("Caixa");
                            var input3 = driver.FindElement(By.Id("cbLoc"));
                            //input.Equals("NewVaue");
                            input3.SendKeys("Linha1");
                            var input4 = driver.FindElement(By.Id("cbPri"));
                            //input.Equals("NewVaue");
                            input4.SendKeys("Urgencia Media"); ;


                            //System.Threading.Thread.Sleep(50000);
                            //driver.Quit();
                        }
                        finally { }


                    }
                    catch { MessageBox.Show("não foi possivel abrir Web Browser"); }
                    finally { }
                }
            }
            catch { MessageBox.Show("Tem de selecionar uma linha"); }







        }

        private void button5_Click(object sender, EventArgs e)
        {
            string c = "";
            try
            {
                c = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                
                    try
                    {
                        var driver = new ChromeDriver();
                        driver.Navigate().GoToUrl("http://10.0.0.243/soft/linha1/regl1_.php");
                        try
                        {
                           
                            var input5 = driver.FindElement(By.Id("artigoCodBarras"));
                            //input.Equals("NewVaue");
                            input5.SendKeys(c);
                            


                            //System.Threading.Thread.Sleep(50000);
                            //driver.Quit();
                        }
                        finally { }


                    }
                    catch { MessageBox.Show("não foi possivel abrir Web Browser"); }
                    finally { }
                


            }
            catch { MessageBox.Show("Tem de selecionar uma linha"); }
        }



    }
}
