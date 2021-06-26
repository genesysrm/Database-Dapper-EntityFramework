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


namespace DatosLayer
{
    public partial class Form1 : Form
    {
        CustomerRepository cr = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
           
            dataGrid.DataSource = cr.GetAll();
      
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var filtro = cr.GetAll().FindAll(x => x.CompanyName.StartsWith(textBox1.Text));
            dataGrid.DataSource = filtro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DatosLayer.Database.ApplicationName = "DEMO C# SQL";
            //DatosLayer.Database.ConnectionTimeout = 30;
            //string stringconnection = DatosLayer.Database.ConnectionString;
            //var connection = DatosLayer.Database.getSqlConnection();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = cr.GetId(txtbuscar.Text);

            txtid.Text = cliente.CustomerID;
            txtcompany.Text = cliente.CompanyName;
            txtcontactname.Text = cliente.ContactName;
            txtcontacttitle.Text = cliente.ContactTitle;
            txtaddress.Text = cliente.Address;
            txtcity.Text = cliente.City;
            txtregion.Text = cliente.Region;
            txtcode.Text = cliente.PostalCode;
            txtcountry.Text = cliente.Country;
            txtphone.Text = cliente.Phone;
            txtfax.Text = cliente.Fax;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newClient = GetNewClient();

            if (newClient.CustomerID == "")
            {
                MessageBox.Show("Customer ID empty");
                return;
            }
            else
            {
               var insert = cr.Save(newClient);
                MessageBox.Show($"{insert} registers save");
            }
        }

        private Customer GetNewClient()
        {
            var newClient = new Customer();
            newClient.CustomerID = txtid.Text;
            newClient.CompanyName = txtcompany.Text;
            newClient.ContactName = txtcontactname.Text;
            newClient.ContactTitle = txtcontacttitle.Text;
            newClient.Address = txtaddress.Text;
            newClient.City = txtcity.Text;
            newClient.Region = txtregion.Text;
            newClient.PostalCode = txtcode.Text;
            newClient.Country = txtcountry.Text;
            newClient.Phone = txtphone.Text;
            newClient.Fax = txtfax.Text;

            return newClient;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var newClient = GetNewClient();
            var updates = cr.Update(newClient);
            MessageBox.Show($"{updates} updates");
        }
    }
}
