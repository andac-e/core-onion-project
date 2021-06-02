﻿using Project.DAL.Context;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repositories.Concretes
{
    public class OrderRepository:BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(MyContext db):base(db)
        {

        }
    }
}
