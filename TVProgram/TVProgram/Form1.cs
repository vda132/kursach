using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVProgram
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectionString = @"Data Source=.\SQLEXPRESS02;Initial Catalog=TVProgramDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            var connection = new SqlConnection(connectionString);
            try
            {
                // Открываем подключение
                connection.Open();
                textBox1.Text += "Connection has been opened\t";
            }
            catch (SqlException ex)
            {
                textBox1.Text = ex.Message;
            }
            finally
            {
                // если подключение открыто
                if (connection.State == ConnectionState.Open)
                {
                    // закрываем подключение
                    connection.Close();
                    textBox1.Text += "Connection has been closed";
                }
            }
        }
	}
}
