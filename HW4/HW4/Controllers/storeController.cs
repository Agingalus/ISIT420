using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class storeController : ApiController
    {
        NodeOrders500Entities1 nodeOrders = new NodeOrders500Entities1();
        public IHttpActionResult getEmployee()
        {
            var allEmployees = (from orders in nodeOrders.SalesPersonTables
                               orderby orders.LastName
                               select orders.LastName).ToList();
            List<string> employeeString = new List<string>();
            foreach (var item in allEmployees)
            {
                employeeString.Add(item);
            }
            return Json(employeeString);
        }
        public IHttpActionResult getEmployee(string id)
        {
            var employeeID = (from salesPeople in nodeOrders.SalesPersonTables
                                 where salesPeople.LastName == id
                                 select salesPeople.salesPersonID).ToList();

            List<int> totalSales = new List<int>();
            using (var context = new NodeOrders500Entities1())
            {
                try
                {
                    var listIt1 = context.Database.SqlQuery<int>($"select SUM(pricePaid) from Orders where salesPersonID = {employeeID[0].ToString()}").ToList();
                    totalSales = listIt1;
                }
                catch
                {
                    totalSales.Add(0);
                }

            }
            return Json(totalSales);
        }
    }
}
