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

        private void markUps_Click(object sender, EventArgs e)

        {
            var getMarkup = (from orders in nodeOrders500.Orders 
                             join sales in nodeOrders500.StoreTables 
                             on orders.storeID equals sales.storeID    
                             where orders.pricePaid > 13
                             group sales by sales.City  into thingy
                             select thingy.Key).ToList();
            var getMarkup1 = (from orders in nodeOrders500.Orders
                             join sales in nodeOrders500.StoreTables
                             on orders.storeID equals sales.storeID
                             where orders.pricePaid > 13
                             group sales by sales.City into thingy
                             select  thingy.Key).ToList();
            //var listIt = nodeOrders500.Orders.SqlQuery("select stores.City, COUNT(*) from Orders as orders join StoreTable as stores on orders.storeID = stores.storeID where orders.pricePaid > 13group by stores.City").ToList();
            /*var otherMarkup = (from orders in nodeOrders500.Orders
                               group orders by orders.cdID into group1
                               where group1.Key > 13

                               select group1);*/
            string allText = "";
            using (var context = new NodeOrders500Entities())
            {
                var listIt1 = context.Database.SqlQuery<int>("select  COUNT(*) from Orders as orders join StoreTable as stores on orders.storeID = stores.storeID where orders.pricePaid > 13group by stores.City").ToList();

                var listIt2 = context.Database.SqlQuery<string>("select  stores.City from Orders as orders join StoreTable as stores on orders.storeID = stores.storeID where orders.pricePaid > 13group by stores.City").ToList();

                
                for (int i = 0; i < listIt1.Count();  i++)
                {
                    allText = listIt2[i] + " " + listIt1[i] ;
                    listView1.Items.Add(allText);
          
                }                          
            }
        }

    }
}
