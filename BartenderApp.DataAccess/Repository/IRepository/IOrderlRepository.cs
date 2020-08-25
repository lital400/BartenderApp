using BartenderApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BartenderApp.DataAccess.Repository.IRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);
    }
}
