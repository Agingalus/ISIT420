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

namespace Order500HW3
{
    public partial class Form1 : Form
    {
        NodeOrders500Entities nodeOrders500 = new NodeOrders500Entities();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_load(object sender, EventArgs e)
        {
            var allEmployees = (from orders in nodeOrders500.SalesPersonTables
                               orderby orders.LastName
                               select  orders.LastName).ToList();
            employeeList.DataSource = allEmployees;

            var allStores = (from stores in nodeOrders500.StoreTables
                             orderby stores.storeID
                             select stores.City).ToList();
            storeList.DataSource = allStores;
        }


        private void employeeButton_Click(object sender, EventArgs e)
        {

        }

        private void storeSelect_Click(object sender, EventArgs e)
        {

        }

        private void employeeList_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void storeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 
    }
}
