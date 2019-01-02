﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStoreEF.Models
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> Orders { get; }
        Order GetOrder(long key);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
