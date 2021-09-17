using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Test.Interfaces;
using Test.Models;

namespace Test.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _db = new OrderContext();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            logger.Info("you have made a request to get all data " + Environment.NewLine + DateTime.Now);
            return _db.Orders;
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            logger.Info("you have made a request to get ID " + Environment.NewLine + DateTime.Now);
            var allOrders = await GetAllOrdersAsync();
            var enumerable = allOrders.ToList();
            return enumerable.FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> SaveOrderAsync(Order order)
        {
            logger.Info("you have made a request to save Order " + Environment.NewLine + DateTime.Now);
            try
            {
                //TODO logic for receipt 
                _db.Orders.Add(order);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> EditOrder(int id, Order order)
        {
            logger.Info("you have made a request to update Order " + Environment.NewLine + DateTime.Now);
            if (id != order.Id) return false;
            _db.Entry(order).State = EntityState.Modified;

            _db.SaveChanges();
            return true;
        }

        public void DeleteOrder(int id)
        {
            logger.Info("you have made a request to delete Order " + Environment.NewLine + DateTime.Now);
            var order = _db.Orders.Find(id);
            if (order == null) return;
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }
    }
}