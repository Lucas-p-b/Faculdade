using Model;
using Repository.VirtualDataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    internal class OrderRepository
    {
        public void Create(Order order)
        {
            MyData.Orders.Add(order);
        }

        public void Delete(Order order)
        {
            MyData.Orders.Remove(order);
        }

        public void Update(Order order)
        {
            var _order = GetById(order.Id);
            _order.Customer = _order.Customer;
            _order.OrderItems = _order.OrderItems;
            _order.OrderDate = _order.OrderDate;
            _order.OrderStatus = _order.OrderStatus;
        }

        public Order GetById(int Id)
        {
            var order = MyData.Orders.FirstOrDefault(x => x.Id == Id);

            if (order is null) return null;

            return order;
        }
    }
}
