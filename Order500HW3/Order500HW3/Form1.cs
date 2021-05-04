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
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_load(object sender, EventArgs e)
        {
            NodeOrders500Entities nodeOrders500 = new NodeOrders500Entities();
            employeeList.Items.Add("hi");
            employeeList.Items.Add("buy");

        }



        private void employeeButton_Click(object sender, EventArgs e)
        {

        }

        private void storeSelect_Click(object sender, EventArgs e)
        {

        }

        private void employeeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            employeeList.Items.Add(2);
            employeeList.Items.Add(1);


        }

        private void storeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 
    }
}
