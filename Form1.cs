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
using CapaConectada.Models;

namespace CapaConectada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btncargar_Click(object sender, EventArgs e)
        {


            SqlConnection conexion = new SqlConnection(@"Data Source=LAPTOP-Q6ODQIT5\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            conexion.Open();

            string sql = "SELECT * FROM [dbo].[Customers]";

            SqlCommand comando = new SqlCommand(sql, conexion);
            SqlDataReader datareader = comando.ExecuteReader();

            List<Customer> customer = new List<Customer>();

            while (datareader.Read())
            {
                Customer customers = new Customer();
                customers.CompanyName = datareader.GetString(0);
                customers.ContactName = datareader.GetString(1);
                customers.ContactTitle = datareader.GetString(2);
                customers.Address = datareader.GetString(3);
                customers.City = datareader.GetString(4);
                customers.Region = datareader["Region"] == DBNull.Value ? "" : (string)datareader["Region"];
                customers.PostalCode = datareader.GetInt32(6);
                customers.Country = datareader.GetString(7);
                customers.Phone = datareader.GetString(8);
                customers.Fax = datareader.GetString(9);

                customer.Add(customers);
            }

            MessageBox.Show("Open connection");
            conexion.Close();

        }
            
        
    }
}
