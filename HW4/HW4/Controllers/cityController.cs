using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HW4.Controllers
{
    public class cityController : ApiController
    {
        NodeOrders500Entities1 nodeOrders = new NodeOrders500Entities1();

        public IHttpActionResult getStore()
        {
            var allStores = (from orders in nodeOrders.StoreTables
                             orderby orders.storeID
                             select orders.City).ToList();
            List<string> storeString = new List<string>();
            foreach (var item in allStores)
            {
                storeString.Add(item);
            }
            return Json(storeString);
        }
        public IHttpActionResult getEmployee(string id)
        {
            var storeID = (from salesStore in nodeOrders.StoreTables
                              where salesStore.City == id
                              select salesStore.storeID).ToList();
            //int storeID = id;
            List<int> totalSales = new List<int>();
            using (var context = new NodeOrders500Entities1())
            {
                try
                {
                    var listIt1 = context.Database.SqlQuery<int>($"select SUM(pricePaid) from Orders where storeID  = {storeID[0].ToString()}").ToList();
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
