using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HW4.Controllers
{
    public class markUpController : ApiController
    {
        NodeOrders500Entities1 nodeOrders = new NodeOrders500Entities1();

        public IHttpActionResult getMarkUp()
        {
            List<string> listView1 = new List<string>();
            string allText = "";
            using (var context = new NodeOrders500Entities1())
            {
                var listIt1 = context.Database.SqlQuery<int>("select  COUNT(*) from Orders as orders join StoreTable as stores on orders.storeID = stores.storeID where orders.pricePaid > 13group by stores.City").ToList();

                var listIt2 = context.Database.SqlQuery<string>("select  stores.City from Orders as orders join StoreTable as stores on orders.storeID = stores.storeID where orders.pricePaid > 13group by stores.City").ToList();


                for (int i = 0; i < listIt1.Count(); i++)
                {
                    allText = listIt2[i] + " " + listIt1[i];
                    listView1.Add(allText);

                }
            }
            List<MyData> allItems = new List<MyData>();
            List<int> allKeys = new List<int>();
            var testIt = (from orders in nodeOrders.Orders
                          where orders.pricePaid > 13
                          group orders by orders.StoreTable.City);
            foreach (var item in testIt)
            {
                MyData temp = new MyData(item.Key, item.Count());
                allItems.Add(temp);
                allKeys.Add(item.Count());
            }

            return Json(allItems);
        }

    }


}
class MyData{
    public int count { get; set; }
    public string key { get; set; }

    public MyData(string pkey, int pcount)
    {
        key = pkey;
        count = pcount;

    }
}




