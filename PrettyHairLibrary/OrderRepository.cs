﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    public class OrderRepository
    {
        public event TickHandler Tick;
        public EventArgs e = null;
        public delegate void TickHandler(OrderRepository m, EventArgs e);
        private List<Order> _orders = new List<Order>();

        public void Add(Order o)
        {
            _orders.Add(o);
            this.ReceiveOrder();
        }

        private void ReceiveOrder()
        {
            Tick?.Invoke(this, e);
        }

        public void Remove(Order o) {
            _orders.Remove(o);
        }

        public void Remove(int orderid)
        {
            _orders.Remove(FindOrder(orderid));
        }

        public Order FindOrder(int orderid)
        {
            Order o = new Order();
            foreach (Order ord in _orders)
            {
                if (ord.OrderId == orderid) o = ord;
            }
            return o;
        }

        public Order GetOrder(int orderid)
        {
            return FindOrder(orderid);
        }

    }
}
