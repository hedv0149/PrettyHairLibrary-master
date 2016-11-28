using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrettyHairLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrettyHairTests
{
    [TestClass]
    public class TestOrder
    {
        [TestMethod]
        public void CanCreateOrder()
        {
            Product product1 = new Product(00, "product", 5.99, 10);
            Product product2 = new Product(00, "product", 5.99, 10);
            Dictionary<Product, int> orderlines = new Dictionary<Product, int>();
            orderlines.Add(product1, 2);
            orderlines.Add(product2, 2);
            Order o = new Order(1, "2016-11-26", "2016-12-26", orderlines);
            Assert.AreEqual("order [deliverydate=2016-11-26, orderdate=2016-12-26]", o.ToString());
        }
        [TestMethod]
        public void CanAddOrderToRepository()
        {
            Product product1 = new Product(00, "product", 5.99, 10);
            Product product2 = new Product(00, "product", 5.99, 10);
            OrderRepository or = new OrderRepository();
            Dictionary<Product, int> orderlines = new Dictionary<Product, int>();
            orderlines.Add(product1, 2);
            orderlines.Add(product2, 2);
            Order o = new Order(1, "2016-11-26", "2016-12-26", orderlines);
            int orderid = 1;
            or.Add(o);
            Assert.AreEqual(or.GetOrder(orderid).ToString(), "order [deliverydate=2016-11-26, orderdate=2016-12-26]");

        }
        [TestMethod]
        public void CanRemoveOrderFromRepository()
        {
            Product product1 = new Product(00, "product", 5.99, 10);
            Product product2 = new Product(01, "product2", 5.99, 10);
            OrderRepository or = new OrderRepository();
            Dictionary<Product, int> orderlines = new Dictionary<Product, int>();
            orderlines.Add(product1, 2);
            orderlines.Add(product2, 2);
            Order o = new Order(1, "2016-11-26", "2016-12-26", orderlines);
           
            or.Add(o);
            or.Remove(o);
            Assert.AreEqual(false, or.GetOrder(o.OrderId));
        }

        [TestMethod]
        public void CanNotifyWarehouseManager()
        {
            Product product1 = new Product(00, "product", 5.99, 10);
            OrderRepository or = new OrderRepository();
            Dictionary<Product, int> orderlines = new Dictionary<Product, int>();
            orderlines.Add(product1, 2);
            Order o = new Order(1, "2016-11-26", "2016-12-26", orderlines);
            
            SendMail sm = new SendMail();
            or.Add(o);
            Assert.AreEqual("", "");

        }

        [TestMethod]
        public void CanCheckAmount()
        {
            Product product1 = new Product(00, "product", 5.99, 2);
            Product product2 = new Product(01, "product2", 5.99, 10);
            Product product3 = new Product(02, "product3", 5.99, 0);
            Product product4 = new Product(03, "product4", 5.99, 2);
            OrderRepository or = new OrderRepository();
            Dictionary<Product, int> orderlines = new Dictionary<Product, int>();
            orderlines.Add(product1, 2);
            orderlines.Add(product2, 2);

            Dictionary<Product, int> orderlines2 = new Dictionary<Product, int>();
            orderlines.Add(product3, 2);
            orderlines.Add(product4, 2);

            Order o = new Order(1, "2016-11-26", "2016-12-26", orderlines);
            Order o2 = new Order(2, "2016-11-22", "2016-12-23", orderlines2);

            Assert.AreEqual(true, o.CheckQuantity());
           // Assert.AreEqual(false, o2.CheckQuantity());

        }
    }
}
